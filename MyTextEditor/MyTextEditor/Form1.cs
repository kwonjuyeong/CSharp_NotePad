using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MyTextEditor
{
    public partial class 메모장 : Form
    {
        #region 전역 변수
        //File 변수
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        //찾기 폼 변수
        private FindForm findDialog;
        public string lastSearchText = string.Empty;
        public bool IsCase = false;

        //바꾸기 폼 변수
        private ChangeForm changeDialog;
        public string lastChangeText = string.Empty;

        //줄 바꿈, 메모장 정보 변수
        private LineMoveForm moveDialog;
        private Information infoDialog;

        private PageSettings pageSetting = new PageSettings();
        private PrinterSettings printerSetting = new PrinterSettings();

        private int zoomLevel = 10;
        #endregion

        public 메모장()
        {
            InitializeComponent();
            MyTextArea.MouseWheel += MyTextArea_MouseWheel;
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
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PageSettings = pageSetting;
            pageSetupDialog.PrinterSettings = printerSetting;
            pageSetupDialog.AllowPrinter = true;
            pageSetupDialog.AllowOrientation = true;
            pageSetupDialog.EnableMetric = true; //인치 - 밀리미터 문제

            // 페이지 설정 다이얼로그가 닫힐 때 이벤트 처리
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                pageSetting = pageSetupDialog.PageSettings;
            }

        }

        //인쇄(Ctrl+P)
        private void PrintToolTip_Click(object sender, EventArgs e)
        {
            ShowDialogs("print");
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
            FindNextPrev("down");
        }

        //이전 찾기(SHIFT+F3)
        private void FindBeforeToolTip_Click(object sender, EventArgs e)
        {
            FindNextPrev("up");
        }

        //바꾸기(Ctrl+H)
        private void ChangeTextToolTip_Click(object sender, EventArgs e)
        {
            ShowDialogs("change");
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
            ShowDialogs("font");
        }
        #endregion

        #region 4. 보기 메뉴
        // 확대하기
        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        // 축소하기
        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        // 기본값으로
        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTextArea.ZoomFactor = 1;
            zoomLevel = 10;
            UpdateStatusBar();
        }


        //상태 표시줄
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StatusBarToolStripMenuItem.Checked == false)
            {
                StatusBarToolStripMenuItem.Checked = true;
                statusStrip1.Visible = true;
            }
            else
            {
                StatusBarToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
            }

        }
        #endregion

        #region 5. 도움말 메뉴
        //도움말
        private void QAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start https://kjy1ho.tistory.com/category/%5BC%23%20%26%20C%2B%2B%5D/%5BC%23%20%EC%9C%88%ED%8F%BC%5D%20%ED%98%BC%EC%9E%90%ED%95%B4%EB%B3%B4%EB%8A%94%20%EC%9C%88%EB%8F%84%EC%9A%B0%20%EB%A9%94%EB%AA%A8%EC%9E%A5%20%EB%A7%8C%EB%93%A4%EA%B8%B0",
                WindowStyle = ProcessWindowStyle.Hidden
            });

        }

        //메모장 정보
        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogs("info");
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
            else if(spec == "change")
            {
                if (changeDialog == null || changeDialog.IsDisposed)
                {
                    changeDialog = new ChangeForm(this);
                    changeDialog.Show(this);
                }
                else
                {
                    changeDialog.BringToFront();
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
            else if (spec == "info")
            {
                infoDialog = new Information();
                infoDialog.ShowDialog();
            }
            else if (spec == "print")
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = new PrintDocument();

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDialog.Document.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                    printDialog.Document.Print();
                }
            }
            else if (spec == "font")
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    MyTextArea.Font = fontDialog.Font;
                }
            }
        }


        // 프린트할 때 호출되는 이벤트 핸들러
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(MyTextArea.Text, font, Brushes.Black, 10, 10);
        }

        private void MyTextArea_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.Delta > 0)
                {
                    ZoomIn();
                }
                else
                {
                    ZoomOut();
                }
            }
        }

        //확대 메소드
        private void ZoomIn()
        {
            if (zoomLevel < 60) // 최대 확대 수준은 60입니다.
            {
                zoomLevel += 1; // 한 번의 스크롤에 대해 1씩 증가합니다.
                MyTextArea.ZoomFactor = zoomLevel / 10f; // ZoomFactor 설정
                Console.WriteLine($"ZoomFactors: {MyTextArea.ZoomFactor}");
                UpdateStatusBar();
            }
        }

        //축소 메소드
        private void ZoomOut()
        {
            if (zoomLevel > 1) // 최소 축소 수준은 1입니다.
            {
                zoomLevel -= 1; // 한 번의 스크롤에 대해 1씩 감소합니다.
                MyTextArea.ZoomFactor = zoomLevel / 10f; // ZoomFactor 설정
                Console.WriteLine($"ZoomFactors: {MyTextArea.ZoomFactor}");
                UpdateStatusBar();
            }
        }
        

        //이전 찾기, 다음 찾기
        private void FindNextPrev(string direction)
        {
            if (!string.IsNullOrEmpty(lastSearchText))
            {
                RichTextBoxFinds options = IsCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;
                if (direction == "up")
                {
                    findDialog.FindUp(lastSearchText, options);
                }
                else
                {
                    findDialog.FindDown(lastSearchText, options);

                }
            }
            else
            {
                ShowDialogs("find");
            }
        }

        //커서 행과 열 정보
        private void UpdateStatusBar()
        {
            // 현재 커서의 행과 열 정보 가져오기
            int line = MyTextArea.GetLineFromCharIndex(MyTextArea.SelectionStart) + 1;
            int column = MyTextArea.SelectionStart - MyTextArea.GetFirstCharIndexOfCurrentLine() + 1;

            // 행과 열 정보 표시
            toolStripCursorPosition.Text = $"Ln {line}, Col {column}";

            if (MyTextArea.ZoomFactor == 1)
            {
                // 확대 비율
                toolStripZoom.Text = $"{(int)Math.Round(MyTextArea.ZoomFactor * 100)}%"; ;
            }
            else
            {
                // 확대 비율
                toolStripZoom.Text = $"Zoom: {(int)Math.Round(MyTextArea.ZoomFactor * 100)}%"; ;
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
            UpdateStatusBar();
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
            if (findDialog != null && !findDialog.IsDisposed){ findDialog.Close(); }
            else if (moveDialog != null && !moveDialog.IsDisposed){moveDialog.Close();}
            else if(changeDialog != null && !changeDialog.IsDisposed) { changeDialog.Close(); }

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

