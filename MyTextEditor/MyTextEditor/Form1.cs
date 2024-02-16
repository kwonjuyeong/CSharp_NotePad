using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MyTextEditor
{
    public partial class 메모장 : Form
    {
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        private FindForm findDialog;
        public string lastSearchText = string.Empty;
        public bool IsCase = false;
        private LineMoveForm moveDialog;


        private Font DefaultFont;

        public 메모장()
        {
            InitializeComponent();
            DefaultFont = MyTextArea.Font;
        }

        #region 1. 파일 메뉴

        // 새 파일(Ctrl+N)
        private void NewFileToolTip_Click(object sender, EventArgs e)
        {
            AskSave();
            MyTextArea.Text = string.Empty;
            isTextChanged = false;
        }

        //새창(Ctrl+Shift+N)
        private void NewMemoToolTip_Click(object sender, EventArgs e)
        {
            메모장 newMemo = new 메모장();
            newMemo.Show();
        }

        //열기(Ctrl+O)
        private void OpenToolTip_Click(object sender, EventArgs e)
        {
            //현재 메모장에 수정이 있으면 저장 여부 후 열기 작업 진행
            AskSave();
            OpenFileDialog();
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
            CallPrintDialog();
        }

        //끝내기
        private void ExitToolTip_Click(object sender, EventArgs e)
        {
            // FormClosing 이벤트를 수동으로 호출하여 종료할 때의 동작을 수행
            메모장_FormClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }
        #endregion

        #region 2. 편집 메뉴

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
            if (!string.IsNullOrEmpty(lastSearchText))
            {
                RichTextBoxFinds options = IsCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;
                findDialog.FindDown(lastSearchText, options);
            }
            else
            {
                ShowDialogs("find");
            }
        }

        //이전 찾기(SHIFT+F3)
        private void FindBeforeToolTip_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastSearchText))
            {
                RichTextBoxFinds options = IsCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;
                findDialog.FindUp(lastSearchText, options);
            }
            else
            {
                ShowDialogs("find");
            }
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
            MyTextArea.Text += DateTime.Now.ToString();
            ControlFocusBack();
        }
        #endregion

        #region 3. 서식 메뉴
        //자동 줄바꿈
        private void AutoLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AutoLineToolStripMenuItem.Checked == false)
            {
                AutoLineToolStripMenuItem.Checked = true;
                MyTextArea.WordWrap = true;
            }
            else
            {
                AutoLineToolStripMenuItem.Checked = false;
                MyTextArea.WordWrap = false;
            }

        }

        //글꼴
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                MyTextArea.Font = fontDialog.Font;
              
                DefaultFont = MyTextArea.Font;
            }
        }
        #endregion


        #region 4. 보기 메뉴
        // 확대하기
        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyTextArea.ZoomFactor < 64) // 최대 값은 64
            {
                MyTextArea.ZoomFactor += 0.1f; // 조절 가능한 값은 1.0f까지
            }
        }

        // 축소하기
        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyTextArea.ZoomFactor > 0.2f) // 최소 값은 0.2f
            {
                MyTextArea.ZoomFactor -= 0.1f; // 조절 가능한 값은 1.0f까지
            }
        }

        // 기본값으로
        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTextArea.ZoomFactor = 1;
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

        // 텍스트 변경 확인/제목 변경/메뉴 활성화
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

        //저장 여부 물어보기
        private void AskSave()
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
                currentFilePath = string.Empty;
            }
            UpdateFormTitle();

        }

        //파일 이름 변경 메소드
        private void UpdateFormTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "제목 없음" : Path.GetFileName(currentFilePath);
            this.Text = isTextChanged ? $"*{fileName}" : fileName;
        }

        //파일 열기
        private void OpenFileDialog()
        {
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

        //인쇄
        private void CallPrintDialog()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = new PrintDocument();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                printDialog.Document.Print();
            }
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


        // 찾기, 줄 이동 다이얼로그 호출
        private void ShowDialogs(string spec)
        {
            if (spec == "find")
            {
                if (findDialog == null || findDialog.IsDisposed)
                {
                    findDialog = new FindForm(this);
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
                    moveDialog = new LineMoveForm(MyTextArea);
                    moveDialog.Show(this);
                }
                else
                {
                    moveDialog.BringToFront();
                }

            }
        }

        private void 메모장_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    if (MyTextArea.ZoomFactor < 64)
                    {
                        MyTextArea.ZoomFactor += 0.1f;
                    }

                }
                else if (e.Delta < 0)
                {
                    if (MyTextArea.ZoomFactor > 0.2f)
                    {
                        MyTextArea.ZoomFactor -= 0.1f;
                    }

                }
            }
        }

        #endregion

        #region 나머지 이벤트
        //텍스트 선택 시 메뉴 활성화
        private void MyTextArea_SelectionChanged(object sender, EventArgs e)
        {
            bool isTextSelected = MyTextArea.SelectionLength > 0;
            CutTextToolTip.Enabled = isTextSelected;
            CopyTextToolTip.Enabled = isTextSelected;
            DeleteTextToolTip.Enabled = isTextSelected;
        }

        //폼 종료 이벤트
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
        #endregion


    }

}

