using BrightIdeasSoftware;
using Krypton.Toolkit;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using WK.Libraries.HotkeyListenerNS;

namespace Hex
{

    public partial class frmMain : KryptonForm
    {
        private readonly IniFile MyIni = new("Settings.ini");
        public Hotkey terminatekey;
        public Hotkey renamekey;
        public HotkeyListener hkl;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]

        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public frmMain()
        {
            LoadFile();
            InitializeComponent();
            IniFile MyIni = new("Settings.ini");
            string terminatekeys = MyIni.Read("TerminateKey");
            string renamekeys = MyIni.Read("RenameKey");
            string testkeys = MyIni.Read("TestKey");
            hkl = new HotkeyListener();
            terminatekey = new Hotkey(terminatekeys);
            renamekey = new Hotkey(renamekeys);
            hkl.Add(terminatekey);
            hkl.Add(renamekey);
            hkl.HotkeyPressed += Hkl_HotkeyPressed;
            SetupListviewCharacters();
            SetupListviewTeams();
            SetupListviewOnlyAccounts();
        }
        public void SetupListviewCharacters()
        {
            foreach (OLVColumn item in listAccounts.Columns)
            {
                HeaderFormatStyle headerstyle = new();
                headerstyle.SetBackColor(Color.FromArgb(158, 158, 158));
                item.HeaderFormatStyle = headerstyle;
                if (!listAccounts.AllColumns.Contains(item))
                {
                    listAccounts.AllColumns.Add(item);
                }
            }
            listAccounts.RebuildColumns();
            listAccounts.ClearObjects();
            listAccounts.BeginUpdate();




            string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
            File.Delete("accounts.ini".ToString());
            File.WriteAllLines("accounts.ini".ToString(), text);



            StreamReader file = new("accounts.ini");
            string sLine;
            while ((sLine = file.ReadLine()) != null)
            {
                string[] sarr = sLine.Split(',');
                if (!sLine.StartsWith("TEAM")& !sLine.StartsWith("ACCOUNT"))
                {
                    MakeAccountList newObject = new(sarr[0], sarr[1], sarr[2], sarr[3], sarr[4], sarr[5], sarr[6]);
                    listAccounts.AddObject(newObject);
                }
            }
            listAccounts.EndUpdate();
            file.Close();
            clmPassword.IsVisible = false;

        }

