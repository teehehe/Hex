using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using System.IO;

namespace Hex
{
    public partial class Import : KryptonForm
    {
        public Form MyParent { get; set; }

        public Import()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                KryptonMessageBox.Show("Username cannot be blank", "No username");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                KryptonMessageBox.Show("Password cannot be blank", "No Password");
                return;
            }

            string[] lines = txtToImport.Text.Split(Environment.NewLine);
            string account=txtUser.Text;
            string password = txtPassword.Text;
            string encryptedString = DPAPI.Encrypt(password);
            foreach (string line in lines)
            {
                String[] names = line.Split('\t');
                //  linetopost = names[0] + names[1] + names[2] + names[3] ;
                string[] character= names[2].Split(' ');

                string content = account + ',' + encryptedString + ',' + character[0].TrimEnd() + ',' + names[3].TrimEnd() + ',' + names[0].TrimEnd() + ',' + names[1].TrimEnd() + ',' + '0';
              
      
               
                
                try
                {
                    using FileStream fs = new("accounts.ini", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter write = new(fs);
                    write.BaseStream.Seek(0, SeekOrigin.End);
                    write.WriteLine(Environment.NewLine + content);
                    write.Flush();
                    write.Close();
                    fs.Close();
                }
                catch
                {
                    KryptonMessageBox.Show("Error Writing to File", "Error");
                }

            }
   
            KryptonMessageBox.Show("Characters saved to accounts.ini", "Saved");
            MyParent.GetType().GetMethod("SetupListviewCharacters").Invoke(MyParent, null);
            this.Close();
        }
    }
}
