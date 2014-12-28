namespace Ultimate_Tic_Tac_Toe
{
    partial class Ultimate_Tic_Toc_Toe
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
            this.lblBilgisayar = new System.Windows.Forms.Label();
            this.lblYaris = new System.Windows.Forms.Label();
            this.lblBilgSonuc = new System.Windows.Forms.Label();
            this.lblYarisSonuc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBilgisayar
            // 
            this.lblBilgisayar.AutoSize = true;
            this.lblBilgisayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgisayar.Location = new System.Drawing.Point(20, 60);
            this.lblBilgisayar.Name = "lblBilgisayar";
            this.lblBilgisayar.Size = new System.Drawing.Size(116, 25);
            this.lblBilgisayar.TabIndex = 0;
            this.lblBilgisayar.Text = "Bilgisayar";
            // 
            // lblYaris
            // 
            this.lblYaris.AutoSize = true;
            this.lblYaris.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYaris.Location = new System.Drawing.Point(655, 60);
            this.lblYaris.Name = "lblYaris";
            this.lblYaris.Size = new System.Drawing.Size(116, 25);
            this.lblYaris.TabIndex = 1;
            this.lblYaris.Text = "Yarışmacı";
            // 
            // lblBilgSonuc
            // 
            this.lblBilgSonuc.AutoSize = true;
            this.lblBilgSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgSonuc.Location = new System.Drawing.Point(34, 144);
            this.lblBilgSonuc.Name = "lblBilgSonuc";
            this.lblBilgSonuc.Size = new System.Drawing.Size(0, 31);
            this.lblBilgSonuc.TabIndex = 2;
            // 
            // lblYarisSonuc
            // 
            this.lblYarisSonuc.AutoSize = true;
            this.lblYarisSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYarisSonuc.Location = new System.Drawing.Point(664, 144);
            this.lblYarisSonuc.Name = "lblYarisSonuc";
            this.lblYarisSonuc.Size = new System.Drawing.Size(0, 31);
            this.lblYarisSonuc.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Yeni Oyun";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ultimate_Tic_Toc_Toe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblYarisSonuc);
            this.Controls.Add(this.lblBilgSonuc);
            this.Controls.Add(this.lblYaris);
            this.Controls.Add(this.lblBilgisayar);
            this.Name = "Ultimate_Tic_Toc_Toe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate Tic Tac Toe";
            this.Load += new System.EventHandler(this.Ultimate_Tic_Toc_Toe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBilgisayar;
        private System.Windows.Forms.Label lblYaris;
        private System.Windows.Forms.Label lblBilgSonuc;
        private System.Windows.Forms.Label lblYarisSonuc;
        private System.Windows.Forms.Button button1;

    }
}

