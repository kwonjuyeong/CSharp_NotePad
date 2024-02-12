namespace MyTextEditor
{
    partial class FindForm
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
            FindLabel = new Label();
            textBoxToSearch = new TextBox();
            FindButton = new Button();
            cancleButton = new Button();
            caseCheckBox = new CheckBox();
            roundCheckBox = new CheckBox();
            directionGroupBox = new GroupBox();
            backwardRadioButton = new RadioButton();
            forwardRadioButton = new RadioButton();
            directionGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Location = new Point(10, 25);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(83, 15);
            FindLabel.TabIndex = 0;
            FindLabel.Text = "찾을 내용(N) :";
            FindLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxToSearch
            // 
            textBoxToSearch.Location = new Point(100, 20);
            textBoxToSearch.Name = "textBoxToSearch";
            textBoxToSearch.Size = new Size(200, 23);
            textBoxToSearch.TabIndex = 1;
            // 
            // FindButton
            // 
            FindButton.Location = new Point(310, 20);
            FindButton.Name = "FindButton";
            FindButton.Size = new Size(85, 30);
            FindButton.TabIndex = 2;
            FindButton.Text = "다음 찾기(F)";
            FindButton.UseVisualStyleBackColor = true;
            FindButton.Click += FindButton_Click;
            // 
            // cancleButton
            // 
            cancleButton.Location = new Point(310, 60);
            cancleButton.Name = "cancleButton";
            cancleButton.Size = new Size(85, 30);
            cancleButton.TabIndex = 3;
            cancleButton.Text = "취소";
            cancleButton.UseVisualStyleBackColor = true;
            cancleButton.Click += cancleButton_Click;
            // 
            // caseCheckBox
            // 
            caseCheckBox.AutoSize = true;
            caseCheckBox.Location = new Point(10, 60);
            caseCheckBox.Name = "caseCheckBox";
            caseCheckBox.Size = new Size(123, 19);
            caseCheckBox.TabIndex = 4;
            caseCheckBox.Text = "대/소문자 구분(C)";
            caseCheckBox.UseVisualStyleBackColor = true;
            caseCheckBox.CheckedChanged += caseCheckBox_CheckedChanged;
            // 
            // roundCheckBox
            // 
            roundCheckBox.AutoSize = true;
            roundCheckBox.Location = new Point(10, 90);
            roundCheckBox.Name = "roundCheckBox";
            roundCheckBox.Size = new Size(105, 19);
            roundCheckBox.TabIndex = 5;
            roundCheckBox.Text = "주위에 배치(R)";
            roundCheckBox.UseVisualStyleBackColor = true;
            roundCheckBox.CheckedChanged += roundCheckBox_CheckedChanged;
            // 
            // directionGroupBox
            // 
            directionGroupBox.Controls.Add(backwardRadioButton);
            directionGroupBox.Controls.Add(forwardRadioButton);
            directionGroupBox.Location = new Point(140, 50);
            directionGroupBox.Name = "directionGroupBox";
            directionGroupBox.Size = new Size(160, 60);
            directionGroupBox.TabIndex = 6;
            directionGroupBox.TabStop = false;
            directionGroupBox.Text = "방향";
            // 
            // backwardRadioButton
            // 
            backwardRadioButton.AutoSize = true;
            backwardRadioButton.Checked = true;
            backwardRadioButton.Location = new Point(80, 25);
            backwardRadioButton.Name = "backwardRadioButton";
            backwardRadioButton.Size = new Size(78, 19);
            backwardRadioButton.TabIndex = 1;
            backwardRadioButton.TabStop = true;
            backwardRadioButton.Text = "아래로(D)";
            backwardRadioButton.UseVisualStyleBackColor = true;
            backwardRadioButton.CheckedChanged += backwardRadioButton_CheckedChanged;
            // 
            // forwardRadioButton
            // 
            forwardRadioButton.AutoSize = true;
            forwardRadioButton.Location = new Point(10, 25);
            forwardRadioButton.Name = "forwardRadioButton";
            forwardRadioButton.Size = new Size(65, 19);
            forwardRadioButton.TabIndex = 0;
            forwardRadioButton.Text = "위로(U)";
            forwardRadioButton.UseVisualStyleBackColor = true;
            forwardRadioButton.CheckedChanged += forwardRadioButton_CheckedChanged;
            // 
            // FindForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 141);
            Controls.Add(directionGroupBox);
            Controls.Add(roundCheckBox);
            Controls.Add(caseCheckBox);
            Controls.Add(cancleButton);
            Controls.Add(FindButton);
            Controls.Add(textBoxToSearch);
            Controls.Add(FindLabel);
            Name = "FindForm";
            Text = "찾기";
            directionGroupBox.ResumeLayout(false);
            directionGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FindLabel;
        private TextBox textBoxToSearch;
        private Button FindButton;
        private Button cancleButton;
        private CheckBox caseCheckBox;
        private CheckBox roundCheckBox;
        private GroupBox directionGroupBox;
        private RadioButton backwardRadioButton;
        private RadioButton forwardRadioButton;
    }
}