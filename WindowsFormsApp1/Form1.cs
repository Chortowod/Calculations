using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //Как быстро скачается
        private void calculateTime()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label6.Visible = true;
                return;
            }
            label6.Visible = false;
            double space = Convert.ToDouble(textBox1.Text);
            double speed = Convert.ToDouble(textBox2.Text);
            int resultMinutesAll = Convert.ToInt32(space * 1024 / speed / 60);
            int resultMinutes = resultMinutesAll % 60;
            int resultHours = resultMinutesAll / 60;

            label3.Text = resultHours.ToString() + Calculations.HourCheck(resultHours);
            label4.Text = resultMinutes.ToString() + Calculations.MinuteCheck(resultMinutes);
        }

        private void calculateLength()
        {
            if (boxHeight.Text == "")
            {
                label7.Text = "Поле <Высота> не заполнено!";
                label7.Visible = true;
                return;
            }
            label7.Visible = false;
            decimal valueRatioX = ratioX.Value;
            decimal valueRatioY = ratioY.Value;
            decimal height = Convert.ToDecimal(boxHeight.Text);
            decimal length = valueRatioX * height / valueRatioY;
            boxLength.Text = Math.Round(length, 2).ToString();
        }

        private void calculateHeight()
        {
            if (boxLength.Text == "")
            {
                label7.Text = "Поле <Длина> не заполнено!";
                label7.Visible = true;
                return;
            }
            label7.Visible = false;
            decimal valueRatioX = ratioX.Value;
            decimal valueRatioY = ratioY.Value;
            decimal length = Convert.ToDecimal(boxLength.Text);
            decimal height = valueRatioY * length / valueRatioX;
            boxHeight.Text = Math.Round(height, 2).ToString();
        }

        private void checkSymbols(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        { calculateTime(); }

        private void button2_Click(object sender, EventArgs e)
        { calculateHeight(); }

        private void button3_Click(object sender, EventArgs e)
        { calculateLength(); }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        { checkSymbols(sender, e); }
        
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        { checkSymbols(sender, e); }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        { checkSymbols(sender, e); }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        { checkSymbols(sender, e); }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) calculateTime(); }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) calculateTime(); }

        private void boxLength_KeyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) calculateHeight(); }

        private void boxHeight_KeyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) calculateLength(); }
    }
}
