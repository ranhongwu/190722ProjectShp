using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.CatalogUI;

namespace DataSwitch
{
    public partial class FrmProjTrans : DevExpress.XtraEditors.XtraForm
    {
        public FrmProjTrans()
        {
            InitializeComponent();
        }

        IWorkspaceFactory pWorkspaceFactory;
        IFeatureWorkspace pFeatureWorkspace;
        IFeatureClass inFeatureClass;
        string inputFeatureName,saveShpName,saveShpPath;

        //此处为测试代码
        string OpenShpPath = "C:\\Users\\rhw\\Desktop\\test";
        //--------------

        ISpatialReference outSpatialReference;

        //窗体加载时遍历工作空间，初始化输入要素类下拉框的列表
        private void FrmProjTrans_Load(object sender, EventArgs e)
        {
            //初始化选择要素集
            //此处为测试工作空间
            pWorkspaceFactory = new ShapefileWorkspaceFactory();
            pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(OpenShpPath, 0) as IFeatureWorkspace;
            IWorkspace pWorkspace = pFeatureWorkspace as IWorkspace;

            List<IFeatureClass> featureClassList = new List<IFeatureClass>();
            List<string> FeatureNameList = new List<string>();
            IEnumDataset pEnumDs = pWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            IDataset pDS;
            while ((pDS= pEnumDs.Next()) != null)
            {
                FeatureNameList.Add(pDS.Name);
                featureClassList.Add(pFeatureWorkspace.OpenFeatureClass(pDS.Name));
            }
            for(int i = 0; i < featureClassList.Count; i++)
            {
                comBxInputFeaClass.Items.Add(FeatureNameList[i]);
            }

            //初始化datagridview控件
            dataGridView1.Rows.Add("X方向平移量","米","0");
            dataGridView1.Rows.Add("Y方向平移量", "米", "0");
            dataGridView1.Rows.Add("Z方向平移量", "米", "0");
            dataGridView1.Rows.Add("X方向旋转角度", "秒", "0");
            dataGridView1.Rows.Add("Y方向旋转角度", "秒", "0");
            dataGridView1.Rows.Add("Z方向旋转角度", "秒", "0");
            dataGridView1.Rows.Add("比例尺差", "%", "0");
        }

        //执行坐标转换
        private void btnExcute_Click(object sender, EventArgs e)
        {
            double Tx, Ty, Tz, Rx, Ry, Rz, SD;
            Tx = Convert.ToDouble(dataGridView1[2, 0].Value);
            Ty = Convert.ToDouble(dataGridView1[2, 1].Value);
            Tz = Convert.ToDouble(dataGridView1[2, 2].Value);
            Rx = Convert.ToDouble(dataGridView1[2, 3].Value);
            Ry = Convert.ToDouble(dataGridView1[2, 4].Value);
            Rz = Convert.ToDouble(dataGridView1[2, 5].Value);
            SD = Convert.ToDouble(dataGridView1[2, 6].Value);
            SpatialRefConversion SRConversion = new SpatialRefConversion(inFeatureClass, outSpatialReference, Tx, Ty, Tz, Rx, Ry, Rz, SD);
            SRConversion.SpatialRefTrans(saveShpName, saveShpPath);
        }

        private void btnChooseCoordination_Click(object sender, EventArgs e)
        {
            
            ISpatialReferenceDialog2 pSRDialog = new SpatialReferenceDialogClass();
            outSpatialReference = pSRDialog.DoModalCreate(true, false, false,0);
            string strSRName = outSpatialReference.Name;
            txbxOutputCoordination.Text = strSRName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择下拉框项目时，自动填充初始坐标系
        private void comBxInputFeaClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txBxInputCoordination.Enabled = true;
            ISpatialReference pSpatialReference;
            IGeoDataset pGeoDataset;

            inputFeatureName = comBxInputFeaClass.Text;
            inFeatureClass = pFeatureWorkspace.OpenFeatureClass(inputFeatureName);
            pGeoDataset = inFeatureClass as IGeoDataset;
            pSpatialReference = pGeoDataset.SpatialReference;
            txBxInputCoordination.Text = pSpatialReference.Name;
            txBxInputCoordination.Enabled = false;
        }

        //点击选择保存路径时弹出文件保存对话框
        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            string fullPath;
            SaveFileDialog DialogSaveShpPath = new SaveFileDialog();
            DialogSaveShpPath.Title = "保存要素类";
            DialogSaveShpPath.Filter = "shp文件(*.shp) | *.shp";
            DialogSaveShpPath.OverwritePrompt = false;
            if (DialogSaveShpPath.ShowDialog() == DialogResult.OK)
            {
                fullPath = DialogSaveShpPath.FileName;
                int i = fullPath.LastIndexOf("\\");
                saveShpPath = fullPath.Substring(0,i);
                saveShpName = fullPath.Substring(i+1);
                txBxOutputPath.Text = fullPath;
            }
        }
    }
}