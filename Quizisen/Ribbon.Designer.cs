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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainTab.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.mainTab.Groups.Add(this.group1);
            this.mainTab.Label = "Quizisen";
            this.mainTab.Name = "mainTab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.parse);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // parse
            // 
            this.parse.Label = "Parse!";
            this.parse.Name = "parse";
            this.parse.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.parse_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "MoodleXML | .xml";
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

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab mainTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton parse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
