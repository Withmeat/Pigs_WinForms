namespace FightPigs.Main.View
{
    partial class pigsView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.healthBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.canvas = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.saveGame,
            this.loadGame});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGame.Size = new System.Drawing.Size(224, 26);
            this.newGame.Text = "New Game";
            // 
            // saveGame
            // 
            this.saveGame.Name = "saveGame";
            this.saveGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveGame.Size = new System.Drawing.Size(224, 26);
            this.saveGame.Text = "Save Game";
            // 
            // loadGame
            // 
            this.loadGame.Name = "loadGame";
            this.loadGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadGame.Size = new System.Drawing.Size(224, 26);
            this.loadGame.Text = "Load Game";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.healthBar});
            this.statusBar.Location = new System.Drawing.Point(0, 775);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 26);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "Jelenleg a x játékos van soron.";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(215, 20);
            this.statusLabel.Text = "Jelenleg az x játékos van soron.";
            // 
            // healthBar
            // 
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(570, 20);
            this.healthBar.Spring = true;
            this.healthBar.Text = "Életerő";
            this.healthBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 30);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(800, 745);
            this.canvas.TabIndex = 2;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "pigSave.pig";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "pigSave.pig";
            // 
            // pigsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 801);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "pigsView";
            this.Text = "Pigs";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGame;
        private ToolStripMenuItem saveGame;
        private ToolStripMenuItem loadGame;
        private StatusStrip statusBar;
        private Panel canvas;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel healthBar;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
    }
}