using System;
using System.Collections.Generic;
using System.Text;
using KMLib.Abstract;

namespace KMLib.Feature
{
    public class Folder : AContainerFeature
    {
        public Folder() { }
        public Folder(string t) {
            name = t;
        }
    }
}
