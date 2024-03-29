﻿namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    partial class HandleTopicControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnCancelUpdate = new System.Windows.Forms.Button();
            this.btnCreateDelete = new System.Windows.Forms.Button();
            this.grouperTopicInformation = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.propertyListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grouperTopicProperties = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.trackBarMaxTopicSize = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.CustomTrackBar();
            this.txtUserMetadata = new System.Windows.Forms.TextBox();
            this.lblUserMetadata = new System.Windows.Forms.Label();
            this.lblMaxTopicSizeInGB = new System.Windows.Forms.Label();
            this.btnOpenDescriptionForm = new System.Windows.Forms.Button();
            this.lblMaxTopicSize = new System.Windows.Forms.Label();
            this.grouperDuplicateDetectionHistoryTimeWindow = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds = new System.Windows.Forms.Label();
            this.txtDuplicateDetectionHistoryTimeWindowMilliseconds = new System.Windows.Forms.TextBox();
            this.lblDuplicateDetectionHistoryTimeWindowSeconds = new System.Windows.Forms.Label();
            this.txtDuplicateDetectionHistoryTimeWindowSeconds = new System.Windows.Forms.TextBox();
            this.lblDuplicateDetectionHistoryTimeWindowMinutes = new System.Windows.Forms.Label();
            this.txtDuplicateDetectionHistoryTimeWindowMinutes = new System.Windows.Forms.TextBox();
            this.lblDuplicateDetectionHistoryTimeWindowHours = new System.Windows.Forms.Label();
            this.lblDuplicateDetectionHistoryTimeWindowDays = new System.Windows.Forms.Label();
            this.txtDuplicateDetectionHistoryTimeWindowHours = new System.Windows.Forms.TextBox();
            this.txtDuplicateDetectionHistoryTimeWindowDays = new System.Windows.Forms.TextBox();
            this.groupergrouperDefaultMessageTimeToLive = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.lblDefaultMessageTimeToLiveMilliseconds = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveMilliseconds = new System.Windows.Forms.TextBox();
            this.lblDefaultMessageTimeToLiveSeconds = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveSeconds = new System.Windows.Forms.TextBox();
            this.lblDefaultMessageTimeToLiveMinutes = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveMinutes = new System.Windows.Forms.TextBox();
            this.lbllblDefaultMessageTimeToLiveHours = new System.Windows.Forms.Label();
            this.lblDefaultMessageTimeToLiveDays = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveHours = new System.Windows.Forms.TextBox();
            this.txtDefaultMessageTimeToLiveDays = new System.Windows.Forms.TextBox();
            this.grouperTopicSettings = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.grouperPath = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.lblRelativeURI = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.grouperTopicInformation.SuspendLayout();
            this.grouperTopicProperties.SuspendLayout();
            this.grouperDuplicateDetectionHistoryTimeWindow.SuspendLayout();
            this.groupergrouperDefaultMessageTimeToLive.SuspendLayout();
            this.grouperTopicSettings.SuspendLayout();
            this.grouperPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Location = new System.Drawing.Point(640, 360);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnRefresh.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnChangeStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnChangeStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnChangeStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangeStatus.Location = new System.Drawing.Point(720, 360);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(72, 24);
            this.btnChangeStatus.TabIndex = 6;
            this.btnChangeStatus.Text = "Disable";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            this.btnChangeStatus.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnChangeStatus.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCancelUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancelUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancelUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelUpdate.Location = new System.Drawing.Point(880, 360);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(72, 24);
            this.btnCancelUpdate.TabIndex = 8;
            this.btnCancelUpdate.Text = "Update";
            this.btnCancelUpdate.UseVisualStyleBackColor = false;
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
            this.btnCancelUpdate.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnCancelUpdate.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnCreateDelete
            // 
            this.btnCreateDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCreateDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreateDelete.Location = new System.Drawing.Point(800, 360);
            this.btnCreateDelete.Name = "btnCreateDelete";
            this.btnCreateDelete.Size = new System.Drawing.Size(72, 24);
            this.btnCreateDelete.TabIndex = 7;
            this.btnCreateDelete.Text = "Create";
            this.btnCreateDelete.UseVisualStyleBackColor = false;
            this.btnCreateDelete.Click += new System.EventHandler(this.btnCreateDelete_Click);
            this.btnCreateDelete.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnCreateDelete.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // grouperTopicInformation
            // 
            this.grouperTopicInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperTopicInformation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperTopicInformation.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperTopicInformation.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperTopicInformation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperTopicInformation.BorderThickness = 1F;
            this.grouperTopicInformation.Controls.Add(this.propertyListView);
            this.grouperTopicInformation.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperTopicInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperTopicInformation.ForeColor = System.Drawing.Color.White;
            this.grouperTopicInformation.GroupImage = null;
            this.grouperTopicInformation.GroupTitle = "Topic Information";
            this.grouperTopicInformation.Location = new System.Drawing.Point(640, 8);
            this.grouperTopicInformation.Name = "grouperTopicInformation";
            this.grouperTopicInformation.Padding = new System.Windows.Forms.Padding(20);
            this.grouperTopicInformation.PaintGroupBox = true;
            this.grouperTopicInformation.RoundCorners = 4;
            this.grouperTopicInformation.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperTopicInformation.ShadowControl = false;
            this.grouperTopicInformation.ShadowThickness = 1;
            this.grouperTopicInformation.Size = new System.Drawing.Size(312, 344);
            this.grouperTopicInformation.TabIndex = 9;
            // 
            // propertyListView
            // 
            this.propertyListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.propertyListView.Location = new System.Drawing.Point(16, 32);
            this.propertyListView.Name = "propertyListView";
            this.propertyListView.OwnerDraw = true;
            this.propertyListView.Size = new System.Drawing.Size(279, 296);
            this.propertyListView.TabIndex = 0;
            this.propertyListView.UseCompatibleStateImageBehavior = false;
            this.propertyListView.View = System.Windows.Forms.View.Details;
            this.propertyListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.propertyListView_DrawColumnHeader);
            this.propertyListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.propertyListView_DrawItem);
            this.propertyListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.propertyListView_DrawSubItem);
            this.propertyListView.Resize += new System.EventHandler(this.propertyListView_Resize);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 160;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 115;
            // 
            // grouperTopicProperties
            // 
            this.grouperTopicProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grouperTopicProperties.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperTopicProperties.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperTopicProperties.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperTopicProperties.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperTopicProperties.BorderThickness = 1F;
            this.grouperTopicProperties.Controls.Add(this.lblMaxTopicSizeInGB);
            this.grouperTopicProperties.Controls.Add(this.trackBarMaxTopicSize);
            this.grouperTopicProperties.Controls.Add(this.txtUserMetadata);
            this.grouperTopicProperties.Controls.Add(this.lblUserMetadata);
            this.grouperTopicProperties.Controls.Add(this.btnOpenDescriptionForm);
            this.grouperTopicProperties.Controls.Add(this.lblMaxTopicSize);
            this.grouperTopicProperties.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperTopicProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperTopicProperties.ForeColor = System.Drawing.Color.White;
            this.grouperTopicProperties.GroupImage = null;
            this.grouperTopicProperties.GroupTitle = "Topic Properties";
            this.grouperTopicProperties.Location = new System.Drawing.Point(16, 184);
            this.grouperTopicProperties.Name = "grouperTopicProperties";
            this.grouperTopicProperties.Padding = new System.Windows.Forms.Padding(20);
            this.grouperTopicProperties.PaintGroupBox = true;
            this.grouperTopicProperties.RoundCorners = 4;
            this.grouperTopicProperties.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperTopicProperties.ShadowControl = false;
            this.grouperTopicProperties.ShadowThickness = 1;
            this.grouperTopicProperties.Size = new System.Drawing.Size(296, 168);
            this.grouperTopicProperties.TabIndex = 3;
            // 
            // trackBarMaxTopicSize
            // 
            this.trackBarMaxTopicSize.BackColor = System.Drawing.Color.Transparent;
            this.trackBarMaxTopicSize.BorderColor = System.Drawing.Color.Black;
            this.trackBarMaxTopicSize.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackBarMaxTopicSize.ForeColor = System.Drawing.Color.Black;
            this.trackBarMaxTopicSize.IndentHeight = 6;
            this.trackBarMaxTopicSize.LargeChange = 1;
            this.trackBarMaxTopicSize.Location = new System.Drawing.Point(8, 40);
            this.trackBarMaxTopicSize.Maximum = 10;
            this.trackBarMaxTopicSize.Minimum = 1;
            this.trackBarMaxTopicSize.Name = "trackBarMaxTopicSize";
            this.trackBarMaxTopicSize.Size = new System.Drawing.Size(248, 29);
            this.trackBarMaxTopicSize.TabIndex = 35;
            this.trackBarMaxTopicSize.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMaxTopicSize.TickColor = System.Drawing.Color.Black;
            this.trackBarMaxTopicSize.TickHeight = 4;
            this.trackBarMaxTopicSize.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.trackBarMaxTopicSize.TrackerSize = new System.Drawing.Size(12, 12);
            this.trackBarMaxTopicSize.TrackLineBrushStyle = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.BrushStyle.Solid;
            this.trackBarMaxTopicSize.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.trackBarMaxTopicSize.TrackLineHeight = 1;
            this.trackBarMaxTopicSize.Value = 1;
            this.trackBarMaxTopicSize.ValueChanged += new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.ValueChangedHandler(this.trackBarMaxTopicSize_ValueChanged);
            // 
            // txtUserMetadata
            // 
            this.txtUserMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserMetadata.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserMetadata.Location = new System.Drawing.Point(16, 88);
            this.txtUserMetadata.Multiline = true;
            this.txtUserMetadata.Name = "txtUserMetadata";
            this.txtUserMetadata.Size = new System.Drawing.Size(232, 64);
            this.txtUserMetadata.TabIndex = 2;
            // 
            // lblUserMetadata
            // 
            this.lblUserMetadata.AutoSize = true;
            this.lblUserMetadata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserMetadata.Location = new System.Drawing.Point(16, 72);
            this.lblUserMetadata.Name = "lblUserMetadata";
            this.lblUserMetadata.Size = new System.Drawing.Size(88, 13);
            this.lblUserMetadata.TabIndex = 27;
            this.lblUserMetadata.Text = "User Description:";
            // 
            // lblMaxTopicSizeInGB
            // 
            this.lblMaxTopicSizeInGB.AutoSize = true;
            this.lblMaxTopicSizeInGB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxTopicSizeInGB.Location = new System.Drawing.Point(252, 48);
            this.lblMaxTopicSizeInGB.Name = "lblMaxTopicSizeInGB";
            this.lblMaxTopicSizeInGB.Size = new System.Drawing.Size(31, 13);
            this.lblMaxTopicSizeInGB.TabIndex = 33;
            this.lblMaxTopicSizeInGB.Text = "1 GB";
            // 
            // btnOpenDescriptionForm
            // 
            this.btnOpenDescriptionForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDescriptionForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOpenDescriptionForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenDescriptionForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenDescriptionForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenDescriptionForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDescriptionForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenDescriptionForm.Location = new System.Drawing.Point(256, 88);
            this.btnOpenDescriptionForm.Name = "btnOpenDescriptionForm";
            this.btnOpenDescriptionForm.Size = new System.Drawing.Size(24, 21);
            this.btnOpenDescriptionForm.TabIndex = 3;
            this.btnOpenDescriptionForm.Text = "...";
            this.btnOpenDescriptionForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenDescriptionForm.UseVisualStyleBackColor = false;
            this.btnOpenDescriptionForm.Click += new System.EventHandler(this.btnOpenUserMetadataForm_Click);
            this.btnOpenDescriptionForm.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnOpenDescriptionForm.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // lblMaxTopicSize
            // 
            this.lblMaxTopicSize.AutoSize = true;
            this.lblMaxTopicSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxTopicSize.Location = new System.Drawing.Point(16, 28);
            this.lblMaxTopicSize.Name = "lblMaxTopicSize";
            this.lblMaxTopicSize.Size = new System.Drawing.Size(118, 13);
            this.lblMaxTopicSize.TabIndex = 24;
            this.lblMaxTopicSize.Text = "Max Queue Size In GB:";
            // 
            // grouperDuplicateDetectionHistoryTimeWindow
            // 
            this.grouperDuplicateDetectionHistoryTimeWindow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperDuplicateDetectionHistoryTimeWindow.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperDuplicateDetectionHistoryTimeWindow.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperDuplicateDetectionHistoryTimeWindow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperDuplicateDetectionHistoryTimeWindow.BorderThickness = 1F;
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.lblDuplicateDetectionHistoryTimeWindowMilliseconds);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.txtDuplicateDetectionHistoryTimeWindowMilliseconds);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.lblDuplicateDetectionHistoryTimeWindowSeconds);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.txtDuplicateDetectionHistoryTimeWindowSeconds);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.lblDuplicateDetectionHistoryTimeWindowMinutes);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.txtDuplicateDetectionHistoryTimeWindowMinutes);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.lblDuplicateDetectionHistoryTimeWindowHours);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.lblDuplicateDetectionHistoryTimeWindowDays);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.txtDuplicateDetectionHistoryTimeWindowHours);
            this.grouperDuplicateDetectionHistoryTimeWindow.Controls.Add(this.txtDuplicateDetectionHistoryTimeWindowDays);
            this.grouperDuplicateDetectionHistoryTimeWindow.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperDuplicateDetectionHistoryTimeWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperDuplicateDetectionHistoryTimeWindow.ForeColor = System.Drawing.Color.White;
            this.grouperDuplicateDetectionHistoryTimeWindow.GroupImage = null;
            this.grouperDuplicateDetectionHistoryTimeWindow.GroupTitle = "Duplicate Detection History Time Window";
            this.grouperDuplicateDetectionHistoryTimeWindow.Location = new System.Drawing.Point(328, 96);
            this.grouperDuplicateDetectionHistoryTimeWindow.Name = "grouperDuplicateDetectionHistoryTimeWindow";
            this.grouperDuplicateDetectionHistoryTimeWindow.Padding = new System.Windows.Forms.Padding(20);
            this.grouperDuplicateDetectionHistoryTimeWindow.PaintGroupBox = true;
            this.grouperDuplicateDetectionHistoryTimeWindow.RoundCorners = 4;
            this.grouperDuplicateDetectionHistoryTimeWindow.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperDuplicateDetectionHistoryTimeWindow.ShadowControl = false;
            this.grouperDuplicateDetectionHistoryTimeWindow.ShadowThickness = 1;
            this.grouperDuplicateDetectionHistoryTimeWindow.Size = new System.Drawing.Size(296, 80);
            this.grouperDuplicateDetectionHistoryTimeWindow.TabIndex = 2;
            // 
            // lblDuplicateDetectionHistoryTimeWindowMilliseconds
            // 
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.AutoSize = true;
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.Location = new System.Drawing.Point(240, 28);
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.Name = "lblDuplicateDetectionHistoryTimeWindowMilliseconds";
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.Size = new System.Drawing.Size(49, 13);
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.TabIndex = 25;
            this.lblDuplicateDetectionHistoryTimeWindowMilliseconds.Text = "Millisecs:";
            // 
            // txtDuplicateDetectionHistoryTimeWindowMilliseconds
            // 
            this.txtDuplicateDetectionHistoryTimeWindowMilliseconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuplicateDetectionHistoryTimeWindowMilliseconds.Location = new System.Drawing.Point(240, 44);
            this.txtDuplicateDetectionHistoryTimeWindowMilliseconds.Name = "txtDuplicateDetectionHistoryTimeWindowMilliseconds";
            this.txtDuplicateDetectionHistoryTimeWindowMilliseconds.Size = new System.Drawing.Size(40, 20);
            this.txtDuplicateDetectionHistoryTimeWindowMilliseconds.TabIndex = 4;
            // 
            // lblDuplicateDetectionHistoryTimeWindowSeconds
            // 
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.AutoSize = true;
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.Location = new System.Drawing.Point(184, 28);
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.Name = "lblDuplicateDetectionHistoryTimeWindowSeconds";
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.Size = new System.Drawing.Size(52, 13);
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.TabIndex = 24;
            this.lblDuplicateDetectionHistoryTimeWindowSeconds.Text = "Seconds:";
            // 
            // txtDuplicateDetectionHistoryTimeWindowSeconds
            // 
            this.txtDuplicateDetectionHistoryTimeWindowSeconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuplicateDetectionHistoryTimeWindowSeconds.Location = new System.Drawing.Point(184, 44);
            this.txtDuplicateDetectionHistoryTimeWindowSeconds.Name = "txtDuplicateDetectionHistoryTimeWindowSeconds";
            this.txtDuplicateDetectionHistoryTimeWindowSeconds.Size = new System.Drawing.Size(40, 20);
            this.txtDuplicateDetectionHistoryTimeWindowSeconds.TabIndex = 3;
            // 
            // lblDuplicateDetectionHistoryTimeWindowMinutes
            // 
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.AutoSize = true;
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.Location = new System.Drawing.Point(128, 28);
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.Name = "lblDuplicateDetectionHistoryTimeWindowMinutes";
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.Size = new System.Drawing.Size(47, 13);
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.TabIndex = 23;
            this.lblDuplicateDetectionHistoryTimeWindowMinutes.Text = "Minutes:";
            // 
            // txtDuplicateDetectionHistoryTimeWindowMinutes
            // 
            this.txtDuplicateDetectionHistoryTimeWindowMinutes.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuplicateDetectionHistoryTimeWindowMinutes.Location = new System.Drawing.Point(128, 44);
            this.txtDuplicateDetectionHistoryTimeWindowMinutes.Name = "txtDuplicateDetectionHistoryTimeWindowMinutes";
            this.txtDuplicateDetectionHistoryTimeWindowMinutes.Size = new System.Drawing.Size(40, 20);
            this.txtDuplicateDetectionHistoryTimeWindowMinutes.TabIndex = 2;
            // 
            // lblDuplicateDetectionHistoryTimeWindowHours
            // 
            this.lblDuplicateDetectionHistoryTimeWindowHours.AutoSize = true;
            this.lblDuplicateDetectionHistoryTimeWindowHours.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDuplicateDetectionHistoryTimeWindowHours.Location = new System.Drawing.Point(72, 28);
            this.lblDuplicateDetectionHistoryTimeWindowHours.Name = "lblDuplicateDetectionHistoryTimeWindowHours";
            this.lblDuplicateDetectionHistoryTimeWindowHours.Size = new System.Drawing.Size(38, 13);
            this.lblDuplicateDetectionHistoryTimeWindowHours.TabIndex = 22;
            this.lblDuplicateDetectionHistoryTimeWindowHours.Text = "Hours:";
            // 
            // lblDuplicateDetectionHistoryTimeWindowDays
            // 
            this.lblDuplicateDetectionHistoryTimeWindowDays.AutoSize = true;
            this.lblDuplicateDetectionHistoryTimeWindowDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDuplicateDetectionHistoryTimeWindowDays.Location = new System.Drawing.Point(16, 28);
            this.lblDuplicateDetectionHistoryTimeWindowDays.Name = "lblDuplicateDetectionHistoryTimeWindowDays";
            this.lblDuplicateDetectionHistoryTimeWindowDays.Size = new System.Drawing.Size(34, 13);
            this.lblDuplicateDetectionHistoryTimeWindowDays.TabIndex = 21;
            this.lblDuplicateDetectionHistoryTimeWindowDays.Text = "Days:";
            // 
            // txtDuplicateDetectionHistoryTimeWindowHours
            // 
            this.txtDuplicateDetectionHistoryTimeWindowHours.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuplicateDetectionHistoryTimeWindowHours.Location = new System.Drawing.Point(72, 44);
            this.txtDuplicateDetectionHistoryTimeWindowHours.Name = "txtDuplicateDetectionHistoryTimeWindowHours";
            this.txtDuplicateDetectionHistoryTimeWindowHours.Size = new System.Drawing.Size(40, 20);
            this.txtDuplicateDetectionHistoryTimeWindowHours.TabIndex = 1;
            // 
            // txtDuplicateDetectionHistoryTimeWindowDays
            // 
            this.txtDuplicateDetectionHistoryTimeWindowDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuplicateDetectionHistoryTimeWindowDays.Location = new System.Drawing.Point(16, 44);
            this.txtDuplicateDetectionHistoryTimeWindowDays.Name = "txtDuplicateDetectionHistoryTimeWindowDays";
            this.txtDuplicateDetectionHistoryTimeWindowDays.Size = new System.Drawing.Size(40, 20);
            this.txtDuplicateDetectionHistoryTimeWindowDays.TabIndex = 0;
            // 
            // groupergrouperDefaultMessageTimeToLive
            // 
            this.groupergrouperDefaultMessageTimeToLive.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.groupergrouperDefaultMessageTimeToLive.BackgroundGradientColor = System.Drawing.Color.White;
            this.groupergrouperDefaultMessageTimeToLive.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.groupergrouperDefaultMessageTimeToLive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupergrouperDefaultMessageTimeToLive.BorderThickness = 1F;
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveMilliseconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveMilliseconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveSeconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveSeconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveMinutes);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveMinutes);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lbllblDefaultMessageTimeToLiveHours);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveDays);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveHours);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveDays);
            this.groupergrouperDefaultMessageTimeToLive.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupergrouperDefaultMessageTimeToLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupergrouperDefaultMessageTimeToLive.ForeColor = System.Drawing.Color.White;
            this.groupergrouperDefaultMessageTimeToLive.GroupImage = null;
            this.groupergrouperDefaultMessageTimeToLive.GroupTitle = "Default Message Time To Live";
            this.groupergrouperDefaultMessageTimeToLive.Location = new System.Drawing.Point(16, 96);
            this.groupergrouperDefaultMessageTimeToLive.Name = "groupergrouperDefaultMessageTimeToLive";
            this.groupergrouperDefaultMessageTimeToLive.Padding = new System.Windows.Forms.Padding(20);
            this.groupergrouperDefaultMessageTimeToLive.PaintGroupBox = true;
            this.groupergrouperDefaultMessageTimeToLive.RoundCorners = 4;
            this.groupergrouperDefaultMessageTimeToLive.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupergrouperDefaultMessageTimeToLive.ShadowControl = false;
            this.groupergrouperDefaultMessageTimeToLive.ShadowThickness = 1;
            this.groupergrouperDefaultMessageTimeToLive.Size = new System.Drawing.Size(296, 80);
            this.groupergrouperDefaultMessageTimeToLive.TabIndex = 1;
            // 
            // lblDefaultMessageTimeToLiveMilliseconds
            // 
            this.lblDefaultMessageTimeToLiveMilliseconds.AutoSize = true;
            this.lblDefaultMessageTimeToLiveMilliseconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveMilliseconds.Location = new System.Drawing.Point(240, 28);
            this.lblDefaultMessageTimeToLiveMilliseconds.Name = "lblDefaultMessageTimeToLiveMilliseconds";
            this.lblDefaultMessageTimeToLiveMilliseconds.Size = new System.Drawing.Size(49, 13);
            this.lblDefaultMessageTimeToLiveMilliseconds.TabIndex = 25;
            this.lblDefaultMessageTimeToLiveMilliseconds.Text = "Millisecs:";
            // 
            // txtDefaultMessageTimeToLiveMilliseconds
            // 
            this.txtDefaultMessageTimeToLiveMilliseconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveMilliseconds.Location = new System.Drawing.Point(240, 44);
            this.txtDefaultMessageTimeToLiveMilliseconds.Name = "txtDefaultMessageTimeToLiveMilliseconds";
            this.txtDefaultMessageTimeToLiveMilliseconds.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveMilliseconds.TabIndex = 4;
            // 
            // lblDefaultMessageTimeToLiveSeconds
            // 
            this.lblDefaultMessageTimeToLiveSeconds.AutoSize = true;
            this.lblDefaultMessageTimeToLiveSeconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveSeconds.Location = new System.Drawing.Point(184, 28);
            this.lblDefaultMessageTimeToLiveSeconds.Name = "lblDefaultMessageTimeToLiveSeconds";
            this.lblDefaultMessageTimeToLiveSeconds.Size = new System.Drawing.Size(52, 13);
            this.lblDefaultMessageTimeToLiveSeconds.TabIndex = 24;
            this.lblDefaultMessageTimeToLiveSeconds.Text = "Seconds:";
            // 
            // txtDefaultMessageTimeToLiveSeconds
            // 
            this.txtDefaultMessageTimeToLiveSeconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveSeconds.Location = new System.Drawing.Point(184, 44);
            this.txtDefaultMessageTimeToLiveSeconds.Name = "txtDefaultMessageTimeToLiveSeconds";
            this.txtDefaultMessageTimeToLiveSeconds.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveSeconds.TabIndex = 3;
            // 
            // lblDefaultMessageTimeToLiveMinutes
            // 
            this.lblDefaultMessageTimeToLiveMinutes.AutoSize = true;
            this.lblDefaultMessageTimeToLiveMinutes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveMinutes.Location = new System.Drawing.Point(128, 28);
            this.lblDefaultMessageTimeToLiveMinutes.Name = "lblDefaultMessageTimeToLiveMinutes";
            this.lblDefaultMessageTimeToLiveMinutes.Size = new System.Drawing.Size(47, 13);
            this.lblDefaultMessageTimeToLiveMinutes.TabIndex = 23;
            this.lblDefaultMessageTimeToLiveMinutes.Text = "Minutes:";
            // 
            // txtDefaultMessageTimeToLiveMinutes
            // 
            this.txtDefaultMessageTimeToLiveMinutes.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveMinutes.Location = new System.Drawing.Point(128, 44);
            this.txtDefaultMessageTimeToLiveMinutes.Name = "txtDefaultMessageTimeToLiveMinutes";
            this.txtDefaultMessageTimeToLiveMinutes.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveMinutes.TabIndex = 2;
            // 
            // lbllblDefaultMessageTimeToLiveHours
            // 
            this.lbllblDefaultMessageTimeToLiveHours.AutoSize = true;
            this.lbllblDefaultMessageTimeToLiveHours.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbllblDefaultMessageTimeToLiveHours.Location = new System.Drawing.Point(72, 28);
            this.lbllblDefaultMessageTimeToLiveHours.Name = "lbllblDefaultMessageTimeToLiveHours";
            this.lbllblDefaultMessageTimeToLiveHours.Size = new System.Drawing.Size(38, 13);
            this.lbllblDefaultMessageTimeToLiveHours.TabIndex = 22;
            this.lbllblDefaultMessageTimeToLiveHours.Text = "Hours:";
            // 
            // lblDefaultMessageTimeToLiveDays
            // 
            this.lblDefaultMessageTimeToLiveDays.AutoSize = true;
            this.lblDefaultMessageTimeToLiveDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveDays.Location = new System.Drawing.Point(16, 28);
            this.lblDefaultMessageTimeToLiveDays.Name = "lblDefaultMessageTimeToLiveDays";
            this.lblDefaultMessageTimeToLiveDays.Size = new System.Drawing.Size(34, 13);
            this.lblDefaultMessageTimeToLiveDays.TabIndex = 21;
            this.lblDefaultMessageTimeToLiveDays.Text = "Days:";
            // 
            // txtDefaultMessageTimeToLiveHours
            // 
            this.txtDefaultMessageTimeToLiveHours.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveHours.Location = new System.Drawing.Point(72, 44);
            this.txtDefaultMessageTimeToLiveHours.Name = "txtDefaultMessageTimeToLiveHours";
            this.txtDefaultMessageTimeToLiveHours.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveHours.TabIndex = 1;
            // 
            // txtDefaultMessageTimeToLiveDays
            // 
            this.txtDefaultMessageTimeToLiveDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveDays.Location = new System.Drawing.Point(16, 44);
            this.txtDefaultMessageTimeToLiveDays.Name = "txtDefaultMessageTimeToLiveDays";
            this.txtDefaultMessageTimeToLiveDays.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveDays.TabIndex = 0;
            // 
            // grouperTopicSettings
            // 
            this.grouperTopicSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grouperTopicSettings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperTopicSettings.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperTopicSettings.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperTopicSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperTopicSettings.BorderThickness = 1F;
            this.grouperTopicSettings.Controls.Add(this.checkedListBox);
            this.grouperTopicSettings.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperTopicSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperTopicSettings.ForeColor = System.Drawing.Color.White;
            this.grouperTopicSettings.GroupImage = null;
            this.grouperTopicSettings.GroupTitle = "Topic Settings";
            this.grouperTopicSettings.Location = new System.Drawing.Point(328, 184);
            this.grouperTopicSettings.Name = "grouperTopicSettings";
            this.grouperTopicSettings.Padding = new System.Windows.Forms.Padding(20);
            this.grouperTopicSettings.PaintGroupBox = true;
            this.grouperTopicSettings.RoundCorners = 4;
            this.grouperTopicSettings.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperTopicSettings.ShadowControl = false;
            this.grouperTopicSettings.ShadowThickness = 1;
            this.grouperTopicSettings.Size = new System.Drawing.Size(296, 168);
            this.grouperTopicSettings.TabIndex = 4;
            // 
            // checkedListBox
            // 
            this.checkedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Enable Batched Operations",
            "Enable Filtering Messages Before Publishing",
            "Requires Duplicate Detection",
            "Enforce Message Ordering",
            "Is Anonymous Accessible"});
            this.checkedListBox.Location = new System.Drawing.Point(16, 43);
            this.checkedListBox.Margin = new System.Windows.Forms.Padding(8);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(264, 109);
            this.checkedListBox.TabIndex = 0;
            this.checkedListBox.ThreeDCheckBoxes = true;
            // 
            // grouperPath
            // 
            this.grouperPath.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperPath.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperPath.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperPath.BorderThickness = 1F;
            this.grouperPath.Controls.Add(this.lblRelativeURI);
            this.grouperPath.Controls.Add(this.txtPath);
            this.grouperPath.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperPath.ForeColor = System.Drawing.Color.White;
            this.grouperPath.GroupImage = null;
            this.grouperPath.GroupTitle = "Path";
            this.grouperPath.Location = new System.Drawing.Point(16, 8);
            this.grouperPath.Name = "grouperPath";
            this.grouperPath.Padding = new System.Windows.Forms.Padding(20);
            this.grouperPath.PaintGroupBox = true;
            this.grouperPath.RoundCorners = 4;
            this.grouperPath.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperPath.ShadowControl = false;
            this.grouperPath.ShadowThickness = 1;
            this.grouperPath.Size = new System.Drawing.Size(608, 80);
            this.grouperPath.TabIndex = 0;
            // 
            // lblRelativeURI
            // 
            this.lblRelativeURI.AutoSize = true;
            this.lblRelativeURI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRelativeURI.Location = new System.Drawing.Point(16, 28);
            this.lblRelativeURI.Name = "lblRelativeURI";
            this.lblRelativeURI.Size = new System.Drawing.Size(71, 13);
            this.lblRelativeURI.TabIndex = 22;
            this.lblRelativeURI.Text = "Relative URI:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPath.Location = new System.Drawing.Point(16, 44);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(576, 20);
            this.txtPath.TabIndex = 0;
            // 
            // HandleTopicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnCancelUpdate);
            this.Controls.Add(this.btnCreateDelete);
            this.Controls.Add(this.grouperTopicInformation);
            this.Controls.Add(this.grouperTopicProperties);
            this.Controls.Add(this.grouperDuplicateDetectionHistoryTimeWindow);
            this.Controls.Add(this.groupergrouperDefaultMessageTimeToLive);
            this.Controls.Add(this.grouperTopicSettings);
            this.Controls.Add(this.grouperPath);
            this.Name = "HandleTopicControl";
            this.Size = new System.Drawing.Size(968, 400);
            this.grouperTopicInformation.ResumeLayout(false);
            this.grouperTopicProperties.ResumeLayout(false);
            this.grouperTopicProperties.PerformLayout();
            this.grouperDuplicateDetectionHistoryTimeWindow.ResumeLayout(false);
            this.grouperDuplicateDetectionHistoryTimeWindow.PerformLayout();
            this.groupergrouperDefaultMessageTimeToLive.ResumeLayout(false);
            this.groupergrouperDefaultMessageTimeToLive.PerformLayout();
            this.grouperTopicSettings.ResumeLayout(false);
            this.grouperPath.ResumeLayout(false);
            this.grouperPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private Grouper grouperPath;
        private System.Windows.Forms.Label lblRelativeURI;
        private System.Windows.Forms.TextBox txtPath;
        private Grouper grouperTopicSettings;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private Grouper groupergrouperDefaultMessageTimeToLive;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveMilliseconds;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveMilliseconds;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveSeconds;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveSeconds;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveMinutes;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveMinutes;
        private System.Windows.Forms.Label lbllblDefaultMessageTimeToLiveHours;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveDays;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveHours;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveDays;
        private Grouper grouperDuplicateDetectionHistoryTimeWindow;
        private System.Windows.Forms.Label lblDuplicateDetectionHistoryTimeWindowMilliseconds;
        private System.Windows.Forms.TextBox txtDuplicateDetectionHistoryTimeWindowMilliseconds;
        private System.Windows.Forms.Label lblDuplicateDetectionHistoryTimeWindowSeconds;
        private System.Windows.Forms.TextBox txtDuplicateDetectionHistoryTimeWindowSeconds;
        private System.Windows.Forms.Label lblDuplicateDetectionHistoryTimeWindowMinutes;
        private System.Windows.Forms.TextBox txtDuplicateDetectionHistoryTimeWindowMinutes;
        private System.Windows.Forms.Label lblDuplicateDetectionHistoryTimeWindowHours;
        private System.Windows.Forms.Label lblDuplicateDetectionHistoryTimeWindowDays;
        private System.Windows.Forms.TextBox txtDuplicateDetectionHistoryTimeWindowHours;
        private System.Windows.Forms.TextBox txtDuplicateDetectionHistoryTimeWindowDays;
        private Grouper grouperTopicProperties;
        private System.Windows.Forms.Label lblMaxTopicSizeInGB;
        private System.Windows.Forms.Button btnOpenDescriptionForm;
        private System.Windows.Forms.TextBox txtUserMetadata;
        private System.Windows.Forms.Label lblUserMetadata;
        private System.Windows.Forms.Label lblMaxTopicSize;
        private Grouper grouperTopicInformation;
        private System.Windows.Forms.ListView propertyListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnCancelUpdate;
        private System.Windows.Forms.Button btnCreateDelete;
        private CustomTrackBar trackBarMaxTopicSize;
    }
}
