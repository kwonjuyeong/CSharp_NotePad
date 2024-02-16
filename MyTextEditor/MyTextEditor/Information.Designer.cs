namespace MyTextEditor
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            okButton = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(57, 201);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "JuJu 개발 저장소";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(57, 216);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "버전 1.0";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(57, 282);
            label3.Name = "label3";
            label3.Size = new Size(298, 15);
            label3.TabIndex = 2;
            label3.Text = "직접 만들어보는 윈도우 메모장 클론 프로젝트입니다. ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(181, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(95, 172);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 304);
            label4.Name = "label4";
            label4.Size = new Size(290, 15);
            label4.TabIndex = 4;
            label4.Text = "지적 재산권은 없으니 맘대로 가져다 쓰셔도 됩니다. ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(111, 216);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 5;
            label5.Text = "(~2024/02/16)";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 175);
            panel1.TabIndex = 6;
            // 
            // okButton
            // 
            okButton.Location = new Point(364, 316);
            okButton.Name = "okButton";
            okButton.Size = new Size(80, 30);
            okButton.TabIndex = 7;
            okButton.Text = "확인";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("한컴 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label6.Location = new Point(57, 254);
            label6.Name = "label6";
            label6.Size = new Size(157, 19);
            label6.TabIndex = 8;
            label6.Text = "윈도우 메모장 프로젝트";
            // 
            // Information
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 361);
            Controls.Add(label6);
            Controls.Add(okButton);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Information";
            Text = "Information";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Button okButton;
        private Label label6;
    }
}