namespace Checker_osenok
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tableBox = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.go = new System.Windows.Forms.ToolStripButton();
            this.tipsPanel = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(966, 480);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(966, 480);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // tableBox
            // 
            this.tableBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBox.Location = new System.Drawing.Point(0, 25);
            this.tableBox.Name = "tableBox";
            this.tableBox.Size = new System.Drawing.Size(966, 480);
            this.tableBox.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.go,
            this.tipsPanel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // go
            // 
            this.go.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.go.Image = ((System.Drawing.Image)(resources.GetObject("go.Image")));
            this.go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(50, 22);
            this.go.Text = "Начать";
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // tipsPanel
            // 
            this.tipsPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tipsPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipsPanel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tipsPanel.Items.AddRange(new object[] {
            "Советы на 5",
            "Советы на 4",
            "Советы на 3"});
            this.tipsPanel.Name = "tipsPanel";
            this.tipsPanel.Size = new System.Drawing.Size(141, 25);
            this.tipsPanel.SelectedIndexChanged += new System.EventHandler(this.TipsPanel_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(966, 505);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tableBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Cheker_osenok";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tableBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridView tableBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton go;
        private System.Windows.Forms.ToolStripComboBox tipsPanel;
    }
}

