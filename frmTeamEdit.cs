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
    public partial class frmTeamEdit : KryptonForm
    {
        private readonly string oldinfo = string.Empty;
        public Form MyParent { get; set; }

        public string s;
        public string s1;
        public string s2;
        public string s3;
        public string s4;
        public string Whichlistview;

        public frmTeamEdit(string teamname1, string teammember1)
        {
            InitializeComponent();
            SetupListviewCharacters();
            txtTeamName.Text = teamname1;
            string teamname2 = teamname1;
            string teammember2 = teammember1;
            oldinfo = "TEAM," + teamname1 + ',' + teammember1;
            SetupListviewTeam(teammember2);
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
                    MakeAccountList newObject = new(sarr[0], sarr[2], sarr[4], sarr[5]);
                    listCharacters.AddObject(newObject);
                }
            }
            file.Close();
            listCharacters.RebuildColumns();
        }

        public class MakeAccountList
        {
            private string account;

            private string character;

            private string server;
            private string realm;


            public MakeAccountList(string account, string character, string server, string realm)
            {
                this.account = account;

                this.character = character;

                this.server = server;
                this.realm = realm;

            }

            public string Account
            {
                get => account;
                set => account = value;
            }

            public string Character
            {
                get => character;
                set => character = value;
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

        }

        public class MakeAccountList2
        {
            private string taccount;

            private string tcharacter;

            private string tserver;
            private string trealm;


            public MakeAccountList2(string taccount, string tcharacter, string tserver, string trealm)
            {
                this.taccount = taccount;

                this.tcharacter = tcharacter;

                this.tserver = tserver;
                this.trealm = trealm;

            }

            public string TAccount
            {
                get => taccount;
                set => taccount = value;
            }

            public string TCharacter
            {
                get => tcharacter;
                set => tcharacter = value;
            }

            public string TServer
            {
                get => tserver;
                set => tserver = value;
            }
            public string TRealm
            {
                get => trealm;
                set => trealm = value;
            }

        }

        public class MakeTeamList
        {
            private string teamname;
            private string teammember;



            public MakeTeamList(string teamname, string teammember)
            {
                this.teamname = teamname;
                this.teammember = teammember;


            }

            public string TeamName
            {
                get => teamname;
                set => teamname = value;
            }

            public string TeamMember
            {
                get => teammember;
                set => teammember = value;
            }

        }


        public void SetupListviewTeam(string teammember2)
        {
            string members = string.Empty;
            foreach (OLVColumn item in listTeams.Columns)
            {
                HeaderFormatStyle headerstyle = new();
                headerstyle.SetBackColor(Color.FromArgb(158, 158, 158));
                item.HeaderFormatStyle = headerstyle;
                if (!listTeams.AllColumns.Contains(item))
                {
                    listTeams.AllColumns.Add(item);
                }
                listTeams.ClearObjects();
                listTeams.View = View.Details;
            }
            StreamReader file1 = new("accounts.ini");
            string sLine1;
            while ((sLine1 = file1.ReadLine()) != null)
            {
                string[] sarr = sLine1.Split(',');
                if (sLine1.StartsWith("TEAM"))
                {
                    if (teammember2 == sarr[2])
                    {
                        string[] member = teammember2.Split(' ');
                        foreach (string item in member)
                        {
                            string[] characters = item.Split('-');
                            StreamReader file2 = new("accounts.ini");
                            string sLine2;
                            while ((sLine2 = file2.ReadLine()) != null)
                            {
                                if (!sLine2.StartsWith("TEAM"))
                                {
                                    string[] sarr1 = sLine2.Split(',');
                                    if (sarr1[2] == characters[0] & sarr1[4] == characters[1])
                                    {
                                        // MessageBox.Show("0 "+sarr1[0] + " 1" + sarr1[1] + " 2" + sarr1[2] + " 3" + sarr1[3]+" 4"+sarr1[4]+" 5"+sarr1[5]);
                                        MakeAccountList2 newobject2 = new(sarr1[0], sarr1[2], sarr1[4], sarr1[5]);
                                        listTeams.AddObject(newobject2);
                                    }
                                }
                            }
                            file2.Close();
                        }
                    }
                }
            }
            file1.Close();
            listTeams.RebuildColumns();
        }

        private void listCharacters_MouseDown(object sender, MouseEventArgs e)
        {
            Whichlistview = "1";
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
            Whichlistview = "2";
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

        private void listCharacters_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listTeams_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listTeams_DragDrop(object sender, DragEventArgs e)
        {
            if (Whichlistview == "2")
            {
                MakeAccountList2 newobject = new(s1, s2, s3, s4);

                listTeams.AddObject(newobject);
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(DataFormats.StringFormat);

                MakeAccountList2 newobject = new(s1, s2, s3, s4);

                bool found = false;
                foreach (ListViewItem item in listTeams.Items)
                {
                    // MessageBox.Show(item.SubItems[0].Text+ " " + item.SubItems[1].Text);

                    if (item.SubItems[0].Text == s1 & item.SubItems[1].Text == s2)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    listTeams.AddObject(newobject);
                }
            }

        }

        private void listCharacters_DragDrop(object sender, DragEventArgs e)
        {
            if (Whichlistview == "1")
            {
                MakeAccountList newobject = new(s1, s2, s3, s4);

                listCharacters.AddObject(newobject);
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string s5 = string.Empty;
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                MakeAccountList newobject = new(s1, s2, s3, s4);
                bool found = false;
                foreach (ListViewItem item in listCharacters.Items)
                {
                    // MessageBox.Show(item.SubItems[0].Text+ " " + item.SubItems[1].Text);

                    if (item.SubItems[0].Text == s1 & item.SubItems[1].Text == s2)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    listCharacters.AddObject(newobject);
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
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
            // MessageBox.Show(oldinfo + Environment.NewLine + content);
            string text = File.ReadAllText("accounts.ini");
            text = text.Replace(oldinfo, content);
            File.WriteAllText("accounts.ini", text);
            KryptonMessageBox.Show(txtTeamName.Text + " was updated", "Team Updated");
            MyParent.GetType().GetMethod("SetupListviewTeams").Invoke(MyParent, null);
            Close();
        }

        private void txtSearchTeam_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearchTeam.Text);
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