using Krypton.Toolkit;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;


namespace Hex
{
    public partial class frmAdd : KryptonForm
    {
        public frmAdd()
        {
            InitializeComponent();
            cbServer.SelectedIndex = 0;
            cbPage.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidateEntry();
        }

        public Form MyParent { get; set; }

        private void ValidateEntry()
        {

            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                KryptonMessageBox.Show(txtAccount.Text + " must not be empty.", "Account Name Empty");
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                KryptonMessageBox.Show(txtPassword.Text + " must not be empty.", "Password Empty");
                return;
            }
            else if (string.IsNullOrEmpty(txtCharacter.Text))
            {
                KryptonMessageBox.Show(txtCharacter.Text + " must not be empty.", "Character Name Empty");
                return;
            }
            else if (string.IsNullOrEmpty(txtNote.Text))
            {
                KryptonMessageBox.Show(txtNote.Text + " must not be empty.", "Note Empty");
                return;
            }
            else if (string.IsNullOrEmpty(cbServer.Text))
            {
                KryptonMessageBox.Show(cbServer.Text + " must not be empty.", "Server not selected");
                return;
            }
            else if (string.IsNullOrEmpty(cbRealm.Text))
            {
                KryptonMessageBox.Show(cbRealm.Text + " must not be empty.", "Realm not selected");
                return;
            }
            else if (string.IsNullOrEmpty(cbPage.Text))
            {
                KryptonMessageBox.Show(cbPage.Text + " must not be empty.", "Page not selected");
                return;
            }
            else
            {
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                txtAccount.Text = textInfo.ToTitleCase(txtAccount.Text);
                string accountinfo = txtAccount.Text;

                string passwordinfo = txtPassword.Text;
                txtCharacter.Text=textInfo.ToTitleCase(txtCharacter.Text);
                string characterinfo = txtCharacter.Text;
                txtNote.Text = textInfo.ToTitleCase(txtNote.Text);
                string noteinfo = txtNote.Text;
                string serverinfo = cbServer.SelectedItem.ToString();
                string realminfo = cbRealm.SelectedItem.ToString();
                string pageinfo = cbPage.SelectedItem.ToString();

               
                string encryptedString = DPAPI.Encrypt(passwordinfo);
                string content = accountinfo + ',' + encryptedString + ',' + characterinfo + ',' + noteinfo + ',' + serverinfo + ',' + realminfo + ',' + pageinfo;
                SaveTextFileNewline("accounts.ini", content);
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                MyParent.GetType().GetMethod("SetupListviewCharacters").Invoke(MyParent, null);
                Close();
            }
        }

        public static void SaveTextFileNewline(string filePath, string content)
        {
            try
            {
                using (FileStream fs = new(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    StreamWriter write = new(fs);
                    write.BaseStream.Seek(0, SeekOrigin.End);
                    write.WriteLine(Environment.NewLine + content);
                    write.Flush();
                    write.Close();
                    fs.Close();
                }
                KryptonMessageBox.Show("Character saved to accounts.ini", "Saved");
            }
            catch
            {
                KryptonMessageBox.Show("Error Writing to File", "Error");
            }
        }
    }
}