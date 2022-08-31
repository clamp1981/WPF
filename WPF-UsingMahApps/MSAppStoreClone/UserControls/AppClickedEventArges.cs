using MSAppStoreClone.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAppStoreClone.UserControls
{
    public class AppClickedEventArges : EventArgs 
    {

        public AppModel SelectAppModel { get; private set; }
        public AppClickedEventArges(AppModel selectAppModel)
        {
            this.SelectAppModel = selectAppModel;
        }
    }
}
