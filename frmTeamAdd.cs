using BrightIdeasSoftware;
using Krypton.Toolkit;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Hex
{
    public partial class frmTeamAdd : KryptonForm
    {
        public string s;
        public string s1;
        public string s2;
        public string s3;
        public string s4;

        public Form MyParent { get; set; }

        public frmTeamAdd()
        {
            InitializeComponent();
            SetupListviewCharacters();
            foreach (OLVColumn item in listTeams.Columns)
            {
                HeaderFormatStyle headerstyle = new();
                headerstyle.SetBackColor(Color.FromArgb(158, 158, 158));
                item.HeaderFormatStyle = headerstyle;
                if (!listTeams.AllColumns.Contains(item))
                {
                    listTeams.AllColumns.Add(item);
                }
            }
        }
        public void SetupListviewCharacters()
        {

            foreach (OLVColumn item in listCharacters.Columns)
            {
                HeaderFormatStyle headerstyle = new();
                headerstyle.SetBackColor(Color.FromArgb(158, 158, 158));
                item.HeaderFormatStyle = headerstyle;
                if (!listCharacters.AllColumns.Contains(item))
                {
                    listCharacters.AllColumns.Add(item);
                }
            }

            listCharacters.ClearObjects();
            listCharacters.View = View.Details;
            string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
            File.Delete("accounts.ini".ToString());
            File.WriteAllLines("accounts.ini".ToString(), text);

            StreamReader file = new("accounts.ini");
            string sLine;
            while ((sLine = file.ReadLine()) != null)
            {
                string[] sarr = sLine.Split(',');
                if (!sLine.StartsWith("TEAM"))
                {
                    MakeAccountList newObject = new(sarr[0], sarr[1], sarr[2], sarr[3], sarr[4], sarr[5], sarr[6]);
                    listCharacters.AddObject(newObject);
                }
            }
            file.Close();
            listCharacters.RebuildColumns();
        }

        public class MakeAccountList
        {
            private string account;
            private string password;
            private string character;
            private string note;
            private string server;
            private string realm;
            private string page;

            public MakeAccountList(string account, string password, string character, string note, string server, string realm, string page)
            {
                this.account = account;
                this.password = password;
                this.character = character;
                this.note = note;
                this.server = server;
                this.realm = realm;
                this.page = page;
            }

            public string Account
            {
                get => account;
                set => account = value;
            }
            public string Password
            {
                get => password;
                set => password = value;
            }

            public string Character
            {
                get => character;
                set => character = value;
            }
            public string Note
            {
                get => note;
                set => note = value;
            }
            public string Server
            {
                get => server;
                set => server = value;
            }
            public string Realm
            {
                get => realm;
                set => realm = value;
            }
            public string Page
            {
                get => page;
                set => page = value;
            }
        }

        public class MakeTeamList
        {
            private string teamaccount;

            private string teamcharacter;

            private string teamserver;
            private string teamrealm;


            public MakeTeamList(string teamaccount, string teamcharacter, string teamserver, string teamrealm)
            {
                this.teamaccount = teamaccount;

                this.teamcharacter = teamcharacter;

                this.teamserver = teamserver;
                this.teamrealm = teamrealm;

            }

            public string TAccount
            {
                get => teamaccount;
                set => teamaccount = value;
            }

            public string TCharacter
            {
                get => teamcharacter;
                set => teamcharacter = value;
            }

            public string TServer
            {
                get => teamserver;
                set => teamserver = value;
            }
            public string TRealm
            {
                get => teamrealm;
                set => teamrealm = value;
            }

        }

        private void listCharacters_MouseDown(object sender, MouseEventArgs e)
        {
            if (listCharacters.Items.Count == 0)
            {
                return;
            }

            int index = listCharacters.HotRowIndex;
            if (index < 0)
            {
                index = 0;
            }

            if (index >= 0)
            {
                s = listCharacters.Items[index].ToString();
                s1 = listCharacters.Items[index].SubItems[0].Text;
                s2 = listCharacters.Items[index].SubItems[1].Text;
                s3 = listCharacters.Items[index].SubItems[2].Text;
                s4 = listCharacters.Items[index].SubItems[3].Text;
                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    listCharacters.Items.RemoveAt(index);
                }
            }
        }

        private void listTeams_MouseDown(object sender, MouseEventArgs e)
        {
            if (listTeams.Items.Count == 0)
            {
                return;
            }

            int index = listTeams.HotRowIndex;
            if (index < 0)
            {
                index = 0;
            }

            if (index >= 0)
            {
                s = listTeams.Items[index].ToString();
                s1 = listTeams.Items[index].SubItems[0].Text;
                s2 = listTeams.Items[index].SubItems[1].Text;
                s3 = listTeams.Items[index].SubItems[2].Text;
                s4 = listTeams.Items[index].SubItems[3].Text;
                string s5 = string.Empty;
                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    listTeams.Items.RemoveAt(index);
                }
            }
        }

        private void listTeams_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void listCharacters_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listTeams_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                MakeTeamList newobject = new(s1, s2, s3, s4);
                listTeams.AddObject(newobject);
            }
        }

        private void listCharacters_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string s5 = string.Empty;
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                MakeAccountList newobject = new(s1, s5, s2, s5, s3, s4, s5);
                listCharacters.AddObject(newobject);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTeamName.Text))
            {
                KryptonMessageBox.Show("Must type a team name", "No Team Name");
                return;
            }
            if (listTeams.Items.Count == 0)
            {
                KryptonMessageBox.Show("Must select atleast 1 team member", "No team members selected");
                return;
            }

            int intindex = -1;
            string content = string.Empty;
            string tmember = string.Empty;
            foreach (ListViewItem item in listTeams.Items)
            {
                intindex++;
                string tname = listTeams.Items[intindex].SubItems[0].Text;
                string tchar = listTeams.Items[intindex].SubItems[1].Text;
                string tserver = listTeams.Items[intindex].SubItems[2].Text;
                tmember += tchar + '-' + tserver + ' ';
            }
            content = "TEAM," + txtTeamName.Text + ',' + tmember;
            content = content.Trim();
            content += Environment.NewLine;


            try
            {
                using (FileStream fs = new("accounts.ini", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    StreamWriter write = new(fs);
                    write.BaseStream.Seek(0, SeekOrigin.End);
                    write.WriteLine(content);
                    write.Flush();
                    write.Close();
                    fs.Close();
                }
                KryptonMessageBox.Show("Team saved to accounts.ini", "Team Saved");
                MyParent.GetType().GetMethod("SetupListviewTeams").Invoke(MyParent, null);
                Close();
            }
            catch
            {
                KryptonMessageBox.Show("Error Writing to File" + e, "Error");
            }




            // MessageBox.Show(content);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }

        private void searchData(string searchTerm)
        {

            HighlightTextRenderer renderer = listCharacters.DefaultRenderer as HighlightTextRenderer;

                SolidBrush brush = renderer.FillBrush as SolidBrush ?? new SolidBrush(Color.Transparent);

                    brush.Color = Color.Transparent;
                    renderer.FillBrush = brush;
                    renderer.FramePen = new Pen(Color.FromArgb(158, 158, 158));
                    listCharacters.DefaultRenderer = renderer;
               
                listCharacters.ModelFilter = TextMatchFilter.Contains(listCharacters, searchTerm);
                listCharacters.Refresh();
          
        }
    }
}


