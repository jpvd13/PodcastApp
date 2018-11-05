namespace KT09_LK_ProductList {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lvProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAddingHeader = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.rbBook = new System.Windows.Forms.RadioButton();
            this.rbCd = new System.Windows.Forms.RadioButton();
            this.tbNumPages = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.tbArtist = new System.Windows.Forms.TextBox();
            this.tbLengthInMinutes = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblNumPages = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblLengthInMinutes = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.rbGame = new System.Windows.Forms.RadioButton();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.tbPlatform = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvProducts
            // 
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvProducts.Location = new System.Drawing.Point(13, 13);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(433, 120);
            this.lvProducts.TabIndex = 0;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Info";
            // 
            // lblAddingHeader
            // 
            this.lblAddingHeader.AutoSize = true;
            this.lblAddingHeader.Location = new System.Drawing.Point(84, 166);
            this.lblAddingHeader.Name = "lblAddingHeader";
            this.lblAddingHeader.Size = new System.Drawing.Size(88, 13);
            this.lblAddingHeader.TabIndex = 1;
            this.lblAddingHeader.Text = "Add new product";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(87, 195);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(85, 20);
            this.tbTitle.TabIndex = 2;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(87, 235);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(85, 20);
            this.tbPrice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(51, 198);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(47, 238);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price:";
            // 
            // rbBook
            // 
            this.rbBook.AutoSize = true;
            this.rbBook.Location = new System.Drawing.Point(48, 280);
            this.rbBook.Name = "rbBook";
            this.rbBook.Size = new System.Drawing.Size(50, 17);
            this.rbBook.TabIndex = 8;
            this.rbBook.TabStop = true;
            this.rbBook.Text = "Book";
            this.rbBook.UseVisualStyleBackColor = true;
            this.rbBook.CheckedChanged += new System.EventHandler(this.rbBook_CheckedChanged);
            // 
            // rbCd
            // 
            this.rbCd.AutoSize = true;
            this.rbCd.Location = new System.Drawing.Point(163, 280);
            this.rbCd.Name = "rbCd";
            this.rbCd.Size = new System.Drawing.Size(40, 17);
            this.rbCd.TabIndex = 9;
            this.rbCd.TabStop = true;
            this.rbCd.Text = "CD";
            this.rbCd.UseVisualStyleBackColor = true;
            this.rbCd.CheckedChanged += new System.EventHandler(this.rbCd_CheckedChanged);
            // 
            // tbNumPages
            // 
            this.tbNumPages.Location = new System.Drawing.Point(303, 235);
            this.tbNumPages.Name = "tbNumPages";
            this.tbNumPages.Size = new System.Drawing.Size(100, 20);
            this.tbNumPages.TabIndex = 10;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(303, 195);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(100, 20);
            this.tbAuthor.TabIndex = 11;
            // 
            // tbArtist
            // 
            this.tbArtist.Location = new System.Drawing.Point(303, 195);
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(100, 20);
            this.tbArtist.TabIndex = 12;
            // 
            // tbLengthInMinutes
            // 
            this.tbLengthInMinutes.Location = new System.Drawing.Point(303, 235);
            this.tbLengthInMinutes.Name = "tbLengthInMinutes";
            this.tbLengthInMinutes.Size = new System.Drawing.Size(100, 20);
            this.tbLengthInMinutes.TabIndex = 13;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(256, 198);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 14;
            this.lblAuthor.Text = "Author:";
            // 
            // lblNumPages
            // 
            this.lblNumPages.AutoSize = true;
            this.lblNumPages.Location = new System.Drawing.Point(221, 242);
            this.lblNumPages.Name = "lblNumPages";
            this.lblNumPages.Size = new System.Drawing.Size(76, 13);
            this.lblNumPages.TabIndex = 15;
            this.lblNumPages.Text = "Num of pages:";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(256, 198);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(33, 13);
            this.lblArtist.TabIndex = 16;
            this.lblArtist.Text = "Artist:";
            // 
            // lblLengthInMinutes
            // 
            this.lblLengthInMinutes.AutoSize = true;
            this.lblLengthInMinutes.Location = new System.Drawing.Point(204, 242);
            this.lblLengthInMinutes.Name = "lblLengthInMinutes";
            this.lblLengthInMinutes.Size = new System.Drawing.Size(93, 13);
            this.lblLengthInMinutes.TabIndex = 17;
            this.lblLengthInMinutes.Text = "Length in minutes:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(279, 277);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(12, 214);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(31, 20);
            this.tbId.TabIndex = 19;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(17, 195);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 20;
            this.lblId.Text = "ID";
            // 
            // rbGame
            // 
            this.rbGame.AutoSize = true;
            this.rbGame.Location = new System.Drawing.Point(104, 280);
            this.rbGame.Name = "rbGame";
            this.rbGame.Size = new System.Drawing.Size(53, 17);
            this.rbGame.TabIndex = 21;
            this.rbGame.TabStop = true;
            this.rbGame.Text = "Game";
            this.rbGame.UseVisualStyleBackColor = true;
            this.rbGame.CheckedChanged += new System.EventHandler(this.rbGame_CheckedChanged);
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(249, 217);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(48, 13);
            this.lblPlatform.TabIndex = 22;
            this.lblPlatform.Text = "Platform:";
            // 
            // tbPlatform
            // 
            this.tbPlatform.Location = new System.Drawing.Point(303, 214);
            this.tbPlatform.Name = "tbPlatform";
            this.tbPlatform.Size = new System.Drawing.Size(100, 20);
            this.tbPlatform.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 306);
            this.Controls.Add(this.tbPlatform);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.rbGame);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblLengthInMinutes);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblNumPages);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.tbLengthInMinutes);
            this.Controls.Add(this.tbArtist);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.tbNumPages);
            this.Controls.Add(this.rbCd);
            this.Controls.Add(this.rbBook);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lblAddingHeader);
            this.Controls.Add(this.lvProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblAddingHeader;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.RadioButton rbBook;
        private System.Windows.Forms.RadioButton rbCd;
        private System.Windows.Forms.TextBox tbNumPages;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.TextBox tbArtist;
        private System.Windows.Forms.TextBox tbLengthInMinutes;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblNumPages;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblLengthInMinutes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.RadioButton rbGame;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.TextBox tbPlatform;
    }
}

