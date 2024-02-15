using System.Data;

namespace MyTextEditor
{
  
    //찾기 폼
    public partial class FindForm : Form
    {
        메모장 Memo;

        public bool isSearchForward = true; // 찾는 방향 (기본값: 아래로)
        private bool isCaseSensitive = false; // 대/소문자 구분 여부
        public bool IsCase
        {
            get { return isCaseSensitive; }
            set { isCaseSensitive = value; }
        }



        private bool isSearchAround = false; // 주위에 배치 여부


        public FindForm(메모장 mainMemo)
        { 
            Memo = mainMemo;
            InitializeComponent();
            textBoxToSearch.Text = Memo.lastSearchText;
            caseCheckBox.Checked = Memo.IsCase;
        }

        public void FindButton_Click(object sender, EventArgs e)
        {
            string searchText = textBoxToSearch.Text;
            bool isCase = caseCheckBox.Checked;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                Find(searchText, isCase);
            }
            else
            {
                MessageBox.Show("찾을 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Find(string searchText, bool isCase)
        {
            Memo.lastSearchText = searchText; // 마지막으로 찾은 문자열 저장
            Memo.IsCase = isCase;

            // 대/소문자 구분 설정 적용
            RichTextBoxFinds options = isCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

            if (isSearchForward)
                FindDown(searchText, options);
            else
                FindUp(searchText, options);
            Memo.MyTextArea.Focus();
        }


        public void FindDown(string searchText, RichTextBoxFinds options) {

            int currentIndex = Memo.MyTextArea.SelectionStart + Memo.MyTextArea.SelectionLength;
            int resultIndex = Memo.MyTextArea.Find(searchText, currentIndex, options);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
                Memo.MyTextArea.ScrollToCaret();
                Memo.MyTextArea.Focus();
            }
            else
            {
                MessageBox.Show("더 이상 다음 발생이 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }


        }

        public void FindUp(string searchText, RichTextBoxFinds options)
        {
            int currentIndex = Memo.MyTextArea.SelectionStart;
            int resultIndex = Memo.MyTextArea.Find(searchText, 0, currentIndex, options | RichTextBoxFinds.Reverse);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
                Memo.MyTextArea.ScrollToCaret();
                Memo.MyTextArea.Focus();
            }
            else
            {
                MessageBox.Show("더 이상 이전 발생이 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //취소 버튼
        private void CancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 대/소문자 구분 체크박스 이벤트 핸들러
        private void CaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Memo.IsCase = caseCheckBox.Checked;
        }

        // 주위에 배치 체크박스 이벤트 핸들러
        private void RoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isSearchAround = roundCheckBox.Checked;
        }

        // 방향 설정 라디오 버튼 이벤트 핸들러
        private void BackwardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSearchForward = backwardRadioButton.Checked;
        }

        private void ForwardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSearchForward = !forwardRadioButton.Checked;
        }


    }

}
