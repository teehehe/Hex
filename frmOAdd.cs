using Krypton.Toolkit;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Hex
{
    public partial class frmOAdd : KryptonForm
    {
        public frmOAdd()
        {
            InitializeComponent();
        }

        public Form MyParent { get; set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidateEntry();
        }

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

            else
            {
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                txtAccount.Text = textInfo.ToTitleCase(txtAccount.Text);
                string accountinfo = txtAccount.Text;
                string passwordinfo = txtPassword.Text;

                string encryptedString = DPAPI.Encrypt(passwordinfo);
                string content = "ACCOUNT," + accountinfo + ',' + encryptedString + ",,,,";
                SaveTextFileNewline("accounts.ini", content);
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                MyParent.GetType().GetMethod("SetupListviewOnlyAccounts").Invoke(MyParent, null);
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
                KryptonMessageBox.Show("Account saved to accounts.ini", "Saved");
            }
            catch
            {
                KryptonMessageBox.Show("Error Writing to File", "Error");
            }
        }


    }
}
