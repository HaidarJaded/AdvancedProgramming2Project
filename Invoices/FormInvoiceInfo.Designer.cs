namespace APP2EFCore.Invoices
{
    partial class FormInvoiceInfo
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
            DGVInvoiceInfo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGVInvoiceInfo).BeginInit();
            SuspendLayout();
            // 
            // DGVInvoiceInfo
            // 
            DGVInvoiceInfo.AllowUserToAddRows = false;
            DGVInvoiceInfo.AllowUserToDeleteRows = false;
            DGVInvoiceInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVInvoiceInfo.BackgroundColor = Color.White;
            DGVInvoiceInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVInvoiceInfo.Dock = DockStyle.Fill;
            DGVInvoiceInfo.Location = new Point(0, 0);
            DGVInvoiceInfo.Name = "DGVInvoiceInfo";
            DGVInvoiceInfo.ReadOnly = true;
            DGVInvoiceInfo.Size = new Size(619, 441);
            DGVInvoiceInfo.TabIndex = 0;
            // 
            // FormInvoiceInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 441);
            Controls.Add(DGVInvoiceInfo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "FormInvoiceInfo";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "معلومات الفاتورة";
            Load += FormInvoiceInfo_Load;
            ((System.ComponentModel.ISupportInitialize)DGVInvoiceInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVInvoiceInfo;
    }
}