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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.ServiceBus.Messaging;

#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public enum FormTypeEnum
    {
        Send,
        Test
    }

    public sealed partial class ContainerForm : Form
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string DateFormat = "<{0,2:00}:{1,2:00}:{2,2:00}> {3}";
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";
        private const string SendMessagesFormat = "Send messages to {0}";
        private const string TestQueueFormat = "Test queue {0} in MDI mode";
        private const string TestTopicFormat = "Test topic {0} in MDI mode";
        private const string TestSubscriptionFormat = "Test subscription {0} in MDI mode";
        private const string HeaderTextTestQueueFormat = "Test Queue: {0}";
        private const string HeaderTextTestTopicFormat = "Test Topic: {0}";
        private const string HeaderTextTestSubscriptionFormat = "Test Subscription: {0}";
        private const string LogFileNameFormat = "ServiceBusExplorer {0}.txt";

        //***************************
        // Constants
        //***************************
        private const string CloseLabel = "Close";
        private const string SaveAsTitle = "Save Log As";
        private const string SaveAsExtension = "txt";
        private const string SaveAsFilter = "Text Documents|*.txt";

        //***************************
        // Sizes
        //***************************
        private const int ControlMinWidth = 816;
        private const int ControlMinHeight = 345;
        #endregion

        #region Private Fields
        private readonly MainForm mainForm;
        private readonly TestQueueControl testQueueControl;
        private readonly TestTopicControl testTopicControl;
        private readonly TestSubscriptionControl testSubscriptionControl;
        private readonly LogTraceListener logTraceListener;
        private readonly int mainSplitterDistance;
        #endregion

        #region Public Constructors
        public ContainerForm(ServiceBusHelper serviceBusHelper, MainForm mainForm, FormTypeEnum formTypeType, QueueDescription queueDescription)
        {
            try
            {
                InitializeComponent();
                this.mainForm = mainForm;
                mainSplitterDistance = mainSplitContainer.SplitterDistance;
                SuspendLayout();
                panelMain.SuspendDrawing();
                panelMain.Controls.Clear();
                panelMain.BackColor = SystemColors.GradientInactiveCaption;
                testQueueControl = new TestQueueControl(mainForm, WriteToLog, new ServiceBusHelper(WriteToLog, serviceBusHelper), queueDescription)
                                       {
                                           Location = new Point(1, panelMain.HeaderHeight + 1)
                                       };


                if (formTypeType == FormTypeEnum.Send)
                {
                    testQueueControl.mainTabControl.TabPages.RemoveAt(2);
                    testQueueControl.receiverEnabledCheckBox.Checked = false;
                    Text = string.Format(SendMessagesFormat, queueDescription.Path);
                }
                else
                {
                    Text = string.Format(TestQueueFormat, queueDescription.Path);
                    logTraceListener = new LogTraceListener(WriteToLog);
                    Trace.Listeners.Add(logTraceListener);
                }

                testQueueControl.btnCancel.Text = CloseLabel;
                testQueueControl.btnCancel.Click -= testQueueControl.btnCancel_Click;
                testQueueControl.btnCancel.Click += BtnCancelOnClick;
                testQueueControl.Focus();

                panelMain.HeaderText = string.Format(HeaderTextTestQueueFormat, queueDescription.Path);
                panelMain.Controls.Add(testQueueControl);
                SetStyle(ControlStyles.ResizeRedraw, true);
            }
            finally
            {
                panelMain.ResumeDrawing();
                ResumeLayout();
            }
        }

        public ContainerForm(ServiceBusHelper serviceBusHelper, MainForm mainForm, FormTypeEnum formTypeType, TopicDescription topicDescription, List<SubscriptionDescription> subscriptionList)
        {
            try
            {
                InitializeComponent();
                this.mainForm = mainForm;
                mainSplitterDistance = mainSplitContainer.SplitterDistance;
                SuspendLayout();
                panelMain.SuspendDrawing();
                panelMain.Controls.Clear();
                panelMain.BackColor = SystemColors.GradientInactiveCaption;

                testTopicControl = new TestTopicControl(mainForm, WriteToLog, new ServiceBusHelper(WriteToLog, serviceBusHelper), topicDescription, subscriptionList)
                                       {
                                           Location = new Point(1, panelMain.HeaderHeight + 1)
                                       };


                if (formTypeType == FormTypeEnum.Send)
                {
                    testTopicControl.mainTabControl.TabPages.RemoveAt(2);
                    testTopicControl.receiverEnabledCheckBox.Checked = false;
                    Text = string.Format(SendMessagesFormat, topicDescription.Path);
                }
                else
                {
                    Text = string.Format(TestTopicFormat, topicDescription.Path);
                    logTraceListener = new LogTraceListener(WriteToLog);
                    Trace.Listeners.Add(logTraceListener);
                }

                testTopicControl.btnCancel.Text = CloseLabel;
                testTopicControl.btnCancel.Click -= testTopicControl.btnCancel_Click;
                testTopicControl.btnCancel.Click += BtnCancelOnClick;
                testTopicControl.Focus();

                panelMain.HeaderText = string.Format(HeaderTextTestTopicFormat, topicDescription.Path);
                panelMain.Controls.Add(testTopicControl);
                SetStyle(ControlStyles.ResizeRedraw, true);
            }
            finally
            {
                panelMain.ResumeDrawing();
                ResumeLayout();
            }
        }

        public ContainerForm(ServiceBusHelper serviceBusHelper, MainForm mainForm, SubscriptionWrapper subscriptionWrapper)
        {
            try
            {
                InitializeComponent();
                this.mainForm = mainForm;
                mainSplitterDistance = mainSplitContainer.SplitterDistance;
                SuspendLayout();
                panelMain.SuspendDrawing();
                panelMain.Controls.Clear();
                panelMain.BackColor = SystemColors.GradientInactiveCaption;

                testSubscriptionControl = new TestSubscriptionControl(mainForm, WriteToLog, new ServiceBusHelper(WriteToLog, serviceBusHelper), subscriptionWrapper)
                                              {
                                                  Location = new Point(1, panelMain.HeaderHeight + 1)
                                              };

                testSubscriptionControl.btnCancel.Click -= testSubscriptionControl.btnCancel_Click;
                testSubscriptionControl.btnCancel.Click += BtnCancelOnClick;
                testSubscriptionControl.Focus();

                Text = string.Format(TestSubscriptionFormat, subscriptionWrapper.SubscriptionDescription.Name);

                panelMain.HeaderText = string.Format(HeaderTextTestSubscriptionFormat, subscriptionWrapper.SubscriptionDescription.Name);
                panelMain.Controls.Add(testSubscriptionControl);
                SetStyle(ControlStyles.ResizeRedraw, true);
            }
            finally
            {
                panelMain.ResumeDrawing();
                ResumeLayout();
            }
        }
        #endregion

        #region Private Methods
        private void BtnCancelOnClick(object sender, EventArgs eventArgs)
        {
            if (testQueueControl != null)
            {
                testQueueControl.CancelActions();
            }
            if (testTopicControl != null)
            {
                testTopicControl.CancelActions();
            }
            if (testSubscriptionControl != null)
            {
                testSubscriptionControl.CancelActions();
            }
            Close();
        }

        private void SetControlSize(Control control)
        {
            var ok = false;
            if (panelMain.Controls.Count > 0)
            {
                try
                {
                    if (control == null)
                    {
                        control = panelMain.Controls[0];
                        control.SuspendDrawing();
                        ok = true;
                    }
                    var width = panelMain.Width - 4;
                    var height = panelMain.Height - 26;
                    control.Width = width < ControlMinWidth ? ControlMinWidth : width;
                    control.Height = height < ControlMinHeight ? ControlMinHeight : height;
                }
                finally
                {
                    if (ok)
                    {
                        control.ResumeDrawing();
                    }
                }
            }
        }

        private void ContainerForm_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendDrawing();
        }

        private void ContainerForm_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeDrawing();
        }

        private void ContainerForm_SizeChanged(object sender, EventArgs e)
        {
            var changingUI = false;
            try
            {
                changingUI = true;
                panelMain.SuspendLayout();
                panelMain.SuspendDrawing();
                SetControlSize(null);
            }
            catch (Exception ex)
            {
                if (mainForm != null)
                {
                    mainForm.HandleException(ex);
                }
            }
            finally
            {
                if (changingUI)
                {
                    panelMain.ResumeDrawing();
                    panelMain.ResumeLayout();
                }
            }
        }

        private void WriteToLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(InternalWriteToLog), new object[] { message });
            }
            else
            {
                InternalWriteToLog(message);
            }
        }

        private void InternalWriteToLog(string message)
        {
            lock (this)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    var lines = message.Split('\n');
                    var objNow = DateTime.Now;
                    var space = new string(' ', 11);

                    for (var i = 0; i < lines.Length; i++)
                    {
                        if (i == 0)
                        {
                            string line = string.Format(DateFormat,
                                                        objNow.Hour,
                                                        objNow.Minute,
                                                        objNow.Second,
                                                        lines[i]);
                            lstLog.Items.Add(line);
                        }
                        else
                        {
                            lstLog.Items.Add(space + lines[i]);
                        }
                    }
                    lstLog.SelectedIndex = lstLog.Items.Count - 1;
                    lstLog.SelectedIndex = -1;
                }
            }
        }

        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logTraceListener != null &&
                Trace.Listeners.Contains(logTraceListener))
            {
                Trace.Listeners.Remove(logTraceListener);
            }
        }

        private void HandleException(Exception ex)
        {
            if (ex == null || string.IsNullOrEmpty(ex.Message))
            {
                return;
            }
            WriteToLog(string.Format(CultureInfo.CurrentCulture, ExceptionFormat, ex.Message));
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            {
                WriteToLog(string.Format(CultureInfo.CurrentCulture, InnerExceptionFormat, ex.InnerException.Message));
            }
        }

        private void mainSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            var changingUI = false;
            try
            {
                changingUI = true;
                panelMain.SuspendLayout();
                panelMain.SuspendDrawing();
                SetControlSize(null);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                if (changingUI)
                {
                    panelMain.ResumeDrawing();
                    panelMain.ResumeLayout();
                }
            }
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        /// <summary>
        /// Saves the log to a text file
        /// </summary>
        /// <param name="sender">MainForm object</param>
        /// <param name="e">System.EventArgs parameter</param>
        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLog.Items.Count > 0)
                {
                    saveFileDialog.Title = SaveAsTitle;
                    saveFileDialog.DefaultExt = SaveAsExtension;
                    saveFileDialog.Filter = SaveAsFilter;
                    saveFileDialog.FileName = string.Format(LogFileNameFormat, DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace('/', '-').Replace(':', '-'));
                    if (saveFileDialog.ShowDialog() == DialogResult.OK &&
                        !string.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (var t in lstLog.Items)
                            {
                                writer.WriteLine(t as string);
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

        private void lstLog_Leave(object sender, EventArgs e)
        {
            lstLog.SelectedIndex = -1;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void setDefaultLayouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainSplitContainer.SplitterDistance = mainSplitterDistance;
        }

        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null)
            {
                mainSplitContainer.Panel2Collapsed = !toolStripMenuItem.Checked;
                mainSplitContainer_SplitterMoved(this, null);
            }
        }
        #endregion      
    }
}
