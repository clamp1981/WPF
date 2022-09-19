using MSAppStoreClone.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSAppStoreClone.UserControls.HambugerMenuViewrs
{

    public class ComboBoxItem
    {
        public string Name { get; set; }
        public object value { get; set; }
    }

    

    public class SelectChangedComboBoxEventArgs :EventArgs
    {
        public MenuComboBoxType ComboType { get; private set;}
        public object ComboItemType { get; private set; }

        public SelectChangedComboBoxEventArgs(MenuComboBoxType type, object itemType  )
        {
            this.ComboType = type;
            this.ComboItemType = itemType;
        }
    }
    /// <summary>
    /// HambugerMenuHeader.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HambugerMenuHeader : UserControl
    {

        public event EventHandler<SelectChangedComboBoxEventArgs> SelectionChangedTypes;
        protected virtual void OnSelectionChangedTypes(SelectChangedComboBoxEventArgs e)
        {
            SelectionChangedTypes?.Invoke(this, e);
        }

        List<ComboBoxItem> _appTypeItems = new List<ComboBoxItem>();
        List<ComboBoxItem> _appSortTypeItems = new List<ComboBoxItem>();
        public HambugerMenuHeader()
        {
            InitializeComponent();
            
            this._appTypeItems.Add(new ComboBoxItem() { Name = "전체", value = AppsMainType.None });
            this._appTypeItems.Add(new ComboBoxItem() { Name = "게임", value = AppsMainType.GameApp });
            this._appTypeItems.Add(new ComboBoxItem() { Name = "유틸리티", value = AppsMainType.UtilityApp });
            this._appTypeItems.Add(new ComboBoxItem() { Name = "엔터테이먼트", value = AppsMainType.EntertainmentApp });

            this._appSortTypeItems.Add(new ComboBoxItem() { Name = "이름별 정렬", value = DisplaySortType.Name});
            this._appSortTypeItems.Add(new ComboBoxItem() { Name = "날짜별 정렬", value = DisplaySortType.Purchased });

            this.AppTypeComboBox.ItemsSource = _appTypeItems;
            this.AppSortTypeComboBox.ItemsSource = _appSortTypeItems;


            this.AppTypeComboBox.SelectedItem = this._appTypeItems[0];
            this.AppSortTypeComboBox.SelectedItem = this._appSortTypeItems[0];

        }

        private void AppTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnSelectionChangedTypes(new SelectChangedComboBoxEventArgs(MenuComboBoxType.AppType, this.AppTypeComboBox.SelectedValue));
        }

        private void AppSortTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnSelectionChangedTypes(new SelectChangedComboBoxEventArgs(MenuComboBoxType.DisplaySort, this.AppSortTypeComboBox.SelectedValue));
        }

        public object GetMenuSelectedValue(MenuComboBoxType type )
        {
            object value = null;
            if (type == MenuComboBoxType.AppType)
                value = this.AppTypeComboBox.SelectedItem;
            else
                value = this.AppSortTypeComboBox.SelectedItem;

            return value;
        }
    }
}
