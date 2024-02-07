using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace MyTextEditor
{
    public partial class �޸��� : Form
    {
        private FindDialog findDialog;
        private MoveDialog moveDialog;
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;
        //private string searchTextForFindDialog = string.Empty;

        public �޸���()
        {
            InitializeComponent();
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
            FindDialog_NextEvent(sender, e);
        }

        //���� ã��(SHIFT+F3)
        private void FindBeforeToolTip_Click(object sender, EventArgs e)
        {
            FindDialog_PreviousEvent(sender, e);
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
                    findDialog = new FindDialog(MyTextArea);
                    //findDialog.Show();
                    findDialog.FindNextEvent += FindDialog_NextEvent;
                    findDialog.FindPrevEvent += FindDialog_PreviousEvent;
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

        //���� ã��
        private void FindDialog_NextEvent(object sender, EventArgs e)
        {
            if (findDialog != null)
            {
                int currentIndex = MyTextArea.SelectionStart + MyTextArea.SelectionLength;
                int resultIndex = MyTextArea.Find(findDialog.SearchText, currentIndex, RichTextBoxFinds.None);

                if (resultIndex != -1)
                {
                    // ���� �߻��� ã������ ����
                    MyTextArea.Select(resultIndex, findDialog.SearchText.Length);
                    MyTextArea.ScrollToCaret();
                    this.Focus();
                }
                else
                {
                    // ���� �߻��� ������ �޽��� ǥ��
                    MessageBox.Show("�� �̻� ���� �߻��� �����ϴ�.", "ã��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        //���� ã��
        private void FindDialog_PreviousEvent(object sender, EventArgs e)
        {
            if (findDialog != null)
            {
                int currentIndex = MyTextArea.SelectionStart;
                int resultIndex = MyTextArea.Find(findDialog.SearchText, 0, currentIndex, RichTextBoxFinds.Reverse);

                if (resultIndex != -1)
                {
                    // ���� �߻��� ã������ ����
                    MyTextArea.Select(resultIndex, findDialog.SearchText.Length);
                    MyTextArea.ScrollToCaret();
                    this.Focus();
                }
                else
                {
                    // ���� �߻��� ������ �޽��� ǥ��
                    MessageBox.Show("�� �̻� ���� �߻��� �����ϴ�.", "ã��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // �� �̵� �̺�Ʈ �ڵ鷯
        private void MoveDialog_MoveEvent(object sender, EventArgs e)
        {
            // MoveDialog���� �� �̵� ��ư�� Ŭ���ϸ� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
            MoveDialog moveDialog = sender as MoveDialog;
            if (moveDialog != null)
            {
                // �� �̵� ó��
                int targetLine = moveDialog.TargetLine;
                if (targetLine >= 1 && targetLine <= MyTextArea.Lines.Length)
                {
                    // �ش� �ٷ� Ŀ�� �̵�
                    MyTextArea.SelectionStart = MyTextArea.GetFirstCharIndexFromLine(targetLine - 1);
                    MyTextArea.ScrollToCaret();
                    MyTextArea.Focus();
                    moveDialog.Close();
                }
                else
                {
                    // ��ȿ���� ���� �� ��ȣ�� ��� �޽��� ǥ��
                    MessageBox.Show("��ȿ���� ���� �� ��ȣ�Դϴ�.", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


    //ã�� ��
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
        public event EventHandler FindPrevEvent;

        public string SearchText => textBoxToSearch.Text;

        public FindDialog(RichTextBox richtextBox)
        {
            textBoxToSearch = richtextBox;
            InitializeUI();
            this.Text = "ã��";
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

            //��
            findLabel.Text = "ã�� ����(N) :";
            findLabel.Location = new Point(10, 25);
            findLabel.AutoSize = true;

            //ã�� ���� TextBox
            textBoxToSearch.Height = 25;
            textBoxToSearch.Width = 200;
            textBoxToSearch.Location = new Point(100, 20);


            //���� ã�� ��ư UI
            findNextButton.Text = "���� ã��(F)";
            findNextButton.Height = 25;
            findNextButton.Width = 80;
            findNextButton.Location = new Point(310, 20);
            findNextButton.Click += FindNextButton_Click;

            //��� ��ư UI
            cancleButton.Text = "���";
            cancleButton.Height = 25;
            cancleButton.Width = 80;
            cancleButton.Location = new Point(310, 60);
            cancleButton.Click += CancelButton_Click;

            //��/�ҹ��� ���� UI
            caseSensitiveCheckBox.Text = "��/�ҹ��� ����(C)";
            caseSensitiveCheckBox.Location = new Point(10, 60);
            caseSensitiveCheckBox.AutoSize = true;

            //������ ��ġ(R)
            roundCheckBox.Text = "������ ��ġ(R)";
            roundCheckBox.Location = new Point(10, 90);
            roundCheckBox.AutoSize = true;


            //ã�� ����
            directionGroupBox.Text = "����";
            directionGroupBox.Location = new Point(140, 50);
            directionGroupBox.Size = new Size(160, 60);

            // ã�� ���� ���� ��ư
            forwardRadioButton.Text = "����(U)";
            forwardRadioButton.Location = new Point(10, 20);
            forwardRadioButton.AutoSize = true;

            backwardRadioButton.Text = "�Ʒ���(D)";
            backwardRadioButton.Location = new Point(80, 20);
            backwardRadioButton.Checked = true;
            backwardRadioButton.AutoSize = true;

           
            // ���� �׷�ڽ��� ���� ��ư �߰�
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

        private void FindPrevButton_Click(object sender, EventArgs e)
        {
            FindPrevEvent?.Invoke(this, EventArgs.Empty);

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // ��� ��ư Ŭ�� �� �� �ݱ�
            this.Close();
        }
        public void SetSearchText(string text)
        {
            textBoxToSearch.Text = text;
        }
    }


    //�� �̵� ��
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
            this.Text = "�� �̵�";
            this.Width = 270;
            this.Height = 160;
        }

        private void InitializeUI()
        {
            findLabel = new Label();
            textBoxToMove = new RichTextBox();
            moveButton = new Button();
            cancleButton = new Button();

            //��
            findLabel.Text = "�� ��ȣ(L) :";
            findLabel.Location = new Point(10, 10);
            findLabel.AutoSize = true;

            //ã�� ���� TextBox
            textBoxToMove.Height = 30;
            textBoxToMove.Width = 230;
            textBoxToMove.Location = new Point(10, 40);
            textBoxToMove.KeyPress += TextBoxToMove_KeyPress;

            //�̵� ��ư
            moveButton.Text = "�̵�";
            moveButton.Height = 25;
            moveButton.Width = 70;
            moveButton.Location = new Point(90, 80);
            moveButton.Click += MoveButton_Click;

            //��� ��ư
            cancleButton.Text = "���";
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
            // ��� ��ư Ŭ�� �� �� �ݱ�
            this.Close();
        }

        // TextBox �Է� ���� - ���ڸ� �Է� �����ϵ���
        private void TextBoxToMove_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

}

