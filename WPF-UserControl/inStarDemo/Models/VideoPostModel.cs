using inStarDemo.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inStarDemo.Models
{
    public class VideoPostModel
    {
        private Uri _videoSource;
        public Uri VideoSource
        {
            get
            {
                if (_videoSource == null)
                    _videoSource = MockDB.GetPostVideo();
                return _videoSource;
            }
            set
            {
                _videoSource = value;
            }
        }
    }
}
