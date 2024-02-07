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

    //찾기 폼
    public partial class FindForm : Form
    {
        private RichTextBox mainTextBox;
        private string LastSearch;
        private bool isCaseSensitive = false; // 대/소문자 구분 여부
        private bool isSearchForward = true; // 찾는 방향 (기본값: 아래로)
        private bool isSearchAround = false; // 주위에 배치 여부

        public FindForm(RichTextBox textBox)
        {
            mainTextBox = textBox;
            InitializeComponent();
        }

        public void FindButton_Click(object sender, EventArgs e)
        {
            string searchText = textBoxToSearch.Text;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                LastSearch = searchText; // 마지막으로 입력한 텍스트 저장

                // 대/소문자 구분 설정 적용
                RichTextBoxFinds options = isCaseSensitive ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

                // 주위에 배치 설정 적용
                if (isSearchAround)
                {
                    options |= RichTextBoxFinds.WholeWord; // 전체 단어로 검색
                }

                int currentIndex = mainTextBox.SelectionStart;
                int resultIndex;

                if (isSearchForward)
                {
                    resultIndex = mainTextBox.Find(searchText, currentIndex, options);
                }
                else
                {
                    resultIndex = mainTextBox.Find(searchText, 0, currentIndex, options | RichTextBoxFinds.Reverse);
                }

                if (resultIndex != -1)
                {
                    // 결과가 찾아진 경우 선택하고 스크롤
                    mainTextBox.Select(resultIndex, searchText.Length);
                    mainTextBox.ScrollToCaret();
                    this.Focus();
                }
                else
                {
                    MessageBox.Show(isSearchForward ? "더 이전에 찾을 수 없습니다." : "더 이후에 찾을 수 없습니다.", isSearchForward ? "이전 찾기" : "다음 찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("찾을 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //취소 버튼
        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 대/소문자 구분 체크박스 이벤트 핸들러
        private void caseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isCaseSensitive = caseCheckBox.Checked;
        }

        // 주위에 배치 체크박스 이벤트 핸들러
        private void roundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isSearchAround = roundCheckBox.Checked;
        }

        // 방향 설정 라디오 버튼 이벤트 핸들러
        private void backwardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSearchForward = backwardRadioButton.Checked;
        }

        private void forwardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSearchForward = !forwardRadioButton.Checked;
        }


    }

}
