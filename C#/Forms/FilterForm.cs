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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class FilterForm : Form
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string CaptionFormat = "Enter {0} Filter Expression";
        private const string FilterExpressionLabelFormat = "{0} Filter Expression:";
        private const string StartsWithFormat = "Startswith({0}, '{1}') Eq true";
        private const string MessageCountFormat = "MessageCount {0} {1}";
        private const string TimeFilterFormat = "{0} {1} '{2}'";
        
        //***************************
        // Constants
        //***************************
        private const string Subscription = "Subscription";
        private const string PathProperty = "Path";
        private const string AndOperator = " And ";

        //***************************
        // Properties & Types
        //***************************
        private const string MessageCountFilterOperator = "Operator";
        private const string MessageCountFilterValue = "Value";
        private const string TimeFilterProperty = "Property";
        private const string TimeFilterOperator = "Operator";
        private const string TimeFilterValue = "Value";

         //***************************
        // RegeEx Patterns & Groups
        //***************************
        private const string AndPattern = @"\s+and\s+";
        private const string StartWithPattern = @"(?i)startswith\(path,\s*\'(?<Path>\S*)\'\)\s+eq\s+true";
        private const string MessageCountPattern = @"(?i)messagecount\s+(?<Operator>eq|ne|gt|ge|le|lt)\s+(?<Value>\d+)";
        private const string TimeFilterPattern = @"(?i)(?<Property>createdat|updatedat|accessedat)\s+(?<Operator>eq|ne|gt|ge|le|lt)\s+\'(?<Value>\S+)\'";
        private const string PathGroup = "Path";
        #endregion

        #region Private Instance Fields
        private readonly string entity;
        private readonly BindingSource bindingSource = new BindingSource();
        #endregion

        #region Private Static Fields
        private static readonly List<string> properties = new List<string> { "CreatedAt", "AccessedAt", "UpdatedAt"};
        private static readonly List<string> operators = new List<string> { "Eq", "Ne", "Ge", "Gt", "Le", "Lt" };
        private static readonly List<TimeFilterInfo> timeFilters = new List<TimeFilterInfo>();
        #endregion

        #region Public Constructor
        public FilterForm(string entity, string filterExpression)
        {
            this.entity = entity;
            FilterExpression = filterExpression;
            InitializeComponent();
            InitializeControls();
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
            FilterExpression = null;
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

        private void filtersDataGridView_Resize(object sender, EventArgs e)
        {
            CalculateLastColumnWidth();
        }

        private void filtersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateLastColumnWidth();
            WriteFilterExpression();
        }

        private void filtersDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateLastColumnWidth();
            WriteFilterExpression();
        }

        private void txtFilterExpression_TextChanged(object sender, EventArgs e)
        {
            FilterExpression = txtFilterExpression.Text;
            ReadFilterExpression();
        }

        private void TextForm_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilterExpression.Text))
            {
                txtFilterExpression.Focus();
            }
            else
            {
                txtStartsWith.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FilterExpression = null;
            txtFilterExpression.Text = null;
        }

        private void txtStartsWith_TextChanged(object sender, EventArgs e)
        {
            WriteFilterExpression();
        }

        private void filtersDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void filtersDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            WriteFilterExpression();
        }

        private void filtersDataGridView_Leave(object sender, EventArgs e)
        {
            WriteFilterExpression();
        }

        private void FilterForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == '\r';
            if (e.Handled && !String.IsNullOrEmpty(txtFilterExpression.Text))
            {
                btnOk_Click(sender, null);
            }
        }

        private void cboMessageCountOperator_TextChanged(object sender, EventArgs e)
        {
            WriteFilterExpression();
        }

        private void txtMessageCount_TextChanged(object sender, EventArgs e)
        {
            WriteFilterExpression();
        }
        #endregion

        #region Public Properties
        public string FilterExpression { get; private set; }
        #endregion

        #region Private Methods
        private void InitializeControls()
        {
            try
            {
                if (string.IsNullOrEmpty(entity))
                {
                    return;
                }

                // Initialize labels and textboxes
                Text = string.Format(CaptionFormat, entity);
                lblFilterExpression.Text = string.Format(FilterExpressionLabelFormat, entity);

                if (!string.IsNullOrEmpty(FilterExpression))
                {
                    txtFilterExpression.TextChanged -= txtFilterExpression_TextChanged;
                    txtFilterExpression.Text = FilterExpression;
                    txtFilterExpression.TextChanged += txtFilterExpression_TextChanged;
                }

                // Initialize filters;
                ReadFilterExpression();
                bindingSource.DataSource = timeFilters;
                TimeFilterInfo.OnChange += WriteFilterExpression;

                // Initialize the DataGridView.
                timeFilterDataGridView.AutoGenerateColumns = false;
                timeFilterDataGridView.AutoSize = true;
                timeFilterDataGridView.DataSource = bindingSource;
                timeFilterDataGridView.ForeColor = SystemColors.WindowText;

                // Create the Property column
                var propertyColumn = new DataGridViewComboBoxColumn
                {
                    DataSource = properties,
                    DataPropertyName = TimeFilterProperty,
                    Name = TimeFilterProperty,
                    Width = 104,
                    FlatStyle = FlatStyle.Flat
                };
                timeFilterDataGridView.Columns.Add(propertyColumn);

                // Create the Operator column
                var operatorColumn = new DataGridViewComboBoxColumn
                {
                    DataSource = operators,
                    DataPropertyName = TimeFilterOperator,
                    Name = TimeFilterOperator,
                    Width = 72,
                    FlatStyle = FlatStyle.Flat
                };
                timeFilterDataGridView.Columns.Add(operatorColumn);

                // Create the Value column
                var valueColumn = new DataGridViewDateTimePickerColumn
                {
                    DataPropertyName = TimeFilterValue,
                    Name = TimeFilterValue,
                    Width = 104
                };
                timeFilterDataGridView.Columns.Add(valueColumn);

                // Set Grid style
                timeFilterDataGridView.EnableHeadersVisualStyles = false;

                // Set the selection background color for all the cells.
                timeFilterDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(92, 125, 150);
                timeFilterDataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.Window;

                // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
                // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
                timeFilterDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 180, 209);

                // Set the background color for all rows and for alternating rows.  
                // The value for alternating rows overrides the value for all rows. 
                timeFilterDataGridView.RowsDefaultCellStyle.BackColor = SystemColors.Window;
                timeFilterDataGridView.RowsDefaultCellStyle.ForeColor = SystemColors.ControlText;
                //filtersDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                //filtersDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText;

                // Set the row and column header styles.
                timeFilterDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
                timeFilterDataGridView.RowHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                timeFilterDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
                timeFilterDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;

                if (String.Compare(entity, Subscription, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    return;
                }
                lblStartsWith.Visible = false;
                txtStartsWith.Visible = false;
                lblTimeFilters.Location = lblMessageCount.Location;
                timeFilterDataGridView.Location = cboMessageCountOperator.Location;
                timeFilterDataGridView.Size = new Size(timeFilterDataGridView.Size.Width, 216);
                lblMessageCount.Location = lblStartsWith.Location;
                cboMessageCountOperator.Location = txtStartsWith.Location;
                txtMessageCount.Location = new Point(txtMessageCount.Location.X, txtStartsWith.Location.Y);
            }
            catch (Exception ex)
            {
                MainForm.SingletonMainForm.HandleException(ex);
            }
        }

        private void CalculateLastColumnWidth()
        {
            if (timeFilterDataGridView.Columns.Count == 3)
            {
                var width = timeFilterDataGridView.Width - timeFilterDataGridView.Columns[0].Width -
                            timeFilterDataGridView.Columns[1].Width - timeFilterDataGridView.RowHeadersWidth;
                var verticalScrollbar = timeFilterDataGridView.Controls.OfType<VScrollBar>().First();
                if (verticalScrollbar.Visible)
                {
                    width -= verticalScrollbar.Width;
                }
                timeFilterDataGridView.Columns[2].Width = width;
            }
        }

        private void ReadFilterExpression()
        {
            try
            {
                // Remove handlers
                txtStartsWith.TextChanged -= txtStartsWith_TextChanged;
                txtMessageCount.TextChanged -= txtMessageCount_TextChanged;
                cboMessageCountOperator.TextChanged -= cboMessageCountOperator_TextChanged;
                timeFilterDataGridView.RowsAdded -= filtersDataGridView_RowsAdded;
                timeFilterDataGridView.RowsRemoved -= filtersDataGridView_RowsRemoved;

                // Initialize control values
                txtStartsWith.Text = string.Empty;
                txtMessageCount.Text = string.Empty;              
                cboMessageCountOperator.SelectedIndex = 0;
                //timeFilterDataGridView.Rows.Clear();
                timeFilters.Clear();

                if (string.IsNullOrEmpty(FilterExpression))
                {
                    return;
                }
                var predicates = Regex.Split(FilterExpression, AndPattern, RegexOptions.IgnoreCase);
                var startswithRegex = new Regex(StartWithPattern);
                var messageCountRegex = new Regex(MessageCountPattern);
                var timeFilterRegex = new Regex(TimeFilterPattern);
                foreach (var predicate in predicates)
                {
                    var ok = false;

                    var matches = startswithRegex.Matches(predicate);
                    for (var j = 0; j < matches.Count; j++)
                    {
                        var pathGroup = matches[j].Groups[PathGroup].Value;
                        if (!string.IsNullOrEmpty(pathGroup))
                        {
                            txtStartsWith.Text = pathGroup;
                        }
                        ok = true;
                    }
                    if (ok)
                    {
                        continue;
                    }
                    matches = messageCountRegex.Matches(predicate);
                    for (var j = 0; j < matches.Count; j++)
                    {
                        var messageCountFilterOperator = matches[j].Groups[MessageCountFilterOperator].Value;
                        var messageCountFilterValue = matches[j].Groups[MessageCountFilterValue].Value;
                        int value;
                        if (!string.IsNullOrEmpty(messageCountFilterOperator) &&
                            !string.IsNullOrEmpty(messageCountFilterValue) &&
                            operators.Any(
                                op =>
                                string.Compare(op, messageCountFilterOperator, StringComparison.OrdinalIgnoreCase) == 0) &&
                            Int32.TryParse(messageCountFilterValue, out value))
                        {
                            cboMessageCountOperator.Text = messageCountFilterOperator;
                            txtMessageCount.Text = messageCountFilterValue;
                            ok = true;
                        }
                    }
                    if (ok)
                    {
                        continue;
                    }
                    matches = timeFilterRegex.Matches(predicate);
                    for (var i = 0; i < matches.Count; i++)
                    {
                        var timeFilterProperty = matches[i].Groups[TimeFilterProperty].Value;
                        var timeFilterOperator = matches[i].Groups[TimeFilterOperator].Value;
                        var timeFilterValue = matches[i].Groups[TimeFilterValue].Value;
                        if (!string.IsNullOrEmpty(timeFilterProperty) &&
                            !string.IsNullOrEmpty(timeFilterOperator) &&
                            !string.IsNullOrEmpty(timeFilterValue))
                        {
                            timeFilters.Add(new TimeFilterInfo
                                {
                                    Property = timeFilterProperty,
                                    Operator = timeFilterOperator,
                                    Value = timeFilterValue
                                });
                        }
                    }
                }
            }
            finally
            {
                // Add handlers
                txtStartsWith.TextChanged += txtStartsWith_TextChanged;
                txtMessageCount.TextChanged += txtMessageCount_TextChanged;
                cboMessageCountOperator.TextChanged += cboMessageCountOperator_TextChanged;
                bindingSource.ResetBindings(true);
                timeFilterDataGridView.RowsAdded += filtersDataGridView_RowsAdded;
                timeFilterDataGridView.RowsRemoved += filtersDataGridView_RowsRemoved;
            }
        }

        private void WriteFilterExpression()
        {
            var builder = new StringBuilder();
            var appendAnd = false;
            if (!string.IsNullOrEmpty(txtStartsWith.Text))
            {
                builder.AppendFormat(StartsWithFormat, PathProperty, txtStartsWith.Text);
                appendAnd = true;
            }
            if (!string.IsNullOrEmpty(txtMessageCount.Text) && cboMessageCountOperator.SelectedIndex > 0)
            {
                if (appendAnd)
                {
                    builder.Append(AndOperator);
                }
                builder.AppendFormat(MessageCountFormat, cboMessageCountOperator.Text, txtMessageCount.IntegerValue);
                appendAnd = true;
            }
            foreach (var timeFilter in timeFilters)
            {
                if (string.IsNullOrEmpty(timeFilter.Property) ||
                    string.IsNullOrEmpty(timeFilter.Operator) ||
                    string.IsNullOrEmpty(timeFilter.Value))
                {
                    continue;
                }
                if (appendAnd)
                {
                    builder.Append(AndOperator);
                }
                builder.AppendFormat(TimeFilterFormat,
                                     timeFilter.Property,
                                     timeFilter.Operator,
                                     timeFilter.Value);
                appendAnd = true;
            }
            txtFilterExpression.TextChanged -= txtFilterExpression_TextChanged;
            txtFilterExpression.Text = builder.ToString();
            FilterExpression = txtFilterExpression.Text;
            txtFilterExpression.TextChanged += txtFilterExpression_TextChanged;
        }
        #endregion
    }
}
