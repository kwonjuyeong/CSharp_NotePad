using System.Data;

namespace MyTextEditor
{
  
    //찾기 폼
    public partial class FindForm : Form
    {
        메모장 Memo;

        public bool isSearchForward = true; // 찾는 방향 (기본값: 아래로)
        private bool isCaseSensitive = false; // 대/소문자 구분 여부
        private bool isSearchAround = false; // 주위에 배치 여부


        public FindForm(메모장 mainMemo)
        { 
            Memo = mainMemo;
            InitializeComponent();
            textBoxToSearch.Text = Memo.lastSearchText;
        }

        public void FindButton_Click(object sender, EventArgs e)
        {
            string searchText = textBoxToSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                Find(searchText);
            }
            else
            {
                MessageBox.Show("찾을 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Find(string searchText)
        {
            Memo.lastSearchText = searchText; // 마지막으로 찾은 문자열 저장

            if (isSearchForward)
                FindDown(searchText);
            else
                FindUp(searchText);
        }

        public void FindNext(string searchText)
        {
            if (isSearchForward)
                FindDown(searchText);
            else
                FindUp(searchText);

        }

        public void FindPrevious(string searchText)
        {
            if (isSearchForward)
                FindUp(searchText);
            else
                FindDown(searchText);
           
        }


        public void FindDown(string searchText) {


            int currentIndex = Memo.MyTextArea.SelectionStart + Memo.MyTextArea.SelectionLength;
            int resultIndex = Memo.MyTextArea.Find(searchText, currentIndex, RichTextBoxFinds.None);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
                Memo.MyTextArea.ScrollToCaret();
                Focus();
            }
            else
            {
                MessageBox.Show("더 이상 다음 발생이 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        public void FindUp(string searchText)
        {
            int currentIndex = Memo.MyTextArea.SelectionStart;
            int resultIndex = Memo.MyTextArea.Find(searchText, 0, currentIndex, RichTextBoxFinds.Reverse);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
                Memo.MyTextArea.ScrollToCaret();
                Focus();
            }
            else
            {
                MessageBox.Show("더 이상 이전 발생이 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
