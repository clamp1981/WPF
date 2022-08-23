using inStarDemo.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace inStarDemo.Models
{
    public class PicturePostModel
    {
        private BitmapImage _postImage;

        public BitmapImage PostImage
        {
            get
            {
                if (_postImage == null)
                    _postImage = MockDB.GetPostPicture();

                return _postImage;
            }
            set
            {
                _postImage = value;
            }
        }
    }
}
