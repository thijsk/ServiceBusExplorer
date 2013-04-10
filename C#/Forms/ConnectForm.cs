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

#region Using Directives
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms; 
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class ConnectForm : Form
    {
        #region Private Constants
        //***************************
        // Constants
        //***************************
        private const string SelectServiceBusNamespace = "Select a service bus namespace...";
        private const string EnterConnectionString = "Enter connection string...";
        private const string UriLabel = "URI or Server FQDN:";
        private const string ConnectionStringLabel = "Connection String:";
        private const string QueueEntity = "Queue";
        private const string TopicEntity = "Topic";
        private const string SubscriptionEntity = "Subscription";

        //***************************
        // Tooltips
        //***************************
        private const string ConnectionStringTooltip = "Windows Azure Service Bus\r\n-----------------------------\r\nEndpoint=sb://<servicebusnamespace>.servicebus.windows.net/;SharedSecretIssuer=<issuer>;SharedSecretValue=<secret>\r\n\r\nService Bus for Windows Server\r\n---------------------------------\r\nEndpoint=sb://<machinename>/<servicebusnamespace>;StsEndpoint=https://<machinename>:9355/<servicebusnamespace>;\r\nRuntimePort=9354;ManagementPort=9355;WindowsUsername=<username>;WindowsDomain=<domain/machinename>;WindowsPassword=<password>";
        private const string UriTooltip = "Gets or sets the Uri of the service bus namespace endpoint.";

        //***************************
        // Tooltips
        //***************************
        private const string ConnectionStringCannotBeNull = "The connection string cannot be null.";
        #endregion

        #region Private Instance Fields
        private readonly ServiceBusHelper serviceBusHelper;
        #endregion

        #region Private Static Fields
        private static int connectionStringIndex = -1;
        private static string connectionString;
        #endregion
        
        #region Public Constructor
        public ConnectForm(ServiceBusHelper serviceBusHelper)
        {
            InitializeComponent();
            this.serviceBusHelper = serviceBusHelper;
            cboServiceBusNamespace.Items.Add(SelectServiceBusNamespace);
            cboServiceBusNamespace.Items.Add(EnterConnectionString);
            if (serviceBusHelper.ServiceBusNamespaces != null)
            {
                // ReSharper disable CoVariantArrayConversion
                cboServiceBusNamespace.Items.AddRange(serviceBusHelper.ServiceBusNamespaces.Keys.ToArray());
                // ReSharper restore CoVariantArrayConversion
            }
            cboServiceBusNamespace.SelectedIndex = connectionStringIndex > 0 ? connectionStringIndex : 0;
            if (cboServiceBusNamespace.Text == EnterConnectionString)
            {
                txtUri.Text = connectionString;
            }
            txtQueueFilterExpression.Text = FilterExpressionHelper.QueueFilterExpression;
            txtTopicFilterExpression.Text = FilterExpressionHelper.TopicFilterExpression;
            txtSubscriptionFilterExpression.Text = FilterExpressionHelper.SubscriptionFilterExpression;
            btnOk.Enabled = cboServiceBusNamespace.SelectedIndex > 1 || (cboServiceBusNamespace.Text == EnterConnectionString && !string.IsNullOrEmpty(connectionString));
        }
        #endregion

        #region Public Properties
        public string Uri { get; private set; }
        public string Namespace { get; private set; }
        public string ServicePath { get; private set; }
        public string IssuerName { get; private set; }
        public string IssuerSecret { get; private set; }
        public string ConnectionString { get; private set; }
        #endregion

        #region Event Handlers
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var connectionStringType = cboServiceBusNamespace.SelectedIndex > 1 ?
                                      serviceBusHelper.ServiceBusNamespaces[cboServiceBusNamespace.Text].ConnectionStringType :
                                      ServiceBusNamespaceType.Custom;
            if (cboServiceBusNamespace.Text == EnterConnectionString || connectionStringType == ServiceBusNamespaceType.OnPremises)
            {
                ConnectionString = txtUri.Text;
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    MainForm.StaticWriteToLog(ConnectionStringCannotBeNull);
                    return;
                }
            }
            else
            {
                Uri = txtUri.Text;
                Namespace = txtNamespace.Text;
                IssuerName = txtIssuerName.Text;
                IssuerSecret = txtIssuerSecret.Text;
            }
            DialogResult = DialogResult.OK;
            FilterExpressionHelper.QueueFilterExpression = txtQueueFilterExpression.Text;
            FilterExpressionHelper.TopicFilterExpression = txtTopicFilterExpression.Text;
            FilterExpressionHelper.SubscriptionFilterExpression = txtSubscriptionFilterExpression.Text;
            connectionStringIndex = cboServiceBusNamespace.SelectedIndex;
            if (cboServiceBusNamespace.Text == EnterConnectionString)
            {
                connectionString = txtUri.Text;
            }
        }

        private void validation_TextChanged(object sender, EventArgs e)
        {
            var connectionStringType = cboServiceBusNamespace.SelectedIndex > 1 ?
                                       serviceBusHelper.ServiceBusNamespaces[cboServiceBusNamespace.Text].ConnectionStringType :
                                       ServiceBusNamespaceType.Custom;
            if (cboServiceBusNamespace.Text == EnterConnectionString || connectionStringType == ServiceBusNamespaceType.OnPremises)
            {
                btnOk.Enabled = !string.IsNullOrEmpty(txtUri.Text);
            }
            else
            {
                btnOk.Enabled = (!string.IsNullOrEmpty(txtUri.Text) ||
                                !string.IsNullOrEmpty(txtNamespace.Text)) &&
                                !string.IsNullOrEmpty(txtIssuerName.Text) &&
                                !string.IsNullOrEmpty(txtIssuerSecret.Text);
            }
        }

        private void cboServiceBusNamespace_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connectionStringType = cboServiceBusNamespace.SelectedIndex > 1 ?
                                       serviceBusHelper.ServiceBusNamespaces[cboServiceBusNamespace.Text].ConnectionStringType :
                                       ServiceBusNamespaceType.Custom;
            if (cboServiceBusNamespace.Text == EnterConnectionString || connectionStringType == ServiceBusNamespaceType.OnPremises)
            {
                lblUri.Text = ConnectionStringLabel;
                txtUri.Multiline = true;
                txtUri.Size = new Size(336, 168);
                txtUri.Text = string.Empty;
                toolTip.SetToolTip(txtUri, ConnectionStringTooltip);
            }
            else
            {
                lblUri.Text = UriLabel;
                txtUri.Multiline = false;
                txtUri.Size = new Size(336, 20);
                toolTip.SetToolTip(txtUri, UriTooltip);
            }
            if (cboServiceBusNamespace.SelectedIndex <= 1)
            {
                return;
            }
            var ns = serviceBusHelper.ServiceBusNamespaces[cboServiceBusNamespace.Text];
            if (ns == null)
            {
                return;
            }
            if (connectionStringType == ServiceBusNamespaceType.OnPremises)
            {
                txtUri.Text = ns.ConnectionString;
            }
            else
            {
                txtUri.Text = ns.Uri;
                txtNamespace.Text = ns.Namespace;
                txtIssuerName.Text = ns.IssuerName;
                txtIssuerSecret.Text = ns.IssuerSecret;
            }
        }

        private void ConnectForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == '\r';
            if (e.Handled && cboServiceBusNamespace.SelectedIndex > 0)
            {
                btnOk_Click(sender, null);
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = SystemColors.ControlText;
            }
        }

        private void clearButton_MouseLeave(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = Color.FromArgb(92, 125, 150);
            }
        }

        private void btnOpenQueueFilterForm_Click(object sender, EventArgs e)
        {
            var form = new FilterForm(QueueEntity, txtQueueFilterExpression.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtQueueFilterExpression.Text = form.FilterExpression;
            }
            txtQueueFilterExpression.Focus();
        }

        private void btnOpenTopicFilterForm_Click(object sender, EventArgs e)
        {
            var form = new FilterForm(TopicEntity, txtTopicFilterExpression.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtTopicFilterExpression.Text = form.FilterExpression;
            }
            txtTopicFilterExpression.Focus();
        }

        private void btnOpenSubscriptionFilterForm_Click(object sender, EventArgs e)
        {
            var form = new FilterForm(SubscriptionEntity, txtSubscriptionFilterExpression.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtSubscriptionFilterExpression.Text = form.FilterExpression;
            }
            txtSubscriptionFilterExpression.Focus();
        }

        private void btnClearQueueFilterExpression_Click(object sender, EventArgs e)
        {
            txtQueueFilterExpression.Text = null;
        }

        private void btnClearTopicFilterExpression_Click(object sender, EventArgs e)
        {
            txtTopicFilterExpression.Text = null;
        }

        private void btnClearSubscriptionFilterExpression_Click(object sender, EventArgs e)
        {
            txtSubscriptionFilterExpression.Text = null;
        }
        #endregion
    }
}
