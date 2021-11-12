using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DragAndDrop.Models
{
    public class ItemsInfo
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public ImageSource Image1 { get; set; }
        public ImageSource Image2 { get; set; }
        public ImageSource Image3 { get; set; }
        public ImageSource Image4 { get; set; }

    }

    public class UserInfo
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
    }
}
