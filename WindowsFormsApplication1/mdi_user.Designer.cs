namespace WindowsFormsApplication1
{
    partial class mdi_user
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdi_user));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediaStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStudentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remainmediaReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MediaToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(868, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // MediaToolStripMenuItem
            // 
            this.MediaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMediaToolStripMenuItem,
            this.viewMediaToolStripMenuItem,
            this.issueMediaToolStripMenuItem,
            this.returnMediaToolStripMenuItem,
            this.MediaStockToolStripMenuItem});
            this.MediaToolStripMenuItem.Name = "MediaToolStripMenuItem";
            this.MediaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.MediaToolStripMenuItem.Text = "Media";
            // 
            // addNewMediaToolStripMenuItem
            // 
            this.addNewMediaToolStripMenuItem.Name = "addNewMediaToolStripMenuItem";
            this.addNewMediaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addNewMediaToolStripMenuItem.Text = "Add New Media";
            this.addNewMediaToolStripMenuItem.Click += new System.EventHandler(this.addNewMediaToolStripMenuItem_Click);
            // 
            // viewMediaToolStripMenuItem
            // 
            this.viewMediaToolStripMenuItem.Name = "viewMediaToolStripMenuItem";
            this.viewMediaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.viewMediaToolStripMenuItem.Text = "View Media";
            this.viewMediaToolStripMenuItem.Click += new System.EventHandler(this.viewMediaToolStripMenuItem_Click);
            // 
            // issueMediaToolStripMenuItem
            // 
            this.issueMediaToolStripMenuItem.Name = "issueMediaToolStripMenuItem";
            this.issueMediaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.issueMediaToolStripMenuItem.Text = "Issue Media";
            this.issueMediaToolStripMenuItem.Click += new System.EventHandler(this.issueMediaToolStripMenuItem_Click);
            // 
            // returnMediaToolStripMenuItem
            // 
            this.returnMediaToolStripMenuItem.Name = "returnMediaToolStripMenuItem";
            this.returnMediaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.returnMediaToolStripMenuItem.Text = "Return Media";
            this.returnMediaToolStripMenuItem.Click += new System.EventHandler(this.returnMediaToolStripMenuItem_Click);
            // 
            // MediaStockToolStripMenuItem
            // 
            this.MediaStockToolStripMenuItem.Name = "MediaStockToolStripMenuItem";
            this.MediaStockToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.MediaStockToolStripMenuItem.Text = "Media Stock";
            this.MediaStockToolStripMenuItem.Click += new System.EventHandler(this.MediaStockToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToolStripMenuItem,
            this.viewStudentInfoToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // addStudentToolStripMenuItem
            // 
            this.addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            this.addStudentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addStudentToolStripMenuItem.Text = "Add Student";
            this.addStudentToolStripMenuItem.Click += new System.EventHandler(this.addStudentToolStripMenuItem_Click);
            // 
            // viewStudentInfoToolStripMenuItem
            // 
            this.viewStudentInfoToolStripMenuItem.Name = "viewStudentInfoToolStripMenuItem";
            this.viewStudentInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewStudentInfoToolStripMenuItem.Text = "View Student Info";
            this.viewStudentInfoToolStripMenuItem.Click += new System.EventHandler(this.viewStudentInfoToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remainmediaReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // remainmediaReportToolStripMenuItem
            // 
            this.remainmediaReportToolStripMenuItem.Name = "remainmediaReportToolStripMenuItem";
            this.remainmediaReportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.remainmediaReportToolStripMenuItem.Text = "Media Report";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripDropDownButton1});
            this.statusStrip.Location = new System.Drawing.Point(0, 480);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(868, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 52F);
            this.button1.Location = new System.Drawing.Point(0, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 148);
            this.button1.TabIndex = 4;
            this.button1.Text = "LogOut";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // mdi_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(868, 502);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "mdi_user";
            this.Text = "MorrowSystems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStudentInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remainmediaReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MediaStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.Button button1;
    }
}



