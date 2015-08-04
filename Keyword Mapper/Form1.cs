using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Keyword_Mapper {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void keywordfilepath_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void keywordfilepath_DragDrop(object sender, DragEventArgs e) {
            keywordfilepath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            StreamReader reader = new StreamReader(keywordfilepath.Text);
            string s = reader.ReadLine();
            int linecount = 0;
            int filecount = 0;
            StreamWriter writer = new StreamWriter(keywordfilepath.Text.Replace(".txt", "." + linecount + ".txt"));
            while (s != null) {
                writer.WriteLine(s);
                if (linecount % 100 == 0 && linecount != 0) {
                    filecount++;
                    label1.Text = "PROCESSING FILE " + filecount + "...";
                    Application.DoEvents();
                    writer.Close();
                    writer = new StreamWriter(keywordfilepath.Text.Replace(".txt", "." + filecount + ".txt"));
                }
                s = reader.ReadLine();
                linecount++;
            }
            reader.Close();
            writer.Close();
            label1.Text = "ALL DONE.";
            Application.DoEvents();
        }
    }
}
