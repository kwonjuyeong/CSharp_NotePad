using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace MyTextEditor
{
    public partial class 메모장 : Form
    {
        private FindDialog findDialog;
        private MoveDialog moveDialog;
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
            // FormClosing 이벤트를 수동으로 호출하여 종료할 때의 동작을 수행
            메모장_FormClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
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
            ShowDialogs("find");
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
            ShowDialogs("move");
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

            if (MyTextArea.Text.Length > 0)
            {
                FindTextToolTip.Enabled = true;
                FindNextToolTip.Enabled = true;
                FindBeforeToolTip.Enabled = true;
            }
            else
            {
                FindTextToolTip.Enabled = false;
                FindNextToolTip.Enabled = false;
                FindBeforeToolTip.Enabled = false;
            }
        }

        private void MyTextArea_SelectionChanged(object sender, EventArgs e)
        {
            // 텍스트가 선택되었는지 여부를 확인하여 메뉴의 활성화 여부를 설정
            bool isTextSelected = MyTextArea.SelectionLength > 0;
            CutTextToolTip.Enabled = isTextSelected;
            CopyTextToolTip.Enabled = isTextSelected;
            DeleteTextToolTip.Enabled = isTextSelected;
        }

        //파일 이름 변경 메소드
        private void UpdateFormTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "제목 없음" : Path.GetFileName(currentFilePath);
            this.Text = isTextChanged ? $"*{fileName}" : fileName;
        }


        //커서 위치 이동(맨 뒤)
        private void ControlFocusBack()
        {
            //커서 맨 뒤로 이동
            MyTextArea.SelectionStart = MyTextArea.Text.Length;
            MyTextArea.SelectionLength = 0;
            MyTextArea.Focus();
        }

        // 프린트할 때 호출되는 이벤트 핸들러
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(MyTextArea.Text, font, Brushes.Black, 10, 10);
        }


        // 찾기 다이얼로그 표시
        private void ShowDialogs(string spec)
        {
            if (spec == "find")
            {
                if (findDialog == null || findDialog.IsDisposed)
                {
                    findDialog = new FindDialog(MyTextArea);
                    //findDialog.Show();
                    findDialog.Show(this);
                }
                else
                {
                    findDialog.BringToFront();
                }
            }
            else if (spec == "move")
            {
                if (moveDialog == null || moveDialog.IsDisposed)
                {
                    moveDialog = new MoveDialog(MyTextArea);
                    moveDialog.MoveEvent += MoveDialog_MoveEvent;
                    moveDialog.Show(this);
                }
                else
                {
                    moveDialog.BringToFront();
                }

            }
        }


        // 줄 이동 이벤트 핸들러
        private void MoveDialog_MoveEvent(object sender, EventArgs e)
        {
            // MoveDialog에서 줄 이동 버튼을 클릭하면 호출되는 이벤트 핸들러
            MoveDialog moveDialog = sender as MoveDialog;
            if (moveDialog != null)
            {
                // 줄 이동 처리
                int targetLine = moveDialog.TargetLine;
                if (targetLine >= 1 && targetLine <= MyTextArea.Lines.Length)
                {
                    // 해당 줄로 커서 이동
                    MyTextArea.SelectionStart = MyTextArea.GetFirstCharIndexFromLine(targetLine - 1);
                    MyTextArea.ScrollToCaret();
                    MyTextArea.Focus();
                    moveDialog.Close();
                }
                else
                {
                    // 유효하지 않은 줄 번호일 경우 메시지 표시
                    MessageBox.Show("유효하지 않은 줄 번호입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion


        private void 메모장_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTextChanged && MyTextArea.Text.Length > 0)
            {
                DialogResult result = MessageBox.Show("변경된 내용을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // 취소 선택 시 창을 닫지 않음
                }
            }

            //다이얼로그가 열려있는 경우 닫기
            if (findDialog != null && !findDialog.IsDisposed)
            {
                findDialog.Close();
            }
            else if (moveDialog != null && !moveDialog.IsDisposed)
            {
                moveDialog.Close();
            }

        }

        private void 메모장_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 현재 열려있는 폼이 없으면 프로그램 종료
            if (Application.OpenForms.Count == 0)
            {     
                Application.Exit();
            }
        }

    }


    //찾기 폼
    public class FindDialog : Form
    {
        private Label findLabel;
        private RichTextBox textBoxToSearch;
        private Button findNextButton;
        private Button cancleButton;
        private CheckBox caseSensitiveCheckBox;
        private CheckBox roundCheckBox;
        private GroupBox directionGroupBox;
        private RadioButton forwardRadioButton;
        private RadioButton backwardRadioButton;

        

        public event EventHandler FindNextEvent;

        public string SearchText => textBoxToSearch.Text;
        public bool CaseSensitive => caseSensitiveCheckBox.Checked;
        public bool SearchForward => forwardRadioButton.Checked;

        public FindDialog(RichTextBox richtextBox)
        {
            textBoxToSearch = richtextBox;
            InitializeUI();
            this.Text = "찾기";
            this.Width = 430;
            this.Height = 180;
        }

        private void InitializeUI()
        {
            findLabel = new Label();
            textBoxToSearch = new RichTextBox();
            findNextButton = new Button();
            cancleButton = new Button();
            caseSensitiveCheckBox = new CheckBox();
            roundCheckBox = new CheckBox();
            directionGroupBox = new GroupBox();
            forwardRadioButton = new RadioButton();
            backwardRadioButton = new RadioButton();

            //라벨
            findLabel.Text = "찾을 내용(N) :";
            findLabel.Location = new Point(10, 25);
            findLabel.AutoSize = true;

            //찾을 내용 TextBox
            textBoxToSearch.Height = 25;
            textBoxToSearch.Width = 200;
            textBoxToSearch.Location = new Point(100, 20);


            //다음 찾기 버튼 UI
            findNextButton.Text = "다음 찾기(F)";
            findNextButton.Height = 25;
            findNextButton.Width = 80;
            findNextButton.Location = new Point(310, 20);
            findNextButton.Click += FindNextButton_Click;

            //취소 버튼 UI
            cancleButton.Text = "취소";
            cancleButton.Height = 25;
            cancleButton.Width = 80;
            cancleButton.Location = new Point(310, 60);
            cancleButton.Click += CancelButton_Click;

            //대/소문자 구분 UI
            caseSensitiveCheckBox.Text = "대/소문자 구분(C)";
            caseSensitiveCheckBox.Location = new Point(10, 60);
            caseSensitiveCheckBox.AutoSize = true;

            //주위에 배치(R)
            roundCheckBox.Text = "주위에 배치(R)";
            roundCheckBox.Location = new Point(10, 90);
            roundCheckBox.AutoSize = true;


            //찾기 방향
            directionGroupBox.Text = "방향";
            directionGroupBox.Location = new Point(140, 50);
            directionGroupBox.Size = new Size(160, 60);

            // 찾기 방향 라디오 버튼
            forwardRadioButton.Text = "위로(U)";
            forwardRadioButton.Location = new Point(10, 20);
            forwardRadioButton.AutoSize = true;

            backwardRadioButton.Text = "아래로(D)";
            backwardRadioButton.Location = new Point(80, 20);
            backwardRadioButton.Checked = true;
            backwardRadioButton.AutoSize = true;

           
            // 방향 그룹박스에 라디오 버튼 추가
            directionGroupBox.Controls.Add(forwardRadioButton);
            directionGroupBox.Controls.Add(backwardRadioButton);

            // Add controls to the form
            Controls.Add(findLabel);
            Controls.Add(textBoxToSearch);
            Controls.Add(findNextButton);
            Controls.Add(cancleButton);
            Controls.Add(caseSensitiveCheckBox);
            Controls.Add(roundCheckBox);
            Controls.Add(directionGroupBox);
        }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            FindNextEvent?.Invoke(this, EventArgs.Empty);


        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // 취소 버튼 클릭 시 폼 닫기
            this.Close();
        }
    }

    //이동 폼
    public class MoveDialog : Form
    {
        private Label findLabel;
        private RichTextBox textBoxToMove;
        private Button moveButton;
        private Button cancleButton;

        public event EventHandler MoveEvent;
        public int TargetLine => int.Parse(textBoxToMove.Text);
        public string MoveText => textBoxToMove.Text;
        
        public MoveDialog(RichTextBox richtextBox)
        {
            textBoxToMove = richtextBox;
            InitializeUI();
            this.Text = "줄 이동";
            this.Width = 270;
            this.Height = 160;
        }

        private void InitializeUI()
        {
            findLabel = new Label();
            textBoxToMove = new RichTextBox();
            moveButton = new Button();
            cancleButton = new Button();

            //라벨
            findLabel.Text = "줄 번호(L) :";
            findLabel.Location = new Point(10, 10);
            findLabel.AutoSize = true;

            //찾을 내용 TextBox
            textBoxToMove.Height = 30;
            textBoxToMove.Width = 230;
            textBoxToMove.Location = new Point(10, 40);
            textBoxToMove.KeyPress += TextBoxToMove_KeyPress;

            //이동 버튼
            moveButton.Text = "이동";
            moveButton.Height = 25;
            moveButton.Width = 70;
            moveButton.Location = new Point(90, 80);
            moveButton.Click += MoveButton_Click;

            //취소 버튼
            cancleButton.Text = "취소";
            cancleButton.Height = 25;
            cancleButton.Width = 70;
            cancleButton.Location = new Point(170, 80);
            cancleButton.Click += CancelButton_Click;

            // Add controls to the form
            Controls.Add(findLabel);
            Controls.Add(textBoxToMove);
            Controls.Add(moveButton);
            Controls.Add(cancleButton);
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            MoveEvent?.Invoke(this, EventArgs.Empty);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // 취소 버튼 클릭 시 폼 닫기
            this.Close();
        }

        // TextBox 입력 제한 - 숫자만 입력 가능하도록
        private void TextBoxToMove_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }

}

