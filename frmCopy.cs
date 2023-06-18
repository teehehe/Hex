using BrightIdeasSoftware;
using Krypton.Toolkit;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Hex
{
    public partial class frmCopy : KryptonForm
    {
        public frmCopy()
        {

            InitializeComponent();
            foreach (OLVColumn item in listCharToCopy.Columns)
            {
                HeaderFormatStyle headerstyle = new();
                headerstyle.SetBackColor(Color.FromArgb(255, 158, 158, 158));
                item.HeaderFormatStyle = headerstyle;
                listCharToCopy.AllColumns.Add(item);
            }
            listCharToCopy.UseCustomSelectionColors = true;
            listCharToCopy.SelectedBackColor = Color.FromArgb(158, 158, 158);
            listCharToCopy.UnfocusedSelectedBackColor = Color.FromArgb(54, 45, 45);
          
        }

        private void LoadListLive()
        {
            listCharToCopy.ClearObjects();
            DirectoryInfo dir = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Lotm"));
            listCharToCopy.View = View.Details;

            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.EndsWith("-41.ini")|| file.Name.EndsWith("-49.ini") || file.Name.EndsWith("-50.ini") || file.Name.EndsWith("-51.ini") || file.Name.EndsWith("-52.ini") || file.Name.EndsWith("-53.ini") || file.Name.EndsWith("-54.ini") || file.Name.EndsWith("-55.ini") || file.Name.EndsWith("-56.ini") || file.Name.EndsWith("-57.ini") || file.Name.EndsWith("-23.ini"))
                {
                    string chartocopy = file.Name;

                    MakeCharacterList newObject = new(chartocopy);
                    listCharToCopy.AddObject(newObject);
                }
            }
        }

        private void LoadListCelestius()
        {
            listCharToCopy.ClearObjects();
            DirectoryInfo dir = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Celestius"));
            listCharToCopy.View = View.Details;

            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.EndsWith("-41.ini"))
                {
                    string chartocopy = file.Name;

                    MakeCharacterList newObject = new(chartocopy);
                    listCharToCopy.AddObject(newObject);
                }
            }
        }

        private void LoadListAtlas()
        {
            listCharToCopy.ClearObjects();
            DirectoryInfo dir = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Atlas"));
            listCharToCopy.View = View.Details;

            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.EndsWith("-5.ini"))
                {
                    string chartocopy = file.Name;
                    MakeCharacterList newObject = new(chartocopy);
                    listCharToCopy.AddObject(newObject);
                }
            }

        }

        public class MakeCharacterList
        {
            private string chartocopy;

            public MakeCharacterList(string chartocopy)
            {
                this.chartocopy = chartocopy;
            }
            public string CharToCopy
            {
                get => chartocopy;
                set => chartocopy = value;
            }
        }

        private void rbCelestiusFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCelestiusFrom.Checked)
            {
                LoadListCelestius();
            }
        }

        private void rbAtlasFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAtlasFrom.Checked)
            {
                LoadListAtlas();
            }
        }
        private void rbLiveFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLiveFrom.Checked)
            {
                LoadListLive();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string copyfromdir = string.Empty;
            string copytodir = string.Empty;
            string fileext = string.Empty;
            string CharCopyToName = string.Empty;
            string CharCopyFromName = string.Empty;

            if (rbAtlasFrom.Checked)
            {
                copyfromdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Atlas";
            }

            if (rbLiveFrom.Checked)
            {
                copyfromdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\lotm";
            }

            if (rbCelestiusFrom.Checked)
            {
                copyfromdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\celestius";
            }

            if (rbAtlasTo.Checked)
            {
                copytodir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Atlas";
                fileext = "-5.ini";
            }
            if (rbLiveTo.Checked)
            {
                copytodir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\lotm";
                string serverlive = kryptonListBox1.SelectedItem.ToString();
                if (serverlive=="Ywain1")
                    fileext = "-41.ini";
                if (serverlive == "Ywain2")
                    fileext = "-49.ini";
                if (serverlive == "Ywain3")
                    fileext = "-50.ini";
                if (serverlive == "Ywain4")
                    fileext = "-51.ini";
                if (serverlive == "Ywain5")
                    fileext = "-52.ini";
                if (serverlive == "Ywain6")
                    fileext = "-53.ini";
                if (serverlive == "Ywain7")
                    fileext = "-54.ini";
                if (serverlive == "Ywain8")
                    fileext = "-55.ini";
                if (serverlive == "Ywain9")
                    fileext = "-56.ini";
                if (serverlive == "Ywain10")
                    fileext = "-57.ini";
                if (serverlive == "Gaheris")
                    fileext = "-23.ini";

            }
            if (rbCelestiusTo.Checked)
            {
                copytodir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\celestius";
                fileext = "-41.ini";
            }


            if (!rbCelestiusFrom.Checked & !rbAtlasFrom.Checked & !rbLiveFrom.Checked)
            {
                KryptonMessageBox.Show("You must select a server to copy from", "Missing Server To Copy From");
                return;
            }

            if (listCharToCopy.SelectedObjects.Count > 0)
            {
                CharCopyFromName = ((MakeCharacterList)listCharToCopy.SelectedObject).CharToCopy;
            }
            else
            {
                listCharToCopy.SelectedObjects.Clear();
                KryptonMessageBox.Show("You must select a character to copy", "Missing Selected Character");
                return;
            }
            if (!rbCelestiusTo.Checked & !rbAtlasTo.Checked & !rbLiveTo.Checked)
            {
                KryptonMessageBox.Show("You must select a server to copy to", "Missing Server To Copy To");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                KryptonMessageBox.Show("You must type the name for the new character", "Missing New Character Name");
                return;
            }
            else
            {
                CharCopyToName = txtName.Text;
            }


            File.Copy(copyfromdir + "\\" + CharCopyFromName, copytodir + "\\" + CharCopyToName + fileext, true);
            KryptonMessageBox.Show("Copied file From: " + copyfromdir + "\\" + CharCopyFromName + Environment.NewLine + "To: " + copytodir + "\\" + CharCopyToName + fileext, "Copy Completed");
        }

        private void rbLiveTo_CheckedChanged(object sender, EventArgs e)
        {
            kryptonListBox1.Visible=true;
        }

        private void rbCelestiusTo_CheckedChanged(object sender, EventArgs e)
        {
            kryptonListBox1.Visible = false;
        }

        private void rbAtlasTo_CheckedChanged(object sender, EventArgs e)
        {
            kryptonListBox1.Visible = false;
        }
    }
}
