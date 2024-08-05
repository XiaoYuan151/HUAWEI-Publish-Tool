using System;
using System.Media;
using System.Windows.Forms;

namespace HUAWEI_Publish_Tool
{
    public partial class Form2 : Form
    {
        private Form1 form1 = null;
        private Boolean willClose = false;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HUAWEI.WAV";
            player.Load();
            player.PlayLooping();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Form3(this.form1).Show();
            willClose = true;
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (willClose == false)
            {
                if (MessageBox.Show("동지여, 당신은 장군에게 충성하는가?\n同志，你对将军忠诚吗？", "본체!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    MessageBox.Show("동지여, 당신은 장군에게 충성하는가?\n同志，你对将军忠诚吗？", "본체!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }
        }
    }
}
