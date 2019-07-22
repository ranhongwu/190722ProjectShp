namespace DataSwitch
{
    partial class FrmProjTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProjTrans));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txBxInputCoordination = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txBxOutputPath = new DevExpress.XtraEditors.TextEdit();
            this.btnChoosePath = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txbxOutputCoordination = new DevExpress.XtraEditors.TextEdit();
            this.btnChooseCoordination = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnExcute = new DevExpress.XtraEditors.SimpleButton();
            this.comBxInputFeaClass = new System.Windows.Forms.ComboBox();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txBxInputCoordination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txBxOutputPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbxOutputCoordination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(12, 406);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "选择要素：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 84);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "输入要素坐标系：";
            // 
            // txBxInputCoordination
            // 
            this.txBxInputCoordination.Location = new System.Drawing.Point(120, 81);
            this.txBxInputCoordination.Name = "txBxInputCoordination";
            this.txBxInputCoordination.Size = new System.Drawing.Size(311, 20);
            this.txBxInputCoordination.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 138);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "输出要素：";
            // 
            // txBxOutputPath
            // 
            this.txBxOutputPath.Location = new System.Drawing.Point(120, 135);
            this.txBxOutputPath.Name = "txBxOutputPath";
            this.txBxOutputPath.Size = new System.Drawing.Size(268, 20);
            this.txBxOutputPath.TabIndex = 6;
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(394, 134);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(37, 23);
            this.btnChoosePath.TabIndex = 7;
            this.btnChoosePath.Text = "浏览";
            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 194);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "输出坐标系：";
            // 
            // txbxOutputCoordination
            // 
            this.txbxOutputCoordination.Location = new System.Drawing.Point(120, 191);
            this.txbxOutputCoordination.Name = "txbxOutputCoordination";
            this.txbxOutputCoordination.Size = new System.Drawing.Size(246, 20);
            this.txbxOutputCoordination.TabIndex = 9;
            // 
            // btnChooseCoordination
            // 
            this.btnChooseCoordination.Location = new System.Drawing.Point(372, 188);
            this.btnChooseCoordination.Name = "btnChooseCoordination";
            this.btnChooseCoordination.Size = new System.Drawing.Size(70, 26);
            this.btnChooseCoordination.TabIndex = 10;
            this.btnChooseCoordination.Text = "选择坐标系";
            this.btnChooseCoordination.Click += new System.EventHandler(this.btnChooseCoordination_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.unit,
            this.Values});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(424, 118);
            this.dataGridView1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 144);
            this.panel1.TabIndex = 12;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(96, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "坐标转换七参数：";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(356, 406);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 13;
            this.btnExcute.Text = "确定";
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // comBxInputFeaClass
            // 
            this.comBxInputFeaClass.FormattingEnabled = true;
            this.comBxInputFeaClass.Location = new System.Drawing.Point(120, 28);
            this.comBxInputFeaClass.Name = "comBxInputFeaClass";
            this.comBxInputFeaClass.Size = new System.Drawing.Size(311, 22);
            this.comBxInputFeaClass.TabIndex = 14;
            this.comBxInputFeaClass.SelectedIndexChanged += new System.EventHandler(this.comBxInputFeaClass_SelectedIndexChanged);
            // 
            // Items
            // 
            this.Items.HeaderText = "项目";
            this.Items.Name = "Items";
            this.Items.ReadOnly = true;
            this.Items.Width = 120;
            // 
            // unit
            // 
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // Values
            // 
            this.Values.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Values.HeaderText = "值";
            this.Values.Name = "Values";
            this.Values.Width = 130;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(225, 406);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmProjTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 451);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.comBxInputFeaClass);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnChooseCoordination);
            this.Controls.Add(this.txbxOutputCoordination);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnChoosePath);
            this.Controls.Add(this.txBxOutputPath);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txBxInputCoordination);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "FrmProjTrans";
            this.Text = "坐标转换";
            this.Load += new System.EventHandler(this.FrmProjTrans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txBxInputCoordination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txBxOutputPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbxOutputCoordination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txBxInputCoordination;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txBxOutputPath;
        private DevExpress.XtraEditors.SimpleButton btnChoosePath;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txbxOutputCoordination;
        private DevExpress.XtraEditors.SimpleButton btnChooseCoordination;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnExcute;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ComboBox comBxInputFeaClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}