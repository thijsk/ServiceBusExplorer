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
using System.Windows.Forms;
using System.Drawing;
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class TextForm : Form
    {
        #region Private Constants
        //***************************
        // Constants
        //***************************
        private const string DefaultLabel = "Text";
        #endregion

        #region Public Constructor
        public TextForm(string label, string content)
        {
            InitializeComponent();
            grouperCaption.GroupTitle = string.IsNullOrEmpty(label) ? DefaultLabel : label;
            txtContent.Text = string.IsNullOrEmpty(content) ? string.Empty : content;
            Content = content;
        }
        #endregion

        #region Event Handlers
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Content = null;
            Close();
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
        #endregion

        #region Public Properties
        public string Content { get; set; }
        #endregion

        #region Private Methods
        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            Content = txtContent.Text;
        }

        private void TextForm_Activated(object sender, EventArgs e)
        {
            txtContent.Focus();
        }
        #endregion
    }
}
