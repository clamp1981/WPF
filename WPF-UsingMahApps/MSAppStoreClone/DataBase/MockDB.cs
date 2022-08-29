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

        public AppModel( string imagPath, AppsMainType type, double price )
        {
            this.ImagPath = imagPath;
            this.AppMainType = type;
            this.AppName = System.IO.Path.GetFileNameWithoutExtension(imagPath).Split('-')[1];
            this.Price = price;
        }
    }


    public class MockDB
    {

        List<string> Files = Directory.GetFiles(Environment.CurrentDirectory + @"..\..\..\Images", "*.png", SearchOption.TopDirectoryOnly).ToList();
        List<AppModel> Apps = new List<AppModel>();
        public MockDB()
        {
            AppsMainType mainType = AppsMainType.UtilityApp;
            for (int i = 0; i < Files.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (i < 20)
                        mainType = AppsMainType.GameApp;
                    else if (i > 60)
                        mainType = AppsMainType.EntertainmentApp;
                }
                else if (i % 2 != 0)
                {
                    if (i < 40)
                        mainType = AppsMainType.EntertainmentApp;
                }

                Apps.Add(new AppModel(Files[i], mainType, i * 130));
            }

        }

        public List<AppModel> GetAppModels(AppsMainType type)
        {
           
            if (type == AppsMainType.None)
            {
                return Apps;
            }

            
            return Apps.Where(x => x.AppMainType == type).ToList();


        }
    }
}
