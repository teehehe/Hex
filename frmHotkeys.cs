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
using WK.Libraries.HotkeyListenerNS;

namespace Hex

{
    public partial class frmHotkeys : KryptonForm
    {
        IniFile MyIni = new("Settings.ini");
        public frmHotkeys()
        {
            if (string.IsNullOrEmpty(MyIni.Read("TerminateKey")))
            {
                MyIni.Write("TerminateKey", "Shift, Control+F4");
                MyIni.Write("RenameKey", "Shift, Control+F1");
            }
                var hks = new HotkeySelector();
            Hotkey TerminateKey = new Hotkey(MyIni.Read("TerminateKey"));
            Hotkey RenameKey = new Hotkey(MyIni.Read("RenameKey"));
            InitializeComponent();

            hks.Enable(txtTerminate, TerminateKey);
            hks.Enable(txtRename, RenameKey);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyIni.Write("TerminateKey", txtTerminate.Text);
            MyIni.Write("RenameKey", txtRename.Text);
            KryptonMessageBox.Show("Terminate Key: "+ txtTerminate.Text + Environment.NewLine + "Rename Key: "+txtRename.Text+Environment.NewLine+"Updated!");
            this.Close();
        }
    }
}
