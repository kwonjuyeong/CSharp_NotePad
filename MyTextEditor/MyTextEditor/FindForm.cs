using System.Data;

namespace MyTextEditor
{
  
    //찾기 폼
    public partial class FindForm : Form
    {
        메모장 Memo;
        public int lastSearchIndex = -1;
        public bool isSearchForward = true; // 찾는 방향 (기본값: 아래로)
     

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

        public void Find(string searchText, RichTextBoxFinds options)
        {
            Memo.lastSearchText = searchText; // 마지막으로 찾은 문자열 저장
           
            if (isSearchForward)
                FindDown(searchText, options);
            else
                FindUp(searchText, options);
            Memo.MyTextArea.Focus();
        }


        public void FindDown(string searchText, RichTextBoxFinds options) {

            int startIndex = lastSearchIndex == -1 ? 0 : lastSearchIndex + 1;
            int resultIndex = Memo.MyTextArea.Find(searchText, startIndex, options);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
                lastSearchIndex = resultIndex;
            }
            else
            {
                MessageBox.Show($"다음 {searchText}를 찾을 수 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }

        }

        public void FindUp(string searchText, RichTextBoxFinds options)
        {
            int startIndex = lastSearchIndex == -1 ? Memo.MyTextArea.Text.Length - 1 : lastSearchIndex - 1;
            int resultIndex = Memo.MyTextArea.Find(searchText, 0, startIndex, options | RichTextBoxFinds.Reverse);

            if (resultIndex != -1)
            {
                Memo.MyTextArea.Select(resultIndex, searchText.Length);
                lastSearchIndex = resultIndex;
            }
            else
            {
                MessageBox.Show($"이전 {searchText}를 찾을 수 없습니다.", "찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
