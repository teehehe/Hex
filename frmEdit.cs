using Krypton.Toolkit;
using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Hex
{
    public partial class frmEdit : KryptonForm
    {
        private readonly string oldinfo = string.Empty;

        public frmEdit(string account, string password, string character, string note, string server, string realm, string page)
        {
            InitializeComponent();
            txtAccount.Text = account;
            string oldaccount = account;
            string oldpassword = password;
            string olderpassword;
            olderpassword =DPAPI.Decrypt(oldpassword);
            txtPassword.Text = olderpassword;
            txtCharacter.Text = character;
            string oldchar = character;
            txtNote.Text = note;
            string oldnote = note;
            cbPage.SelectedItem = page;
            string oldpage = page;
            cbRealm.SelectedItem = realm;
            string oldrealm = realm;
            cbServer.SelectedItem = server;
            string oldserver = server;
            oldinfo = oldaccount + ',' + oldpassword + ',' + oldchar + ',' + oldnote + ',' + oldserver + ',' + oldrealm + ',' + oldpage;
        }

        public Form MyParent { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtNote.Text = textInfo.ToTitleCase(txtNote.Text);
            txtCharacter.Text = textInfo.ToTitleCase(txtCharacter.Text);
            txtCharacter.Text = textInfo.ToTitleCase(txtCharacter.Text);
            string newpage = cbPage.SelectedItem.ToString();
            string newrealm = cbRealm.SelectedItem.ToString();
            string newserver = cbServer.SelectedItem.ToString();
            string newaccount = txtAccount.Text;
            string newpassword = txtPassword.Text;
            string newchar = txtCharacter.Text;
            string newnote = txtNote.Text;
            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                KryptonMessageBox.Show(txtAccount.Tag + " must not be empty.", "Account Empty");
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                KryptonMessageBox.Show(txtPassword.Tag + " must not be empty.", "Password Empty");
                return;
            }
            else if (string.IsNullOrEmpty(txtCharacter.Text))
            {
                KryptonMessageBox.Show(txtCharacter.Tag + " must not be empty.", "Character Empty");
                return;
            }
            else if (string.IsNullOrEmpty(txtNote.Text))
            {
                KryptonMessageBox.Show(txtNote.Tag + " must not be empty.", "Note Empty");
                return;
            }
            else if (string.IsNullOrEmpty(cbServer.Text))
            {
                KryptonMessageBox.Show(cbServer.Tag + " must not be empty.", "Server not selected");
                return;
            }
            else if (string.IsNullOrEmpty(cbRealm.Text))
            {
                KryptonMessageBox.Show(cbRealm.Tag + " must not be empty.", "Realm not selected");
                return;
            }
            else if (string.IsNullOrEmpty(cbPage.Text))
            {
                KryptonMessageBox.Show(cbPage.Tag + " must not be empty.", "Page not selected");
                return;
            }
            else
            {
                string encryptedString = DPAPI.Encrypt(newpassword);
                string newinfo = newaccount + ',' + encryptedString + ',' + newchar + ',' + newnote + ',' + newserver + ',' + newrealm + ',' + newpage;
                string text = File.ReadAllText("accounts.ini");
                text = text.Replace(oldinfo, newinfo);
                File.WriteAllText("accounts.ini", text);
                KryptonMessageBox.Show(newchar + " was updated", "Character Updated");
                MyParent.GetType().GetMethod("SetupListviewCharacters").Invoke(MyParent, null);
                Close();
            }
        }
    }
}
