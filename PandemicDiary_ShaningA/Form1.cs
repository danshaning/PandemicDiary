using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PandemicDiary_ShaningA
{
    public partial class Form1 : Form
    {
        Image[] pics = new Image[5];

        string[] captions = new string[5];

        int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                //populate the pics array
                pics[0] = Image.FromFile("firstPic.jpg");
                pics[1] = Image.FromFile("secPic.jpg");
                pics[2] = Image.FromFile("thirdPic.jpg");
                pics[3] = Image.FromFile("fourthpic.jpg");
                pics[4] = Image.FromFile("fifthPic.jpg");

                //populate the captions array
                captions[0] = "Covid19 is a crazy story, and I believe it learns us all a big lesson. Everything can change from one day to the other in this global world. I mean who could ever imagine that the whole world will be mandated to wear a mask in public space. This just shows us that even the smallest thing like breathing freely is not granted.";
                captions[1] = "Bringing back the focus on me, I can say that I was very affected by this situation. In fact, I came to the U.S at the beginning of 2020, just before covid started and the lockdown was first emitted. This situation has been a very weird experience since I did not know many people and was trying to adapt to the new culture. I don't need to say that it was not possible. The lockdown has caused the classes to go online, which highly limited interaction with people. And with no family around, I can tell you enough about how lonely I felt during the first months. ";
                captions[2] = "During that period, I browsed a lot on the internet. From dating apps like tinder to streaming apps like Netflix. In fact, I think I watched more movies and shows during 2020-2021 than I did in the last ten years of my life. Seriously! Netflix and my bed were my refuges. ";
                captions[3] = "Food delivery company increased their market share from under 20% in 2018 to 53% in 2021. Yes, like most of us, 2021 was not a good year in terms of good alimentation habits. I believe I highly participated in the Uber eats market share spike. I was giving myself excuses to not cook at home and eat all the junk food possible near me, without putting one foot outside. Meanwhile, my weight spiked too ...";
                captions[4] = "Now that life is getting back to normal, I think I have to take back control of my health wellbeing. In-person classes started to be offered again and my objective is to lose those extra pounds quickly to show the best version of myself. Also, I deleted a delivery app because the temptation is just insane. \n\nGood luck to everyone going back out there! See you soon hopefully.";

                pictureBox1.Image = pics[currentIndex];

                capt.Text = captions[currentIndex];
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("The file " + ex.Message + " does not exist.");
            }

        }

        private void capt_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            try
            {
                currentIndex--; //increment currentIndex


                //refresh picturebox
                pictureBox1.Image = pics[currentIndex];
                capt.Text = captions[currentIndex];
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("You've reached the first picture.", "Last Picture");
                currentIndex++;

            }

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                currentIndex++; //increment currentIndex


                //refresh picturebox
                pictureBox1.Image = pics[currentIndex];
                capt.Text = captions[currentIndex];
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("You've reached the last picture.", "Last Picture");
                //MessageBox.Show(ex.Message);
                currentIndex--;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Are you sure you want to quit?",
                                               "QUIT?",
                                               MessageBoxButtons.YesNo);

            if (ans == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            capt.Font = fontDialog1.Font;
        }
    }
}
