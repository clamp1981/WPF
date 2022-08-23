using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace inStarDemo.DataBase
{
    public class MockDB
    {
        static List<string> imagePathList = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\PostSample", "*.jpg").ToList<string>();
        public static Uri GetPostVideo()
        {
            return new Uri(Environment.CurrentDirectory + @"\..\..\PostSample\sample.mp4");
        }

        public static BitmapImage GetPostPicture()
        {
            
            Random rd = new Random();
            int idx = rd.Next(4);
            Uri uri = new Uri(imagePathList[idx]);
            return new BitmapImage(uri);
        }
    }
}
