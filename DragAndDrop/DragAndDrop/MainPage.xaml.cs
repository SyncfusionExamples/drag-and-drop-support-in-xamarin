using DragAndDrop.Models;
using DragAndDrop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragAndDrop
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Constructor class for Main Page.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the listview selection is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            if (e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                string name = (e.AddedItems[0] as ItemsInfo).Name;
                App.Current.MainPage.Navigation.PushAsync(new ItemsPage());
            }
            itemsListView.SelectedItems.Clear();
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ItemsInfo> itemsCollection;
        public ObservableCollection<ItemsInfo> ItemsCollection
        {
            get { return itemsCollection; }
            set { itemsCollection = value; }
        }

        /// <summary>
        /// Constructor class for MainPageViewModel class.
        /// </summary>
        public MainPageViewModel()
        {
            ItemsCollection = new ObservableCollection<ItemsInfo>();
            ItemsCollection.Add
            (
                new ItemsInfo() 
                {
                    Name = "Electronics", 
                    Image1 = ImageSource.FromFile("mouse.jpg"),
                    Image2 = ImageSource.FromFile("pendrive.jpg"),
                    Image3 = ImageSource.FromFile("charger.jpg"),
                    Image4 = ImageSource.FromFile("budsZ.jpg")
                }
            );
            ItemsCollection.Add
            (
                new ItemsInfo() 
                {
                    Name = "Home", 
                    Image1 = ImageSource.FromFile("swingchair.jpg"),
                    Image2 = ImageSource.FromFile("chair.jpg"),
                    Image3 = ImageSource.FromFile("bottle.jpg"),
                    Image4 = ImageSource.FromFile("beanbag.jpg")
                }
            );
            ItemsCollection.Add
            (
                new ItemsInfo() 
                {
                    Name = "Appliances", 
                    Image1 = ImageSource.FromFile("tv.jpg"),
                    Image2 = ImageSource.FromFile("fridge.jpg"),
                    Image3 = ImageSource.FromFile("heater.jpg"),
                    Image4 = ImageSource.FromFile("iron.jpg")
                }
            );
        }
    }
}
