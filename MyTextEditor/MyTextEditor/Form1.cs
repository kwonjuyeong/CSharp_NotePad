using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace MyTextEditor
{
    public partial class 메모장 : Form
    {

        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        public 메모장()
        {
            InitializeComponent();
        }

        #region 파일
        // 새 파일(Ctrl+N)
        private void NewFileToolTip_Click(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                // 파일이 변경되었을 경우 저장 여부 확인
                DialogResult result = MessageBox.Show("변경된 내용을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 저장
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    // 취소
                    return;
                }
            }

            // 새 파일 초기화
            MyTextArea.Text = string.Empty;
            currentFilePath = string.Empty;
            isTextChanged = false;
        }

        //새창(Ctrl+Shift+N)
        private void NewMemoToolTip_Click(object sender, EventArgs e)
        {
            // 새 창을 만들기 위해 Form1의 복사본을 생성
            메모장 newMemo = new 메모장();
            newMemo.Show();
        }

        //열기(Ctrl+O)
        private void OpenToolTip_Click(object sender, EventArgs e)
        {
            //현재 메모장에 수정이 있으면 저장 여부 후 열기 작업 진행
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("변경된 내용을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            //OpenFileDialog 호출(.txt text 파일만 열기)
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                MyTextArea.Text = File.ReadAllText(currentFilePath);
                isTextChanged = false;
            }
        }

        // 저장(Ctrl+S)
        private void SaveToolTip_Click(object sender, EventArgs e)
        {
            SaveFile();
        }


        //다른 이름으로 저장(Ctrl+Shift+S)
        private void DnameSaveToolTip_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                SaveFile();
            }

        }

        //페이지 설정
        private void PageSettingToolTip_Click(object sender, EventArgs e)
        {

        }


        //인쇄(Ctrl+P)
        private void PrintToolTip_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = new PrintDocument();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                printDialog.Document.Print();
            }

        }
        #endregion





        #region 편집
        //시간 입력(F5)
        private void TimeTextToolTip_Click(object sender, EventArgs e)
        {
            //현재 시간 추가
            MyTextArea.Text += DateTime.Now.ToString();
            //커서 맨 뒤로 이동
            MyTextArea.SelectionStart = MyTextArea.Text.Length;
            MyTextArea.SelectionLength = 0;
            MyTextArea.Focus();
        }

        #endregion


        #region 메소드들
        // 실제 파일 저장 로직
        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                // 파일 경로가 없는 경우 SaveFileDialog 표시
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return; // 사용자가 취소한 경우 저장 중단
                }
            }

            try
            {
                // 텍스트 에디터의 내용을 파일에 저장
                File.WriteAllText(currentFilePath, MyTextArea.Text);
                isTextChanged = false; // 저장 후 변경되지 않은 상태로 표시
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 저장 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 텍스트 에디터 내용 변경 여부 확인
        private void MyTextArea_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }


        // 프린트할 때 호출되는 이벤트 핸들러
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(MyTextArea.Text, font, Brushes.Black, 10, 10);
        }
        #endregion







    }
}
