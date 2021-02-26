namespace F013
{
    partial class F013
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.listViewStockOfStoreHouses = new System.Windows.Forms.ListView();
            this.labelMainText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(10, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Kilépés";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Location = new System.Drawing.Point(402, 226);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(75, 23);
            this.buttonTransfer.TabIndex = 1;
            this.buttonTransfer.Text = "Átmozgatás";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // listViewStockOfStoreHouses
            // 
            this.listViewStockOfStoreHouses.HideSelection = false;
            this.listViewStockOfStoreHouses.Location = new System.Drawing.Point(10, 20);
            this.listViewStockOfStoreHouses.Name = "listViewStockOfStoreHouses";
            this.listViewStockOfStoreHouses.Size = new System.Drawing.Size(465, 196);
            this.listViewStockOfStoreHouses.TabIndex = 2;
            this.listViewStockOfStoreHouses.UseCompatibleStateImageBehavior = false;
            this.listViewStockOfStoreHouses.View = System.Windows.Forms.View.Details;
            this.listViewStockOfStoreHouses.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewColumnclicked);
            this.listViewStockOfStoreHouses.DoubleClick += new System.EventHandler(this.listViewStockOfStoreHouses_DoubleClick);
            // 
            // labelMainText
            // 
            this.labelMainText.Location = new System.Drawing.Point(0, 3);
            this.labelMainText.Name = "labelMainText";
            this.labelMainText.Size = new System.Drawing.Size(484, 13);
            this.labelMainText.TabIndex = 3;
            this.labelMainText.Text = "Raktárkészletek megjelenítése";
            this.labelMainText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // F013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.labelMainText);
            this.Controls.Add(this.listViewStockOfStoreHouses);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "F013";
            this.Text = "F013";
            this.Load += new System.EventHandler(this.F013_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.ListView listViewStockOfStoreHouses;
        private System.Windows.Forms.Label labelMainText;
    }
}

