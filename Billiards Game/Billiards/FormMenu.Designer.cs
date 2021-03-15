namespace Billiards
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.button_start = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.правилоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ОбАвтореToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btComp = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(665, 334);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(196, 35);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Играть вдвоем";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            this.button_start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenu_KeyDown);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(665, 446);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(196, 35);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            this.button_exit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenu_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правилоToolStripMenuItem,
            this.ОбАвтореToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(873, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // правилоToolStripMenuItem
            // 
            this.правилоToolStripMenuItem.Name = "правилоToolStripMenuItem";
            this.правилоToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.правилоToolStripMenuItem.Text = "Правило";
            this.правилоToolStripMenuItem.Click += new System.EventHandler(this.правилоToolStripMenuItem_Click);
            // 
            // ОбАвтореToolStripMenuItem
            // 
            this.ОбАвтореToolStripMenuItem.Name = "ОбАвтореToolStripMenuItem";
            this.ОбАвтореToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.ОбАвтореToolStripMenuItem.Text = "Об авторе";
            this.ОбАвтореToolStripMenuItem.Click += new System.EventHandler(this.ОбАвтореToolStripMenuItem_Click);
            // 
            // btComp
            // 
            this.btComp.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btComp.Location = new System.Drawing.Point(665, 375);
            this.btComp.Name = "btComp";
            this.btComp.Size = new System.Drawing.Size(196, 35);
            this.btComp.TabIndex = 3;
            this.btComp.Text = "Играть с компьютером";
            this.btComp.UseVisualStyleBackColor = true;
            this.btComp.Click += new System.EventHandler(this.btComp_Click);
            this.btComp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenu_KeyDown);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Billiards.Properties.Resources.PhotoMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(873, 493);
            this.Controls.Add(this.btComp);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billiards";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenu_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem правилоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ОбАвтореToolStripMenuItem;
        private System.Windows.Forms.Button btComp;
    }
}

