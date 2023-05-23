namespace FightPigs.Main.View
{
    partial class sizeDialog
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
            this.OK = new System.Windows.Forms.Button();
            this.sizes = new System.Windows.Forms.GroupBox();
            this.bigSize = new System.Windows.Forms.RadioButton();
            this.mediumSize = new System.Windows.Forms.RadioButton();
            this.smallSize = new System.Windows.Forms.RadioButton();
            this.sizes.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(64, 91);
            this.OK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(85, 31);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // sizes
            // 
            this.sizes.Controls.Add(this.bigSize);
            this.sizes.Controls.Add(this.mediumSize);
            this.sizes.Controls.Add(this.smallSize);
            this.sizes.Location = new System.Drawing.Point(13, 6);
            this.sizes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sizes.Name = "sizes";
            this.sizes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sizes.Size = new System.Drawing.Size(189, 75);
            this.sizes.TabIndex = 1;
            this.sizes.TabStop = false;
            this.sizes.Text = "Válaszd ki a kívánt méretet!";
            // 
            // bigSize
            // 
            this.bigSize.AutoSize = true;
            this.bigSize.Location = new System.Drawing.Point(119, 40);
            this.bigSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bigSize.Name = "bigSize";
            this.bigSize.Size = new System.Drawing.Size(53, 24);
            this.bigSize.TabIndex = 2;
            this.bigSize.TabStop = true;
            this.bigSize.Text = "8x8";
            this.bigSize.UseVisualStyleBackColor = true;
            // 
            // mediumSize
            // 
            this.mediumSize.AutoSize = true;
            this.mediumSize.Checked = true;
            this.mediumSize.Location = new System.Drawing.Point(63, 40);
            this.mediumSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mediumSize.Name = "mediumSize";
            this.mediumSize.Size = new System.Drawing.Size(53, 24);
            this.mediumSize.TabIndex = 1;
            this.mediumSize.TabStop = true;
            this.mediumSize.Text = "6x6";
            this.mediumSize.UseVisualStyleBackColor = true;
            // 
            // smallSize
            // 
            this.smallSize.AutoSize = true;
            this.smallSize.Location = new System.Drawing.Point(7, 40);
            this.smallSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.smallSize.Name = "smallSize";
            this.smallSize.Size = new System.Drawing.Size(53, 24);
            this.smallSize.TabIndex = 0;
            this.smallSize.TabStop = true;
            this.smallSize.Text = "4x4";
            this.smallSize.UseVisualStyleBackColor = true;
            // 
            // sizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 135);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.sizes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "sizeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Méret";
            this.TopMost = true;
            this.sizes.ResumeLayout(false);
            this.sizes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton smallSize;
        private System.Windows.Forms.RadioButton bigSize;
        private System.Windows.Forms.RadioButton mediumSize;
        private System.Windows.Forms.GroupBox sizes;
    }
}