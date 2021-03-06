﻿namespace WindowsFormsApp1
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvFeeds = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwEpisodes = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwCategories = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbbCategories = new System.Windows.Forms.ComboBox();
            this.cbbFrequency = new System.Windows.Forms.ComboBox();
            this.btnDeletePod = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnDeleteCategory = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFeedUrl = new System.Windows.Forms.TextBox();
            this.lblTitleDesc = new System.Windows.Forms.Label();
            this.tbEpisodeDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvFeeds
            // 
            this.lvFeeds.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFeeds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvFeeds.GridLines = true;
            this.lvFeeds.Location = new System.Drawing.Point(18, 18);
            this.lvFeeds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvFeeds.MultiSelect = false;
            this.lvFeeds.Name = "lvFeeds";
            this.lvFeeds.Size = new System.Drawing.Size(530, 241);
            this.lvFeeds.TabIndex = 0;
            this.lvFeeds.UseCompatibleStateImageBehavior = false;
            this.lvFeeds.View = System.Windows.Forms.View.Details;
            this.lvFeeds.SelectedIndexChanged += new System.EventHandler(this.lvFeeds_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 162;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Episodes";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Frequency";
            // 
            // lwEpisodes
            // 
            this.lwEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lwEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lwEpisodes.GridLines = true;
            this.lwEpisodes.Location = new System.Drawing.Point(18, 402);
            this.lwEpisodes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lwEpisodes.MultiSelect = false;
            this.lwEpisodes.Name = "lwEpisodes";
            this.lwEpisodes.Size = new System.Drawing.Size(530, 302);
            this.lwEpisodes.TabIndex = 1;
            this.lwEpisodes.UseCompatibleStateImageBehavior = false;
            this.lwEpisodes.View = System.Windows.Forms.View.Details;
            this.lwEpisodes.SelectedIndexChanged += new System.EventHandler(this.lwEpisodes_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Episodes";
            this.columnHeader5.Width = 348;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "id";
            this.columnHeader6.Width = 0;
            // 
            // lwCategories
            // 
            this.lwCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lwCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7});
            this.lwCategories.GridLines = true;
            this.lwCategories.HideSelection = false;
            this.lwCategories.Location = new System.Drawing.Point(622, 43);
            this.lwCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lwCategories.MultiSelect = false;
            this.lwCategories.Name = "lwCategories";
            this.lwCategories.Size = new System.Drawing.Size(354, 216);
            this.lwCategories.TabIndex = 2;
            this.lwCategories.UseCompatibleStateImageBehavior = false;
            this.lwCategories.View = System.Windows.Forms.View.Details;
            this.lwCategories.SelectedIndexChanged += new System.EventHandler(this.lwCategories_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Categories";
            this.columnHeader7.Width = 229;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(195, 357);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbbCategories
            // 
            this.cbbCategories.FormattingEnabled = true;
            this.cbbCategories.Location = new System.Drawing.Point(195, 315);
            this.cbbCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbCategories.Name = "cbbCategories";
            this.cbbCategories.Size = new System.Drawing.Size(162, 28);
            this.cbbCategories.TabIndex = 5;
            // 
            // cbbFrequency
            // 
            this.cbbFrequency.FormattingEnabled = true;
            this.cbbFrequency.Items.AddRange(new object[] {
            "5 min",
            "10 min",
            "15 min",
            "30 min",
            "60 min"});
            this.cbbFrequency.Location = new System.Drawing.Point(369, 315);
            this.cbbFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbFrequency.Name = "cbbFrequency";
            this.cbbFrequency.Size = new System.Drawing.Size(180, 28);
            this.cbbFrequency.TabIndex = 6;
            this.cbbFrequency.Text = "60 min";
            // 
            // btnDeletePod
            // 
            this.btnDeletePod.Location = new System.Drawing.Point(438, 357);
            this.btnDeletePod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeletePod.Name = "btnDeletePod";
            this.btnDeletePod.Size = new System.Drawing.Size(112, 35);
            this.btnDeletePod.TabIndex = 7;
            this.btnDeletePod.Text = "Delete";
            this.btnDeletePod.UseVisualStyleBackColor = true;
            this.btnDeletePod.Click += new System.EventHandler(this.btnDeletePod_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(316, 357);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 35);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(744, 315);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnUpdateCategory);
            // 
            // BtnDeleteCategory
            // 
            this.BtnDeleteCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDeleteCategory.Location = new System.Drawing.Point(866, 315);
            this.BtnDeleteCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnDeleteCategory.Name = "BtnDeleteCategory";
            this.BtnDeleteCategory.Size = new System.Drawing.Size(112, 35);
            this.BtnDeleteCategory.TabIndex = 10;
            this.BtnDeleteCategory.Text = "Delete";
            this.BtnDeleteCategory.UseVisualStyleBackColor = true;
            this.BtnDeleteCategory.Click += new System.EventHandler(this.BtnDeleteCategory_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(622, 315);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 9;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(622, 274);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(354, 26);
            this.txtCategory.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(626, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Url";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 286);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Update Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(190, 286);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Category";
            // 
            // txtFeedUrl
            // 
            this.txtFeedUrl.Location = new System.Drawing.Point(18, 315);
            this.txtFeedUrl.Name = "txtFeedUrl";
            this.txtFeedUrl.Size = new System.Drawing.Size(146, 26);
            this.txtFeedUrl.TabIndex = 20;
            // 
            // lblTitleDesc
            // 
            this.lblTitleDesc.AutoSize = true;
            this.lblTitleDesc.Location = new System.Drawing.Point(620, 363);
            this.lblTitleDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleDesc.Name = "lblTitleDesc";
            this.lblTitleDesc.Size = new System.Drawing.Size(0, 20);
            this.lblTitleDesc.TabIndex = 13;
            // 
            // tbEpisodeDesc
            // 
            this.tbEpisodeDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEpisodeDesc.Location = new System.Drawing.Point(622, 402);
            this.tbEpisodeDesc.Multiline = true;
            this.tbEpisodeDesc.Name = "tbEpisodeDesc";
            this.tbEpisodeDesc.ReadOnly = true;
            this.tbEpisodeDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEpisodeDesc.Size = new System.Drawing.Size(354, 304);
            this.tbEpisodeDesc.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 725);
            this.Controls.Add(this.tbEpisodeDesc);
            this.Controls.Add(this.txtFeedUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitleDesc);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnDeleteCategory);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeletePod);
            this.Controls.Add(this.cbbFrequency);
            this.Controls.Add(this.cbbCategories);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lwCategories);
            this.Controls.Add(this.lwEpisodes);
            this.Controls.Add(this.lvFeeds);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lwEpisodes;
        private System.Windows.Forms.ListView lwCategories;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbbCategories;
        private System.Windows.Forms.ComboBox cbbFrequency;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnDeletePod;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnDeleteCategory;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvFeeds;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtFeedUrl;
        private System.Windows.Forms.Label lblTitleDesc;
        private System.Windows.Forms.TextBox tbEpisodeDesc;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}

