using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    public class WebAd : IAdvertisement
    {
        private int _id;
        private string _adCopy = "";
        public WebAd(int id)
        {
            _id = id;
        }

        public int ID
        {
            get { return _id; }
        }
        public string AdCopy { get => _adCopy; set => _adCopy = value; } //expression body definition
    }
}
