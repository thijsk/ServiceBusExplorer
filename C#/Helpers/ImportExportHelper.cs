﻿#region Copyright
//=======================================================================================
// Microsoft Business Platform Division Customer Advisory Team  
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://www.appfabriccat.com/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.ServiceBus.Messaging;

#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    /// <summary>
    ///  This class is used to serialize and deserialize XML request.
    /// </summary>
    public static class ImportExportHelper
    {
        #region Private Constants
        //***************************
        // Constants
        //***************************
        private const string Namespace = @"http://schemas.microsoft.com/servicebusexplorer";
        private const string QueueDescriptionClass = "QueueDescription";
        private const string TopicDescriptionClass = "TopicDescription";
        private const string SubscriptionDescriptionClass = "SubscriptionDescription";
        private const string RuleDescriptionClass = "RuleDescription";
        private const string QueueEntity = "Queue";
        private const string TopicEntity = "Topic";
        private const string SubscriptionEntity = "Subscription";
        private const string RuleEntity = "Rule";
        private const string FilterEntity = "Filter";
        private const string ActionEntity = "Action";
        private const string QueueEntityList = "Queues";
        private const string TopicEntityList = "Topics";
        private const string SubscriptionEntityList = "Subscriptions";
        private const string RuleEntityList = "Rules";
        private const string SqlFilterEntity = "SqlFilter";
        private const string CorrelationFilterEntity = "CorrelationFilter";
        private const string SqlRuleActionEntity = "SqlRuleAction";
        private const string EntityList = "Entities";
        private const string NamespaceAttribute = "serviceBusNamespace";
        private const string Unknown = "Unknown";
        private const string ExtensionData = "ExtensionData";
        private const string EntityFormat = "{0}";
        private const string LambdaExpressionFilterFQDN = "Microsoft.ServiceBus.Messaging.Filters.LambdaExpressionFilter";
        private const string LambdaExpressionRuleActionFQDN = "Microsoft.ServiceBus.Messaging.Filters.LambdaExpressionRuleAction";
        private const string EmptyRuleActionFQDN = "Microsoft.ServiceBus.Messaging.EmptyRuleAction";
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";
        private const string StackTraceFormat = "StackTrace: {0}";
        private const string NodeNameFormat = "{{{0}}}{1}";
        private const string Path = "Path";
        private const string Name = "Name";
        private const string TopicPath = "TopicPath";
        private const string SqlExpression = "SqlExpression";
        private const string Correlationid = "Correlationid";
        private const string QueueExported = "The queue {0} has been successfully exported.";
        private const string TopicExported = "The topic {0} has been successfully exported.";
        private const string SubscriptionExported = "The subscription {0} of the topic {1} has been successfully exported.";
        private const string RuleExported = "The rule {0} has been successfully exported.";
        #endregion

        #region Private Static Fields
        private static readonly Dictionary<string, Dictionary<string, PropertyInfo>> propertyCache = new Dictionary<string, Dictionary<string, PropertyInfo>>();
        #endregion

        #region Static Constructor
        /// <summary>
        /// This is the static constructor of the Utility class.
        /// </summary>
        static ImportExportHelper()
        {
            GetProperties(typeof(QueueDescription), true, true);
            GetProperties(typeof(TopicDescription), true, true);
            GetProperties(typeof(SubscriptionDescription), true, true);
            GetProperties(typeof(RuleDescription), true, true);
            GetProperties(typeof(SqlFilter), true, true);
            GetProperties(typeof(CorrelationFilter), true, true);
            GetProperties(typeof(SqlRuleAction), true, true);
            GetProperties(typeof(Filter), true, true);
            GetProperties(typeof(RuleAction), true, true);
            var fullName = typeof(Filter).FullName;
            if (!string.IsNullOrEmpty(fullName))
            {
                propertyCache[LambdaExpressionFilterFQDN] = propertyCache[fullName];
            }
            fullName = typeof(RuleAction).FullName;
            if (!string.IsNullOrEmpty(fullName))
            {
                propertyCache[LambdaExpressionRuleActionFQDN] = propertyCache[fullName];
                propertyCache[EmptyRuleActionFQDN] = propertyCache[fullName];
            }
        }
        #endregion

        #region Public Static Methods

        /// <summary>
        /// Serializes a list of entities.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="entityList">The list of entities to serialize.</param>
        /// <returns>A XML string.</returns>
        public static string ReadAndSerialize(ServiceBusHelper serviceBusHelper, List<EntityDescription> entityList)
        {
            if (entityList != null &&
                entityList.Count > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var stringWriter = new StreamWriter(memoryStream, Encoding.ASCII))
                    {
                        using (var xmlWriter = XmlWriter.Create(stringWriter))
                        {
                            var queueList = entityList.Where(e => e is QueueDescription).Cast<QueueDescription>();
                            var topicList = entityList.Where(e => e is TopicDescription).Cast<TopicDescription>();
                            xmlWriter.WriteStartElement(EntityList, Namespace);
                            xmlWriter.WriteAttributeString(NamespaceAttribute, string.IsNullOrEmpty(serviceBusHelper.Namespace) ? 
                                                                               Unknown : 
                                                                               serviceBusHelper.Namespace);
                            if (queueList.Any())
                            {
                                xmlWriter.WriteStartElement(QueueEntityList);
                                foreach (var queue in queueList)
                                {
                                    try
                                    {
                                        SerializeEntity(serviceBusHelper, xmlWriter, queue);
                                    }
                                    catch (Exception ex)
                                    {
                                        HandleException(ex);
                                    }                                    
                                }
                                xmlWriter.WriteEndElement();
                            }
                            if (topicList.Any())
                            {
                                xmlWriter.WriteStartElement(TopicEntityList);
                                foreach (var topic in topicList)
                                {
                                    try
                                    {
                                        SerializeEntity(serviceBusHelper, xmlWriter, topic);
                                    }
                                    catch (Exception ex)
                                    {
                                        HandleException(ex);
                                    }  
                                }
                                xmlWriter.WriteEndElement();
                            }
                            xmlWriter.WriteEndElement();
                        }
                    }
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
            return null;
        }

        /// <summary>
        /// Deserialize the xml string into an object instance.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="xml">The string that must be deserialized.</param>
        /// <returns>The object deserialized.</returns>
        public static void DeserializeAndCreate(ServiceBusHelper serviceBusHelper, string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return;
            }
            using (var stringReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(stringReader))
                {
                    var root = XElement.Load(xmlReader);
                    var descendants = root.Descendants();
                    CreateQueues(serviceBusHelper,
                                 root.Descendants(string.Format(NodeNameFormat, Namespace, QueueEntity)));
                    CreateTopics(serviceBusHelper,
                                 root.Descendants(string.Format(NodeNameFormat, Namespace, TopicEntity)));
                }
            }
        }
        #endregion

        #region Private Static Methods
        /// <summary>
        /// Gets the collection of properties.
        /// </summary>
        /// <param name="type">The type of the object to get the properties for.</param>
        /// <param name="canRead">Gets a value indicating whether the property can be read.</param>
        /// <param name="canWrite">TGets a value indicating whether the property can be written.</param>
        /// <returns><see cref="PropertyDescriptorCollection"/> of bindable properties.</returns>
        private static void GetProperties(Type type, bool canRead, bool canWrite)
        {
            if (type == null)
            {
                return;
            }
            var fullName = type.FullName;
            if (string.IsNullOrEmpty(fullName) ||
                propertyCache.ContainsKey(fullName))
            {
                return;
            }
            var propertyArray = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (propertyArray.Length > 0)
            {
                var propertyDictionary = propertyArray.
                    Where(p => p.CanRead == canRead && p.CanWrite == canWrite && p.Name != ExtensionData).
                    ToDictionary(p=>p.Name);
                propertyCache[fullName] = propertyDictionary;
                return;
            }
            return;
        }

        /// <summary>
        /// Reads a property value from an Xml document and saves it to the propertyValue dictionary.
        /// </summary>
        /// <param name="propertyDictionary">The dictionary containing the definition of properties.</param>
        /// <param name="propertyValue">The dictionary containing the value of properties.</param>
        /// <param name="xmlReader">The XmlReader object used to read the property value.</param>
        private static void GetPropertyValue(Dictionary<string, PropertyInfo> propertyDictionary,
                                             Dictionary<string, object> propertyValue,
                                             XmlReader xmlReader)
        {
            if (propertyDictionary == null ||
                propertyValue == null ||
                xmlReader == null)
            {
                return;
            }
            xmlReader.Read();
            if (!propertyDictionary.ContainsKey(xmlReader.Name))
            {
                return;
            }
            var property = propertyDictionary[xmlReader.Name];
            var name = xmlReader.Name;
            if (property == null)
            {
                return;
            }
            if (property.PropertyType == typeof(int))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsInt();
                return;
            }
            if (property.PropertyType == typeof(long))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsLong();
                return;
            }
            if (property.PropertyType == typeof(float))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsFloat();
                return;
            }
            if (property.PropertyType == typeof(double))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsDouble();
                return;
            }
            if (property.PropertyType == typeof(decimal))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsDecimal();
                return;
            }
            if (property.PropertyType == typeof(bool))
            {
                bool ok;
                if (bool.TryParse(xmlReader.ReadElementContentAsString().ToLower(), out ok))
                {
                    propertyValue[name] = ok;
                }
                return;
            }
            if (property.PropertyType == typeof(DateTime))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsDateTime();
                return;
            }
            if (property.PropertyType == typeof(TimeSpan))
            {
                TimeSpan timeSpan;
                if (TimeSpan.TryParse(xmlReader.ReadElementContentAsString(), out timeSpan))
                {
                    propertyValue[name] = timeSpan;
                }
                return;
            }
            if (property.PropertyType == typeof(string))
            {
                propertyValue[name] = xmlReader.ReadElementContentAsString();
            }
        }

        /// <summary>
        /// Sets the value of the properties of an object passes as a parameter.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="propertyDictionary">The dictionary containing the definition of properties.</param>
        /// <param name="propertyValue">The dictionary containing the value of properties.</param>
        /// <param name="item">The object whose properties must be assigned a value.</param>
        private static void SetPropertyValue<T>(Dictionary<string, PropertyInfo> propertyDictionary,
                                                Dictionary<string, object> propertyValue,
                                                T item) where T : class
        {
            foreach (var property in propertyValue)
            {
                propertyDictionary[property.Key].SetValue(item, property.Value, null);
            }
        }

        /// <summary>
        /// Maps a class to the corresponding name of the Xml node.
        /// </summary>
        /// <param name="type">A Type object.</param>
        /// <returns>The name of the Xml node.</returns>
        private static string MapClassToEntity(Type type)
        {
            if (type == null ||
                string.IsNullOrEmpty(type.Name))
            {
                return Unknown;
            }
            switch (type.Name)
            {
                case QueueDescriptionClass:
                    return QueueEntity;
                case TopicDescriptionClass:
                    return TopicEntity;
                case SubscriptionDescriptionClass:
                    return SubscriptionEntity;
                case RuleDescriptionClass:
                    return RuleEntity;
                default:
                    return type.Name;
            }
        }

        /// <summary>
        /// Serializes an entity using the XmlSerializer.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="xmlWriter">The XmlWriter object to use.</param>
        /// <param name="entity">The entity to serialize.</param>
        /// <returns>A XML string.</returns>
        private static void SerializeEntity(ServiceBusHelper serviceBusHelper, XmlWriter xmlWriter, object entity)
        {
            if (xmlWriter == null ||
                entity == null)
            {
                return;
            }
            var type = entity.GetType();
            var typeName = type.Name;
            if (type.FullName == null || !propertyCache.ContainsKey(type.FullName))
            {
                return;
            }
            var propertyDictionary = propertyCache[type.FullName];
            xmlWriter.WriteStartElement(MapClassToEntity(type));
            foreach (var keyValuePair in propertyDictionary)
            {
                var value = keyValuePair.Value.GetValue(entity, null);
                xmlWriter.WriteStartElement(keyValuePair.Value.Name);
                if (value is Filter || value is RuleAction)
                {
                    SerializeEntity(serviceBusHelper, xmlWriter, value);
                }
                else
                {
                    xmlWriter.WriteString(string.Format(EntityFormat, value));
                }
                xmlWriter.WriteEndElement();
            }
            if (entity is TopicDescription)
            {
                var topic = entity as TopicDescription;
                var subscriptionList = serviceBusHelper.GetSubscriptions(topic.Path);
                if (subscriptionList.Any())
                {
                    xmlWriter.WriteStartElement(SubscriptionEntityList);
                    foreach (var subscription in subscriptionList)
                    {
                        SerializeEntity(serviceBusHelper, xmlWriter, subscription);
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            if (entity is SubscriptionDescription)
            {
                var subscription = entity as SubscriptionDescription;
                var ruleList = serviceBusHelper.GetRules(subscription.TopicPath, subscription.Name);
                if (ruleList.Any())
                {
                    xmlWriter.WriteStartElement(RuleEntityList);
                    foreach (var rule in ruleList)
                    {
                        SerializeEntity(serviceBusHelper, xmlWriter, rule);
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            xmlWriter.WriteEndElement();
            switch (typeName)
            {
                case QueueDescriptionClass:
                    var queueDescription = entity as QueueDescription;
                    if (queueDescription != null)
                    {
                        MainForm.StaticWriteToLog(string.Format(QueueExported, queueDescription.Path));
                    }
                    break;
                case TopicDescriptionClass:
                    var topicDescription = entity as TopicDescription;
                    if (topicDescription != null)
                    {
                        MainForm.StaticWriteToLog(string.Format(TopicExported, topicDescription.Path));
                    }
                    break;
                case SubscriptionDescriptionClass:
                    var subscriptionDescription = entity as SubscriptionDescription;
                    if (subscriptionDescription != null)
                    {
                        MainForm.StaticWriteToLog(string.Format(SubscriptionExported, 
                                                      subscriptionDescription.Name,
                                                      subscriptionDescription.TopicPath));
                    }
                    break;
                case RuleDescriptionClass:
                    var ruleDescription = entity as RuleDescription;
                    if (ruleDescription != null)
                    {
                        MainForm.StaticWriteToLog(string.Format(RuleExported, 
                                                      ruleDescription.Name));
                    }
                    break;
            }
        }

        /// <summary>
        /// Creates the queues which xml definition is contained in the collection passed as a parameter.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="queues">The IEnumerable<XElement/> collection containing the xml definition of the queues to create.</param>
        private static void CreateQueues(ServiceBusHelper serviceBusHelper, IEnumerable<XElement> queues)
        {
            try
            {
                if (serviceBusHelper == null ||
                    queues == null)
                {
                    return;
                }
                var fullName = typeof (QueueDescription).FullName;
                if (string.IsNullOrEmpty(fullName) ||
                    !propertyCache.ContainsKey(fullName))
                {
                    return;
                }
                var propertyDictionary = propertyCache[fullName];
                foreach (var queue in queues)
                {
                    try
                    {
                        var propertyValue = new Dictionary<string, object>();
                        var properties = queue.Elements();
                        foreach (var property in properties)
                        {
                            var xmlReader = property.CreateReader();
                            GetPropertyValue(propertyDictionary,
                                             propertyValue,
                                             xmlReader);
                        }
                        if (propertyValue.ContainsKey(Path))
                        {
                            var queueDescription = new QueueDescription(propertyValue[Path] as string);
                            SetPropertyValue(propertyDictionary,
                                             propertyValue,
                                             queueDescription);
                            serviceBusHelper.CreateQueue(queueDescription);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Creates the topics which xml definition is contained in the collection passed as a parameter.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="topics">The IEnumerable<XElement/> collection containing the xml definition of the topics to create.</param>
        private static void CreateTopics(ServiceBusHelper serviceBusHelper, IEnumerable<XElement> topics)
        {
            try
            {
                if (serviceBusHelper == null ||
                    topics == null)
                {
                    return;
                }
                var fullName = typeof(TopicDescription).FullName;
                if (string.IsNullOrEmpty(fullName) ||
                    !propertyCache.ContainsKey(fullName))
                {
                    return;
                }
                var propertyDictionary = propertyCache[fullName];
                var subscriptionName = string.Format(NodeNameFormat, Namespace, SubscriptionEntity);
                var subscriptionsName = string.Format(NodeNameFormat, Namespace, SubscriptionEntityList);
                foreach (var topic in topics)
                {
                    try
                    {
                        var propertyValue = new Dictionary<string, object>();
                        var properties = topic.Elements();
                        IEnumerable<XElement> subscriptions = null;
                        foreach (var property in properties)
                        {
                            if (property.Name == subscriptionsName)
                            {
                                subscriptions = property.Descendants(subscriptionName);
                            }
                            else
                            {
                                var xmlReader = property.CreateReader();
                                GetPropertyValue(propertyDictionary,
                                                 propertyValue,
                                                 xmlReader);
                            }
                        }

                        if (propertyValue.ContainsKey(Path))
                        {
                            var topicDescription = new TopicDescription(propertyValue[Path] as string);
                            SetPropertyValue(propertyDictionary,
                                             propertyValue,
                                             topicDescription);
                            topicDescription = serviceBusHelper.CreateTopic(topicDescription);
                            CreateSubscriptions(serviceBusHelper, topicDescription, subscriptions);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Creates the subscriptions which xml definition is contained in the collection passed as a parameter.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="topicDescription">A description of the topic to which to add the subscription.</param>
        /// <param name="subscriptions">The IEnumerable<XElement/> collection containing the xml definition of the subscriptions to create.</param>
        private static void CreateSubscriptions(ServiceBusHelper serviceBusHelper, TopicDescription topicDescription, IEnumerable<XElement> subscriptions)
        {
            try
            {
                if (serviceBusHelper == null ||
                    subscriptions == null)
                {
                    return;
                }
                var fullName = typeof(SubscriptionDescription).FullName;
                if (string.IsNullOrEmpty(fullName) ||
                    !propertyCache.ContainsKey(fullName))
                {
                    return;
                }
                var propertyDictionary = propertyCache[fullName];
                var ruleName = string.Format(NodeNameFormat, Namespace, RuleEntity);
                var rulesName = string.Format(NodeNameFormat, Namespace, RuleEntityList);
                foreach (var subscription in subscriptions)
                {
                    var propertyValue = new Dictionary<string, object>();
                    var properties = subscription.Elements();
                    IEnumerable<XElement> rules = null;
                    foreach (var property in properties)
                    {
                        if (property.Name == rulesName)
                        {
                            rules = property.Descendants(ruleName);
                        }
                        else
                        {
                            var xmlReader = property.CreateReader();
                            GetPropertyValue(propertyDictionary,
                                             propertyValue,
                                             xmlReader);
                        }
                    }

                    if (propertyValue.ContainsKey(Name) &&
                        propertyValue.ContainsKey(TopicPath))
                    {
                        RuleDescription defaultRuleDescription = null;
                        IEnumerable<RuleDescription> nonDefaultRuleDescriptions = null;
                        var ruleDescriptions = CreateRules(serviceBusHelper, rules);
                        if (ruleDescriptions != null)
                        {
                            defaultRuleDescription =
                                ruleDescriptions.FirstOrDefault(r => r.Name == RuleDescription.DefaultRuleName);
                            nonDefaultRuleDescriptions = ruleDescriptions.Where(r => r.Name != RuleDescription.DefaultRuleName);
                        }
                        var subscriptionDescription = new SubscriptionDescription(propertyValue[TopicPath] as string,
                                                                                  propertyValue[Name] as string);
                        SetPropertyValue(propertyDictionary,
                                         propertyValue,
                                         subscriptionDescription);
                        if (defaultRuleDescription != null)
                        {
                            serviceBusHelper.CreateSubscription(topicDescription, subscriptionDescription, defaultRuleDescription);
                        }
                        else
                        {
                            serviceBusHelper.CreateSubscription(topicDescription, subscriptionDescription);
                        }
                        if (nonDefaultRuleDescriptions != null)
                        {
                            foreach (var ruleDescription in nonDefaultRuleDescriptions)
                            {
                                serviceBusHelper.AddRule(subscriptionDescription, ruleDescription);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Creates the rules which xml definition is contained in the collection passed as a parameter.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="rules">The IEnumerable<XElement/> collection containing the xml definition of the rules to create.</param>
        private static List<RuleDescription> CreateRules(ServiceBusHelper serviceBusHelper, IEnumerable<XElement> rules)
        {
            if (rules == null)
            {
                return null;
            }
            var fullName = typeof(RuleDescription).FullName;
            if (string.IsNullOrEmpty(fullName) ||
                !propertyCache.ContainsKey(fullName))
            {
                return null;
            }
            var propertyDictionary = propertyCache[fullName];
            var list = new List<RuleDescription>();
            var filterName = string.Format(NodeNameFormat, Namespace, FilterEntity);
            var actionName = string.Format(NodeNameFormat, Namespace, ActionEntity);
            foreach (var rule in rules)
            {
                Filter filter = null;
                RuleAction action = null;
                var propertyValue = new Dictionary<string, object>();
                var properties = rule.Elements();
                foreach (var property in properties)
                {
                    if (property.Name == filterName)
                    {
                        filter = CreateFilter(serviceBusHelper, property.Elements().FirstOrDefault());
                    }
                    else
                    {
                        if (property.Name == actionName)
                        {
                            action = CreateAction(serviceBusHelper, property.Elements().FirstOrDefault());
                        }
                        else
                        {
                            var xmlReader = property.CreateReader();
                            GetPropertyValue(propertyDictionary,
                                             propertyValue,
                                             xmlReader);
                        }
                    }
                }
                var ruleDescription = new RuleDescription();
                if (filter != null)
                {
                    ruleDescription.Filter = filter;
                }
                if (action != null)
                {
                    ruleDescription.Action = action;
                }
                if (propertyValue.ContainsKey(Name))
                {
                    ruleDescription.Name = propertyValue[Name] as string;
                }
                list.Add(ruleDescription);
            }
            return list;
        }

        /// <summary>
        /// Creates the filter which xml definition is contained in the element parameter.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="filter">The XElement containing the filter definition.</param>
        /// <returns>The filter.</returns>
        private static Filter CreateFilter(ServiceBusHelper serviceBusHelper, XElement filter)
        {
            if (filter == null)
            {
                return null;
            }
            string fullName = null;
            if (filter.Name == string.Format(NodeNameFormat, Namespace, SqlFilterEntity))
            {
                fullName = typeof(SqlFilter).FullName;
            }
            if (filter.Name == string.Format(NodeNameFormat, Namespace, CorrelationFilterEntity))
            {
                fullName = typeof(CorrelationFilter).FullName;
            }
            if (string.IsNullOrEmpty(fullName) ||
                !propertyCache.ContainsKey(fullName))
            {
                return null;
            }
            var propertyDictionary = propertyCache[fullName];
            var propertyValue = new Dictionary<string, object>();
            var properties = filter.Elements();
            foreach (var property in properties)
            {
                var xmlReader = property.CreateReader();
                GetPropertyValue(propertyDictionary,
                                 propertyValue,
                                 xmlReader);
            }
            Filter ruleFilter = null;
            if (filter.Name == string.Format(NodeNameFormat, Namespace, SqlFilterEntity) &&
                propertyValue.ContainsKey(SqlExpression))
            {
                ruleFilter = new SqlFilter(propertyValue[SqlExpression] as string);
            }
            if (filter.Name == string.Format(NodeNameFormat, Namespace, CorrelationFilterEntity))
            {
                ruleFilter = new CorrelationFilter(propertyValue[Correlationid] as string);
            }
            if (ruleFilter != null)
            {
                SetPropertyValue(propertyDictionary,
                                 propertyValue,
                                 ruleFilter);
            }
            return ruleFilter;
        }

        /// <summary>
        /// Creates the action which xml definition is contained in the element parameter.
        /// </summary>
        /// <param name="serviceBusHelper">A ServiceBusHelper object.</param>
        /// <param name="action">The XElement containing the action definition.</param>
        /// <returns>The action.</returns>
        private static RuleAction CreateAction(ServiceBusHelper serviceBusHelper, XElement action)
        {
            if (action == null)
            {
                return null;
            }
            string fullName = null;
            if (action.Name == string.Format(NodeNameFormat, Namespace, SqlRuleActionEntity))
            {
                fullName = typeof(SqlRuleAction).FullName;
            }
            if (string.IsNullOrEmpty(fullName) ||
                !propertyCache.ContainsKey(fullName))
            {
                return null;
            }
            var propertyDictionary = propertyCache[fullName];
            var propertyValue = new Dictionary<string, object>();
            var properties = action.Elements();
            foreach (var property in properties)
            {
                var xmlReader = property.CreateReader();
                GetPropertyValue(propertyDictionary,
                                 propertyValue,
                                 xmlReader);
            }
            RuleAction ruleAction = null;
            if (action.Name == string.Format(NodeNameFormat, Namespace, SqlRuleActionEntity) &&
                propertyValue.ContainsKey(SqlExpression))
            {
                ruleAction = new SqlRuleAction(propertyValue[SqlExpression] as string);
            }
            if (ruleAction != null)
            {
                SetPropertyValue(propertyDictionary,
                                 propertyValue,
                                 ruleAction);
            }
            return ruleAction;
        }

        /// <summary>
        /// Writes the specified message to the trace listener.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        private static void HandleException(Exception ex)
        {
            if (ex == null || string.IsNullOrEmpty(ex.Message))
            {
                return;
            }
            MainForm.StaticWriteToLog(string.Format(CultureInfo.CurrentCulture, ExceptionFormat, ex.Message));
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            {
                MainForm.StaticWriteToLog(string.Format(CultureInfo.CurrentCulture, InnerExceptionFormat, ex.InnerException.Message));
            }
            MainForm.StaticWriteToLog(string.Format(CultureInfo.CurrentCulture, StackTraceFormat, ex.StackTrace));
        }
        #endregion
    }
}