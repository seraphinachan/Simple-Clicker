using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Clicker
{
    public partial class Form1 : Form
    {
        private double iTick = 0;
        private double iTotal = 0;

        private int i1Add = 1;
        private int i1Level = 1;

        private int i3Add = 1;
        private int i3Level = 0;

        private int i50Add = 0;
        private int i50Level = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer oTimer = new System.Windows.Forms.Timer();
            oTimer.Enabled = true;
            oTimer.Interval = 100;
            oTimer.Tick += OTimer_Tick;
            oTimer.Start();

            oTimer.Stop();
        }

        // 타이머에서 호출할 Event (Interval 간격 기준)
        private void OTimer_Tick(object sender, EventArgs e)
        {
            iTick = i1Add + i3Add + i50Add;
            iTotal = iTotal + iTick;

            lblTickPoint.Text = string.Format("{0} (1:{1}), (3:{2}), (50:{3})", iTick.ToString(), i1Level.ToString(), i3Level.ToString(), i50Level.ToString()); 
            lblTotal.Text = iTotal.ToString();
        }

        private void btn1Add_Click(object sender, EventArgs e)
        {
            Button obtn = sender as Button;

            switch (obtn.Name)
            {
                case "btn1Add":
                    if (iTotal > 100)
                    {
                        iTotal =iTotal - 100;

                        i1Level++;
                        i1Add = 1 * i1Level;
                    }
                    break;
                case "btn3Add":
                    if (iTotal > 300)
                    {

                        iTotal = iTotal - 300;

                        i3Level++;
                        i3Add = 3 * i3Level;
                    }
                    break;
                case "btn50Add":
                    if (iTotal > 5000)
                    {

                        iTotal = iTotal - 5000;

                        i50Level++;
                        i50Add = 50 * i3Level;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}