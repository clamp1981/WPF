using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAppStoreClone.DataBase
{

    public enum AppsMainType
    {
        None,
        GameApp,
        UtilityApp,
        EntertainmentApp
    }

   
    public class AppModel
    {
        public string ImagPath { get; private set; }
        public AppsMainType AppMainType { get; private set; }
        public int DiscountPercent { get; private set; }
        public double Price { get; private set; }
        public string AppName { get; private set; }

        public string AppTypeName { get; private set; }

        public AppModel( string imagPath, AppsMainType type, double price )
        {
            this.ImagPath = imagPath;
            this.AppMainType = type;
            this.AppName = System.IO.Path.GetFileNameWithoutExtension(imagPath).Split('-')[1];
            this.Price = price;

            if (this.AppMainType == AppsMainType.GameApp)
                this.AppTypeName = "Game";
            else if (this.AppMainType == AppsMainType.EntertainmentApp)
                this.AppTypeName = "Entertainment";
            else
                this.AppTypeName = "Utility";
        }
    }


    public class MockDB
    {

        static List<string> Files = Directory.GetFiles(Environment.CurrentDirectory + @"..\..\..\Images", "*.png", SearchOption.TopDirectoryOnly).ToList();
       
        
        public static List<AppModel> GetAppModels(AppsMainType type)
        {
            List<AppModel> apps = new List<AppModel>();
            AppsMainType mainType = AppsMainType.UtilityApp;
            for (int i = 0; i < Files.Count; i++)
            {
                if (i < 25)
                    mainType = AppsMainType.GameApp;
                else if (i < 50)
                    mainType = AppsMainType.EntertainmentApp;
                else
                    mainType = AppsMainType.UtilityApp;

                apps.Add(new AppModel(Files[i], mainType, i * 150));
            }
            if (type == AppsMainType.None)
            {
                return apps;
            }
           
            
            return apps.Where(x => x.AppMainType == type).ToList();


        }
    }
}
