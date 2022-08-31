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
        public string AppDetail { get; private set; }

        public List<string> ScreenShotImagePathList { get; private set; }

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

            this.AppSummary = $"{this.AppName}는 음악, 동영상, TV 프로그램 등을 즐길 수 있는 가장 간편한 방법이며 쉽게 구성할 수 있습니다.";

            this.AppDetail = $"{this.AppName}는 음악, 동영상, TV 프로그램 등을 즐길 수 있는 가장 간편한 방법이며 쉽게 구성할 수 있습니다.\r\n\r\n" +
                $"{this.AppName} 앱은 무료로 이용하실 수 있으며, 수천 편의 영화와 TV 프로그램을 무제한으로 시청하실 수 있습니다.\r\n\r\n" +
                $"{this.AppName} 장점\r\n" +
                $"- {this.AppName} 회원은 저렴한 월 요금으로 TV 프로그램을 무제한으로 시청할 수 있습니다. \r\n" +
                $"- {this.AppName} 앱으로 언제 어디서나 원하는 영화와 TV 프로그램을 자유롭게 시청하실 수 있습니다.\r\n" +
                $"- 수천 편의 영화와 TV 프로그램을 골라 시청할 수 있으며, 정기적으로 신규 동영상이 등록됩니다.\r\n\r\n" +
                $"설치를 클릭하시면 Netflix 앱 설치 및 업데이트와 업그레이드에 동의하시는 것이 됩니다.";

            int appNumber = Convert.ToInt32(System.IO.Path.GetFileNameWithoutExtension(imagPath).Split('-')[0]);
            string url = Path.GetDirectoryName(imagPath) + "\\ScreenShot";
            if ( appNumber % 2 == 0 )
            {
                url += "\\02";
            }
            else
            {
                url += "\\01";
            }
            ScreenShotImagePathList = Directory.GetFiles(url, " *.png", SearchOption.TopDirectoryOnly).ToList();

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
