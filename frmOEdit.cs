using Krypton.Toolkit;
using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Hex
{
    public partial class frmOEdit : KryptonForm
    {
        private readonly string oldinfo = string.Empty;

        public Form MyParent { get; set; }


        public frmOEdit(string account, string password)
        {
            InitializeComponent();
            txtAccount.Text = account;
            string oldaccount = account;
            string oldpassword = password;
            string olderpassword;
            olderpassword = DPAPI.Decrypt(oldpassword);
            txtPassword.Text = olderpassword;
            oldinfo = "ACCOUNT," + oldaccount + ',' + oldpassword + ",,,,";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            string newaccount = txtAccount.Text;
            string newpassword = txtPassword.Text;

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

            else
            {
                string encryptedString = DPAPI.Encrypt(newpassword);
                string newinfo = "ACCOUNT,"+newaccount + ',' + encryptedString + ",,,,,";
                string text = File.ReadAllText("accounts.ini");
                text = text.Replace(oldinfo, newinfo);
                File.WriteAllText("accounts.ini", text);
                KryptonMessageBox.Show(newaccount + " was updated", "Account Updated");
                MyParent.GetType().GetMethod("SetupListviewOnlyAccounts").Invoke(MyParent, null);
                Close();
            }

        }
    }
}