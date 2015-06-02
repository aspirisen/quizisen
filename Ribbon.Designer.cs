namespace Quizisen
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.parse = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.markAsRightAnswer = this.Factory.CreateRibbonButton();
            this.markAsWrongAnswer = this.Factory.CreateRibbonButton();
            this.box2 = this.Factory.CreateRibbonBox();
            this.markAsChoiceQuestion = this.Factory.CreateRibbonButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainTab.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.box1.SuspendLayout();
            this.box2.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.mainTab.Groups.Add(this.group1);
            this.mainTab.Groups.Add(this.group2);
            this.mainTab.Label = "Quizisen";
            this.mainTab.Name = "mainTab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.parse);
            this.group1.Label = "Файл";
            this.group1.Name = "group1";
            // 
            // parse
            // 
            this.parse.Label = "Сохранить Как";
            this.parse.Name = "parse";
            this.parse.OfficeImageId = "FileSaveAs";
            this.parse.ShowImage = true;
            this.parse.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.parse_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.box1);
            this.group2.Items.Add(this.box2);
            this.group2.Label = "Вопросы";
            this.group2.Name = "group2";
            // 
            // box1
            // 
            this.box1.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box1.Items.Add(this.markAsRightAnswer);
            this.box1.Items.Add(this.markAsWrongAnswer);
            this.box1.Name = "box1";
            // 
            // markAsRightAnswer
            // 
            this.markAsRightAnswer.Label = "Верный ответ";
            this.markAsRightAnswer.Name = "markAsRightAnswer";
            this.markAsRightAnswer.ShowImage = true;
            this.markAsRightAnswer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.markAsRightAnswer_Click);
            // 
            // markAsWrongAnswer
            // 
            this.markAsWrongAnswer.Label = "Неверный ответ";
            this.markAsWrongAnswer.Name = "markAsWrongAnswer";
            this.markAsWrongAnswer.ShowImage = true;
            this.markAsWrongAnswer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.markAsWrongAnswer_Click);
            // 
            // box2
            // 
            this.box2.Items.Add(this.markAsChoiceQuestion);
            this.box2.Name = "box2";
            // 
            // markAsChoiceQuestion
            // 
            this.markAsChoiceQuestion.Label = "Множественный \\ Одиночный выбор";
            this.markAsChoiceQuestion.Name = "markAsChoiceQuestion";
            this.markAsChoiceQuestion.ShowImage = true;
            this.markAsChoiceQuestion.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.markAsChoiceQuestion_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "MoodleXML | *.xml";
            this.saveFileDialog.Title = "Save Moodle XML";
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.mainTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab mainTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton parse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton markAsRightAnswer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton markAsWrongAnswer;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton markAsChoiceQuestion;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
