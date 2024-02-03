namespace MyTextEditor
{
    partial class 메모장
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            NewFileToolTip = new ToolStripMenuItem();
            NewMemoToolTip = new ToolStripMenuItem();
            OpenToolTip = new ToolStripMenuItem();
            SaveToolTip = new ToolStripMenuItem();
            DnameSaveToolTip = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            PageSettingToolTip = new ToolStripMenuItem();
            PrintToolTip = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ExitToolTip = new ToolStripMenuItem();
            편집EToolStripMenuItem = new ToolStripMenuItem();
            DoCancleToolTip = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            CutTextToolTip = new ToolStripMenuItem();
            CopyTextToolTip = new ToolStripMenuItem();
            PasteTextToolTip = new ToolStripMenuItem();
            DeleteTextToolTip = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            FindTextToolTip = new ToolStripMenuItem();
            FindNextToolTip = new ToolStripMenuItem();
            FindBeforeToolTip = new ToolStripMenuItem();
            ChangeTextToolTip = new ToolStripMenuItem();
            MoveTextToolTip = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            AllSelectTextToolTip = new ToolStripMenuItem();
            TimeTextToolTip = new ToolStripMenuItem();
            서식OToolStripMenuItem = new ToolStripMenuItem();
            자동줄바꿈ToolStripMenuItem = new ToolStripMenuItem();
            글꼴ToolStripMenuItem = new ToolStripMenuItem();
            보기VToolStripMenuItem = new ToolStripMenuItem();
            확대하기축소하기ToolStripMenuItem = new ToolStripMenuItem();
            확대ToolStripMenuItem = new ToolStripMenuItem();
            축소ToolStripMenuItem = new ToolStripMenuItem();
            기본값으로ToolStripMenuItem = new ToolStripMenuItem();
            상태표시줄ToolStripMenuItem = new ToolStripMenuItem();
            도움말HToolStripMenuItem = new ToolStripMenuItem();
            bindingSource1 = new BindingSource(components);
            MyTextArea = new RichTextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, 편집EToolStripMenuItem, 서식OToolStripMenuItem, 보기VToolStripMenuItem, 도움말HToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewFileToolTip, NewMemoToolTip, OpenToolTip, SaveToolTip, DnameSaveToolTip, toolStripSeparator1, PageSettingToolTip, PrintToolTip, toolStripSeparator2, ExitToolTip });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(57, 20);
            fileToolStripMenuItem.Text = "파일(F)";
            // 
            // NewFileToolTip
            // 
            NewFileToolTip.Name = "NewFileToolTip";
            NewFileToolTip.ShortcutKeys = Keys.Control | Keys.N;
            NewFileToolTip.Size = new Size(252, 22);
            NewFileToolTip.Text = "새 파일";
            NewFileToolTip.Click += NewFileToolTip_Click;
            // 
            // NewMemoToolTip
            // 
            NewMemoToolTip.Name = "NewMemoToolTip";
            NewMemoToolTip.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            NewMemoToolTip.Size = new Size(252, 22);
            NewMemoToolTip.Text = "새 창";
            NewMemoToolTip.Click += NewMemoToolTip_Click;
            // 
            // OpenToolTip
            // 
            OpenToolTip.Name = "OpenToolTip";
            OpenToolTip.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolTip.Size = new Size(252, 22);
            OpenToolTip.Text = "열기";
            OpenToolTip.Click += OpenToolTip_Click;
            // 
            // SaveToolTip
            // 
            SaveToolTip.Name = "SaveToolTip";
            SaveToolTip.ShortcutKeys = Keys.Control | Keys.S;
            SaveToolTip.Size = new Size(252, 22);
            SaveToolTip.Text = "저장";
            SaveToolTip.Click += SaveToolTip_Click;
            // 
            // DnameSaveToolTip
            // 
            DnameSaveToolTip.Name = "DnameSaveToolTip";
            DnameSaveToolTip.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            DnameSaveToolTip.Size = new Size(252, 22);
            DnameSaveToolTip.Text = "다른 이름으로 저장";
            DnameSaveToolTip.Click += DnameSaveToolTip_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(249, 6);
            // 
            // PageSettingToolTip
            // 
            PageSettingToolTip.Name = "PageSettingToolTip";
            PageSettingToolTip.Size = new Size(252, 22);
            PageSettingToolTip.Text = "페이지 설정";
            PageSettingToolTip.Click += PageSettingToolTip_Click;
            // 
            // PrintToolTip
            // 
            PrintToolTip.Name = "PrintToolTip";
            PrintToolTip.ShortcutKeys = Keys.Control | Keys.P;
            PrintToolTip.Size = new Size(252, 22);
            PrintToolTip.Text = "인쇄";
            PrintToolTip.Click += PrintToolTip_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(249, 6);
            // 
            // ExitToolTip
            // 
            ExitToolTip.Name = "ExitToolTip";
            ExitToolTip.Size = new Size(252, 22);
            ExitToolTip.Text = "끝내기";
            // 
            // 편집EToolStripMenuItem
            // 
            편집EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DoCancleToolTip, toolStripSeparator3, CutTextToolTip, CopyTextToolTip, PasteTextToolTip, DeleteTextToolTip, toolStripSeparator4, FindTextToolTip, FindNextToolTip, FindBeforeToolTip, ChangeTextToolTip, MoveTextToolTip, toolStripSeparator5, AllSelectTextToolTip, TimeTextToolTip });
            편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            편집EToolStripMenuItem.Size = new Size(57, 20);
            편집EToolStripMenuItem.Text = "편집(E)";
            // 
            // DoCancleToolTip
            // 
            DoCancleToolTip.Name = "DoCancleToolTip";
            DoCancleToolTip.ShortcutKeys = Keys.Control | Keys.Z;
            DoCancleToolTip.Size = new Size(179, 22);
            DoCancleToolTip.Text = "실행 취소";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(176, 6);
            // 
            // CutTextToolTip
            // 
            CutTextToolTip.Name = "CutTextToolTip";
            CutTextToolTip.ShortcutKeys = Keys.Control | Keys.X;
            CutTextToolTip.Size = new Size(179, 22);
            CutTextToolTip.Text = "잘라내기";
            // 
            // CopyTextToolTip
            // 
            CopyTextToolTip.Name = "CopyTextToolTip";
            CopyTextToolTip.ShortcutKeys = Keys.Control | Keys.C;
            CopyTextToolTip.Size = new Size(179, 22);
            CopyTextToolTip.Text = "복사";
            // 
            // PasteTextToolTip
            // 
            PasteTextToolTip.Name = "PasteTextToolTip";
            PasteTextToolTip.ShortcutKeys = Keys.Control | Keys.V;
            PasteTextToolTip.Size = new Size(179, 22);
            PasteTextToolTip.Text = "붙여넣기";
            // 
            // DeleteTextToolTip
            // 
            DeleteTextToolTip.Name = "DeleteTextToolTip";
            DeleteTextToolTip.ShortcutKeys = Keys.Delete;
            DeleteTextToolTip.Size = new Size(179, 22);
            DeleteTextToolTip.Text = "삭제";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(176, 6);
            // 
            // FindTextToolTip
            // 
            FindTextToolTip.Name = "FindTextToolTip";
            FindTextToolTip.ShortcutKeys = Keys.Control | Keys.F;
            FindTextToolTip.Size = new Size(179, 22);
            FindTextToolTip.Text = "찾기";
            // 
            // FindNextToolTip
            // 
            FindNextToolTip.Name = "FindNextToolTip";
            FindNextToolTip.ShortcutKeys = Keys.F3;
            FindNextToolTip.Size = new Size(179, 22);
            FindNextToolTip.Text = "다음 찾기";
            // 
            // FindBeforeToolTip
            // 
            FindBeforeToolTip.Name = "FindBeforeToolTip";
            FindBeforeToolTip.ShortcutKeys = Keys.Shift | Keys.F3;
            FindBeforeToolTip.Size = new Size(179, 22);
            FindBeforeToolTip.Text = "이전 찾기";
            // 
            // ChangeTextToolTip
            // 
            ChangeTextToolTip.Name = "ChangeTextToolTip";
            ChangeTextToolTip.ShortcutKeys = Keys.Control | Keys.H;
            ChangeTextToolTip.Size = new Size(179, 22);
            ChangeTextToolTip.Text = "바꾸기";
            // 
            // MoveTextToolTip
            // 
            MoveTextToolTip.Name = "MoveTextToolTip";
            MoveTextToolTip.ShortcutKeys = Keys.Control | Keys.G;
            MoveTextToolTip.Size = new Size(179, 22);
            MoveTextToolTip.Text = "이동";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(176, 6);
            // 
            // AllSelectTextToolTip
            // 
            AllSelectTextToolTip.Name = "AllSelectTextToolTip";
            AllSelectTextToolTip.ShortcutKeys = Keys.Control | Keys.A;
            AllSelectTextToolTip.Size = new Size(179, 22);
            AllSelectTextToolTip.Text = "모두 선택";
            // 
            // TimeTextToolTip
            // 
            TimeTextToolTip.Name = "TimeTextToolTip";
            TimeTextToolTip.ShortcutKeys = Keys.F5;
            TimeTextToolTip.Size = new Size(179, 22);
            TimeTextToolTip.Text = "시간/날짜";
            TimeTextToolTip.Click += TimeTextToolTip_Click;
            // 
            // 서식OToolStripMenuItem
            // 
            서식OToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 자동줄바꿈ToolStripMenuItem, 글꼴ToolStripMenuItem });
            서식OToolStripMenuItem.Name = "서식OToolStripMenuItem";
            서식OToolStripMenuItem.Size = new Size(60, 20);
            서식OToolStripMenuItem.Text = "서식(O)";
            // 
            // 자동줄바꿈ToolStripMenuItem
            // 
            자동줄바꿈ToolStripMenuItem.Name = "자동줄바꿈ToolStripMenuItem";
            자동줄바꿈ToolStripMenuItem.Size = new Size(138, 22);
            자동줄바꿈ToolStripMenuItem.Text = "자동 줄바꿈";
            // 
            // 글꼴ToolStripMenuItem
            // 
            글꼴ToolStripMenuItem.Name = "글꼴ToolStripMenuItem";
            글꼴ToolStripMenuItem.Size = new Size(138, 22);
            글꼴ToolStripMenuItem.Text = "글꼴";
            // 
            // 보기VToolStripMenuItem
            // 
            보기VToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 확대하기축소하기ToolStripMenuItem, 상태표시줄ToolStripMenuItem });
            보기VToolStripMenuItem.Name = "보기VToolStripMenuItem";
            보기VToolStripMenuItem.Size = new Size(59, 20);
            보기VToolStripMenuItem.Text = "보기(V)";
            // 
            // 확대하기축소하기ToolStripMenuItem
            // 
            확대하기축소하기ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 확대ToolStripMenuItem, 축소ToolStripMenuItem, 기본값으로ToolStripMenuItem });
            확대하기축소하기ToolStripMenuItem.Name = "확대하기축소하기ToolStripMenuItem";
            확대하기축소하기ToolStripMenuItem.Size = new Size(175, 22);
            확대하기축소하기ToolStripMenuItem.Text = "확대하기/축소하기";
            // 
            // 확대ToolStripMenuItem
            // 
            확대ToolStripMenuItem.Name = "확대ToolStripMenuItem";
            확대ToolStripMenuItem.Size = new Size(134, 22);
            확대ToolStripMenuItem.Text = "확대";
            // 
            // 축소ToolStripMenuItem
            // 
            축소ToolStripMenuItem.Name = "축소ToolStripMenuItem";
            축소ToolStripMenuItem.Size = new Size(134, 22);
            축소ToolStripMenuItem.Text = "축소";
            // 
            // 기본값으로ToolStripMenuItem
            // 
            기본값으로ToolStripMenuItem.Name = "기본값으로ToolStripMenuItem";
            기본값으로ToolStripMenuItem.Size = new Size(134, 22);
            기본값으로ToolStripMenuItem.Text = "기본값으로";
            // 
            // 상태표시줄ToolStripMenuItem
            // 
            상태표시줄ToolStripMenuItem.Name = "상태표시줄ToolStripMenuItem";
            상태표시줄ToolStripMenuItem.Size = new Size(175, 22);
            상태표시줄ToolStripMenuItem.Text = "상태 표시줄";
            // 
            // 도움말HToolStripMenuItem
            // 
            도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            도움말HToolStripMenuItem.Size = new Size(72, 20);
            도움말HToolStripMenuItem.Text = "도움말(H)";
            // 
            // MyTextArea
            // 
            MyTextArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MyTextArea.Location = new Point(0, 27);
            MyTextArea.Name = "MyTextArea";
            MyTextArea.Size = new Size(800, 423);
            MyTextArea.TabIndex = 1;
            MyTextArea.Text = "";
            MyTextArea.TextChanged += MyTextArea_TextChanged;
            // 
            // 메모장
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MyTextArea);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "메모장";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem NewFileToolTip;
        private ToolStripMenuItem NewMemoToolTip;
        private ToolStripMenuItem OpenToolTip;
        private ToolStripMenuItem SaveToolTip;
        private ToolStripMenuItem DnameSaveToolTip;
        private ToolStripMenuItem PageSettingToolTip;
        private ToolStripMenuItem PrintToolTip;
        private ToolStripMenuItem ExitToolTip;
        private ToolStripMenuItem 편집EToolStripMenuItem;
        private ToolStripMenuItem 서식OToolStripMenuItem;
        private ToolStripMenuItem 보기VToolStripMenuItem;
        private ToolStripMenuItem 도움말HToolStripMenuItem;
        private ToolStripMenuItem DoCancleToolTip;
        private ToolStripMenuItem CutTextToolTip;
        private ToolStripMenuItem CopyTextToolTip;
        private ToolStripMenuItem PasteTextToolTip;
        private ToolStripMenuItem DeleteTextToolTip;
        private ToolStripMenuItem FindTextToolTip;
        private ToolStripMenuItem FindNextToolTip;
        private ToolStripMenuItem FindBeforeToolTip;
        private ToolStripMenuItem ChangeTextToolTip;
        private ToolStripMenuItem MoveTextToolTip;
        private ToolStripMenuItem AllSelectTextToolTip;
        private ToolStripMenuItem TimeTextToolTip;
        private ToolStripMenuItem 자동줄바꿈ToolStripMenuItem;
        private ToolStripMenuItem 글꼴ToolStripMenuItem;
        private ToolStripMenuItem 확대하기축소하기ToolStripMenuItem;
        private ToolStripMenuItem 확대ToolStripMenuItem;
        private ToolStripMenuItem 축소ToolStripMenuItem;
        private ToolStripMenuItem 기본값으로ToolStripMenuItem;
        private ToolStripMenuItem 상태표시줄ToolStripMenuItem;
        private BindingSource bindingSource1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private RichTextBox MyTextArea;
    }
}
