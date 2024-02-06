using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace MyTextEditor
{
    public partial class �޸��� : Form
    {
        private FindDialog findDialog;
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        public �޸���()
        {
            InitializeComponent();
        }

        #region ���� �޴�
        // �� ����(Ctrl+N)
        private void NewFileToolTip_Click(object sender, EventArgs e)
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
            }

            // �� ���� �ʱ�ȭ
            MyTextArea.Text = string.Empty;
            currentFilePath = string.Empty;
            isTextChanged = false;
        }

        //��â(Ctrl+Shift+N)
        private void NewMemoToolTip_Click(object sender, EventArgs e)
        {
            // �� â�� ����� ���� �޸����� ���纻�� ����
            �޸��� newMemo = new �޸���();
            // �� â�� ������
            newMemo.Show();
        }

        //����(Ctrl+O)
        private void OpenToolTip_Click(object sender, EventArgs e)
        {
            //���� �޸��忡 ������ ������ ���� ���� �� ���� �۾� ����
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("����� ������ �����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

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
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = new PrintDocument();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                printDialog.Document.Print();
            }

        }

        //������
        private void ExitToolTip_Click(object sender, EventArgs e)
        {
            ExitApplication();

        }


        // ���ø����̼� ���� �޼ҵ�
        private void ExitApplication()
        {
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("����� ������ �����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // ���� �����ִ� ���� ������ ���α׷� ����
            if (Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
            else
            {
                // �� �ݱ�
                this.Close();
            }
        }




        #endregion


        #region ����
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
        }

        //���� ã��(F3)
        private void FindNextToolTip_Click(object sender, EventArgs e)
        {
        }

        //���� ã��(SHIFT+F3)
        private void FindBeforeToolTip_Click(object sender, EventArgs e)
        {

        }

        //�ٲٱ�(Ctrl+H)
        private void ChangeTextToolTip_Click(object sender, EventArgs e)
        {
        }


        //�̵�(Ctrl+G)
        private void MoveTextToolTip_Click(object sender, EventArgs e)
        {
        }

        //��� ����(Ctrl+A)
        private void AllSelectTextToolTip_Click(object sender, EventArgs e)
        {
            MyTextArea.SelectAll();
        }

        //�ð� �Է�(F5)
        private void TimeTextToolTip_Click(object sender, EventArgs e)
        {
            //���� �ð� �߰�
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



        // �ؽ�Ʈ ���� ���� Ȯ�� �޼ҵ�
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
            // �ؽ�Ʈ�� ���õǾ����� ���θ� Ȯ���Ͽ� �޴��� Ȱ��ȭ ���θ� ����
            bool isTextSelected = MyTextArea.SelectionLength > 0;
            CutTextToolTip.Enabled = isTextSelected;
            CopyTextToolTip.Enabled = isTextSelected;
            DeleteTextToolTip.Enabled = isTextSelected;
        }

        //���� �̸� ���� �޼ҵ�
        private void UpdateFormTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "���� ����" : Path.GetFileName(currentFilePath);
            this.Text = isTextChanged ? $"*{fileName}" : fileName;
        }



        //Ŀ�� ��ġ �̵�(�� ��)
        private void ControlFocusBack()
        {
            //Ŀ�� �� �ڷ� �̵�
            MyTextArea.SelectionStart = MyTextArea.Text.Length;
            MyTextArea.SelectionLength = 0;
            MyTextArea.Focus();
        }

        // ����Ʈ�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(MyTextArea.Text, font, Brushes.Black, 10, 10);
        }




        private void �޸���_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("����� ������ �����Ͻðڽ��ϱ�?", "���� Ȯ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // �� �ݱ⸦ ���
                    return;
                }
            }

            // ���� ���������� ����� �� ���� �����ִ� ���� ������ ���α׷� ����
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
        private CheckBox caseSensitiveCheckBox;
        private CheckBox roundCheckBox;
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
            forwardRadioButton = new RadioButton();
            backwardRadioButton = new RadioButton();
            roundCheckBox = new CheckBox();

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


            // ã�� ���� ���� ��ư
            forwardRadioButton.Text = "����(U)";
            forwardRadioButton.Location = new Point(150, 60);
            forwardRadioButton.Checked = false;
            forwardRadioButton.AutoSize = true;

            backwardRadioButton.Text = "�Ʒ���(D)";
            backwardRadioButton.Location = new Point(220, 60);
            backwardRadioButton.Checked = true;
            backwardRadioButton.AutoSize = true;

            //������ ��ġ(R)
            roundCheckBox.Text = "������ ��ġ(R)";
            roundCheckBox.Location = new Point(10, 90);
            roundCheckBox.AutoSize = true;


            // Add controls to the form
            Controls.Add(findLabel);
            Controls.Add(textBoxToSearch);
            Controls.Add(findNextButton);
            Controls.Add(cancleButton);
            Controls.Add(caseSensitiveCheckBox);
            Controls.Add(forwardRadioButton);
            Controls.Add(backwardRadioButton);
            Controls.Add(roundCheckBox);
        }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            FindNextEvent?.Invoke(this, EventArgs.Empty);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // ��� ��ư Ŭ�� �� �� �ݱ�
            this.Close();
        }

    }



}





