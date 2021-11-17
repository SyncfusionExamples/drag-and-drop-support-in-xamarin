using DragAndDrop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragAndDrop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        /// <summary>
        /// Constructor class for ItemsPage class.
        /// </summary>
        /// <param name="name">Seleceted Item Name</param>
        public ItemsPage()
        {
            InitializeComponent();
            //Set the selected Item name as page title.
            Page_TitleLabel.Text = "Gift Shop";
            //Set the binding context for View.
            BindingContext = new ItemsPageViewModel();
        }

        /// <summary>
        /// Invoked when the drag source is dragged over the drop target. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        /// <summary>
        /// Invoked when drag is started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragStarting(object sender, DragStartingEventArgs e)
        {
            var layout = (sender as Element).Parent as StackLayout;
            e.Data.Properties.Add("Layout", layout);
            UsersListView.IsVisible = true;
            ShowHide_Label.Text = "Hide Users";
        }

        /// <summary>
        /// Invoked when drag source is dropped over the drop target.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDrop(object sender, DropEventArgs e)
        {
            var userLayout = (sender as Element).Parent as Grid;
            var itemsLayout = (StackLayout)e.Data.Properties["Layout"];
            if (itemsLayout.Children != null && itemsLayout.Children.Count > 0)
            {
                var label = itemsLayout.Children[1] as Label;
                var secondLabel = itemsLayout.Children[2] as Label;
                var gridImage = itemsLayout.Children[0] as Image;

                if (userLayout != null && userLayout.Children.Count > 0)
                {
                    var label1 = userLayout.Children[1] as Label;
                    var label2 = userLayout.Children[2] as Label;
                    var image = userLayout.Children[3] as Image;

                    label1.Text = label.Text;
                    label1.IsVisible = true;
                    label2.Text = secondLabel.Text;
                    label2.IsVisible = true;
                    image.Source = gridImage.Source;
                }
            }
        }

        /// <summary>
        /// Invoked when the show hide label is tapped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Tapped(object sender, EventArgs e)
        {
            if (ShowHide_Label.Text.ToLower().Replace(" ", "") == "showusers")
            {
                ShowHide_Label.Text = "Hide Users";
                UsersListView.IsVisible = true;
            }
            else
            {
                ShowHide_Label.Text = "Show Users";
                UsersListView.IsVisible = false;
            }
        }
    }

    public class ItemsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ItemsInfo> itemsCollection;
        public ObservableCollection<ItemsInfo> ItemsCollection
        {
            get { return itemsCollection; }
            set { itemsCollection = value; }
        }

        private ObservableCollection<UserInfo> usersCollection;
        public ObservableCollection<UserInfo> UsersCollection
        {
            get { return usersCollection; }
            set { usersCollection = value; }
        }

        /// <summary>
        /// Constructor class for the ItemsPageViewModel class.
        /// </summary>
        /// <param name="name"></param>
        public ItemsPageViewModel()
        {
            ItemsCollection = new ObservableCollection<ItemsInfo>();

            ItemsCollection.Add(new ItemsInfo() { Name = "Wired Mouse", Price = "Rs: 349", Image1 = ImageSource.FromFile("mouse.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Pen Drive", Price = "Rs: 670", Image1 = ImageSource.FromFile("pendrive.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Wireless Keyboard", Price = "Rs: 1,199", Image1 = ImageSource.FromFile("keyboard.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "USB Type-C Cable", Price = "Rs: 228", Image1 = ImageSource.FromFile("usb.png") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Buds Z", Price = "Rs: 2,999", Image1 = ImageSource.FromFile("budsZ.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Airdopes", Price = "Rs: 1,299", Image1 = ImageSource.FromFile("airpodes.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Car Charger", Price = "Rs: 699", Image1 = ImageSource.FromFile("charger.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Hammock", Price = "Rs: 2,699", Image1 = ImageSource.FromFile("swingchair.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Bean Bag XXXL", Price = "Rs: 1,779", Image1 = ImageSource.FromFile("beanbag.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Laptop Table Desk", Price = "Rs: 799", Image1 = ImageSource.FromFile("laptoptable.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Plastic Chair", Price = "Rs: 1,899", Image1 = ImageSource.FromFile("chair.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Brush Pens", Price = "Rs: 289", Image1 = ImageSource.FromFile("pens.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Color Papers", Price = "Rs: 119", Image1 = ImageSource.FromFile("papers.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Chopper", Price = "Rs: 249", Image1 = ImageSource.FromFile("chopper.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Water Bottle", Price = "Rs: 930", Image1 = ImageSource.FromFile("bottle.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "LED TV", Price = "Rs: 15,990", Image1 = ImageSource.FromFile("tv.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Washing Machine", Price = "Rs: 1,090", Image1 = ImageSource.FromFile("washingmachine.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Microwave oven", Price = "Rs: 13,199", Image1 = ImageSource.FromFile("oven.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Refrigerator", Price = "Rs: 23,790", Image1 = ImageSource.FromFile("fridge.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Dry Iron Box", Price = "Rs: 899", Image1 = ImageSource.FromFile("iron.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Fan Heater", Price = "Rs: 1,090", Image1 = ImageSource.FromFile("heater.jpg") });
            ItemsCollection.Add(new ItemsInfo() { Name = "Kettle", Price = "Rs: 625", Image1 = ImageSource.FromFile("kettle.jpg") });

            UsersCollection = new ObservableCollection<UserInfo>();
            UsersCollection.Add(new UserInfo() { Name = "You" });
            UsersCollection.Add(new UserInfo() { Name = "Tom" });
            UsersCollection.Add(new UserInfo() { Name = "Jessi" });
        }
    }
}