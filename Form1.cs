using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace HUAWEI_Publish_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (MessageBox.Show("출시될 시스템은 자체 개발하여 출시가 가능한 것으로 확인되었습니다!\n检测到要发布的系统是自研的，可以发布！", "자체 개발 업데이트 릴리스 도구 NEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    MessageBox.Show("사용 중인 시스템이 아마추어 시스템인 것으로 감지되었습니다. Huawei의 전문 시스템으로 변경하고 다시 시도하십시오!\n检测到您使用的系统是业余系统，请更换到华为的专业系统后重试！", "자체 개발 업데이트 릴리스 도구 NEXT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("동지님, 당신은 화웨이에 불충한 것 같습니다!\n同志，你疑似对华为不忠了！", "렌정페이", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                if (MessageBox.Show("检测到要发布的系统是自研的，可以发布！", "自研更新发布工具 NEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    MessageBox.Show("检测到您使用的系统是业余系统，请更换到华为的专业系统后重试！", "自研更新发布工具 NEXT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("同志，你疑似对华为不忠了！", "任正非", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    checkBox1_CheckedChanged(this, EventArgs.Empty);
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            checkBox1.Enabled = false;
            //File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV");
            //File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\본체!.MP4");
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV"))
                HttpDownloadFile("https://oss.xiaoyuan151.top/raw/Song%20of%20the%20Korean%20People's%20Army.wav", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV");
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\본체!.MP4"))
                HttpDownloadFile("https://oss.xiaoyuan151.top/raw/%E3%80%90P1%E3%80%91%E6%9C%9D%E9%B2%9C%E6%B0%91%E4%B8%BB%E4%B8%BB%E4%B9%89%E4%BA%BA%E6%B0%91%E5%85%B1%E5%92%8C%E5%9B%BD%E4%B8%87%E5%B2%81%EF%BC%81.mp4", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\본체!.MP4");
            MessageBox.Show("동료! 화웨이의 친절은 끝이 없습니다!\n同志！华为的恩情是还不完的！", "렌정페이", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            new Form2(this).Show();
            this.Hide();
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\본체!.WAV"))
                {
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV"))
                        HttpDownloadFile("https://oss.xiaoyuan151.top/raw/Song%20of%20the%20Korean%20People's%20Army.wav", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV");
                    File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\본체!.WAV");
                }
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\본체!.WAV");
            }
        }
    }
}
