
namespace DMONET
{
    partial class BO2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement7 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement9 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement8 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement6 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.statTimer = new System.Windows.Forms.Timer(this.components);
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.panelControl1);
            this.fluentDesignFormContainer1.Controls.Add(this.accordionControl1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 30);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(858, 494);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(169, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(689, 494);
            this.panelControl1.TabIndex = 4;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barHeaderItem1});
            this.fluentFormDefaultManager1.MaxItemId = 2;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Connection:";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.barHeaderItem1.Appearance.Options.UseForeColor = true;
            this.barHeaderItem1.Caption = "IDLE";
            this.barHeaderItem1.Id = 1;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement3,
            this.accordionControlElement5});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(169, 494);
            this.accordionControl1.TabIndex = 3;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement4});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Console Functions";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Connect";
            this.accordionControlElement2.Click += new System.EventHandler(this.accordionControlElement2_Click);
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Take Screenshot";
            this.accordionControlElement4.Click += new System.EventHandler(this.accordionControlElement4_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement7,
            this.accordionControlElement9,
            this.accordionControlElement8});
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Pages";
            // 
            // accordionControlElement7
            // 
            this.accordionControlElement7.Name = "accordionControlElement7";
            this.accordionControlElement7.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement7.Text = "Multiplayer";
            // 
            // accordionControlElement9
            // 
            this.accordionControlElement9.Name = "accordionControlElement9";
            this.accordionControlElement9.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement9.Text = "Recovery";
            this.accordionControlElement9.Click += new System.EventHandler(this.accordionControlElement9_Click);
            // 
            // accordionControlElement8
            // 
            this.accordionControlElement8.Name = "accordionControlElement8";
            this.accordionControlElement8.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement8.Text = "Zombies";
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement6});
            this.accordionControlElement5.Expanded = true;
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Text = "Other Functions";
            this.accordionControlElement5.Click += new System.EventHandler(this.accordionControlElement5_Click);
            // 
            // accordionControlElement6
            // 
            this.accordionControlElement6.Name = "accordionControlElement6";
            this.accordionControlElement6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement6.Text = "Restart Current Game";
            this.accordionControlElement6.Click += new System.EventHandler(this.accordionControlElement6_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barHeaderItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(858, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem1);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barHeaderItem1);
            // 
            // statTimer
            // 
            this.statTimer.Interval = 5000;
            this.statTimer.Tick += new System.EventHandler(this.statTimer_Tick);
            // 
            // BO2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 524);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "BO2";
            this.Text = "BO2";
            this.Load += new System.EventHandler(this.BO2_Load);
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement7;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement9;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement8;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement6;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private System.Windows.Forms.Timer statTimer;
    }
}