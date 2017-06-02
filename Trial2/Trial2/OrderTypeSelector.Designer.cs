namespace Trial2
{
    partial class OrderTypeSelector
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
            this.WeddingOrderBTN = new System.Windows.Forms.Button();
            this.PromOrderBTN = new System.Windows.Forms.Button();
            this.SingleOrderBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WeddingOrderBTN
            // 
            this.WeddingOrderBTN.Location = new System.Drawing.Point(12, 152);
            this.WeddingOrderBTN.Name = "WeddingOrderBTN";
            this.WeddingOrderBTN.Size = new System.Drawing.Size(215, 94);
            this.WeddingOrderBTN.TabIndex = 0;
            this.WeddingOrderBTN.Text = "Wedding";
            this.WeddingOrderBTN.UseVisualStyleBackColor = true;
            // 
            // PromOrderBTN
            // 
            this.PromOrderBTN.Location = new System.Drawing.Point(233, 152);
            this.PromOrderBTN.Name = "PromOrderBTN";
            this.PromOrderBTN.Size = new System.Drawing.Size(215, 94);
            this.PromOrderBTN.TabIndex = 1;
            this.PromOrderBTN.Text = "Prom";
            this.PromOrderBTN.UseVisualStyleBackColor = true;
            // 
            // SingleOrderBTN
            // 
            this.SingleOrderBTN.Location = new System.Drawing.Point(454, 152);
            this.SingleOrderBTN.Name = "SingleOrderBTN";
            this.SingleOrderBTN.Size = new System.Drawing.Size(215, 94);
            this.SingleOrderBTN.TabIndex = 2;
            this.SingleOrderBTN.Text = "Single Order";
            this.SingleOrderBTN.UseVisualStyleBackColor = true;
            this.SingleOrderBTN.Click += new System.EventHandler(this.SingleOrderBTN_Click);
            // 
            // OrderTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 411);
            this.Controls.Add(this.SingleOrderBTN);
            this.Controls.Add(this.PromOrderBTN);
            this.Controls.Add(this.WeddingOrderBTN);
            this.Name = "OrderTypeSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Order Type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WeddingOrderBTN;
        private System.Windows.Forms.Button PromOrderBTN;
        private System.Windows.Forms.Button SingleOrderBTN;
    }
}