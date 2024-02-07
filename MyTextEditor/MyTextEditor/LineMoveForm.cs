using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextEditor
{
    //줄 이동 폼
    public partial class LineMoveForm : Form
    {
        private RichTextBox mainTextBox;
        public LineMoveForm(RichTextBox textBox)
        {
            mainTextBox = textBox;
            InitializeComponent();
        }

        // TextBox 입력 제한 - 숫자만 입력 가능하도록
        private void TextBoxToMove_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void moveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxToMove.Text))
            {
                int lineNumber = int.Parse(textBoxToMove.Text);
                MoveToLine(lineNumber);
            }
            else
            {
                MessageBox.Show("이동할 줄 번호를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MoveToLine(int lineNumber)
        {
            // 입력된 줄 번호가 유효한 범위인지 확인
            if (lineNumber >= 1 && lineNumber <= mainTextBox.Lines.Length)
            {
                // 해당 줄로 커서 이동
                mainTextBox.SelectionStart = mainTextBox.GetFirstCharIndexFromLine(lineNumber - 1);
                mainTextBox.ScrollToCaret();
                mainTextBox.Focus();
                this.Close(); // 이동 완료 후 폼 닫기
            }
            else
            {
                MessageBox.Show("유효하지 않은 줄 번호입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
