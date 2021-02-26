namespace F013
{
    partial class StockTransfer
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
            this.comboBoxStoreHouseWhereFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxStoreHouseDestination = new System.Windows.Forms.ComboBox();
            this.labelMainText = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.comboBoxSelectedStoreHouseProducts = new System.Windows.Forms.ComboBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.numericUpDownDeliveryAmount = new System.Windows.Forms.NumericUpDown();
            this.labelWhereFromStock = new System.Windows.Forms.Label();
            this.labelDestinationStock = new System.Windows.Forms.Label();
            this.labelAmountOfWhereFromStock = new System.Windows.Forms.Label();
            this.labelAmountOfDestinationStock = new System.Windows.Forms.Label();
            this.labelMinimumTransferAmountText = new System.Windows.Forms.Label();
            this.labelMinimumTransferAmountValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeliveryAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxStoreHouseWhereFrom
            // 
            this.comboBoxStoreHouseWhereFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoreHouseWhereFrom.FormattingEnabled = true;
            this.comboBoxStoreHouseWhereFrom.Location = new System.Drawing.Point(128, 30);
            this.comboBoxStoreHouseWhereFrom.Name = "comboBoxStoreHouseWhereFrom";
            this.comboBoxStoreHouseWhereFrom.Size = new System.Drawing.Size(150, 21);
            this.comboBoxStoreHouseWhereFrom.TabIndex = 0;
            this.comboBoxStoreHouseWhereFrom.SelectedIndexChanged += new System.EventHandler(this.ComboboxSelectionChanged);
            // 
            // comboBoxStoreHouseDestination
            // 
            this.comboBoxStoreHouseDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoreHouseDestination.FormattingEnabled = true;
            this.comboBoxStoreHouseDestination.Location = new System.Drawing.Point(128, 61);
            this.comboBoxStoreHouseDestination.Name = "comboBoxStoreHouseDestination";
            this.comboBoxStoreHouseDestination.Size = new System.Drawing.Size(150, 21);
            this.comboBoxStoreHouseDestination.TabIndex = 1;
            this.comboBoxStoreHouseDestination.SelectedIndexChanged += new System.EventHandler(this.ComboboxSelectionChanged);
            // 
            // labelMainText
            // 
            this.labelMainText.Location = new System.Drawing.Point(0, 3);
            this.labelMainText.Name = "labelMainText";
            this.labelMainText.Size = new System.Drawing.Size(419, 13);
            this.labelMainText.TabIndex = 2;
            this.labelMainText.Text = "Adja meg a mozgatáshoz szükséges adatokat";
            this.labelMainText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(10, 33);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(102, 13);
            this.labelStart.TabIndex = 3;
            this.labelStart.Text = "Elszállítás helyszíne";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(10, 64);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(97, 13);
            this.labelDestination.TabIndex = 4;
            this.labelDestination.Text = "Célraktár helyszíne";
            // 
            // comboBoxSelectedStoreHouseProducts
            // 
            this.comboBoxSelectedStoreHouseProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedStoreHouseProducts.FormattingEnabled = true;
            this.comboBoxSelectedStoreHouseProducts.Location = new System.Drawing.Point(128, 94);
            this.comboBoxSelectedStoreHouseProducts.Name = "comboBoxSelectedStoreHouseProducts";
            this.comboBoxSelectedStoreHouseProducts.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSelectedStoreHouseProducts.TabIndex = 5;
            this.comboBoxSelectedStoreHouseProducts.SelectedIndexChanged += new System.EventHandler(this.ComboboxSelectionChanged);
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(10, 97);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(43, 13);
            this.labelProduct.TabIndex = 7;
            this.labelProduct.Text = "Termék";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(10, 130);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(113, 13);
            this.labelAmount.TabIndex = 8;
            this.labelAmount.Text = "Szállítandó mennyiség";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(10, 163);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Vissza";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Location = new System.Drawing.Point(332, 163);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(75, 23);
            this.buttonTransfer.TabIndex = 10;
            this.buttonTransfer.Text = "Átmozgatás";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // numericUpDownDeliveryAmount
            // 
            this.numericUpDownDeliveryAmount.Location = new System.Drawing.Point(128, 128);
            this.numericUpDownDeliveryAmount.Name = "numericUpDownDeliveryAmount";
            this.numericUpDownDeliveryAmount.Size = new System.Drawing.Size(86, 20);
            this.numericUpDownDeliveryAmount.TabIndex = 11;
            // 
            // labelWhereFromStock
            // 
            this.labelWhereFromStock.AutoSize = true;
            this.labelWhereFromStock.Location = new System.Drawing.Point(284, 33);
            this.labelWhereFromStock.Name = "labelWhereFromStock";
            this.labelWhereFromStock.Size = new System.Drawing.Size(44, 13);
            this.labelWhereFromStock.TabIndex = 12;
            this.labelWhereFromStock.Text = "Készlet:";
            // 
            // labelDestinationStock
            // 
            this.labelDestinationStock.AutoSize = true;
            this.labelDestinationStock.Location = new System.Drawing.Point(284, 64);
            this.labelDestinationStock.Name = "labelDestinationStock";
            this.labelDestinationStock.Size = new System.Drawing.Size(44, 13);
            this.labelDestinationStock.TabIndex = 13;
            this.labelDestinationStock.Text = "Készlet:";
            // 
            // labelAmountOfWhereFromStock
            // 
            this.labelAmountOfWhereFromStock.AutoSize = true;
            this.labelAmountOfWhereFromStock.Location = new System.Drawing.Point(325, 33);
            this.labelAmountOfWhereFromStock.Name = "labelAmountOfWhereFromStock";
            this.labelAmountOfWhereFromStock.Size = new System.Drawing.Size(0, 13);
            this.labelAmountOfWhereFromStock.TabIndex = 14;
            // 
            // labelAmountOfDestinationStock
            // 
            this.labelAmountOfDestinationStock.AutoSize = true;
            this.labelAmountOfDestinationStock.Location = new System.Drawing.Point(325, 64);
            this.labelAmountOfDestinationStock.Name = "labelAmountOfDestinationStock";
            this.labelAmountOfDestinationStock.Size = new System.Drawing.Size(0, 13);
            this.labelAmountOfDestinationStock.TabIndex = 15;
            // 
            // labelMinimumTransferAmountText
            // 
            this.labelMinimumTransferAmountText.AutoSize = true;
            this.labelMinimumTransferAmountText.Location = new System.Drawing.Point(224, 130);
            this.labelMinimumTransferAmountText.Name = "labelMinimumTransferAmountText";
            this.labelMinimumTransferAmountText.Size = new System.Drawing.Size(104, 13);
            this.labelMinimumTransferAmountText.TabIndex = 16;
            this.labelMinimumTransferAmountText.Text = "Minimum mennyiség:";
            // 
            // labelMinimumTransferAmountValue
            // 
            this.labelMinimumTransferAmountValue.AutoSize = true;
            this.labelMinimumTransferAmountValue.Location = new System.Drawing.Point(329, 130);
            this.labelMinimumTransferAmountValue.Name = "labelMinimumTransferAmountValue";
            this.labelMinimumTransferAmountValue.Size = new System.Drawing.Size(0, 13);
            this.labelMinimumTransferAmountValue.TabIndex = 17;
            // 
            // StockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 194);
            this.Controls.Add(this.labelMinimumTransferAmountValue);
            this.Controls.Add(this.labelMinimumTransferAmountText);
            this.Controls.Add(this.labelAmountOfDestinationStock);
            this.Controls.Add(this.labelAmountOfWhereFromStock);
            this.Controls.Add(this.labelDestinationStock);
            this.Controls.Add(this.labelWhereFromStock);
            this.Controls.Add(this.numericUpDownDeliveryAmount);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.comboBoxSelectedStoreHouseProducts);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.labelMainText);
            this.Controls.Add(this.comboBoxStoreHouseDestination);
            this.Controls.Add(this.comboBoxStoreHouseWhereFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Raktárkészlet átmozgatása";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockTransfer_FormClosing);
            this.Load += new System.EventHandler(this.StockTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeliveryAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStoreHouseWhereFrom;
        private System.Windows.Forms.ComboBox comboBoxStoreHouseDestination;
        private System.Windows.Forms.Label labelMainText;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.ComboBox comboBoxSelectedStoreHouseProducts;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.NumericUpDown numericUpDownDeliveryAmount;
        private System.Windows.Forms.Label labelWhereFromStock;
        private System.Windows.Forms.Label labelDestinationStock;
        private System.Windows.Forms.Label labelAmountOfWhereFromStock;
        private System.Windows.Forms.Label labelAmountOfDestinationStock;
        private System.Windows.Forms.Label labelMinimumTransferAmountText;
        private System.Windows.Forms.Label labelMinimumTransferAmountValue;
    }
}