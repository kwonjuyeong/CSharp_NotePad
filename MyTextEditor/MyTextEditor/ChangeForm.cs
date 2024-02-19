using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextEditor
{
    public partial class ChangeForm : Form
    {
        메모장 Memo;

        public ChangeForm(메모장 mainMemo)
        {
            Memo = mainMemo;
            InitializeComponent();
            textBoxToSearch.Text = Memo.lastSearchText;
            caseCheckBox.Checked = Memo.IsCase;
        }
    }
}
