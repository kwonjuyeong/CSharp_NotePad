namespace MyTextEditor
{
    partial class Form1
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
            새파일ToolStripMenuItem = new ToolStripMenuItem();
            새창ToolStripMenuItem = new ToolStripMenuItem();
            열기ToolStripMenuItem = new ToolStripMenuItem();
            저장ToolStripMenuItem = new ToolStripMenuItem();
            다른이름으로저장ToolStripMenuItem = new ToolStripMenuItem();
            페이지설정ToolStripMenuItem = new ToolStripMenuItem();
            인쇄ToolStripMenuItem = new ToolStripMenuItem();
            끝내기ToolStripMenuItem = new ToolStripMenuItem();
            편집EToolStripMenuItem = new ToolStripMenuItem();
            실행취소ToolStripMenuItem = new ToolStripMenuItem();
            잘라내기ToolStripMenuItem = new ToolStripMenuItem();
            복사ToolStripMenuItem = new ToolStripMenuItem();
            붙여넣기ToolStripMenuItem = new ToolStripMenuItem();
            삭제ToolStripMenuItem = new ToolStripMenuItem();
            찾기ToolStripMenuItem = new ToolStripMenuItem();
            다음찾기ToolStripMenuItem = new ToolStripMenuItem();
            이전찾기ToolStripMenuItem = new ToolStripMenuItem();
            바꾸기ToolStripMenuItem = new ToolStripMenuItem();
            이동ToolStripMenuItem = new ToolStripMenuItem();
            모두선택ToolStripMenuItem = new ToolStripMenuItem();
            시간날짜ToolStripMenuItem = new ToolStripMenuItem();
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
            도구OToolStripMenuItem = new ToolStripMenuItem();
            bindingSource1 = new BindingSource(components);
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripSeparator5 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, 편집EToolStripMenuItem, 서식OToolStripMenuItem, 보기VToolStripMenuItem, 도움말HToolStripMenuItem, 도구OToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 새파일ToolStripMenuItem, 새창ToolStripMenuItem, 열기ToolStripMenuItem, 저장ToolStripMenuItem, 다른이름으로저장ToolStripMenuItem, toolStripSeparator1, 페이지설정ToolStripMenuItem, 인쇄ToolStripMenuItem, toolStripSeparator2, 끝내기ToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(57, 20);
            fileToolStripMenuItem.Text = "파일(F)";
            // 
            // 새파일ToolStripMenuItem
            // 
            새파일ToolStripMenuItem.Name = "새파일ToolStripMenuItem";
            새파일ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            새파일ToolStripMenuItem.Size = new Size(252, 22);
            새파일ToolStripMenuItem.Text = "새 파일";
            // 
            // 새창ToolStripMenuItem
            // 
            새창ToolStripMenuItem.Name = "새창ToolStripMenuItem";
            새창ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            새창ToolStripMenuItem.Size = new Size(252, 22);
            새창ToolStripMenuItem.Text = "새 창";
            // 
            // 열기ToolStripMenuItem
            // 
            열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            열기ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            열기ToolStripMenuItem.Size = new Size(252, 22);
            열기ToolStripMenuItem.Text = "열기";
            // 
            // 저장ToolStripMenuItem
            // 
            저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            저장ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            저장ToolStripMenuItem.Size = new Size(180, 22);
            저장ToolStripMenuItem.Text = "저장";
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            다른이름으로저장ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            다른이름으로저장ToolStripMenuItem.Size = new Size(252, 22);
            다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
            // 
            // 페이지설정ToolStripMenuItem
            // 
            페이지설정ToolStripMenuItem.Name = "페이지설정ToolStripMenuItem";
            페이지설정ToolStripMenuItem.Size = new Size(252, 22);
            페이지설정ToolStripMenuItem.Text = "페이지 설정";
            // 
            // 인쇄ToolStripMenuItem
            // 
            인쇄ToolStripMenuItem.Name = "인쇄ToolStripMenuItem";
            인쇄ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            인쇄ToolStripMenuItem.Size = new Size(252, 22);
            인쇄ToolStripMenuItem.Text = "인쇄";
            // 
            // 끝내기ToolStripMenuItem
            // 
            끝내기ToolStripMenuItem.Name = "끝내기ToolStripMenuItem";
            끝내기ToolStripMenuItem.Size = new Size(180, 22);
            끝내기ToolStripMenuItem.Text = "끝내기";
            // 
            // 편집EToolStripMenuItem
            // 
            편집EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 실행취소ToolStripMenuItem, toolStripSeparator3, 잘라내기ToolStripMenuItem, 복사ToolStripMenuItem, 붙여넣기ToolStripMenuItem, 삭제ToolStripMenuItem, toolStripSeparator4, 찾기ToolStripMenuItem, 다음찾기ToolStripMenuItem, 이전찾기ToolStripMenuItem, 바꾸기ToolStripMenuItem, 이동ToolStripMenuItem, toolStripSeparator5, 모두선택ToolStripMenuItem, 시간날짜ToolStripMenuItem });
            편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            편집EToolStripMenuItem.Size = new Size(57, 20);
            편집EToolStripMenuItem.Text = "편집(E)";
            // 
            // 실행취소ToolStripMenuItem
            // 
            실행취소ToolStripMenuItem.Name = "실행취소ToolStripMenuItem";
            실행취소ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            실행취소ToolStripMenuItem.Size = new Size(180, 22);
            실행취소ToolStripMenuItem.Text = "실행 취소";
            // 
            // 잘라내기ToolStripMenuItem
            // 
            잘라내기ToolStripMenuItem.Name = "잘라내기ToolStripMenuItem";
            잘라내기ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            잘라내기ToolStripMenuItem.Size = new Size(180, 22);
            잘라내기ToolStripMenuItem.Text = "잘라내기";
            // 
            // 복사ToolStripMenuItem
            // 
            복사ToolStripMenuItem.Name = "복사ToolStripMenuItem";
            복사ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            복사ToolStripMenuItem.Size = new Size(180, 22);
            복사ToolStripMenuItem.Text = "복사";
            // 
            // 붙여넣기ToolStripMenuItem
            // 
            붙여넣기ToolStripMenuItem.Name = "붙여넣기ToolStripMenuItem";
            붙여넣기ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            붙여넣기ToolStripMenuItem.Size = new Size(180, 22);
            붙여넣기ToolStripMenuItem.Text = "붙여넣기";
            // 
            // 삭제ToolStripMenuItem
            // 
            삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            삭제ToolStripMenuItem.ShortcutKeys = Keys.Delete;
            삭제ToolStripMenuItem.Size = new Size(180, 22);
            삭제ToolStripMenuItem.Text = "삭제";
            // 
            // 찾기ToolStripMenuItem
            // 
            찾기ToolStripMenuItem.Name = "찾기ToolStripMenuItem";
            찾기ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            찾기ToolStripMenuItem.Size = new Size(180, 22);
            찾기ToolStripMenuItem.Text = "찾기";
            // 
            // 다음찾기ToolStripMenuItem
            // 
            다음찾기ToolStripMenuItem.Name = "다음찾기ToolStripMenuItem";
            다음찾기ToolStripMenuItem.ShortcutKeys = Keys.F3;
            다음찾기ToolStripMenuItem.Size = new Size(180, 22);
            다음찾기ToolStripMenuItem.Text = "다음 찾기";
            // 
            // 이전찾기ToolStripMenuItem
            // 
            이전찾기ToolStripMenuItem.Name = "이전찾기ToolStripMenuItem";
            이전찾기ToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F3;
            이전찾기ToolStripMenuItem.Size = new Size(180, 22);
            이전찾기ToolStripMenuItem.Text = "이전 찾기";
            // 
            // 바꾸기ToolStripMenuItem
            // 
            바꾸기ToolStripMenuItem.Name = "바꾸기ToolStripMenuItem";
            바꾸기ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.H;
            바꾸기ToolStripMenuItem.Size = new Size(180, 22);
            바꾸기ToolStripMenuItem.Text = "바꾸기";
            // 
            // 이동ToolStripMenuItem
            // 
            이동ToolStripMenuItem.Name = "이동ToolStripMenuItem";
            이동ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            이동ToolStripMenuItem.Size = new Size(180, 22);
            이동ToolStripMenuItem.Text = "이동";
            // 
            // 모두선택ToolStripMenuItem
            // 
            모두선택ToolStripMenuItem.Name = "모두선택ToolStripMenuItem";
            모두선택ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            모두선택ToolStripMenuItem.Size = new Size(180, 22);
            모두선택ToolStripMenuItem.Text = "모두 선택";
            // 
            // 시간날짜ToolStripMenuItem
            // 
            시간날짜ToolStripMenuItem.Name = "시간날짜ToolStripMenuItem";
            시간날짜ToolStripMenuItem.ShortcutKeys = Keys.F5;
            시간날짜ToolStripMenuItem.Size = new Size(180, 22);
            시간날짜ToolStripMenuItem.Text = "시간/날짜";
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
            // 도구OToolStripMenuItem
            // 
            도구OToolStripMenuItem.Name = "도구OToolStripMenuItem";
            도구OToolStripMenuItem.Size = new Size(60, 20);
            도구OToolStripMenuItem.Text = "도구(O)";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(249, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(249, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(177, 6);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(177, 6);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
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
        private ToolStripMenuItem 새파일ToolStripMenuItem;
        private ToolStripMenuItem 새창ToolStripMenuItem;
        private ToolStripMenuItem 열기ToolStripMenuItem;
        private ToolStripMenuItem 저장ToolStripMenuItem;
        private ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private ToolStripMenuItem 페이지설정ToolStripMenuItem;
        private ToolStripMenuItem 인쇄ToolStripMenuItem;
        private ToolStripMenuItem 끝내기ToolStripMenuItem;
        private ToolStripMenuItem 편집EToolStripMenuItem;
        private ToolStripMenuItem 서식OToolStripMenuItem;
        private ToolStripMenuItem 보기VToolStripMenuItem;
        private ToolStripMenuItem 도움말HToolStripMenuItem;
        private ToolStripMenuItem 도구OToolStripMenuItem;
        private ToolStripMenuItem 실행취소ToolStripMenuItem;
        private ToolStripMenuItem 잘라내기ToolStripMenuItem;
        private ToolStripMenuItem 복사ToolStripMenuItem;
        private ToolStripMenuItem 붙여넣기ToolStripMenuItem;
        private ToolStripMenuItem 삭제ToolStripMenuItem;
        private ToolStripMenuItem 찾기ToolStripMenuItem;
        private ToolStripMenuItem 다음찾기ToolStripMenuItem;
        private ToolStripMenuItem 이전찾기ToolStripMenuItem;
        private ToolStripMenuItem 바꾸기ToolStripMenuItem;
        private ToolStripMenuItem 이동ToolStripMenuItem;
        private ToolStripMenuItem 모두선택ToolStripMenuItem;
        private ToolStripMenuItem 시간날짜ToolStripMenuItem;
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
    }
}
