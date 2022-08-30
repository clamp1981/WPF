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

    public enum DisplayType
    {
        All,
        Best,
        Free
    }

   
    public class AppModel
    {
        public string ImagPath { get; private set; }
        public AppsMainType AppMainType { get; private set; }
        public int DiscountPercent { get; private set; }
        public double Price { get; private set; }
        public string AppName { get; private set; }

        public string AppTypeName { get; private set; }
        public int SaledCount { get; private set; }
        public string AppSummary { get; private set; }

        public AppModel( string imagPath, AppsMainType type, double price )
        {
            this.ImagPath = imagPath;
            this.AppMainType = type;
            string appName = System.IO.Path.GetFileNameWithoutExtension(imagPath).Split('-')[1].Split(' ')[0];
            this.AppName = appName.Substring(0, 1).ToUpper() + appName.Substring(1);
            this.Price = price;

            if (this.AppMainType == AppsMainType.GameApp)
                this.AppTypeName = "Game";
            else if (this.AppMainType == AppsMainType.EntertainmentApp)
                this.AppTypeName = "Entertainment";
            else
                this.AppTypeName = "Utility";

            Random rd = new Random();
            this.SaledCount = rd.Next(100000);

            this.AppSummary = "111111111111111111111111111111";
        }
    }


    public class MockDB
    {

        static List<string> Files = Directory.GetFiles(Environment.CurrentDirectory + @"..\..\..\Images", "*.png", SearchOption.TopDirectoryOnly).ToList();
       
        
        public static List<AppModel> GetAppModels(AppsMainType type, DisplayType displayType = DisplayType.All )
        {
            List<AppModel> apps = new List<AppModel>();
            AppsMainType mainType = AppsMainType.UtilityApp;
            double price = 0.0;
            for (int i = 0; i < Files.Count; i++)
            {
                if (i < 25)
                    mainType = AppsMainType.GameApp;
                else if (i < 50)
                    mainType = AppsMainType.EntertainmentApp;
                else
                    mainType = AppsMainType.UtilityApp;

                if (i % 6 == 0)
                    price = 0.0;
                else
                    price = (i + 1) * 150;

                apps.Add(new AppModel(Files[i], mainType, price));
            }

            if (type != AppsMainType.None)
                apps = apps.Where(x => x.AppMainType == type).ToList();

            if (displayType == DisplayType.Best)
                apps = apps.OrderByDescending(x => x.SaledCount).ToList();
            else if (displayType == DisplayType.Free)
                apps = apps.Where(x => (x.Price == 0.0)).ToList();


            return apps;


        }
    }
}
