using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MyTextEditor
{
    public partial class �޸��� : Form
    {
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        private FindForm findDialog;
        public string lastSearchText = string.Empty;
        public bool IsCase = false;
        private LineMoveForm moveDialog;


        private Font DefaultFont;

        public �޸���()
        {
            InitializeComponent();
            DefaultFont = MyTextArea.Font;
        }

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
        }

        //�μ�(Ctrl+P)
        private void PrintToolTip_Click(object sender, EventArgs e)
        {
            CallPrintDialog();
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

        //���� ã��(SHIFT+F3)
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
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                MyTextArea.Font = fontDialog.Font;
              
                DefaultFont = MyTextArea.Font;
            }
        }
        #endregion


        #region 4. ���� �޴�
        // Ȯ���ϱ�
        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyTextArea.ZoomFactor < 64) // �ִ� ���� 64
            {
                MyTextArea.ZoomFactor += 0.1f; // ���� ������ ���� 1.0f����
            }
        }

        // ����ϱ�
        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyTextArea.ZoomFactor > 0.2f) // �ּ� ���� 0.2f
            {
                MyTextArea.ZoomFactor -= 0.1f; // ���� ������ ���� 1.0f����
            }
        }

        // �⺻������
        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTextArea.ZoomFactor = 1;
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

        //�μ�
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

        // ����Ʈ�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(MyTextArea.Text, font, Brushes.Black, 10, 10);
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
        }

        private void �޸���_MouseWheel(object sender, MouseEventArgs e)
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

        #region ������ �̺�Ʈ
        //�ؽ�Ʈ ���� �� �޴� Ȱ��ȭ
        private void MyTextArea_SelectionChanged(object sender, EventArgs e)
        {
            bool isTextSelected = MyTextArea.SelectionLength > 0;
            CutTextToolTip.Enabled = isTextSelected;
            CopyTextToolTip.Enabled = isTextSelected;
            DeleteTextToolTip.Enabled = isTextSelected;
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

