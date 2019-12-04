using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    interface IAdvertisement
    {
        int ID { get; }
        string AdCopy { get; set; }

        //above implementation is using properties thanks to which unknown client can have access to this properts through reflections
        //don't use below type of implementation
        //int GetID();
        //string GetAdCopy();
        //void SetAdCopy(string text);
    }
}
