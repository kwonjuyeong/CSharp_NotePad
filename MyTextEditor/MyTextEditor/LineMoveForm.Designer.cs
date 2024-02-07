namespace MyTextEditor
{
    partial class LineMoveForm
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
            LineNumLabel = new Label();
            textBoxToMove = new TextBox();
            moveButton = new Button();
            cancleButton = new Button();
            SuspendLayout();
            // 
            // LineNumLabel
            // 
            LineNumLabel.AutoSize = true;
            LineNumLabel.Location = new Point(10, 10);
            LineNumLabel.Name = "LineNumLabel";
            LineNumLabel.Size = new Size(68, 15);
            LineNumLabel.TabIndex = 0;
            LineNumLabel.Text = "줄 번호(L) :";
            // 
            // textBoxToMove
            // 
            textBoxToMove.Location = new Point(10, 40);
            textBoxToMove.Name = "textBoxToMove";
            textBoxToMove.Size = new Size(230, 23);
            textBoxToMove.TabIndex = 1;
            textBoxToMove.KeyPress += TextBoxToMove_KeyPress;
            // 
            // moveButton
            // 
            moveButton.Location = new Point(90, 80);
            moveButton.Name = "moveButton";
            moveButton.Size = new Size(75, 25);
            moveButton.TabIndex = 2;
            moveButton.Text = "이동";
            moveButton.UseVisualStyleBackColor = true;
            moveButton.Click += moveButton_Click;
            // 
            // cancleButton
            // 
            cancleButton.Location = new Point(170, 80);
            cancleButton.Name = "cancleButton";
            cancleButton.Size = new Size(75, 25);
            cancleButton.TabIndex = 3;
            cancleButton.Text = "취소";
            cancleButton.UseVisualStyleBackColor = true;
            cancleButton.Click += cancleButton_Click;
            // 
            // LineMoveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 121);
            Controls.Add(cancleButton);
            Controls.Add(moveButton);
            Controls.Add(textBoxToMove);
            Controls.Add(LineNumLabel);
            Name = "LineMoveForm";
            Text = "줄 이동";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LineNumLabel;
        private TextBox textBoxToMove;
        private Button moveButton;
        private Button cancleButton;
    }
}