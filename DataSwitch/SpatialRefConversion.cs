
/*
 * Class：SpatialRefConversion
 * Namespace：DataSwitch
 * Author: Ran Hongwu
 * Date: 2019/07/19
 * Description: 转换要素类的空间参考系，生成新的要素类文件（*.shp）
 * Alter History：
 *      version     |Date           |Log
 *      -----------------------------------------------------------
 *      v1.0        |2019/07/19     |
 *      -----------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace DataSwitch
{
    /// <summary>
    /// 空间参考转换类，转换现要素的空间参考，生成新的shp文件
    /// </summary>
    class SpatialRefConversion
    {
        #region 定义变量
        private string TransName;
        private ISpatialReference spatialRefFrom;
        private ISpatialReference spatialRefTo;
        //坐标转换七参数
        private double Tx,Ty,Tz,Rx,Ry,Rz,SD;
        private IFeatureClass inFeatureClass, outFeatureClass;
        //坐标变换接口
        IGeoTransformation geoTransformation;
        #endregion


        #region 构造函数
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="pFeatureClass">待转换的要素类</param>
        /// <param name="poutFeatureClass">导出的要素类</param>
        /// <param name="pSpatialRefTo"></param>
        /// <param name="pTx">坐标转换七参数Tx</param>
        /// <param name="pTy">坐标转换七参数Ty</param>
        /// <param name="pTz">坐标转换七参数Tz</param>
        /// <param name="pRx">坐标转换七参数Rx</param>
        /// <param name="pRy">坐标转换七参数Ry</param>
        /// <param name="pRz">坐标转换七参数Rz</param>
        /// <param name="pSD">坐标转换七参数SD</param>
        public SpatialRefConversion(IFeatureClass pFeatureClass,ISpatialReference pSpatialRefTo,
            double pTx,double pTy,double pTz ,double pRx,double pRy,double pRz,double pSD)
        {
            inFeatureClass = pFeatureClass;
            //outFeatureClass = poutFeatureClass;
            TransName = "TransferName";
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            spatialRefFrom = pGeoDataset.SpatialReference;
            spatialRefTo = pSpatialRefTo;
            Tx = pTx;
            Ty = pTy;
            Tz = pTz;
            Rx = pRx;
            Ry = pRy;
            Rz = pRz;
            SD = pSD; 
        }
        #endregion


        #region 集成方法，在前端直接调用
        /// <summary>
        /// 转换要素类的坐标系
        /// </summary>
        /// <param name="fileName">目标要素类的名字</param>
        /// <param name="savePath">存储目标要素类的路径</param>
        public void SpatialRefTrans(string fileName,string savePath)
        {
                                                                                                    //三个步骤完成坐标系的转换
            outFeatureClass = CreateNewShpFile(inFeatureClass, fileName, savePath, spatialRefTo);   //step.1 建立空的shpfile，以提供复制要素的空间
            geoTransformation = CreateSpatialRefTrans();                                            //step.2 创建坐标转换接口,为IGeometry2接口的ProjectEx()方法提供转换参数
            featureClassTransSpatialRef(inFeatureClass, outFeatureClass);                           //step.3 遍历待复制的要素类，复制图形和属性并改变图形的坐标系
        }
        #endregion


        #region 工具方法，在集成方法中调用
        //step.1 建立空的shpfile，以提供复制要素的空间
        /// <summary>
        /// 建立空的shpfile，以提供复制要素的空间
        /// </summary>
        /// <param name="FromfeatureClass">待转换的要素类</param>
        /// <param name="name">待建立空shp文件名</param>
        /// <param name="savePath">存储空shp文件的路径</param>
        /// <param name="spatialReference">新建shp文件的空间参考（目标坐标系）</param>
        /// <returns>返回建立空shp的要素类</returns>
        private IFeatureClass CreateNewShpFile(IFeatureClass FromfeatureClass, string name, string savePath, ISpatialReference spatialReference)
        {
            IFeatureClass pFeatureClass;
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            string s = FromfeatureClass.ShapeType.ToString();

            //定义属性字段
            DataManager DM = new DataManager();
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = (IFieldEdit)pField;

            //设置地理属性字段，点线面，空间参考等
            pFieldEdit.Name_2 = "shape";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef pGeoDef = new GeometryDefClass();
            IGeometryDefEdit pGeoDefEdit = pGeoDef as IGeometryDefEdit;
            pGeoDefEdit.GeometryType_2 = FromfeatureClass.ShapeType;
            pGeoDefEdit.SpatialReference_2 = spatialReference;
            pGeoDefEdit.HasM_2 = true;
            pGeoDefEdit.HasZ_2 = true;
            pFieldEdit.GeometryDef_2 = pGeoDef;
            pFieldsEdit.AddField(pField);

            //遍历各字段设置其他属性字段
            for (int i = 2; i < FromfeatureClass.Fields.FieldCount; i++)
            {
                pField = new FieldClass();
                pFieldEdit = (IFieldEdit)pField;
                pFieldEdit.Name_2 = FromfeatureClass.Fields.Field[i].Name;
                pFieldEdit.AliasName_2 = FromfeatureClass.Fields.Field[i].AliasName;
                pFieldEdit.Type_2 = FromfeatureClass.Fields.Field[i].Type;
                pFieldsEdit.AddField(pField);
            }
            //建立空的shapefile
            pFeatureClass = DM.CreateVoidShp(savePath, name, pFields, spatialReference);
            return pFeatureClass;
        }

        //step.2 创建坐标转换接口,为IGeometry2接口的ProjectEx()方法提供转换参数
        /// <summary>
        /// 创建坐标转换接口,为IGeometry2接口的ProjectEx()方法提供转换参数
        /// </summary>
        /// <returns>返回根据坐标转换参数创建的坐标转换接口</returns>
        private IGeoTransformation CreateSpatialRefTrans()
        {
            //转换和待转换的坐标系
            IGeographicCoordinateSystem pGeoCoordSysFrom = (spatialRefFrom as IProjectedCoordinateSystem).GeographicCoordinateSystem;
            IGeographicCoordinateSystem pGeoCoordSysTo = (spatialRefTo as IProjectedCoordinateSystem).GeographicCoordinateSystem;
            //定义转换参数
            ICoordinateFrameTransformation pCoordinateFrameTrans = new CoordinateFrameTransformationClass();
            pCoordinateFrameTrans.PutParameters(Tx,Ty,Tz,Rx,Ry,Rz,SD);
            pCoordinateFrameTrans.PutSpatialReferences(pGeoCoordSysFrom, pGeoCoordSysTo);
            pCoordinateFrameTrans.Name = TransName;
            //geoTransformationOperationSet.Set(esriTransformDirection.esriTransformForward, pCoordinateFrameTrans);
            geoTransformation = pCoordinateFrameTrans as IGeoTransformation;
            return geoTransformation;
        }

        //step.3 遍历待复制的要素类，复制图形和属性并改变图形的坐标系
        /// <summary>
        /// 遍历待复制的要素类，复制图形和属性并改变图形的坐标系
        /// </summary>
        /// <param name="fromFeatureClass">待复制的要素类</param>
        /// <param name="toFeatureClass">目标要素类</param>
        private void featureClassTransSpatialRef(IFeatureClass fromFeatureClass,IFeatureClass toFeatureClass)
        {
            IFeature pFeature;
            IGeometry2 pGeometry;
            IFeatureCursor toCursor = toFeatureClass.Insert(true);
            int FeatureCount = fromFeatureClass.FeatureCount(null);
            for (int i = 0; i < FeatureCount; i++)
            {
                pFeature = fromFeatureClass.GetFeature(i);
                pGeometry = pFeature.Shape as IGeometry2;
                IZAware pZAware = pGeometry as IZAware;
                pZAware.ZAware = true;
                pGeometry.ProjectEx(spatialRefTo, esriTransformDirection.esriTransformForward, geoTransformation, false, 0, 0);
                IFeatureBuffer pFeaBuffer = toFeatureClass.CreateFeatureBuffer();
                pFeaBuffer.Shape = pGeometry;
                for (int j = 2; j < fromFeatureClass.Fields.FieldCount; j++)
                {
                    try
                    {
                        pFeaBuffer.set_Value(j, pFeature.Value[fromFeatureClass.FindField(toFeatureClass.Fields.Field[j].Name)]);
                    }
                    catch
                    {
                        continue;
                    }
                }
                toCursor.InsertFeature(pFeaBuffer);
                toCursor.Flush();
            }
        }
        #endregion
    }
}