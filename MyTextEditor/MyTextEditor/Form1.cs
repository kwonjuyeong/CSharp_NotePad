using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace MyTextEditor
{
    public partial class 메모장 : Form
    {
        private FindDialog findDialog;
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        public 메모장()
        {
            InitializeComponent();
        }

        #region 파일 메뉴
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
            // 새 창을 만들기 위해 메모장의 복사본을 생성
            메모장 newMemo = new 메모장();
            // 새 창을 보여줌
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
                UpdateFormTitle();
                ControlFocusBack();
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

        //끝내기
        private void ExitToolTip_Click(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
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

            //폼 닫기
            Close();
        }
        #endregion




        #region 편집
        //복사(Ctrl+C)
        private void CopyTextToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.SelectionLength > 0)
            {
                MyTextArea.Copy();
            }

        }

        //붙여넣기(Ctrl+V)
        private void PasteTextToolTip_Click(object sender, EventArgs e)
        {
            MyTextArea.Paste();
        }

        //자르기(Ctrl+X)
        private void CutTextToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.SelectionLength > 0)
            {
                MyTextArea.Cut();
            }
        }

        //실행 취소(Ctrl+Z)
        private void DoCancleToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.CanUndo)
            {
                MyTextArea.Undo();
            }
        }

        //실행 복구(Ctrl+Y)
        private void RedoToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.CanRedo)
            {
                MyTextArea.Redo();
            }
        }

        //삭제(Delete)
        private void DeleteTextToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.SelectionLength > 0)
            {
                MyTextArea.SelectedText = string.Empty;
            }
        }

        //찾기(Ctrl+F)
        private void FindTextToolTip_Click(object sender, EventArgs e)
        {
            ShowFindDialog();
        }

        private void ShowFindDialog()
        {
            if (findDialog == null || findDialog.IsDisposed)
            {
                findDialog = new FindDialog(MyTextArea);
                findDialog.FindNextEvent += FindDialog_FindNextEvent;
                findDialog.Show();
            }
            else
            {
                findDialog.BringToFront();
            }
        }

        private void FindDialog_FindNextEvent(object sender, EventArgs e)
        {
            // FindDialog에서 발생한 이벤트를 처리
            FindNext();
        }

        private void FindNext()
        {
            if (findDialog != null)
            {
                int startIndex = MyTextArea.SelectionStart + MyTextArea.SelectionLength;

                int index = MyTextArea.Text.IndexOf(findDialog.SearchText, startIndex, StringComparison.CurrentCultureIgnoreCase);

                if (index != -1)
                {
                    MyTextArea.Select(index, findDialog.SearchText.Length);
                    MyTextArea.ScrollToCaret();
                }
                else
                {
                    MessageBox.Show("더 이상 찾을 문자열이 없습니다.", "찾기 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        //다음 찾기(F3)
        private void FindNextToolTip_Click(object sender, EventArgs e)
        {
        }

        //이전 찾기(SHIFT+F3)
        private void FindBeforeToolTip_Click(object sender, EventArgs e)
        {

        }

        //바꾸기(Ctrl+H)
        private void ChangeTextToolTip_Click(object sender, EventArgs e)
        {
        }


        //이동(Ctrl+G)
        private void MoveTextToolTip_Click(object sender, EventArgs e)
        {
        }

        //모두 선택(Ctrl+A)
        private void AllSelectTextToolTip_Click(object sender, EventArgs e)
        {
            MyTextArea.SelectAll();
        }


        //시간 입력(F5)
        private void TimeTextToolTip_Click(object sender, EventArgs e)
        {
            //현재 시간 추가
            MyTextArea.Text += DateTime.Now.ToString();
            ControlFocusBack();
        }
        #endregion


        #region 메소드
        // 파일 저장 메소드
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
                UpdateFormTitle(); // 저장 후 파일 이름 표시 갱신
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 저장 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 텍스트 변경 여부 확인 메소드
        private void MyTextArea_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
            UpdateFormTitle();
        }

        //파일 이름 변경 메소드
        private void UpdateFormTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "제목 없음" : Path.GetFileName(currentFilePath);
            this.Text = isTextChanged ? $"*{fileName}" : fileName;
        }

        // 프린트할 때 호출되는 이벤트 핸들러
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(MyTextArea.Text, font, Brushes.Black, 10, 10);
        }

        //커서 위치 이동(맨 뒤)
        private void ControlFocusBack()
        {
            //커서 맨 뒤로 이동
            MyTextArea.SelectionStart = MyTextArea.Text.Length;
            MyTextArea.SelectionLength = 0;
            MyTextArea.Focus();
        }


        private void 메모장_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 모든 폼이 닫히면 프로그램 종료
            if (Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
        }
        #endregion

    }


    public class FindDialog : Form
    {
        private Label findLabel;
        private RichTextBox textBoxToSearch;
        private Button findNextButton;
        private Button cancleButton;
        private 

        public event EventHandler FindNextEvent;

        public string SearchText => textBoxToSearch.Text;

        public FindDialog(RichTextBox richtextBox)
        {
            textBoxToSearch = richtextBox;
            InitializeUI();
        }

        private void InitializeUI()
        {
            findLabel = new Label();
            textBoxToSearch = new RichTextBox();
            findNextButton = new Button();
            cancleButton = new Button();

            this.Text = "찾기";
            this.Width = 400;
            this.Height = 200;

            findLabel.Text = "찾을 내용(N) :";
            findLabel.Location = new Point(10, 25);
            findLabel.AutoSize = true;


            //찾을 내용 TextBox
            textBoxToSearch.Height = 25;
            textBoxToSearch.Width = 200;
            textBoxToSearch.Location = new Point(80, 20);


            //다음 찾기 버튼 UI
            findNextButton.Text = "다음 찾기(F)";
            findNextButton.Height = 25;
            findNextButton.Width = 80;
            findNextButton.Location = new Point(290, 20);

            cancleButton.Text = "취소";
            cancleButton.Height = 25;
            cancleButton.Width = 80;
            cancleButton.Location = new Point(290, 60);
            

            // Add controls to the form
            Controls.Add(findLabel);
            Controls.Add(textBoxToSearch);
            Controls.Add(findNextButton);
            Controls.Add(cancleButton);

            // findNextButton 클릭 이벤트 등록
            findNextButton.Click += FindNextButton_Click;
        }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            FindNextEvent?.Invoke(this, EventArgs.Empty);
        }

    }



}