        public void SetupListviewOnlyAccounts()
        {
            foreach (OLVColumn item in listOAccounts.Columns)
            {
                HeaderFormatStyle headerstyle = new();
                headerstyle.SetBackColor(Color.FromArgb(158, 158, 158));
                item.HeaderFormatStyle = headerstyle;
                if (!listOAccounts.AllColumns.Contains(item))
                {
                    listOAccounts.AllColumns.Add(item);
                }
            }
            listOAccounts.RebuildColumns();
            listOAccounts.ClearObjects();
            listOAccounts.BeginUpdate();




            string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
            File.Delete("accounts.ini".ToString());
            File.WriteAllLines("accounts.ini".ToString(), text);



            StreamReader file = new("accounts.ini");
            string sLine;
            while ((sLine = file.ReadLine()) != null)
            {
                string[] sarr = sLine.Split(',');
                if (sLine.StartsWith("ACCOUNT"))
                {
                    MakeOAccountList newObject = new(sarr[1], sarr[2]);
                    listOAccounts.AddObject(newObject);
                }
            }
            listOAccounts.EndUpdate();
            file.Close();
            clmPassword.IsVisible = false;

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

        public class MakeOAccountList
        {
            private string account;
            private string password;


            public MakeOAccountList(string account, string password)
            {
                this.account = account;
                this.password = password;

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
        }
        private void listAccounts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                IntPtr hWnd;
                string depassword = string.Empty;
                string gamename = string.Empty;
                string serveraddress = string.Empty;
                string realmid = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                password = password.Trim(' ');
                string character = ((MakeAccountList)listAccounts.SelectedObject).Character;
                string realm = ((MakeAccountList)listAccounts.SelectedObject).Realm;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string page = ((MakeAccountList)listAccounts.SelectedObject).Page;
                realm = realm.ToString();
                if (realm == "Albion")
                {
                    realmid = "1";
                }

                if (realm == "Hibernia")
                {
                    realmid = "3";
                }

                if (realm == "Midgard")
                {
                    realmid = "2";
                }

                if (server == "Atlas")
                {
                    serveraddress = "138.201.59.161";
                    gamename = "game1127.dll";
                    try
                    {
                        using Process proc = new();
                        //IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("AtlasPath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        proc.StartInfo.WorkingDirectory = DAoCFolder;
                        proc.StartInfo.FileName = DAoCFolder + "\\connect.exe";
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        depassword = DPAPI.Decrypt(password);
                        proc.StartInfo.Arguments = gamename + ' ' + serveraddress + ' ' + account + ' ' + depassword + ' ' + character + ' ' + realmid;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.RedirectStandardOutput = false;
                        proc.Start();
                        var count=0;
                        do
                        {
                            count++;
                            Thread.Sleep(500);
                            //  "Dark Age of Camelot © 2001-2019 Electronic Arts Inc. All Rights Reserved."
                            // FindWindow("DAoCMW", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                            hWnd = FindWindow("DAoCMWC", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                            if (count > 15)
                            {
                                KryptonMessageBox.Show("Timed out waiting for game to start", "Timed Out");
                                break;
                            }
                        }
                        while (hWnd == IntPtr.Zero);
                        SetWindowText(hWnd, character);
                        Thread.Sleep(500);
                        proc.Kill();
                    }
                    catch (Exception j)
                    {
                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                    }
                    killmutex();
                    return;
                }

                if (server == "Celestius")
                {

                    serveraddress = "127.0.0.1 10300";
                    gamename = "game.dll";

                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("CelestiusPath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        //proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.FileName = DAoCFolder + "\\CelestiusConnect.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        depassword = DPAPI.Decrypt(password);
                       // proc1.StartInfo.Arguments= "/K CelestiusConnect.exe launch " + serveraddress + ' ' + account + ' ' + "\""+DAoCFolder+"\"" + " -p " + depassword + " --character-page " + page + " --character-name " + character + " --realm " + realmid;
                        proc1.StartInfo.Arguments = "launch " + serveraddress + ' ' + account + ' ' + "\"" + DAoCFolder + "\"" + " -p " + depassword + " --character-page " + page + " --character-name " + character + " --realm " + realmid;                        proc1.StartInfo.UseShellExecute = false;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.StartInfo.Verb = "runas";
                        proc1.Start();
                        proc1.WaitForExit();
                    }
                    catch (Exception j)
                    {
                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                    }
                    int count = 0;
                        do
                        {
                            count++;
                            Thread.Sleep(500);
                            //  "Dark Age of Camelot © 2001-2019 Electronic Arts Inc. All Rights Reserved."
                            // FindWindow("DAoCMW", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                            hWnd = FindWindow("DAoCMWC", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                            if (count > 15)
                            {
                                KryptonMessageBox.Show("Timed out waiting for game to start", "Timed Out");
                                break;
                            }
                        }
                        while (hWnd == IntPtr.Zero);
                        SetWindowText(hWnd, character);
                        Thread.Sleep(500);
                    killmutex();
                    return;
                }
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    string serverid = string.Empty;
                    gamename = "game.dll";
                    serveraddress = string.Empty;
                    string port = "10622";

                    if (server == "Ywain1")
                    {
                        serverid = "41";
                        serveraddress = "107.23.173.143";
                    }
                    if (server == "Ywain2")
                    {
                        serverid = "49";
                        serveraddress = "107.23.173.143";
                    }
                    if (server == "Ywain3")
                    {
                        serverid = "50";
                        serveraddress = "107.23.173.143";
                    }
                    if (server == "Ywain4")
                    {
                        serverid = "51";
                        serveraddress = "107.23.173.143";
                    }

                    if (server == "Ywain5")
                    {
                        serverid = "52";
                        serveraddress = "107.23.173.143";
                    }

                    if (server == "Ywain6")
                    {
                        serverid = "53";
                        serveraddress = "107.23.173.143";
                    }
                    if (server == "Ywain7")
                    {
                        serverid = "54";
                        serveraddress = "107.23.173.143";
                    }
                    if (server == "Ywain8")
                    {
                        serverid = "55";
                        serveraddress = "107.23.173.143";
                    }

                    if (server == "Ywain9")
                    {
                        serverid = "56";
                        serveraddress = "107.23.173.143";
                    }

                    if (server == "Ywain10")
                    {
                        serverid = "57";
                        serveraddress = "107.23.173.143";
                    }

                    if (server == "Gaheris")
                    {
                        serverid = "23";
                        serveraddress = "107.21.60.95";
                    }

                    //% daocdir %\game.dll % ServerIP % " " % port % " " % ServerID % " " % CharToLaunchI1 % " " % Unprotect % " " % CharToLaunchI3 % " " % RealmID %
                    try
                    {

                        using Process proc1 = new();
                        IniFile MyIni1 = new("Settings.ini");
                        string DAoCFolder = MyIni1.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        depassword = depassword.Trim();

                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword + ' ' + character + ' ' + realmid;
                        proc1.StartInfo.UseShellExecute = false;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                        var count = 0;
                        do
                        {
                            count++;
                            Thread.Sleep(500);
                            //  "Dark Age of Camelot © 2001-2019 Electronic Arts Inc. All Rights Reserved."
                            // FindWindow("DAoCMW", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                            hWnd = FindWindow("DAoCMWC", "Dark Age of Camelot © 2001-2023 Electronic Arts Inc. All Rights Reserved.");
                            if (count > 15)
                            {
                                KryptonMessageBox.Show("Timed out waiting for game to start", "Timed Out");
                                break;
                            }
                        }
                        while (hWnd == IntPtr.Zero);
                        SetWindowText(hWnd, character);
                        Thread.Sleep(500);
                        proc1.Kill();
                    }
                    catch (Exception j)
                    {
                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                    }

                    killmutex();
                    AdminMode();
                    return;
                }
            }
        }
        private static void LoadFile()
        {
            if (File.Exists("Settings.ini"))
            {
                IniFile MyIni = new("Settings.ini");
                if (string.IsNullOrEmpty(MyIni.Read("TerminateKey")))
                MyIni.Write("TerminateKey", "Control+Shift+F4");
                if (string.IsNullOrEmpty(MyIni.Read("RenameKey")))
                    MyIni.Write("RenameKey", "Control+Shift+F1");
              }
            else
            {
                IniFile MyIni = new("Settings.ini");
                MyIni.Write("TerminateKey", "Control+Shift+F4");
                MyIni.Write("RenameKey", "Control+Alt+F1");
            }

            if (!File.Exists("accounts.ini"))                   
                File.Create("accounts.ini");

        }
        public static void CheckInstallation()
        {
            IniFile MyIni = new("Settings.ini");
            using frmServer frmServer = new();
            frmServer.ShowDialog();
            frmServer.Close();
        }

        public class Select : ISelect
        {
            /// <summary>
            /// Gets/sets folder in which dialog will be open.
            /// </summary>
            public string InitialFolder { get; set; }

            /// <summary>
            /// Gets/sets directory in which dialog will be open 
            /// if there is no recent directory available.
            /// </summary>
            public string DefaultFolder { get; set; }

            /// <summary>
            /// Gets selected folder.
            /// </summary>
            public string Folder { get; set; }
            public DialogResult ShowDialog()
            {
                return ShowDialog(owner: new WindowWrapper(IntPtr.Zero));
            }
            public DialogResult ShowDialog(IWin32Window owner)
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return ShowVistaDialog(owner);
                }
                else
                {
                    return ShowLegacyDialog(owner);
                }
            }
            public DialogResult ShowVistaDialog(IWin32Window owner)
            {
                NativeMethods.IFileDialog frm = (NativeMethods.IFileDialog)(new NativeMethods.FileOpenDialogRCW());
                frm.GetOptions(out uint options);
                options |= NativeMethods.FOS_PICKFOLDERS |
                           NativeMethods.FOS_FORCEFILESYSTEM |
                           NativeMethods.FOS_NOVALIDATE |
                           NativeMethods.FOS_NOTESTFILECREATE |
                           NativeMethods.FOS_DONTADDTORECENT;
                frm.SetOptions(options);
                if (InitialFolder != null)
                {
                    Guid riid = new("43826D1E-E718-42EE-BC55-A1E261C37BFE"); //IShellItem
                    if (NativeMethods.SHCreateItemFromParsingName
                       (InitialFolder, IntPtr.Zero, ref riid,
                        out NativeMethods.IShellItem directoryShellItem) == NativeMethods.S_OK)
                    {
                        frm.SetFolder(directoryShellItem);
                    }
                }
                if (DefaultFolder != null)
                {
                    Guid riid = new("43826D1E-E718-42EE-BC55-A1E261C37BFE"); //IShellItem
                    if (NativeMethods.SHCreateItemFromParsingName
                       (DefaultFolder, IntPtr.Zero, ref riid,
                        out NativeMethods.IShellItem directoryShellItem) == NativeMethods.S_OK)
                    {
                        frm.SetDefaultFolder(directoryShellItem);
                    }
                }

                if (frm.Show(owner.Handle) == NativeMethods.S_OK)
                {
                    if (frm.GetResult(out NativeMethods.IShellItem shellItem) == NativeMethods.S_OK)
                    {
                        if (shellItem.GetDisplayName(NativeMethods.SIGDN_FILESYSPATH,
                            out IntPtr pszString) == NativeMethods.S_OK)
                        {
                            if (pszString != IntPtr.Zero)
                            {
                                try
                                {
                                    Folder = Marshal.PtrToStringAuto(pszString);
                                    return DialogResult.OK;
                                }
                                finally
                                {
                                    Marshal.FreeCoTaskMem(pszString);
                                }
                            }
                        }
                    }
                }
                return DialogResult.Cancel;
            }
            public DialogResult ShowLegacyDialog(IWin32Window owner)
            {
                using SaveFileDialog frm = new();
                frm.CheckFileExists = false;
                frm.CheckPathExists = true;
                frm.CreatePrompt = false;
                frm.Filter = "|" + Guid.Empty.ToString();
                frm.FileName = "any";
                if (InitialFolder != null) { frm.InitialDirectory = InitialFolder; }
                frm.OverwritePrompt = false;
                frm.Title = "Select Folder";
                frm.ValidateNames = false;
                if (frm.ShowDialog(owner) == DialogResult.OK)
                {
                    Folder = Path.GetDirectoryName(frm.FileName);
                    return DialogResult.OK;
                }
                else
                {
                    return DialogResult.Cancel;
                }
            }

            public void Dispose() { } //just to have possibility of Using statement.
        }
        public class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="handle">Handle to wrap</param>
            public WindowWrapper(IntPtr handle)
            {
                _hwnd = handle;
            }

            /// <summary>
            /// Original ptr
            /// </summary>
            public IntPtr Handle => _hwnd;

            private readonly IntPtr _hwnd;
        }
        internal static class NativeMethods
        {
            #region Constants

            public const uint FOS_PICKFOLDERS = 0x00000020;
            public const uint FOS_FORCEFILESYSTEM = 0x00000040;
            public const uint FOS_NOVALIDATE = 0x00000100;
            public const uint FOS_NOTESTFILECREATE = 0x00010000;
            public const uint FOS_DONTADDTORECENT = 0x02000000;

            public const uint S_OK = 0x0000;

            public const uint SIGDN_FILESYSPATH = 0x80058000;

            #endregion

            #region COM

            [ComImport, ClassInterface(ClassInterfaceType.None),
            TypeLibType(TypeLibTypeFlags.FCanCreate),
                        Guid("DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7")]
            internal class FileOpenDialogRCW { }

            [ComImport(), Guid("42F85136-DB7E-439C-85F1-E4075D135FC8"),
                          InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            internal interface IFileDialog
            {
                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                [PreserveSig()]
                uint Show([In, Optional] IntPtr hwndOwner); //IModalWindow 

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetFileTypes([In] uint cFileTypes,
                [In, MarshalAs(UnmanagedType.LPArray)] IntPtr rgFilterSpec);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetFileTypeIndex([In] uint iFileType);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint GetFileTypeIndex(out uint piFileType);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint Advise([In, MarshalAs(UnmanagedType.Interface)] IntPtr pfde,
                out uint pdwCookie);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint Unadvise([In] uint dwCookie);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetOptions([In] uint fos);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint GetOptions(out uint fos);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint GetCurrentSelection
                     ([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint AddPlace
                  ([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, uint fdap);

                [MethodImpl(MethodImplOptions.InternalCall,
                 MethodCodeType = MethodCodeType.Runtime)]
                uint SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)]
                                     string pszDefaultExtension);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint Close([MarshalAs(UnmanagedType.Error)] uint hr);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint SetClientGuid([In] ref Guid guid);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint ClearClientData();

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
            }

            [ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"),
                        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            internal interface IShellItem
            {
                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint BindToHandler([In] IntPtr pbc, [In] ref Guid rbhid,
                [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out IntPtr ppvOut);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint GetDisplayName([In] uint sigdnName, out IntPtr ppszName);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint GetAttributes([In] uint sfgaoMask, out uint psfgaoAttribs);

                [MethodImpl(MethodImplOptions.InternalCall,
                            MethodCodeType = MethodCodeType.Runtime)]
                uint Compare([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
                             [In] uint hint, out int piOrder);
            }

            #endregion

            [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int SHCreateItemFromParsingName
             ([MarshalAs(UnmanagedType.LPWStr)] string pszPath, IntPtr pbc,
             ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new()
            {
                MyParent = this
            };
            frmAdd.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string character = ((MakeAccountList)listAccounts.SelectedObject).Character;
                string realm = ((MakeAccountList)listAccounts.SelectedObject).Realm;
                string note = ((MakeAccountList)listAccounts.SelectedObject).Note;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string page = ((MakeAccountList)listAccounts.SelectedObject).Page;

                using frmEdit frmEdit = new(account, password, character, note, server, realm, page);
                frmEdit.MyParent = this;
                frmEdit.ShowDialog();
                frmEdit.Close();
            }

            else
            {
                listAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Character is selected", "No Character Selected");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string character = ((MakeAccountList)listAccounts.SelectedObject).Character;
                string realm = ((MakeAccountList)listAccounts.SelectedObject).Realm;
                string note = ((MakeAccountList)listAccounts.SelectedObject).Note;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string page = ((MakeAccountList)listAccounts.SelectedObject).Page;
                string content = account + ',' + password + ',' + character + ',' + note + ',' + server + ',' + realm + ',' + page;

                string tempFile = Path.GetTempFileName();
                System.Collections.Generic.IEnumerable<string> linesToKeep = File.ReadLines("accounts.ini").Where(l => l != content);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete("accounts.ini");
                File.Move(tempFile, "accounts.ini");
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                listAccounts.RemoveObject(listAccounts.SelectedObject);
            }
            else
            {
                listAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Character is selected", "No Character Selected");
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string character = ((MakeAccountList)listAccounts.SelectedObject).Character;
                string realm = ((MakeAccountList)listAccounts.SelectedObject).Realm;
                string note = ((MakeAccountList)listAccounts.SelectedObject).Note;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string page = ((MakeAccountList)listAccounts.SelectedObject).Page;

                using frmEdit frmEdit = new(account, password, character, note, server, realm, page);
                frmEdit.MyParent = this;
                frmEdit.ShowDialog();
                frmEdit.Close();
            }
            else
            {
                listAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Character is selected", "No Character Selected");
            }
        }

        private void heraldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string character = ((MakeAccountList)listAccounts.SelectedObject).Character;
                string realm = ((MakeAccountList)listAccounts.SelectedObject).Realm;
                string note = ((MakeAccountList)listAccounts.SelectedObject).Note;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string page = ((MakeAccountList)listAccounts.SelectedObject).Page;
                if (server == "Atlas")
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://herald.atlasfreeshard.com/playerstat.php?player_name=" + character,
                        UseShellExecute = true
                    });
                }
                if (server == "Celestius")
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://herald.celestiusrvr.com/characters/" + character,
                        UseShellExecute = true
                    });
                }
                if (server.Contains("Ywain"))
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://search.camelotherald.com/#/search/c/Ywain/" + character,
                        UseShellExecute = true
                    });
                }
                if (server.Contains("Gaheris"))
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://search.camelotherald.com/#/search/c/Gaheris/" + character,
                        UseShellExecute = true
                    });
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string character = ((MakeAccountList)listAccounts.SelectedObject).Character;
                string realm = ((MakeAccountList)listAccounts.SelectedObject).Realm;
                string note = ((MakeAccountList)listAccounts.SelectedObject).Note;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string page = ((MakeAccountList)listAccounts.SelectedObject).Page;
                string content = account + ',' + password + ',' + character + ',' + note + ',' + server + ',' + realm + ',' + page;

                string tempFile = Path.GetTempFileName();
                System.Collections.Generic.IEnumerable<string> linesToKeep = File.ReadLines("accounts.ini").Where(l => l != content);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete("accounts.ini");
                File.Move(tempFile, "accounts.ini");
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                listAccounts.RemoveObject(listAccounts.SelectedObject);
            }
            else
            {
                listAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Character is selected", "No Character Selected");
            }
        }

        private void atlasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string FolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Atlas");
            System.IO.Directory.CreateDirectory(FolderName);
            Process.Start("explorer.exe", FolderName);
        }

        private void celestiusToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string FolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Celestius");
            System.IO.Directory.CreateDirectory(FolderName);
            Process.Start("explorer.exe", FolderName);
        }

        private void liveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string FolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\lotm");
            System.IO.Directory.CreateDirectory(FolderName);
            Process.Start("explorer.exe", FolderName);
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        private void terminateDAoCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using Process proc1 = new();
            proc1.StartInfo.FileName = "cmd.exe";
            proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc1.StartInfo.Arguments = "/C taskkill /im game.dll /f";
            proc1.StartInfo.UseShellExecute = true;
            proc1.StartInfo.RedirectStandardOutput = false;
            proc1.Start();
            using Process proc2 = new();
            proc2.StartInfo.FileName = "cmd.exe";
            proc2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc2.StartInfo.Arguments = "/C taskkill /im game1127.dll /f";
            proc2.StartInfo.UseShellExecute = true;
            proc2.StartInfo.RedirectStandardOutput = false;
            proc2.Start();
        }

        private void OnTerminate()
        {
            
            using Process proc1 = new();
            proc1.StartInfo.FileName = "cmd.exe";
            proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc1.StartInfo.Arguments = "/C taskkill /im game.dll /f";
            proc1.StartInfo.UseShellExecute = true;
            proc1.StartInfo.RedirectStandardOutput = false;
            proc1.Start();
            using Process proc2 = new();
            proc2.StartInfo.FileName = "cmd.exe";
            proc2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc2.StartInfo.Arguments = "/C taskkill /im game1127.dll /f";
            proc2.StartInfo.UseShellExecute = true;
            proc2.StartInfo.RedirectStandardOutput = false;
            proc2.Start();
            GC.Collect();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = listAccounts.SelectedObject == null;
        }

        public void SetupListviewTeams()
        {
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

            listTeams.ClearObjects();
            listTeams.View = View.Details;
            string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
            File.Delete("accounts.ini".ToString());
            File.WriteAllLines("accounts.ini".ToString(), text);
            StreamReader file = new("accounts.ini");
            string sLine;
            listTeams.BeginUpdate();
            while ((sLine = file.ReadLine()) != null)
            {
                string[] sarr = sLine.Split(',');
                if (sLine.StartsWith("TEAM"))
                {
                    MakeTeamList newObject = new(sarr[1], sarr[2]);
                    listTeams.AddObject(newObject);
                }
            }
            listTeams.EndUpdate();

            file.Close();
            listTeams.RebuildColumns();
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

        private void button3_Click(object sender, EventArgs e)
        {
            using frmTeamAdd frmTeamAdd = new();
            frmTeamAdd.MyParent = this;
            frmTeamAdd.ShowDialog();
            frmTeamAdd.Close();
        }

        private void btnTeamDelete_Click(object sender, EventArgs e)
        {
            if (listTeams.SelectedObjects.Count > 0)
            {
                string TeamName1 = ((MakeTeamList)listTeams.SelectedObject).TeamName;
                string members1 = ((MakeTeamList)listTeams.SelectedObject).TeamMember;
                string content = "TEAM," + TeamName1 + ',' + members1;

                string tempFile = Path.GetTempFileName();
                System.Collections.Generic.IEnumerable<string> linesToKeep = File.ReadLines("accounts.ini").Where(l => l != content);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete("accounts.ini");
                File.Move(tempFile, "accounts.ini");
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                listTeams.RemoveObject(listTeams.SelectedObject);
                //KryptonMessageBox.Show(content);
            }
            else
            {
                listTeams.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Team is selected", "No Team Selected");
            }
            listAccounts.Refresh();
        }

        public class MakeMemberList
        {
            private string teamname;
            private string teammember;



            public MakeMemberList(string teamname, string teammembers)
            {
                this.teamname = teamname;
                teammember = teammembers;


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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listTeams.SelectedObjects.Count > 0)
            {
                string teamname1 = ((MakeTeamList)listTeams.SelectedObject).TeamName;
                string teammember1 = ((MakeTeamList)listTeams.SelectedObject).TeamMember;
                using frmTeamEdit frmTeamEdit = new(teamname1, teammember1);
                frmTeamEdit.MyParent = this;
                frmTeamEdit.ShowDialog();
                frmTeamEdit.Close();
            }
            else
            {
                listTeams.SelectedObjects.Clear();
                KryptonMessageBox.Show("No team is selected", "No Team Selected");
            }
        }

        private void listTeams_DoubleClick(object sender, EventArgs e)
        {
            IntPtr hWnd;
            if (listTeams.SelectedObjects.Count > 0)
            {
                killmutex();
                string teammembersclicked = ((MakeTeamList)listTeams.SelectedObject).TeamMember;
                string[] seperateteammembers = teammembersclicked.Split(' ');
                foreach (string singlemember in seperateteammembers)
                {
                    string[] nameandrealm = singlemember.Split('-');
                    // MessageBox.Show("Name: " + nameandrealm[0] + Environment.NewLine + "Realm: " + nameandrealm[1]);

                    StreamReader filefindcharacters = new("accounts.ini");
                    string sLinefindcharacters;
                    while ((sLinefindcharacters = filefindcharacters.ReadLine()) != null)
                    {
                        string[] sarrfindcharacters = sLinefindcharacters.Split(',');
                        if (!sLinefindcharacters.StartsWith("TEAM"))
                        {
                            if (sarrfindcharacters[2] == nameandrealm[0] & sarrfindcharacters[4] == nameandrealm[1])
                            {
                                string account = sarrfindcharacters[0];
                                string password = sarrfindcharacters[1];
                                string character = sarrfindcharacters[2];
                                string realm = sarrfindcharacters[5];
                                string server = sarrfindcharacters[4];
                                string page = sarrfindcharacters[6];
                                string depassword = string.Empty;
                                string realmid = string.Empty;
                                string serveraddress = string.Empty;
                                string gamename = string.Empty;




                                if (realm == "Albion")
                                {
                                    realmid = "1";
                                }

                                if (realm == "Hibernia")
                                {
                                    realmid = "3";
                                }

                                if (realm == "Midgard")
                                {
                                    realmid = "2";
                                }

                                if (server == "Atlas")
                                {
                                    serveraddress = "138.201.59.161";
                                    gamename = "game1127.dll";
                                    try
                                    {
                                        using Process proc = new();
                                        IniFile MyIni = new("Settings.ini");
                                        string DAoCFolder = MyIni.Read("AtlasPath");
                                        if (string.IsNullOrEmpty(DAoCFolder))
                                        {
                                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                                            CheckInstallation();
                                            return;
                                        }
                                        proc.StartInfo.WorkingDirectory = DAoCFolder;
                                        proc.StartInfo.FileName = DAoCFolder + "\\connect.exe";
                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                        depassword = DPAPI.Decrypt(password);
                                        proc.StartInfo.Arguments = gamename + ' ' + serveraddress + ' ' + account + ' ' + depassword + ' ' + character + ' ' + realmid;
                                        proc.StartInfo.UseShellExecute = false;
                                        proc.StartInfo.RedirectStandardOutput = false;
                                        proc.Start();
                                        var count = 0;
                                        do
                                        {
                                            count++;
                                            Thread.Sleep(500);
                                            //  "Dark Age of Camelot © 2001-2019 Electronic Arts Inc. All Rights Reserved."
                                            // FindWindow("DAoCMW", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                                            hWnd = FindWindow("DAoCMWC", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                                            if (count > 15)
                                            {
                                                KryptonMessageBox.Show("Timed out waiting for game to start", "Timed Out");
                                                break;
                                            }
                                        }
                                        while (hWnd == IntPtr.Zero);
                                        Thread.Sleep(500);
                                        proc.Kill();
                                    }
                                    catch (Exception j)
                                    {
                                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                                    }
                                    killmutex();
                                }

                                if (server == "Celestius")
                                {

                                    serveraddress = "78.46.92.190 10300";
                                    gamename = "game.dll";

                                    try
                                    {
                                        using Process proc1 = new();
                                        IniFile MyIni = new("Settings.ini");
                                        string DAoCFolder = MyIni.Read("CelestiusPath");
                                        if (string.IsNullOrEmpty(DAoCFolder))
                                        {
                                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                                            CheckInstallation();
                                            return;
                                        }
                                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                                        proc1.StartInfo.FileName = DAoCFolder + "\\CelestiusConnect.exe";
                                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                        depassword = DPAPI.Decrypt(password);
                                        proc1.StartInfo.Arguments = "launch " + serveraddress + ' ' + account + ' ' + "\""+DAoCFolder+"\"" + " -p " + depassword + " --character-page " + page + " --character-name " + character + " --realm " + realmid;
                                        proc1.StartInfo.UseShellExecute = true;
                                        proc1.StartInfo.RedirectStandardOutput = false;
                                        proc1.Start();
                                        proc1.WaitForExit();
                                    }
                                    catch (Exception j)
                                    {
                                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                                    }
                                    int count = 0;
                                        do
                                        {
                                            count++;
                                            Thread.Sleep(500);
                                            //  "Dark Age of Camelot © 2001-2019 Electronic Arts Inc. All Rights Reserved."
                                            // FindWindow("DAoCMW", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                                            hWnd = FindWindow("DAoCMWC", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                                            if (count > 15)
                                            {
                                                KryptonMessageBox.Show("Timed out waiting for game to start", "Timed Out");
                                                break;
                                            }
                                        }
                                        while (hWnd == IntPtr.Zero);
                                        SetWindowText(hWnd, character);
                                        Thread.Sleep(500);
                                    killmutex();
                                }

                                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                                {
                                    string serverid = string.Empty;
                                    gamename = "game.dll";
                                    serveraddress = string.Empty;
                                    string port = "10622";

                                    if (server == "Ywain1")
                                    {
                                        serverid = "41";
                                        serveraddress = "107.23.173.143";
                                    }
                                    if (server == "Ywain2")
                                    {
                                        serverid = "49";
                                        serveraddress = "107.23.173.143";
                                    }
                                    if (server == "Ywain3")
                                    {
                                        serverid = "50";
                                        serveraddress = "107.23.173.143";
                                    }
                                    if (server == "Ywain4")
                                    {
                                        serverid = "51";
                                        serveraddress = "107.23.173.143";
                                    }

                                    if (server == "Ywain5")
                                    {
                                        serverid = "52";
                                        serveraddress = "107.23.173.143";
                                    }

                                    if (server == "Ywain6")
                                    {
                                        serverid = "53";
                                        serveraddress = "107.23.173.143";
                                    }
                                    if (server == "Ywain7")
                                    {
                                        serverid = "54";
                                        serveraddress = "107.23.173.143";
                                    }
                                    if (server == "Ywain8")
                                    {
                                        serverid = "55";
                                        serveraddress = "107.23.173.143";
                                    }

                                    if (server == "Ywain9")
                                    {
                                        serverid = "56";
                                        serveraddress = "107.23.173.143";
                                    }

                                    if (server == "Ywain10")
                                    {
                                        serverid = "57";
                                        serveraddress = "107.23.173.143";
                                    }

                                    if (server == "Gaheris")
                                    {
                                        serverid = "23";
                                        serveraddress = "107.21.60.95";
                                    }

                                    //% daocdir %\game.dll % ServerIP % " " % port % " " % ServerID % " " % CharToLaunchI1 % " " % Unprotect % " " % CharToLaunchI3 % " " % RealmID %
                                    try
                                    {
                                        using Process proc1 = new();
                                        IniFile MyIni = new("Settings.ini");
                                        string DAoCFolder = MyIni.Read("LivePath");
                                        if (string.IsNullOrEmpty(DAoCFolder))
                                        {
                                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                                            CheckInstallation();
                                            return;
                                        }
                                        depassword = DPAPI.Decrypt(password);
                                        depassword = depassword.Trim();

                                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                                        proc1.StartInfo.FileName = "cmd.exe";
                                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword + ' ' + character + ' ' + realmid;
                                        proc1.StartInfo.UseShellExecute = false;
                                        proc1.StartInfo.RedirectStandardOutput = false;
                                        proc1.Start();
                                        var count = 0;
                                        do
                                        {
                                            count++;
                                            Thread.Sleep(500);
                                            //  "Dark Age of Camelot © 2001-2019 Electronic Arts Inc. All Rights Reserved."
                                            // FindWindow("DAoCMW", "Dark Age of Camelot © 2001-2021 Electronic Arts Inc. All Rights Reserved.");
                                            hWnd = FindWindow("DAoCMWC", "Dark Age of Camelot © 2001-2023 Electronic Arts Inc. All Rights Reserved.");
                                            if (count > 10)
                                            {
                                                KryptonMessageBox.Show("Timed out waiting for game to start", "Timed Out");
                                                break;
                                            }
                                        }
                                        while (hWnd == IntPtr.Zero);
                                        SetWindowText(hWnd, character);
                                        Thread.Sleep(500);
                                        proc1.Kill();
                                    }
                                    catch (Exception j)
                                    {
                                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                                    }

                                    killmutex();
                                    AdminMode();
                                  
                                }

                            }


                        }


                    }

                }
            }
        }

        private void toolStripMenuTeamAdd_Click(object sender, EventArgs e)
        {
            using frmTeamAdd frmTeamAdd = new();
            frmTeamAdd.MyParent = this;
            frmTeamAdd.ShowDialog();
            frmTeamAdd.Close();

        }

        private void toolStripMenuTeamEdit_Click(object sender, EventArgs e)
        {
            if (listTeams.SelectedObjects.Count > 0)
            {
                string teamname1 = ((MakeTeamList)listTeams.SelectedObject).TeamName;
                string teammember1 = ((MakeTeamList)listTeams.SelectedObject).TeamMember;
                frmTeamEdit frmTeamEdit1 = new(teamname1, teammember1);
                using frmTeamEdit frmTeamEdit = frmTeamEdit1;
                frmTeamEdit.MyParent = this;
                frmTeamEdit.ShowDialog();
                frmTeamEdit.Close();
            }
            else
            {
                listTeams.SelectedObjects.Clear();
                KryptonMessageBox.Show("No team is selected", "No Team Selected");
            }
        }

        private void toolStripMenuTeamDelete_Click(object sender, EventArgs e)
        {
            if (listTeams.SelectedObjects.Count > 0)
            {
                string TeamName1 = ((MakeTeamList)listTeams.SelectedObject).TeamName;
                string members1 = ((MakeTeamList)listTeams.SelectedObject).TeamMember;
                string content = "TEAM," + TeamName1 + ',' + members1;
                string tempFile = Path.GetTempFileName();
                System.Collections.Generic.IEnumerable<string> linesToKeep = File.ReadLines("accounts.ini").Where(l => l != content);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete("accounts.ini");
                File.Move(tempFile, "accounts.ini");
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                listTeams.RemoveObject(listTeams.SelectedObject);
                // KryptonMessageBox.Show(content);
            }
            else
            {
                listTeams.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Team is selected", "No Team Selected");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }

        private void searchData(string searchTerm)
        {
            HighlightTextRenderer renderer = listAccounts.DefaultRenderer as HighlightTextRenderer;
            SolidBrush brush = renderer.FillBrush as SolidBrush ?? new SolidBrush(Color.Transparent);
            brush.Color = Color.Transparent;
            renderer.FillBrush = brush;
            renderer.FramePen = new Pen(Color.FromArgb(158, 158, 158));
            listAccounts.DefaultRenderer = renderer;
            listAccounts.ModelFilter = TextMatchFilter.Contains(listAccounts, searchTerm);
            listAccounts.Refresh();
        }

        private void searchDataTeam(string searchTermTeam)
        {
            HighlightTextRenderer renderer = listTeams.DefaultRenderer as HighlightTextRenderer;
            SolidBrush brush = renderer.FillBrush as SolidBrush ?? new SolidBrush(Color.Transparent);
            brush.Color = Color.Transparent;
            renderer.FillBrush = brush;
            renderer.FramePen = new Pen(Color.FromArgb(158, 158, 158));
            listTeams.DefaultRenderer = renderer;
            listTeams.ModelFilter = TextMatchFilter.Contains(listTeams, searchTermTeam);
            listTeams.Refresh();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            searchDataTeam(txtSearchTeam.Text);
        }

        private void gaherisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string gamename = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string port = "10622";
                gamename = "game.dll";
                string serverid = "23";
                string serveraddress = "107.21.60.95";
                if (server.Contains("Ywain") || server.Contains("gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        depassword = depassword.Trim();
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception j)
                    {
                        KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                    }
                    killmutex();
                    AdminMode();
                }
                else
                    KryptonMessageBox.Show("This account is not from a live server");
            }
        }

        private void ywain1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                string port = "10622";
                string serverid = "41";
                string serveraddress = "107.23.173.143";
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "49";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }

                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();

                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string port = "10622";
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + "50" + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "51";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "52";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }

                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "53";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }

                    killmutex();
                    AdminMode();
                }

                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "54";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "55";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "56";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void ywain10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeAccountList)listAccounts.SelectedObject).Account;
                string password = ((MakeAccountList)listAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "57";
                string serveraddress = "107.23.173.143";
                string server = ((MakeAccountList)listAccounts.SelectedObject).Server;
                if (server.Contains("Ywain") || server.Contains("Gaheris"))
                {
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }

                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
                else
                {
                    KryptonMessageBox.Show("This server did not have different servers", "Not Live");
                }
            }
        }

        private void OnRename()
        {
            IntPtr handle = GetForegroundWindow();
            string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Rename Window", "New Window Name", 0, 0);
            SetWindowText(handle, input);
        }

        private void convertOldAccountsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dr = KryptonMessageBox.Show("Are you sure? This can cause duplicate entries if your current character list is not empty." + Environment.NewLine + "This should only be done with a blank accounts.ini file to convert your AHK version of Hex to this version.",
                      "Experimental Feature", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    CopyAccounts();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        public void CopyAccounts()
        {
            System.IO.File.Copy("accounts.ini", "accountsbackup.ini", true);
            string account = string.Empty;
            string team = string.Empty;
            string depassword = string.Empty;
            string newmember = string.Empty;
            StreamReader file = new("accountsold.ini");
            string sLine;
            while ((sLine = file.ReadLine()) != null)
            {
                string[] sarr = sLine.Split(',');
                if (!string.IsNullOrEmpty(sarr[1]))
                {
                    sarr[1] = DPAPI.Decrypt(sarr[1]);
                    sarr[1] = sarr[1].Remove(sarr[1].Length - 1, 1);
                    sarr[1] = DPAPI.Encrypt(sarr[1]);
                }
                if (!string.IsNullOrEmpty(sarr[0]) & !string.IsNullOrEmpty(sarr[1]) & !string.IsNullOrEmpty(sarr[2]) & !string.IsNullOrEmpty(sarr[3]) & !string.IsNullOrEmpty(sarr[4]))
                {
                    account = sarr[0] + ',' + sarr[1] + ',' + sarr[2] + ',' + sarr[3] + ',' + sarr[4] + ',' + sarr[5] + ",0";
                    try
                    {
                        using FileStream fs = new("accounts.ini", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter write = new(fs);
                        write.BaseStream.Seek(0, SeekOrigin.End);
                        write.WriteLine(account);
                        write.Flush();
                        write.Close();
                        fs.Close();
                    }
                    catch
                    {
                        KryptonMessageBox.Show("Error Writing to File", "Error");
                        return;
                    }
                }

                if (string.IsNullOrEmpty(sarr[0]) & string.IsNullOrEmpty(sarr[1]))
                {
                    if (sarr[2].Contains("Ywain"))
                    {
                        newmember = sarr[2].Replace("Ywain", "-Ywain");
                    }
                    if (sarr[2].Contains("Gaheris"))
                    {
                        newmember = sarr[2].Replace("Gaheris", "-Gaheris");
                    }

                    try
                    {
                        FileStream fileStream = new("accounts.ini", FileMode.OpenOrCreate, FileAccess.Write);
                        using FileStream fs = fileStream;
                        StreamWriter write = new(fs);
                        write.BaseStream.Seek(0, SeekOrigin.End);
                        write.WriteLine("TEAM," + sarr[7] + ',' + newmember + Environment.NewLine);
                        write.Flush();
                        write.Close();
                        fs.Close();
                    }
                    catch
                    {
                        KryptonMessageBox.Show("Error Writing to File", "Error");
                        return;
                    }
                }
            }
            file.Close();
            SetupListviewCharacters();
            SetupListviewTeams();
            KryptonMessageBox.Show("Reconstruction of old accounts.ini complete....I hope", "Good Luck");

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2)
            };



        }

        private void OnTest()
        {
            MessageBox.Show("this was a test");
        }

        private void killmutex()
        {
            Thread.Sleep(500);
            try
            {
                using Process proc2 = new();
                proc2.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\Resources\\";
                proc2.StartInfo.FileName = "killmutex.exe";
                proc2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc2.StartInfo.Arguments = "\\BaseNamedObjects\\DAoCi1 \\BaseNamedObjects\\DAoCi2 \\BaseNamedObjects\\DAoC107.23.173.143_1 \\BaseNamedObjects\\DAoC107.23.173.143_2 \\BaseNamedObjects\\DAoC107.23.173.143_3";
                proc2.StartInfo.UseShellExecute = true;
                proc2.StartInfo.RedirectStandardOutput = false;
                proc2.Start();
            }
            catch (Exception t)
            {
                KryptonMessageBox.Show(t.Message, "Error");
            }
        }

        private void AdminMode()
        {
            string AdminMode = MyIni.Read("AdminMode");
            if (AdminMode == "TeeheheIsPr0")
            {

                try
                {
                    using Process proc3 = new();
                    proc3.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\Resources\\";
                    proc3.StartInfo.FileName = "Guid.exe";
                    proc3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    proc3.StartInfo.UseShellExecute = true;
                    proc3.StartInfo.RedirectStandardOutput = false;
                    proc3.Start();
                }
                catch (Exception t)
                {
                    KryptonMessageBox.Show(t.Message, "Error");
                }
                Thread.Sleep(3000);
            }

        }

        private void Hkl_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == terminatekey)
                OnTerminate();
            if (e.Hotkey == renamekey)
                OnRename();

        }

        private void dAoCInstallationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using frmServer frmServer = new();
            frmServer.ShowDialog();
            frmServer.Close();
        }

        private void copyCharacterFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using frmCopy frmCopy = new();
            frmCopy.ShowDialog();
            frmCopy.Close();
        }
        private void atlasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            string sourcePath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Atlas");
            string targetPath = Directory.GetCurrentDirectory() + "\\AtlasBackup" + DateTime.Now.ToFileTime();

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);


            System.IO.Directory.CreateDirectory(targetPath);
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                KryptonMessageBox.Show("Source path does not exist!", "File not found");
            }
            KryptonMessageBox.Show("Backup Complete");
            System.IO.Directory.CreateDirectory(targetPath);
            Process.Start("explorer.exe", targetPath);
        }

        private void celestiusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            string sourcePath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Celestius");
            string targetPath = "CelestiusBackup" + DateTime.Now.ToFileTime();

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);


            System.IO.Directory.CreateDirectory(targetPath);
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                KryptonMessageBox.Show("Source path does not exist!", "Folder does not exist");
            }
            KryptonMessageBox.Show("Backup Complete");
            string FolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Atlas");
            System.IO.Directory.CreateDirectory(targetPath);
            Process.Start("explorer.exe", targetPath);
        }

        private void ywainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            string sourcePath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData) + "\\Electronic Arts\\Dark Age of Camelot\\Lotm");
            string targetPath = "LiveBackup" + DateTime.Now.ToFileTime();

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);


            System.IO.Directory.CreateDirectory(targetPath);
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                KryptonMessageBox.Show("Source path does not exist!", "Folder does not exist");
            }
            KryptonMessageBox.Show("Backup Complete");
            string FolderName = Path.Combine(Directory.GetCurrentDirectory() + "\\" + fileName);
            System.IO.Directory.CreateDirectory(targetPath);
            Process.Start("explorer.exe", targetPath);
        }

        private void importLiveCharactersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using Import Import = new();
            Import.MyParent = this;
            Import.ShowDialog();
            Import.Close();
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hkl.Suspend();
            using frmHotkeys frmHotkeys = new();
            frmHotkeys.ShowDialog();
            frmHotkeys.Close();
            hkl.Update(ref terminatekey, new Hotkey(MyIni.Read("TerminateKey")));
            hkl.Update(ref renamekey, new Hotkey(MyIni.Read("RenameKey")));
            hkl.Resume();
        }

        private void listOAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gaherisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                if (listOAccounts.SelectedObjects.Count > 0)
                {
                    killmutex();
                    string depassword = string.Empty;
                    string gamename = string.Empty;
                    string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                    string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                    string port = "10622";
                    gamename = "game.dll";
                string server = "gaheris";
                    string serverid = "23";
                    string serveraddress = "107.21.60.95";
                    if (server.Contains("Ywain") || server.Contains("gaheris"))
                    {
                        try
                        {
                            using Process proc1 = new();
                            IniFile MyIni = new("Settings.ini");
                            string DAoCFolder = MyIni.Read("LivePath");
                            if (string.IsNullOrEmpty(DAoCFolder))
                            {
                                KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                                CheckInstallation();
                                return;
                            }
                            depassword = DPAPI.Decrypt(password);
                            depassword = depassword.Trim();
                            proc1.StartInfo.WorkingDirectory = DAoCFolder;
                            proc1.StartInfo.FileName = "cmd.exe";
                            proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                            proc1.StartInfo.UseShellExecute = true;
                            proc1.StartInfo.RedirectStandardOutput = false;
                            proc1.Start();
                        }
                        catch (Exception j)
                        {
                            KryptonMessageBox.Show(j.Message, "Error Possible Wrong Directory");
                        }
                        killmutex();
                        AdminMode();
                    }
                    else
                        KryptonMessageBox.Show("This account is not from a live server");
                }
            }

        private void ywain1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "41";
                string serveraddress = "107.23.173.143";
              
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
            }
        }

        private void ywain2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "49";
                string serveraddress = "107.23.173.143";

                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }

                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();

                }

            }

        private void ywain3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string port = "10622";
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string serveraddress = "107.23.173.143";
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + "50" + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
            }

        private void ywain4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "51";
                string serveraddress = "107.23.173.143";
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
            }

        private void ywain5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "52";
                string serveraddress = "107.23.173.143";
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }

                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }

            }

        private void ywain6ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "53";
                string serveraddress = "107.23.173.143";

                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }

                    killmutex();
                    AdminMode();
                }

        }

        private void ywain7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "54";
                string serveraddress = "107.23.173.143";
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }

        }

        private void ywain8ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "55";
                string serveraddress = "107.23.173.143";

                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }

            }

        private void ywain9ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "56";
                string serveraddress = "107.23.173.143";
                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }
                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }
             
        }

        private void ywain10ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                killmutex();
                string depassword = string.Empty;
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string port = "10622";
                string serverid = "57";
                string serveraddress = "107.23.173.143";

                    try
                    {
                        using Process proc1 = new();
                        IniFile MyIni = new("Settings.ini");
                        string DAoCFolder = MyIni.Read("LivePath");
                        if (string.IsNullOrEmpty(DAoCFolder))
                        {
                            KryptonMessageBox.Show("Missing installation folder please select", "Missing information");
                            CheckInstallation();
                            return;
                        }

                        depassword = DPAPI.Decrypt(password);
                        proc1.StartInfo.WorkingDirectory = DAoCFolder;
                        proc1.StartInfo.FileName = "cmd.exe";
                        proc1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc1.StartInfo.Arguments = "/K game.dll " + serveraddress + ' ' + port + ' ' + serverid + ' ' + account + ' ' + depassword;
                        proc1.StartInfo.UseShellExecute = true;
                        proc1.StartInfo.RedirectStandardOutput = false;
                        proc1.Start();

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message);
                    }
                    killmutex();
                    AdminMode();
                }

        }

        private void AddA_Click(object sender, EventArgs e)
        {
            frmOAdd frmOAdd = new()
            {
                MyParent = this
            };

            frmOAdd.ShowDialog();
        }

        private void EditA_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;


                using frmOEdit frmOEdit = new(account, password);
                frmOEdit.MyParent = this;
                frmOEdit.ShowDialog();
                frmOEdit.Close();
            }

            else
            {
                listOAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Account is selected", "No Account Selected");
            }
        }

        private void DeleteA_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string content = "ACCOUNT," + account + ',' + password + ",,,,";

                string tempFile = Path.GetTempFileName();
                System.Collections.Generic.IEnumerable<string> linesToKeep = File.ReadLines("accounts.ini").Where(l => l != content);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete("accounts.ini");
                File.Move(tempFile, "accounts.ini");
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                listOAccounts.RemoveObject(listOAccounts.SelectedObject);
            }
            else
            {
                listOAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Account is selected", "No Account Selected");
            }
        }

        private void contextMenuStrip5_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = listOAccounts.SelectedObject == null;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOAdd frmOAdd = new()
            {
                MyParent = this
            };
            frmOAdd.ShowDialog();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;
                string content = "ACCOUNT,"+account + ',' + password + ",,,,,";

                string tempFile = Path.GetTempFileName();
                System.Collections.Generic.IEnumerable<string> linesToKeep = File.ReadLines("accounts.ini").Where(l => l != content);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete("accounts.ini");
                File.Move(tempFile, "accounts.ini");
                string[] text = File.ReadAllLines("accounts.ini".ToString()).Where(s => s.Trim() != string.Empty).ToArray();
                File.Delete("accounts.ini".ToString());
                File.WriteAllLines("accounts.ini".ToString(), text);
                listOAccounts.RemoveObject(listOAccounts.SelectedObject);
            }
            else
            {
                listOAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Account is selected", "No Account Selected");
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listOAccounts.SelectedObjects.Count > 0)
            {
                string account = ((MakeOAccountList)listOAccounts.SelectedObject).Account;
                string password = ((MakeOAccountList)listOAccounts.SelectedObject).Password;


                using frmOEdit frmOEdit = new(account, password);
                frmOEdit.MyParent = this;
                frmOEdit.ShowDialog();
                frmOEdit.Close();
            }
            else
            {
                listOAccounts.SelectedObjects.Clear();
                KryptonMessageBox.Show("No Account is selected", "No Account Selected");
            }
        }

        private void textBoxAccount_TextChanged(object sender, EventArgs e)
        {
            searchDataAccount(textBoxAccount.Text);
        }
        private void searchDataAccount(string searchTermAccount)
        {
            HighlightTextRenderer renderer = listOAccounts.DefaultRenderer as HighlightTextRenderer;
            SolidBrush brush = renderer.FillBrush as SolidBrush ?? new SolidBrush(Color.Transparent);
            brush.Color = Color.Transparent;
            renderer.FillBrush = brush;
            renderer.FramePen = new Pen(Color.FromArgb(158, 158, 158));
            listOAccounts.DefaultRenderer = renderer;
            listOAccounts.ModelFilter = TextMatchFilter.Contains(listOAccounts, searchTermAccount);
            listOAccounts.Refresh();
        }
    }
}
  