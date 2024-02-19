using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MyTextEditor
{
    public partial class �޸��� : Form
    {
        public �޸���()
        {
            InitializeComponent();
            MyTextArea.MouseWheel += MyTextArea_MouseWheel;
        }

        //File ����
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        //ã�� �� ����
        private FindForm findDialog;
        public string lastSearchText = string.Empty;
        public bool IsCase = false;

        //�� �ٲ�, �޸��� ���� ����
        private LineMoveForm moveDialog;
        private Information infoDialog;

        private PageSettings pageSetting = new PageSettings();
        private PrinterSettings printerSetting = new PrinterSettings();
        private int zoomLevel = 10;

        #region 1. ���� �޴�

        // �� ����(Ctrl+N)
        private void NewFileToolTip_Click(object sender, EventArgs e)
        {
            AskSave();
            MyTextArea.Text = string.Empty;
            isTextChanged = false;
        }

        //��â(Ctrl+Shift+N)
        private void NewMemoToolTip_Click(object sender, EventArgs e)
        {
            �޸��� newMemo = new �޸���();
            newMemo.Show();
        }

        //����(Ctrl+O)
        private void OpenToolTip_Click(object sender, EventArgs e)
        {
            //���� �޸��忡 ������ ������ ���� ���� �� ���� �۾� ����
            AskSave();
            OpenFileDialog();
        }

        // ����(Ctrl+S)
        private void SaveToolTip_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        //�ٸ� �̸����� ����(Ctrl+Shift+S)
        private void DnameSaveToolTip_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "�ؽ�Ʈ ���� (*.txt)|*.txt|��� ���� (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                SaveFile();
            }
        }

        //������ ����
        private void PageSettingToolTip_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PageSettings = pageSetting;
            pageSetupDialog.PrinterSettings = printerSetting;
            pageSetupDialog.AllowPrinter = true;
            pageSetupDialog.AllowOrientation = true;
            pageSetupDialog.EnableMetric = true; //��ġ - �и����� ����

            // ������ ���� ���̾�αװ� ���� �� �̺�Ʈ ó��
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                pageSetting = pageSetupDialog.PageSettings;
            }

        }

        //�μ�(Ctrl+P)
        private void PrintToolTip_Click(object sender, EventArgs e)
        {
            ShowDialogs("print");
        }

        //������
        private void ExitToolTip_Click(object sender, EventArgs e)
        {
            // FormClosing �̺�Ʈ�� �������� ȣ���Ͽ� ������ ���� ������ ����
            �޸���_FormClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }
        #endregion

        #region 2. ���� �޴�

        //����(Ctrl+C)
        private void CopyTextToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.SelectionLength > 0)
            {
                MyTextArea.Copy();
            }
        }

        //�ٿ��ֱ�(Ctrl+V)
        private void PasteTextToolTip_Click(object sender, EventArgs e)
        {
            MyTextArea.Paste();
        }

        //�ڸ���(Ctrl+X)
        private void CutTextToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.SelectionLength > 0)
            {
                MyTextArea.Cut();
            }
        }

        //���� ���(Ctrl+Z)
        private void DoCancleToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.CanUndo)
            {
                MyTextArea.Undo();
            }
        }

        //���� ����(Ctrl+Y)
        private void RedoToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.CanRedo)
            {
                MyTextArea.Redo();
            }
        }

        //����(Delete)
        private void DeleteTextToolTip_Click(object sender, EventArgs e)
        {
            if (MyTextArea.SelectionLength > 0)
            {
                MyTextArea.SelectedText = string.Empty;
            }
        }

        //ã��(Ctrl+F)
        private void FindTextToolTip_Click(object sender, EventArgs e)
        {
            ShowDialogs("find");
        }

        //���� ã��(F3)
        private void FindNextToolTip_Click(object sender, EventArgs e)
        {
            FindNextPrev("down");
        }

        //���� ã��(SHIFT+F3)
        private void FindBeforeToolTip_Click(object sender, EventArgs e)
        {
            FindNextPrev("up");
        }

        //�ٲٱ�(Ctrl+H)
        private void ChangeTextToolTip_Click(object sender, EventArgs e)
        {
        }

        //�̵�(Ctrl+G)
        private void MoveTextToolTip_Click(object sender, EventArgs e)
        {
            ShowDialogs("move");
        }

        //��� ����(Ctrl+A)
        private void AllSelectTextToolTip_Click(object sender, EventArgs e)
        {
            MyTextArea.SelectAll();
        }

        //�ð� �Է�(F5)
        private void TimeTextToolTip_Click(object sender, EventArgs e)
        {
            MyTextArea.Text += DateTime.Now.ToString();
            ControlFocusBack();
        }
        #endregion

        #region 3. ���� �޴�
        //�ڵ� �ٹٲ�
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

        //�۲�
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogs("font");
        }
        #endregion

        #region 4. ���� �޴�
        // Ȯ���ϱ�
        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        // ����ϱ�
        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        // �⺻������
        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTextArea.ZoomFactor = 1;
            zoomLevel = 10;
            UpdateStatusBar();
        }


        //���� ǥ����
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

        #region 5. ���� �޴�
        //����
        private void QAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start https://kjy1ho.tistory.com/category/%5BC%23%20%26%20C%2B%2B%5D/%5BC%23%20%EC%9C%88%ED%8F%BC%5D%20%ED%98%BC%EC%9E%90%ED%95%B4%EB%B3%B4%EB%8A%94%20%EC%9C%88%EB%8F%84%EC%9A%B0%20%EB%A9%94%EB%AA%A8%EC%9E%A5%20%EB%A7%8C%EB%93%A4%EA%B8%B0",
                WindowStyle = ProcessWindowStyle.Hidden
            });

        }

        //�޸��� ����
        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogs("info");
        }
        #endregion

        #region �޼ҵ�
        // ���� ���� �޼ҵ�
        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                // ���� ��ΰ� ���� ��� SaveFileDialog ǥ��
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "�ؽ�Ʈ ���� (*.txt)|*.txt|��� ���� (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return; // ����ڰ� ����� ��� ���� �ߴ�
                }
            }
            try
            {
                // �ؽ�Ʈ �������� ������ ���Ͽ� ����
                File.WriteAllText(currentFilePath, MyTextArea.Text);
                isTextChanged = false; // ���� �� ������� ���� ���·� ǥ��
                UpdateFormTitle(); // ���� �� ���� �̸� ǥ�� ����
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� ���� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �ؽ�Ʈ ���� Ȯ��/���� ����/�޴� Ȱ��ȭ
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

        //���� ���� �����
        private void AskSave()
        {
            if (isTextChanged)
            {
                // ������ ����Ǿ��� ��� ���� ���� Ȯ��
                DialogResult result = MessageBox.Show("����� ������ �����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // ����
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    // ���
                    return;
                }
                currentFilePath = string.Empty;
            }
            UpdateFormTitle();

        }

        //���� �̸� ���� �޼ҵ�
        private void UpdateFormTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "���� ����" : Path.GetFileName(currentFilePath);
            this.Text = isTextChanged ? $"*{fileName}" : fileName;
        }

        //���� ����
        private void OpenFileDialog()
        {
            //OpenFileDialog ȣ��(.txt text ���ϸ� ����)
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "�ؽ�Ʈ ���� (*.txt)|*.txt|��� ���� (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                MyTextArea.Text = File.ReadAllText(currentFilePath);
                isTextChanged = false;
                UpdateFormTitle();
                ControlFocusBack();
            }
        }

        //Ŀ�� ��ġ �̵�(�� ��)
        private void ControlFocusBack()
        {
            //Ŀ�� �� �ڷ� �̵�
            MyTextArea.SelectionStart = MyTextArea.Text.Length;
            MyTextArea.SelectionLength = 0;
            MyTextArea.Focus();
        }


        // ã��, �� �̵� ���̾�α� ȣ��
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


        // ����Ʈ�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
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

        //Ȯ�� �޼ҵ�
        private void ZoomIn()
        {
            if (zoomLevel < 60) // �ִ� Ȯ�� ������ 60�Դϴ�.
            {
                zoomLevel += 1; // �� ���� ��ũ�ѿ� ���� 1�� �����մϴ�.
                MyTextArea.ZoomFactor = zoomLevel / 10f; // ZoomFactor ����
                Console.WriteLine($"ZoomFactors: {MyTextArea.ZoomFactor}");
                UpdateStatusBar();
            }
        }

        //��� �޼ҵ�
        private void ZoomOut()
        {
            if (zoomLevel > 1) // �ּ� ��� ������ 1�Դϴ�.
            {
                zoomLevel -= 1; // �� ���� ��ũ�ѿ� ���� 1�� �����մϴ�.
                MyTextArea.ZoomFactor = zoomLevel / 10f; // ZoomFactor ����
                Console.WriteLine($"ZoomFactors: {MyTextArea.ZoomFactor}");
                UpdateStatusBar();
            }
        }
        

        //���� ã��, ���� ã��
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

        //Ŀ�� ��� �� ����
        private void UpdateStatusBar()
        {
            // ���� Ŀ���� ��� �� ���� ��������
            int line = MyTextArea.GetLineFromCharIndex(MyTextArea.SelectionStart) + 1;
            int column = MyTextArea.SelectionStart - MyTextArea.GetFirstCharIndexOfCurrentLine() + 1;

            // ��� �� ���� ǥ��
            toolStripCursorPosition.Text = $"Ln {line}, Col {column}";

            if (MyTextArea.ZoomFactor == 1)
            {
                // Ȯ�� ����
                toolStripZoom.Text = $"{(int)Math.Round(MyTextArea.ZoomFactor * 100)}%"; ;
            }
            else
            {
                // Ȯ�� ����
                toolStripZoom.Text = $"Zoom: {(int)Math.Round(MyTextArea.ZoomFactor * 100)}%"; ;
            }
        }
        #endregion

        #region ������ �̺�Ʈ
        //�ؽ�Ʈ ���� �� �޴� Ȱ��ȭ
        private void MyTextArea_SelectionChanged(object sender, EventArgs e)
        {
            bool isTextSelected = MyTextArea.SelectionLength > 0;
            CutTextToolTip.Enabled = isTextSelected;
            CopyTextToolTip.Enabled = isTextSelected;
            DeleteTextToolTip.Enabled = isTextSelected;
            UpdateStatusBar();
        }

        //�� ���� �̺�Ʈ
        private void �޸���_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTextChanged && MyTextArea.Text.Length > 0)
            {
                DialogResult result = MessageBox.Show("����� ������ �����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // ��� ���� �� â�� ���� ����
                }
            }

            //���̾�αװ� �����ִ� ��� �ݱ�
            if (findDialog != null && !findDialog.IsDisposed)
            {
                findDialog.Close();
            }
            else if (moveDialog != null && !moveDialog.IsDisposed)
            {
                moveDialog.Close();
            }

        }

        private void �޸���_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ���� �����ִ� ���� ������ ���α׷� ����
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
        #endregion



      
    }

}

