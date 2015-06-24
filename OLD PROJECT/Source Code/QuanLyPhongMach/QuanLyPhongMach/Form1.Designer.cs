namespace QuanLyPhongMach
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thaoTácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bcntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemBảngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thaoTácToolStripMenuItem,
            this.xemBảngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(457, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thaoTácToolStripMenuItem
            // 
            this.thaoTácToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnToolStripMenuItem,
            this.pkToolStripMenuItem,
            this.hdToolStripMenuItem,
            this.ntToolStripMenuItem,
            this.dsToolStripMenuItem,
            this.bcToolStripMenuItem,
            this.bctToolStripMenuItem,
            this.bcntToolStripMenuItem});
            this.thaoTácToolStripMenuItem.Name = "thaoTácToolStripMenuItem";
            this.thaoTácToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.thaoTácToolStripMenuItem.Text = "Thao tác";
            // 
            // bnToolStripMenuItem
            // 
            this.bnToolStripMenuItem.Name = "bnToolStripMenuItem";
            this.bnToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.bnToolStripMenuItem.Text = "Bệnh nhân";
            this.bnToolStripMenuItem.Click += new System.EventHandler(this.bnToolStripMenuItem_Click);
            // 
            // pkToolStripMenuItem
            // 
            this.pkToolStripMenuItem.Name = "pkToolStripMenuItem";
            this.pkToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.pkToolStripMenuItem.Text = "Phiếu khám";
            this.pkToolStripMenuItem.Click += new System.EventHandler(this.pkToolStripMenuItem_Click);
            // 
            // hdToolStripMenuItem
            // 
            this.hdToolStripMenuItem.Name = "hdToolStripMenuItem";
            this.hdToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.hdToolStripMenuItem.Text = "Hóa đơn";
            this.hdToolStripMenuItem.Click += new System.EventHandler(this.hdToolStripMenuItem_Click);
            // 
            // ntToolStripMenuItem
            // 
            this.ntToolStripMenuItem.Name = "ntToolStripMenuItem";
            this.ntToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ntToolStripMenuItem.Text = "Nhập thuốc";
            this.ntToolStripMenuItem.Click += new System.EventHandler(this.ntToolStripMenuItem_Click);
            // 
            // dsToolStripMenuItem
            // 
            this.dsToolStripMenuItem.Name = "dsToolStripMenuItem";
            this.dsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.dsToolStripMenuItem.Text = "Danh sách bệnh nhân";
            this.dsToolStripMenuItem.Click += new System.EventHandler(this.dsToolStripMenuItem_Click);
            // 
            // bcToolStripMenuItem
            // 
            this.bcToolStripMenuItem.Name = "bcToolStripMenuItem";
            this.bcToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.bcToolStripMenuItem.Text = "Báo cáo doanh thu";
            this.bcToolStripMenuItem.Click += new System.EventHandler(this.bcToolStripMenuItem_Click);
            // 
            // bctToolStripMenuItem
            // 
            this.bctToolStripMenuItem.Name = "bctToolStripMenuItem";
            this.bctToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.bctToolStripMenuItem.Text = "Báo cáo sử dụng thuốc";
            this.bctToolStripMenuItem.Click += new System.EventHandler(this.bctToolStripMenuItem_Click);
            // 
            // bcntToolStripMenuItem
            // 
            this.bcntToolStripMenuItem.Name = "bcntToolStripMenuItem";
            this.bcntToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.bcntToolStripMenuItem.Text = "Báo cáo nhập thuốc";
            this.bcntToolStripMenuItem.Click += new System.EventHandler(this.bcntToolStripMenuItem_Click);
            // 
            // xemBảngToolStripMenuItem
            // 
            this.xemBảngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qdToolStripMenuItem});
            this.xemBảngToolStripMenuItem.Name = "xemBảngToolStripMenuItem";
            this.xemBảngToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.xemBảngToolStripMenuItem.Text = "Xem bảng";
            // 
            // qdToolStripMenuItem
            // 
            this.qdToolStripMenuItem.Name = "qdToolStripMenuItem";
            this.qdToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.qdToolStripMenuItem.Text = "Quy định";
            this.qdToolStripMenuItem.Click += new System.EventHandler(this.qdToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 185);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Quản lý phòng mạch";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thaoTácToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemBảngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bcntToolStripMenuItem;
    }
}

