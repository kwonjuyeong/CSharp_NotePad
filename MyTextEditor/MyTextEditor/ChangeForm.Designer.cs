namespace MyTextEditor
{
    partial class ChangeForm
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
            roundCheckBox = new CheckBox();
            caseCheckBox = new CheckBox();
            CancleButton = new Button();
            FindButton = new Button();
            textBoxToSearch = new TextBox();
            FindLabel = new Label();
            ChangeButton = new Button();
            AllChangeButton = new Button();
            textBoxToChange = new TextBox();
            ChangeLabel = new Label();
            SuspendLayout();
            // 
            // roundCheckBox
            // 
            roundCheckBox.AutoSize = true;
            roundCheckBox.Enabled = false;
            roundCheckBox.Location = new Point(20, 132);
            roundCheckBox.Name = "roundCheckBox";
            roundCheckBox.Size = new Size(105, 19);
            roundCheckBox.TabIndex = 12;
            roundCheckBox.Text = "주위에 배치(R)";
            roundCheckBox.UseVisualStyleBackColor = true;
            // 
            // caseCheckBox
            // 
            caseCheckBox.AutoSize = true;
            caseCheckBox.Location = new Point(20, 102);
            caseCheckBox.Name = "caseCheckBox";
            caseCheckBox.Size = new Size(123, 19);
            caseCheckBox.TabIndex = 11;
            caseCheckBox.Text = "대/소문자 구분(C)";
            caseCheckBox.UseVisualStyleBackColor = true;
            // 
            // CancleButton
            // 
            CancleButton.Location = new Point(320, 119);
            CancleButton.Name = "CancleButton";
            CancleButton.Size = new Size(100, 25);
            CancleButton.TabIndex = 10;
            CancleButton.Text = "취소";
            CancleButton.UseVisualStyleBackColor = true;
            // 
            // FindButton
            // 
            FindButton.Location = new Point(320, 21);
            FindButton.Name = "FindButton";
            FindButton.Size = new Size(100, 25);
            FindButton.TabIndex = 9;
            FindButton.Text = "다음 찾기(F)";
            FindButton.UseVisualStyleBackColor = true;
            // 
            // textBoxToSearch
            // 
            textBoxToSearch.Location = new Point(110, 21);
            textBoxToSearch.Name = "textBoxToSearch";
            textBoxToSearch.Size = new Size(200, 23);
            textBoxToSearch.TabIndex = 8;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Location = new Point(20, 26);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(83, 15);
            FindLabel.TabIndex = 7;
            FindLabel.Text = "찾을 내용(N) :";
            FindLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangeButton
            // 
            ChangeButton.Location = new Point(320, 54);
            ChangeButton.Name = "ChangeButton";
            ChangeButton.Size = new Size(100, 25);
            ChangeButton.TabIndex = 14;
            ChangeButton.Text = "바꾸기(R)";
            ChangeButton.UseVisualStyleBackColor = true;
            // 
            // AllChangeButton
            // 
            AllChangeButton.Location = new Point(320, 86);
            AllChangeButton.Name = "AllChangeButton";
            AllChangeButton.Size = new Size(100, 25);
            AllChangeButton.TabIndex = 15;
            AllChangeButton.Text = "모두 바꾸기(A)";
            AllChangeButton.UseVisualStyleBackColor = true;
            // 
            // textBoxToChange
            // 
            textBoxToChange.Location = new Point(110, 57);
            textBoxToChange.Name = "textBoxToChange";
            textBoxToChange.Size = new Size(200, 23);
            textBoxToChange.TabIndex = 17;
            // 
            // ChangeLabel
            // 
            ChangeLabel.AutoSize = true;
            ChangeLabel.Location = new Point(20, 62);
            ChangeLabel.Name = "ChangeLabel";
            ChangeLabel.Size = new Size(81, 15);
            ChangeLabel.TabIndex = 16;
            ChangeLabel.Text = "바꿀 내용(P) :";
            ChangeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 161);
            Controls.Add(textBoxToChange);
            Controls.Add(ChangeLabel);
            Controls.Add(AllChangeButton);
            Controls.Add(ChangeButton);
            Controls.Add(roundCheckBox);
            Controls.Add(caseCheckBox);
            Controls.Add(CancleButton);
            Controls.Add(FindButton);
            Controls.Add(textBoxToSearch);
            Controls.Add(FindLabel);
            Name = "ChangeForm";
            Text = "바꾸기";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox roundCheckBox;
        private CheckBox caseCheckBox;
        private Button CancleButton;
        private Button FindButton;
        private TextBox textBoxToSearch;
        private Label FindLabel;
        private Button ChangeButton;
        private Button AllChangeButton;
        private TextBox textBoxToChange;
        private Label ChangeLabel;
    }
}