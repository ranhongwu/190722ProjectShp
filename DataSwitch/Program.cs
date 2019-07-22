using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using ESRI.ArcGIS.esriSystem;

namespace DataSwitch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);
            ESRI.ArcGIS.RuntimeManager.BindLicense(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            IAoInitialize m_AoInitialize = new AoInitializeClass();
            m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeArcServer);
            IAoInitialize m_AoInitialize2 = new AoInitializeClass();
            m_AoInitialize2.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngine);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.Run(new FrmProjTrans());
        }
    }
}
