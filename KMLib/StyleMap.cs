using System;
using System.Collections.Generic;
using System.Text;
using KMLib.Abstract;
using System.Xml;
using System.Xml.Serialization;

namespace KMLib
{
    public class StyleMap : AStyleSelector
    {
        private string smid;
        [XmlAttribute("id")]
        public string Id
        {
            get { return smid; }
            set { smid = value; }
        }
        
        private List<Pair> pairs;
        [XmlElement("Pair")]
        public List<Pair> Pairs
        {
            get { return pairs; }
            set { pairs = value; }
        }

        public void AddPairs(Pair pairNormal, Pair pairHighlight)
        {
            if (pairs == null)
            {
                pairs = new List<Pair>();
            }
            pairs.Add(pairNormal);
            pairs.Add(pairHighlight);
        }
    }

    public class Pair : StyleMap
    {
        private string key;
        [XmlElement("key")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string styleUrl;
        [XmlElement("styleUrl")]
        public string StyleUrl
        {
            get { return styleUrl; }
            set { styleUrl = value; }
        }

        public Pair()
        {
        }

        public Pair(string key, string styleUrl)
        {
            this.key = key;
            this.styleUrl = styleUrl;
        }
    }

    /*
    <StyleMap id="ID">
      <!-- extends StyleSelector -->
      <!-- elements specific to StyleMap -->
      <Pair id="ID">
        <key>normal</key>              <!-- kml:styleStateEnum:  normal or highlight -->
        <styleUrl>...</styleUrl> or <Style>...</Style>
      </Pair>
    </StyleMap>
    */
}
