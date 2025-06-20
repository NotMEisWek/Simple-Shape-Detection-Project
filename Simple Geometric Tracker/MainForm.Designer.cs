namespace Simple_Geometric_Tracker
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            gbVideo = new GroupBox();
            panel1 = new Panel();
            pbVideo = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            openVideoToolStripMenuItem = new ToolStripMenuItem();
            loadVideoToolStripMenuItem = new ToolStripMenuItem();
            selecLoadPicturToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            addShapeToolStripMenuItem = new ToolStripMenuItem();
            btnStartTracking = new MaterialSkin.Controls.MaterialButton();
            timer1 = new System.Windows.Forms.Timer(components);
            cbShape = new ComboBox();
            gbShapeSelect = new GroupBox();
            gbFrameRate = new GroupBox();
            txtFrameRate = new TextBox();
            btnApply = new MaterialSkin.Controls.MaterialButton();
            gbVideo.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbVideo).BeginInit();
            menuStrip1.SuspendLayout();
            gbShapeSelect.SuspendLayout();
            gbFrameRate.SuspendLayout();
            SuspendLayout();
            // 
            // gbVideo
            // 
            gbVideo.Controls.Add(panel1);
            gbVideo.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbVideo.Location = new Point(200, 29);
            gbVideo.Name = "gbVideo";
            gbVideo.Size = new Size(588, 426);
            gbVideo.TabIndex = 0;
            gbVideo.TabStop = false;
            gbVideo.Text = "Geo Tracker";
            // 
            // panel1
            // 
            panel1.Controls.Add(pbVideo);
            panel1.Location = new Point(6, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(576, 393);
            panel1.TabIndex = 0;
            // 
            // pbVideo
            // 
            pbVideo.Location = new Point(3, 3);
            pbVideo.Name = "pbVideo";
            pbVideo.Size = new Size(566, 383);
            pbVideo.TabIndex = 0;
            pbVideo.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { openVideoToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // openVideoToolStripMenuItem
            // 
            openVideoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadVideoToolStripMenuItem, selecLoadPicturToolStripMenuItem });
            openVideoToolStripMenuItem.Name = "openVideoToolStripMenuItem";
            openVideoToolStripMenuItem.Size = new Size(37, 20);
            openVideoToolStripMenuItem.Text = "File";
            // 
            // loadVideoToolStripMenuItem
            // 
            loadVideoToolStripMenuItem.Name = "loadVideoToolStripMenuItem";
            loadVideoToolStripMenuItem.Size = new Size(145, 22);
            loadVideoToolStripMenuItem.Text = "Select Video";
            loadVideoToolStripMenuItem.Click += loadVideoToolStripMenuItem_Click;
            // 
            // selecLoadPicturToolStripMenuItem
            // 
            selecLoadPicturToolStripMenuItem.Name = "selecLoadPicturToolStripMenuItem";
            selecLoadPicturToolStripMenuItem.Size = new Size(145, 22);
            selecLoadPicturToolStripMenuItem.Text = "Select Picture";
            selecLoadPicturToolStripMenuItem.Click += selecLoadPicturToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addShapeToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // addShapeToolStripMenuItem
            // 
            addShapeToolStripMenuItem.Name = "addShapeToolStripMenuItem";
            addShapeToolStripMenuItem.Size = new Size(180, 22);
            addShapeToolStripMenuItem.Text = "Add Shape";
            addShapeToolStripMenuItem.Click += addShapeToolStripMenuItem_Click;
            // 
            // btnStartTracking
            // 
            btnStartTracking.AutoSize = false;
            btnStartTracking.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStartTracking.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStartTracking.Depth = 0;
            btnStartTracking.HighEmphasis = true;
            btnStartTracking.Icon = null;
            btnStartTracking.Location = new Point(23, 335);
            btnStartTracking.Margin = new Padding(4, 6, 4, 6);
            btnStartTracking.MouseState = MaterialSkin.MouseState.HOVER;
            btnStartTracking.Name = "btnStartTracking";
            btnStartTracking.NoAccentTextColor = Color.Empty;
            btnStartTracking.Size = new Size(158, 36);
            btnStartTracking.TabIndex = 2;
            btnStartTracking.Text = "Start";
            btnStartTracking.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStartTracking.UseAccentColor = false;
            btnStartTracking.UseVisualStyleBackColor = true;
            btnStartTracking.Click += btnStartTracking_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // cbShape
            // 
            cbShape.FormattingEnabled = true;
            cbShape.Location = new Point(22, 43);
            cbShape.Name = "cbShape";
            cbShape.Size = new Size(112, 29);
            cbShape.TabIndex = 3;
            cbShape.Click += cbShape_Click;
            // 
            // gbShapeSelect
            // 
            gbShapeSelect.Controls.Add(cbShape);
            gbShapeSelect.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbShapeSelect.Location = new Point(23, 82);
            gbShapeSelect.Name = "gbShapeSelect";
            gbShapeSelect.Size = new Size(158, 98);
            gbShapeSelect.TabIndex = 4;
            gbShapeSelect.TabStop = false;
            gbShapeSelect.Text = "Shape Selection";
            // 
            // gbFrameRate
            // 
            gbFrameRate.Controls.Add(btnApply);
            gbFrameRate.Controls.Add(txtFrameRate);
            gbFrameRate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbFrameRate.Location = new Point(23, 207);
            gbFrameRate.Name = "gbFrameRate";
            gbFrameRate.Size = new Size(158, 107);
            gbFrameRate.TabIndex = 5;
            gbFrameRate.TabStop = false;
            gbFrameRate.Text = "Adjust Frame Rate";
            // 
            // txtFrameRate
            // 
            txtFrameRate.Location = new Point(22, 28);
            txtFrameRate.Name = "txtFrameRate";
            txtFrameRate.Size = new Size(112, 29);
            txtFrameRate.TabIndex = 0;
            // 
            // btnApply
            // 
            btnApply.AutoSize = false;
            btnApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnApply.Depth = 0;
            btnApply.HighEmphasis = true;
            btnApply.Icon = null;
            btnApply.Location = new Point(35, 66);
            btnApply.Margin = new Padding(4, 6, 4, 6);
            btnApply.MouseState = MaterialSkin.MouseState.HOVER;
            btnApply.Name = "btnApply";
            btnApply.NoAccentTextColor = Color.Empty;
            btnApply.Size = new Size(81, 32);
            btnApply.TabIndex = 1;
            btnApply.Text = "Apply";
            btnApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnApply.UseAccentColor = false;
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 482);
            Controls.Add(gbFrameRate);
            Controls.Add(gbShapeSelect);
            Controls.Add(btnStartTracking);
            Controls.Add(gbVideo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Simple Geometric Tracker";
            gbVideo.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbVideo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gbShapeSelect.ResumeLayout(false);
            gbFrameRate.ResumeLayout(false);
            gbFrameRate.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbVideo;
        private Panel panel1;
        private PictureBox pbVideo;
        private OpenFileDialog openFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem openVideoToolStripMenuItem;
        private ToolStripMenuItem loadVideoToolStripMenuItem;
        private ToolStripMenuItem selecLoadPicturToolStripMenuItem;
        private MaterialSkin.Controls.MaterialButton btnStartTracking;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem addShapeToolStripMenuItem;
        private ComboBox cbShape;
        private GroupBox gbShapeSelect;
        private GroupBox gbFrameRate;
        private TextBox txtFrameRate;
        private MaterialSkin.Controls.MaterialButton btnApply;
    }
}
