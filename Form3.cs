using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace HUAWEI_Publish_Tool
{
    public partial class Form3 : Form
    {
        Form1 form1 = null;
        public Form3(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\본체!.MP4";
        }

        public static string HttpDownloadFile(string url, string path)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form1.Close();
        }
    }
}
