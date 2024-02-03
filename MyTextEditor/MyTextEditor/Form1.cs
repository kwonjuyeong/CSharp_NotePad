using Microsoft.VisualBasic;

namespace MyTextEditor
{
    public partial class �޸��� : Form
    {

        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        public �޸���()
        {
            InitializeComponent();
        }

        #region ����
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
            // �� â�� ����� ���� Form1�� ���纻�� ����
            �޸��� newMemo = new �޸���();
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

        }

        //������ ����
        private void PageSettingToolTip_Click(object sender, EventArgs e)
        {

        }


        //�μ�(Ctrl+P)
        private void PrintToolTip_Click(object sender, EventArgs e)
        {
        }
        #endregion





        #region ����
        //�ð� �Է�(F5)
        private void TimeTextToolTip_Click(object sender, EventArgs e)
        {
            //���� �ð� �߰�
            MyTextArea.Text += DateTime.Now.ToString();
            //Ŀ�� �� �ڷ� �̵�
            MyTextArea.SelectionStart = MyTextArea.Text.Length;
            MyTextArea.SelectionLength = 0;
            MyTextArea.Focus();
        }

        #endregion


        #region �޼ҵ��
        // ���� ���� ���� ����
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� ���� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �ؽ�Ʈ ������ ���� ���� ���� Ȯ��
        private void MyTextArea_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }
        #endregion






        
    }
}
