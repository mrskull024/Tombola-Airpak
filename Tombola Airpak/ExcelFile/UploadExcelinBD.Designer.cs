namespace Tombola_Airpak.ExcelFile
{
    partial class UploadExcelinBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadExcelinBD));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnFindExcel = new System.Windows.Forms.Button();
            this.btnUploadExcel = new System.Windows.Forms.Button();
            this.lblStatusUploadExcel = new System.Windows.Forms.Label();
            this.linklErrasePreviousData = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(18, 18);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(809, 375);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(19, 401);
            this.txtFilePath.Multiline = true;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(808, 53);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnFindExcel
            // 
            this.btnFindExcel.Location = new System.Drawing.Point(612, 460);
            this.btnFindExcel.Name = "btnFindExcel";
            this.btnFindExcel.Size = new System.Drawing.Size(105, 44);
            this.btnFindExcel.TabIndex = 3;
            this.btnFindExcel.Text = "Buscar XLS";
            this.btnFindExcel.UseVisualStyleBackColor = true;
            this.btnFindExcel.Click += new System.EventHandler(this.btnFindExcel_Click);
            // 
            // btnUploadExcel
            // 
            this.btnUploadExcel.Location = new System.Drawing.Point(723, 460);
            this.btnUploadExcel.Name = "btnUploadExcel";
            this.btnUploadExcel.Size = new System.Drawing.Size(105, 44);
            this.btnUploadExcel.TabIndex = 4;
            this.btnUploadExcel.Text = "Subir XLS";
            this.btnUploadExcel.UseVisualStyleBackColor = true;
            this.btnUploadExcel.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // lblStatusUploadExcel
            // 
            this.lblStatusUploadExcel.AutoSize = true;
            this.lblStatusUploadExcel.Location = new System.Drawing.Point(15, 472);
            this.lblStatusUploadExcel.Name = "lblStatusUploadExcel";
            this.lblStatusUploadExcel.Size = new System.Drawing.Size(165, 20);
            this.lblStatusUploadExcel.TabIndex = 5;
            this.lblStatusUploadExcel.Text = "labelStatusUploadFile";
            // 
            // linklErrasePreviousData
            // 
            this.linklErrasePreviousData.AutoSize = true;
            this.linklErrasePreviousData.Location = new System.Drawing.Point(608, 518);
            this.linklErrasePreviousData.Name = "linklErrasePreviousData";
            this.linklErrasePreviousData.Size = new System.Drawing.Size(177, 20);
            this.linklErrasePreviousData.TabIndex = 6;
            this.linklErrasePreviousData.TabStop = true;
            this.linklErrasePreviousData.Text = "Borrar Datos Anteriores";
            this.linklErrasePreviousData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklErrasePreviousData_LinkClicked);
            // 
            // UploadExcelinBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 545);
            this.Controls.Add(this.linklErrasePreviousData);
            this.Controls.Add(this.lblStatusUploadExcel);
            this.Controls.Add(this.btnUploadExcel);
            this.Controls.Add(this.btnFindExcel);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UploadExcelinBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UploadExcelinBD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnFindExcel;
        private System.Windows.Forms.Button btnUploadExcel;
        private System.Windows.Forms.Label lblStatusUploadExcel;
        private System.Windows.Forms.LinkLabel linklErrasePreviousData;
    }
}