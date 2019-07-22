using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;
using System.IO;

namespace DataSwitch
{
    /// <summary>
    /// 数据管理基础类，提供shp文件创建、空间参考获取及文件操作的方法
    /// </summary>
    class DataManager
    {
        /// <summary>
        /// 创建新的shapefile文件
        /// </summary>
        /// <param name="path">建立空白shp的路径</param>
        /// <param name="name">建立shp的文件名</param>
        /// <param name="fields">待建立shp的字段</param>
        /// <param name="spatialReference">待建立shp的空间参考</param>
        /// <returns>返回建立的FeatureClass</returns>
        public IFeatureClass CreateVoidShp(string path,string name,IFields fields,ISpatialReference spatialReference)
        {
            IFeatureClass pFeatureClass;
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(path, 0) as IFeatureWorkspace;

            //注意：用CreateFeatureClass()方法时应该特别注意fields参数是否含有几何信息，如空间参考，几何类型等
            pFeatureClass = pFeatureWorkspace.CreateFeatureClass(name, fields, null, null, esriFeatureType.esriFTSimple, "shape", "");
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            IGeoDatasetSchemaEdit pGeoDatasetSchemaEdit = pGeoDataset as IGeoDatasetSchemaEdit;
            pGeoDatasetSchemaEdit.AlterSpatialReference(spatialReference);
            pFeatureClass = pFeatureWorkspace.OpenFeatureClass(name);
            return pFeatureClass;
        }
        
        /// <summary>
        /// 获取featureclass的空间参考
        /// </summary>
        /// <param name="pFeatureClass">待获取空间参考的FeatureClass</param>
        /// <returns>返回pFeatureClass的空间参考</returns>
        public static ISpatialReference getSpatialReference(IFeatureClass pFeatureClass)
        {
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            return pGeoDataset.SpatialReference;
        }
        
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="path">新建文件夹的路径</param>
        /// <param name="folderName">新建文件夹的名称</param>
        public static void NewFolder(string path,string folderName)
        {
            if (!Directory.Exists(path+"\\"+folderName))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(path,folderName));
            }
        }
    }
}