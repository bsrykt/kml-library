using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KMLib;
using KMLib.Feature;
using Core.FileHandling;
using KMLib.Geometry;

namespace KmlTestbed
{
    public partial class TestFrm : Form
    {
        public TestFrm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            KMLRoot kml = CreateKmlDoc();
            LoadSave ls = new LoadSave("kml");
            string fpath = ls.GetSavePath();
            if (fpath != null) {
                kml.Save(fpath);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            KMLRoot kml = CreateKmlFeat();
            LoadSave ls = new LoadSave("kml");
            string fpath = ls.GetSavePath();
            if (fpath != null) {
                kml.Save(fpath);
            }
        }

        private KMLRoot CreateKmlDoc() {
            KMLRoot kml = new KMLRoot();
            Placemark pm = new Placemark();
            pm.name = "foo";
            pm.Point = new KmlPoint(120, 45, 50);
            pm.Snippet = "foo is cool";
            pm.Snippet.maxLines = 1;

            Folder fldr = new Folder("Test Folder");

            kml.Document.Add(pm);
            kml.Document.Add(new Placemark());
            kml.Document.Add(fldr);

            return kml;
        }

        private KMLRoot CreateKmlFeat() {
            KMLRoot kml = new KMLRoot();
            Folder fldr = new Folder("Test Folder");
            fldr.Add(new Folder("Sub Folder"));

            GroundOverlay g = new GroundOverlay();
            g.altitude = 100;
            g.altitudeMode = AltitudeMode.relativeToGround;
            g.color = Color.Blue;
            g.description = "Cool overlay";

            fldr.Add(g);
            kml.Feature = fldr;

            return kml;
        }



        private void button2_Click(object sender, EventArgs e) {
            LoadSave ls = new LoadSave("kml");
            string fpath = ls.GetLoadPath();
            if (fpath != null) {
                KMLRoot kml = KMLRoot.Load(fpath);
                if (kml.UsesDocument) {
                    MessageBox.Show("Loaded kml (doc): " + kml.Document.List.Count);
                } else {
                    MessageBox.Show("Loaded kml (feature): " + kml.Feature.name);
                }
            }

        }

        private void btnTestLoadAndSave_Click(object sender, EventArgs e)
        {
            LoadSave ls = new LoadSave("kml");
            string fpath = ls.GetLoadPath();
            if (fpath != null)
            {
                KMLRoot kml = KMLRoot.Load(fpath);
                //MessageBox.Show("Loaded kml: " + fpath);
                Style s = new Style();
                s.Id = "#style1";
                LineStyle lineStyle = new LineStyle();
                lineStyle.Color = Color.White;
                PolyStyle polyStyle = new PolyStyle();
                polyStyle.Color = Color.FromArgb(1, 255, 0, 0);
                s.Add(lineStyle);
                s.Add(polyStyle);

                StyleMap smap = new StyleMap();
                smap.Id = "#sm1";
                smap.AddPairs(new Pair("normal", "#style1"), new Pair("highlight", "#style1"));


                kml.Document.Styles.Add(s);
                kml.Document.Styles.Add(smap);

                fpath = ls.GetSavePath();
                if (fpath != null)
                {
                    kml.Save(fpath);
                }
            }
        }


    }
}