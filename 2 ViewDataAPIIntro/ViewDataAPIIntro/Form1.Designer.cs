namespace ViewDataAPIIntro
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
            this.buttonToken = new System.Windows.Forms.Button();
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.labelRequest = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.buttonBucket = new System.Windows.Forms.Button();
            this.textBoxBucketName = new System.Windows.Forms.TextBox();
            this.labelBucket = new System.Windows.Forms.Label();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.buttonFile = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.labelToken = new System.Windows.Forms.Label();
            this.labelUrn = new System.Windows.Forms.Label();
            this.textBoxUrn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonToken
            // 
            this.buttonToken.Location = new System.Drawing.Point(439, 12);
            this.buttonToken.Name = "buttonToken";
            this.buttonToken.Size = new System.Drawing.Size(96, 25);
            this.buttonToken.TabIndex = 0;
            this.buttonToken.Text = "Get Token";
            this.buttonToken.UseVisualStyleBackColor = true;
            this.buttonToken.Click += new System.EventHandler(this.buttonToken_Click);
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Location = new System.Drawing.Point(35, 242);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRequest.Size = new System.Drawing.Size(389, 65);
            this.textBoxRequest.TabIndex = 1;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Location = new System.Drawing.Point(35, 341);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(389, 94);
            this.textBoxResponse.TabIndex = 2;
            // 
            // labelRequest
            // 
            this.labelRequest.AutoSize = true;
            this.labelRequest.Location = new System.Drawing.Point(35, 218);
            this.labelRequest.Name = "labelRequest";
            this.labelRequest.Size = new System.Drawing.Size(61, 17);
            this.labelRequest.TabIndex = 3;
            this.labelRequest.Text = "Request";
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(35, 320);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(72, 17);
            this.labelResponse.TabIndex = 4;
            this.labelResponse.Text = "Response";
            // 
            // buttonBucket
            // 
            this.buttonBucket.Location = new System.Drawing.Point(439, 50);
            this.buttonBucket.Name = "buttonBucket";
            this.buttonBucket.Size = new System.Drawing.Size(96, 25);
            this.buttonBucket.TabIndex = 5;
            this.buttonBucket.Text = "Create";
            this.buttonBucket.UseVisualStyleBackColor = true;
            this.buttonBucket.Click += new System.EventHandler(this.buttonBucket_Click);
            // 
            // textBoxBucketName
            // 
            this.textBoxBucketName.Location = new System.Drawing.Point(100, 50);
            this.textBoxBucketName.Name = "textBoxBucketName";
            this.textBoxBucketName.Size = new System.Drawing.Size(275, 22);
            this.textBoxBucketName.TabIndex = 6;
            // 
            // labelBucket
            // 
            this.labelBucket.AutoSize = true;
            this.labelBucket.Location = new System.Drawing.Point(35, 50);
            this.labelBucket.Name = "labelBucket";
            this.labelBucket.Size = new System.Drawing.Size(55, 17);
            this.labelBucket.TabIndex = 7;
            this.labelBucket.Text = "Bucket:";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(439, 96);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(96, 25);
            this.buttonUpload.TabIndex = 8;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(438, 144);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(96, 25);
            this.buttonRegister.TabIndex = 9;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(100, 100);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(275, 22);
            this.textBoxFile.TabIndex = 10;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(35, 100);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(30, 17);
            this.labelFile.TabIndex = 11;
            this.labelFile.Text = "File";
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(376, 98);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(29, 27);
            this.buttonFile.TabIndex = 12;
            this.buttonFile.Text = "...";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(100, 141);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(275, 22);
            this.textBoxId.TabIndex = 13;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(35, 144);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(19, 17);
            this.labelId.TabIndex = 14;
            this.labelId.Text = "id";
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(100, 14);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.ReadOnly = true;
            this.textBoxToken.Size = new System.Drawing.Size(275, 22);
            this.textBoxToken.TabIndex = 15;
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.Location = new System.Drawing.Point(35, 12);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(48, 17);
            this.labelToken.TabIndex = 16;
            this.labelToken.Text = "Token";
            // 
            // labelUrn
            // 
            this.labelUrn.AutoSize = true;
            this.labelUrn.Location = new System.Drawing.Point(35, 180);
            this.labelUrn.Name = "labelUrn";
            this.labelUrn.Size = new System.Drawing.Size(29, 17);
            this.labelUrn.TabIndex = 17;
            this.labelUrn.Text = "urn";
            // 
            // textBoxUrn
            // 
            this.textBoxUrn.Location = new System.Drawing.Point(100, 180);
            this.textBoxUrn.Name = "textBoxUrn";
            this.textBoxUrn.ReadOnly = true;
            this.textBoxUrn.Size = new System.Drawing.Size(275, 22);
            this.textBoxUrn.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 459);
            this.Controls.Add(this.textBoxUrn);
            this.Controls.Add(this.labelUrn);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.labelBucket);
            this.Controls.Add(this.textBoxBucketName);
            this.Controls.Add(this.buttonBucket);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.labelRequest);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.textBoxRequest);
            this.Controls.Add(this.buttonToken);
            this.Name = "Form1";
            this.Text = "View and Data API Intro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToken;
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.Label labelRequest;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.Button buttonBucket;
        private System.Windows.Forms.TextBox textBoxBucketName;
        private System.Windows.Forms.Label labelBucket;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.Label labelUrn;
        private System.Windows.Forms.TextBox textBoxUrn;
    }
}

