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
            UndoToolTip = new ToolStripMenuItem();
            RedoToolTip = new ToolStripMenuItem();
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
            AutoLineToolStripMenuItem = new ToolStripMenuItem();
            FontToolStripMenuItem = new ToolStripMenuItem();
            보기VToolStripMenuItem = new ToolStripMenuItem();
            확대하기축소하기ToolStripMenuItem = new ToolStripMenuItem();
            ZoomINToolStripMenuItem = new ToolStripMenuItem();
            ZoomOutToolStripMenuItem = new ToolStripMenuItem();
            DefaultToolStripMenuItem = new ToolStripMenuItem();
            상태표시줄ToolStripMenuItem = new ToolStripMenuItem();
            도움말HToolStripMenuItem = new ToolStripMenuItem();
            QAToolStripMenuItem = new ToolStripMenuItem();
            InformationToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip1.Size = new Size(855, 24);
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
            ExitToolTip.Click += ExitToolTip_Click;
            // 
            // 편집EToolStripMenuItem
            // 
            편집EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UndoToolTip, RedoToolTip, toolStripSeparator3, CutTextToolTip, CopyTextToolTip, PasteTextToolTip, DeleteTextToolTip, toolStripSeparator4, FindTextToolTip, FindNextToolTip, FindBeforeToolTip, ChangeTextToolTip, MoveTextToolTip, toolStripSeparator5, AllSelectTextToolTip, TimeTextToolTip });
            편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            편집EToolStripMenuItem.Size = new Size(57, 20);
            편집EToolStripMenuItem.Text = "편집(E)";
            // 
            // UndoToolTip
            // 
            UndoToolTip.Name = "UndoToolTip";
            UndoToolTip.ShortcutKeys = Keys.Control | Keys.Z;
            UndoToolTip.Size = new Size(179, 22);
            UndoToolTip.Text = "실행 취소";
            UndoToolTip.Click += DoCancleToolTip_Click;
            // 
            // RedoToolTip
            // 
            RedoToolTip.Name = "RedoToolTip";
            RedoToolTip.ShortcutKeys = Keys.Control | Keys.Y;
            RedoToolTip.Size = new Size(179, 22);
            RedoToolTip.Text = "실행 복구";
            RedoToolTip.Click += RedoToolTip_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(176, 6);
            // 
            // CutTextToolTip
            // 
            CutTextToolTip.Enabled = false;
            CutTextToolTip.Name = "CutTextToolTip";
            CutTextToolTip.ShortcutKeys = Keys.Control | Keys.X;
            CutTextToolTip.Size = new Size(179, 22);
            CutTextToolTip.Text = "잘라내기";
            CutTextToolTip.Click += CutTextToolTip_Click;
            // 
            // CopyTextToolTip
            // 
            CopyTextToolTip.Enabled = false;
            CopyTextToolTip.Name = "CopyTextToolTip";
            CopyTextToolTip.ShortcutKeys = Keys.Control | Keys.C;
            CopyTextToolTip.Size = new Size(179, 22);
            CopyTextToolTip.Text = "복사";
            CopyTextToolTip.Click += CopyTextToolTip_Click;
            // 
            // PasteTextToolTip
            // 
            PasteTextToolTip.Name = "PasteTextToolTip";
            PasteTextToolTip.ShortcutKeys = Keys.Control | Keys.V;
            PasteTextToolTip.Size = new Size(179, 22);
            PasteTextToolTip.Text = "붙여넣기";
            PasteTextToolTip.Click += PasteTextToolTip_Click;
            // 
            // DeleteTextToolTip
            // 
            DeleteTextToolTip.Enabled = false;
            DeleteTextToolTip.Name = "DeleteTextToolTip";
            DeleteTextToolTip.ShortcutKeys = Keys.Delete;
            DeleteTextToolTip.Size = new Size(179, 22);
            DeleteTextToolTip.Text = "삭제";
            DeleteTextToolTip.Click += DeleteTextToolTip_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(176, 6);
            // 
            // FindTextToolTip
            // 
            FindTextToolTip.Enabled = false;
            FindTextToolTip.Name = "FindTextToolTip";
            FindTextToolTip.ShortcutKeys = Keys.Control | Keys.F;
            FindTextToolTip.Size = new Size(179, 22);
            FindTextToolTip.Text = "찾기";
            FindTextToolTip.Click += FindTextToolTip_Click;
            // 
            // FindNextToolTip
            // 
            FindNextToolTip.Enabled = false;
            FindNextToolTip.Name = "FindNextToolTip";
            FindNextToolTip.ShortcutKeys = Keys.F3;
            FindNextToolTip.Size = new Size(179, 22);
            FindNextToolTip.Text = "다음 찾기";
            FindNextToolTip.Click += FindNextToolTip_Click;
            // 
            // FindBeforeToolTip
            // 
            FindBeforeToolTip.Enabled = false;
            FindBeforeToolTip.Name = "FindBeforeToolTip";
            FindBeforeToolTip.ShortcutKeys = Keys.Shift | Keys.F3;
            FindBeforeToolTip.Size = new Size(179, 22);
            FindBeforeToolTip.Text = "이전 찾기";
            FindBeforeToolTip.Click += FindBeforeToolTip_Click;
            // 
            // ChangeTextToolTip
            // 
            ChangeTextToolTip.Name = "ChangeTextToolTip";
            ChangeTextToolTip.ShortcutKeys = Keys.Control | Keys.H;
            ChangeTextToolTip.Size = new Size(179, 22);
            ChangeTextToolTip.Text = "바꾸기";
            ChangeTextToolTip.Click += ChangeTextToolTip_Click;
            // 
            // MoveTextToolTip
            // 
            MoveTextToolTip.Name = "MoveTextToolTip";
            MoveTextToolTip.ShortcutKeys = Keys.Control | Keys.G;
            MoveTextToolTip.Size = new Size(179, 22);
            MoveTextToolTip.Text = "이동";
            MoveTextToolTip.Click += MoveTextToolTip_Click;
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
            AllSelectTextToolTip.Click += AllSelectTextToolTip_Click;
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
            서식OToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AutoLineToolStripMenuItem, FontToolStripMenuItem });
            서식OToolStripMenuItem.Name = "서식OToolStripMenuItem";
            서식OToolStripMenuItem.Size = new Size(60, 20);
            서식OToolStripMenuItem.Text = "서식(O)";
            // 
            // AutoLineToolStripMenuItem
            // 
            AutoLineToolStripMenuItem.Name = "AutoLineToolStripMenuItem";
            AutoLineToolStripMenuItem.Size = new Size(138, 22);
            AutoLineToolStripMenuItem.Text = "자동 줄바꿈";
            AutoLineToolStripMenuItem.Click += AutoLineToolStripMenuItem_Click;
            // 
            // FontToolStripMenuItem
            // 
            FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            FontToolStripMenuItem.Size = new Size(138, 22);
            FontToolStripMenuItem.Text = "글꼴";
            FontToolStripMenuItem.Click += FontToolStripMenuItem_Click;
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
            확대하기축소하기ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ZoomINToolStripMenuItem, ZoomOutToolStripMenuItem, DefaultToolStripMenuItem });
            확대하기축소하기ToolStripMenuItem.Name = "확대하기축소하기ToolStripMenuItem";
            확대하기축소하기ToolStripMenuItem.Size = new Size(175, 22);
            확대하기축소하기ToolStripMenuItem.Text = "확대하기/축소하기";
            // 
            // ZoomINToolStripMenuItem
            // 
            ZoomINToolStripMenuItem.Name = "ZoomINToolStripMenuItem";
            ZoomINToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+더하기";
            ZoomINToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            ZoomINToolStripMenuItem.Size = new Size(282, 22);
            ZoomINToolStripMenuItem.Text = "확대";
            ZoomINToolStripMenuItem.Click += ZoomInToolStripMenuItem_Click;
            // 
            // ZoomOutToolStripMenuItem
            // 
            ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem";
            ZoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+빼기";
            ZoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            ZoomOutToolStripMenuItem.Size = new Size(282, 22);
            ZoomOutToolStripMenuItem.Text = "축소";
            ZoomOutToolStripMenuItem.Click += ZoomOutToolStripMenuItem_Click;
            // 
            // DefaultToolStripMenuItem
            // 
            DefaultToolStripMenuItem.Name = "DefaultToolStripMenuItem";
            DefaultToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            DefaultToolStripMenuItem.Size = new Size(282, 22);
            DefaultToolStripMenuItem.Text = "확대하기/축소하기 기본값으로";
            DefaultToolStripMenuItem.Click += DefaultToolStripMenuItem_Click;
            // 
            // 상태표시줄ToolStripMenuItem
            // 
            상태표시줄ToolStripMenuItem.Name = "상태표시줄ToolStripMenuItem";
            상태표시줄ToolStripMenuItem.Size = new Size(175, 22);
            상태표시줄ToolStripMenuItem.Text = "상태 표시줄";
            // 
            // 도움말HToolStripMenuItem
            // 
            도움말HToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { QAToolStripMenuItem, InformationToolStripMenuItem });
            도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            도움말HToolStripMenuItem.Size = new Size(72, 20);
            도움말HToolStripMenuItem.Text = "도움말(H)";
            // 
            // QAToolStripMenuItem
            // 
            QAToolStripMenuItem.Name = "QAToolStripMenuItem";
            QAToolStripMenuItem.Size = new Size(180, 22);
            QAToolStripMenuItem.Text = "도움말 보기";
            QAToolStripMenuItem.Click += QAToolStripMenuItem_Click;
            // 
            // InformationToolStripMenuItem
            // 
            InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
            InformationToolStripMenuItem.Size = new Size(180, 22);
            InformationToolStripMenuItem.Text = "메모장 정보";
            InformationToolStripMenuItem.Click += InformationToolStripMenuItem_Click;
            // 
            // MyTextArea
            // 
            MyTextArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MyTextArea.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            MyTextArea.Location = new Point(0, 27);
            MyTextArea.Name = "MyTextArea";
            MyTextArea.Size = new Size(855, 477);
            MyTextArea.TabIndex = 1;
            MyTextArea.Text = "";
            MyTextArea.WordWrap = false;
            MyTextArea.SelectionChanged += MyTextArea_SelectionChanged;
            MyTextArea.TextChanged += MyTextArea_TextChanged;
            MyTextArea.MouseWheel += 메모장_MouseWheel;
            // 
            // 메모장
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(855, 503);
            Controls.Add(MyTextArea);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "메모장";
            Text = "제목없음 - 내가만든메모장";
            FormClosing += 메모장_FormClosing;
            FormClosed += 메모장_FormClosed;
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
        private ToolStripMenuItem UndoToolTip;
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
        private ToolStripMenuItem AutoLineToolStripMenuItem;
        private ToolStripMenuItem FontToolStripMenuItem;
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
        private ToolStripMenuItem RedoToolTip;
        public RichTextBox MyTextArea;
        private ToolStripMenuItem ZoomINToolStripMenuItem;
        private ToolStripMenuItem ZoomOutToolStripMenuItem;
        private ToolStripMenuItem DefaultToolStripMenuItem;
        private ToolStripMenuItem QAToolStripMenuItem;
        private ToolStripMenuItem InformationToolStripMenuItem;
    }
}
