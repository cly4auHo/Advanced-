using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace GZIPer
{
    public partial class Form1 : Form
    {
        private const string messageInPath = "Enter file name";
        private const string messageErrorFile = "File not found";
        private const string messageErrorDriver = "Chose driver";
        private const string messageErrorName = "File name is empty";
        private const string extension = ".txt";
        private const string extensionCompression = ".zip";
        private string correctPath;

        public Form1()
        {
            InitializeComponent();
            string[] logicalDrivers = Directory.GetLogicalDrives();

            foreach (string driver in logicalDrivers)
                CheckedListBox.Items.Add(driver);

            CheckedListBox.SetItemChecked(0, true);
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName.Text))
            {
                string driver = null;

                foreach (var item in CheckedListBox.CheckedItems)
                    if (item != null)
                        driver = item as string;

                if (!string.IsNullOrEmpty(driver))
                {
                    string[] allFiles = Directory.GetFiles(driver, "*" + extension, SearchOption.AllDirectories);

                    foreach (string file in allFiles)
                    {
                        if ((FileName.Text + extension).Equals(Path.GetFileName(file)))
                        {
                            correctPath = file;

                            using (FileStream fs = File.OpenRead(file))
                            {
                                byte[] bytes = new byte[1024];
                                UTF8Encoding encoding = new UTF8Encoding(true);

                                while (fs.Read(bytes, 0, bytes.Length) > 0)
                                    FileText.Text = encoding.GetString(bytes);

                                FileName.Text = messageInPath;
                                return;
                            }
                        }
                    }

                    FileText.Text = messageErrorFile;
                    return;
                }
                else
                {
                    FileText.Text = messageErrorDriver;
                    return;
                }
            }

            FileText.Text = messageErrorName;
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < CheckedListBox.Items.Count; i++)
                if (i != e.Index)
                    CheckedListBox.SetItemChecked(i, false);
        }

        private void FileName_MouseClick(object sender, MouseEventArgs e)
        {
            FileName.Text = string.Empty;
        }

        private void ButtonCompression_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(correctPath) && File.Exists(correctPath))
            {
                using (FileStream source = File.OpenRead(correctPath))
                {
                    string compressionFilePath = Path.GetDirectoryName(correctPath) + "\\" + Path.GetFileNameWithoutExtension(correctPath) + extensionCompression;

                    if (!File.Exists(compressionFilePath))
                    {
                        using (FileStream archive = File.Create(compressionFilePath))
                        {
                            using (GZipStream compressor = new GZipStream(archive, CompressionMode.Compress))
                            {
                                int bytes = source.ReadByte();

                                while (bytes != -1)
                                {
                                    compressor.WriteByte((byte)bytes);
                                    bytes = source.ReadByte();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
