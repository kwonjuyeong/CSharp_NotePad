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
    public partial class ChangeForm : Form
    {
        메모장 Memo;

        public ChangeForm(메모장 mainMemo)
        {
            Memo = mainMemo;
            InitializeComponent();
            textBoxToSearch.Text = Memo.lastSearchText;
            textBoxToChange.Text = Memo.lastChangeText;
            caseCheckBox.Checked = Memo.IsCase;
        }


        private void FindButton_Click(object sender, EventArgs e)
        {
            string searchText = textBoxToSearch.Text;
            bool isCase = caseCheckBox.Checked;

            // 대/소문자 구분 설정 적용
            RichTextBoxFinds options = isCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                Find(searchText, options);
            }
            else
            {
                MessageBox.Show("찾을 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Find(string searchText, RichTextBoxFinds options)
        {
            Memo.lastSearchText = searchText; // 마지막으로 찾은 문자열 저장
            
            int startIndex = Memo.MyTextArea.SelectionStart + Memo.MyTextArea.SelectionLength;
            int resultIndex = Memo.MyTextArea.Find(searchText, startIndex, options);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
            }
            else
            {
                MessageBox.Show($"'{searchText}'를 찾을 수 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Memo.MyTextArea.Focus();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            
            // 선택된 텍스트 바꾸기
            string searchText = textBoxToSearch.Text;
            string replaceText = textBoxToChange.Text;

            RichTextBoxFinds options = caseCheckBox.Checked ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;
            Find(searchText,options);

            Memo.lastChangeText = textBoxToChange.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                Memo.MyTextArea.SelectedText = replaceText;
                Memo.lastChangeText = replaceText;
            }
            else
            {
                MessageBox.Show("찾을 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Memo.MyTextArea.Focus();
        }

        private void AllChangeButton_Click(object sender, EventArgs e)
        {
            // 모든 텍스트 바꾸기
            string searchText = textBoxToSearch.Text;
            string replaceText = textBoxToChange.Text;
            bool isCase = caseCheckBox.Checked;
            Memo.lastChangeText = textBoxToChange.Text;

            // 대/소문자 구분 설정 적용
            RichTextBoxFinds options = isCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

            int currentIndex = 0;
            while (currentIndex < Memo.MyTextArea.TextLength)
            {
                int resultIndex = Memo.MyTextArea.Find(searchText, currentIndex, options);

                if (resultIndex != -1)
                {
                    Memo.MyTextArea.SelectedText = replaceText;
                    currentIndex = resultIndex + replaceText.Length;
                }
                else
                {
                    break;
                }
            }
            Memo.lastChangeText = replaceText;
            Memo.MyTextArea.Focus();
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 대/소문자 구분 체크박스 이벤트 핸들러
        private void CaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Memo.IsCase = caseCheckBox.Checked;
        }


    }
}
