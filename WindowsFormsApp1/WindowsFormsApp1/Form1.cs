using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        // these values are needed for some interpolations 
        int j = 0;
        int k = 0;
        int a = 0;
        int p = 100;
        int sL = 8;
        int sH = 45;
            
        //for manual mode
        int oilvalue { get; set; }
        int watervalue { get; set; }
        int oilLoW { get; set; }
        int waterLoW { get; set; }
        int sandLoW { get; set; }
        int sand { get; set; }
        int pmv { get; set; }
        int pressurevalue { get; set; }
        int pressurevalueLoW { get; set; }
        
        

        System.Media.SoundPlayer alarm = new System.Media.SoundPlayer("alarm.wav");

        public Form1()
        {

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //These contain what is to be done during form load, some initial presets.
            //disable display buttons
           

            Continue_btn1.Enabled = false;
            CONTINUE2.Enabled = false;           
            CONTINUE3.Enabled = false;
            CONTINUE4.Enabled = false;
            CONTINUE5.Enabled = false;
            Cancel_btn.Enabled = false;

            //disable sensor buttons
            rB_LIC.Enabled = false;
            rB_CV.Enabled = false;
            rB_PIC.Enabled = false;

            //disable input parameters and pressure control parameters
            Pressure_SP_txt.Enabled = false;
            Oil_Level_txtB.Enabled = false;
            Water_Level_txtB.Enabled = false;
            Sand_Level_txtB.Enabled = false;
            SEToilLW.Enabled = false;
            WaterLOW.Enabled = false;
            SandLow.Enabled = false;
            pressureLOW.Enabled = false;

            //open and disable all valves
            rB_open1.Checked = false;
            rB_open2.Checked = false;
            rB_open3.Checked = false;
            rB_open4.Checked = false;
            rB_open5.Checked = false;

            rB_open1.Enabled = false;
            rB_open2.Enabled = false;
            rB_open3.Enabled = false;
            rB_open4.Enabled = false;
            rB_open5.Enabled = false;

            rB_close1.Enabled = false;
            rB_close2.Enabled = false;
            rB_close3.Enabled = false;
            rB_close4.Enabled = false;
            rB_close5.Enabled = false;


            //disabling lables to display automatic values on start
            label11.Visible = false;
            label10.Visible = false;
            label9.Visible = false;
            label42.Visible = false;
            label43.Visible = false;
            label44.Visible = false;


            //timer for date and time             
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //enable the date and time
            label_Date.Text = DateTime.Now.ToLongDateString();
            label_time.Text = DateTime.Now.ToLongTimeString();

        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
           
            //at the start, the system checks if admin chooses manual or automatic mode.
            //checking for neccessary inputs

            if ((rB_AutoMode.Checked == false) && (rB_ManualMode.Checked == false))
            {
                MessageBox.Show("Welcome, Please select a mode and press start to begin to begin.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (rB_AutoMode.Checked == true)
            {
                Continue_btn1.Enabled = true;
                MessageBox.Show("You have selected Automatic mode, please press ok and Continue1 ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rB_ManualMode.Checked == true)
            {
                Continue_btn1.Enabled = true;
                MessageBox.Show("You have selected Maunual mode, please press ok and continue1", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            rB_AutoMode.Checked = false;
            rB_ManualMode.Checked = false;
            rB_close1.Checked = false;
            rB_close2.Checked = false;
            rB_close3.Checked = false;
            rB_close4.Checked = false;
            rB_close5.Checked = false;
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
            timer8.Stop();
            timer9.Stop();

            Pressure_SP_txt.Text = "";
            Oil_Level_txtB.Text = "";
            Water_Level_txtB.Text = "";
            Sand_Level_txtB.Text = "";


        }
        private void automode(object sender, EventArgs e)
        {

            //disable manual button
            rB_ManualMode.Enabled = false;

            //close and disable all valves
            rB_open1.Checked = false;
            rB_open2.Checked = false;
            rB_open3.Checked = false;
            rB_open4.Checked = false;
            rB_open5.Checked = false;

            rB_close1.Checked = true;
            rB_close2.Checked = true;
            rB_close3.Checked = true;
            rB_close4.Checked = true;
            rB_close5.Checked = true;

            rB_open1.Enabled = true;
            rB_open2.Enabled = true;
            rB_open3.Enabled = true;
            rB_open4.Enabled = true;
            rB_open5.Enabled = true;

            rB_close1.Enabled = true;
            rB_close2.Enabled = true;
            rB_close3.Enabled = true;
            rB_close4.Enabled = true;
            rB_close5.Enabled = true;
            


        }
        private void ManualMode(object sender, EventArgs e)
        {
            //disable automode button
            rB_AutoMode.Enabled = false;


            //close and disable all valves
            rB_open1.Checked = false;
            rB_open2.Checked = false;
            rB_open3.Checked = false;
            rB_open4.Checked = false;
            rB_open5.Checked = false;

            rB_close1.Checked = true;
            rB_close2.Checked = true;
            rB_close3.Checked = true;
            rB_close4.Checked = true;
            rB_close5.Checked = true;

            rB_open1.Enabled = true;
            rB_open2.Enabled = true;
            rB_open3.Enabled = true;
            rB_open4.Enabled = true;
            rB_open5.Enabled = true;

            rB_close1.Enabled = true;
            rB_close2.Enabled = true;
            rB_close3.Enabled = true;
            rB_close4.Enabled = true;
            rB_close5.Enabled = true;


        }
        private void Crude_Oil_In_timer_Tick(object sender, EventArgs e)
        {    
        }
        private void LMVwater_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
        private void Continue_btn1_Click(object sender, EventArgs e)
        {

            //first we check if manual or automode has been selectedby using these if statements.
            if (rB_ManualMode.Checked == true)
            {

                //if manual mode is selected, User has to input all level setpoints. Bt first we enable all textboxes
                Pressure_SP_txt.Enabled = true;
                Oil_Level_txtB.Enabled = true;
                Water_Level_txtB.Enabled = true;
                Sand_Level_txtB.Enabled = true;
                SEToilLW.Enabled = true;
                WaterLOW.Enabled = true;
                SandLow.Enabled = true;
                pressureLOW.Enabled = true;
                label46.Visible = false;
                label45.Visible = false;
                CONTINUE2.Enabled = true;

                if (Oil_Level_txtB.Text == "")
                {
                    MessageBox.Show("Please Enter Oil Level Setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (Water_Level_txtB.Text == "")
                {
                    MessageBox.Show("Please Enter Water Level Setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (Sand_Level_txtB.Text == "")
                {
                    MessageBox.Show("Please Enter Sand Level Setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (pressureLOW.Text == "")
                {
                    MessageBox.Show("Please enter a value for pressure setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (SEToilLW.Text == "")
                {
                    MessageBox.Show("Please enter a value for the low oil setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (WaterLOW.Text == "")
                {
                    MessageBox.Show("Please enter a value for the low water setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (SandLow.Text == "")
                {
                    MessageBox.Show("Please enter a value for the low sand setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Pressure_SP_txt.Text=="")
                {
                    MessageBox.Show("Please enter a value for the low pressure setpoint and all other setpoints and press ok then continue2", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (Convert.ToDouble(Pressure_SP_txt.Text) <= 100 || Convert.ToDouble(Pressure_SP_txt.Text) >= 300)
                {
                    MessageBox.Show("Please Pressure Setpoint Range is 100PSI - 300PSI", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(Oil_Level_txtB.Text) <= 50 || Convert.ToDouble(Oil_Level_txtB.Text) >= 100)
                {
                    MessageBox.Show("Please Oil Level Setpoint Range is 50m - 100m", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(Water_Level_txtB.Text) <= 50 || Convert.ToDouble(Water_Level_txtB.Text) >= 100)
                {
                    MessageBox.Show("Please Water Level Setpoint Range is 50m - 100m", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (Convert.ToDouble(Sand_Level_txtB.Text) <= 10 || Convert.ToDouble(Sand_Level_txtB.Text) >= 50)
                {
                    MessageBox.Show("Please Sand Level Setpoint Range is <=55", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(pressureLOW.Text) <= 50 || Convert.ToDouble(pressureLOW.Text) >= 100)
                {
                    MessageBox.Show("Please pressure value setpoint Range is >50", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(SandLow.Text) <= 0 || Convert.ToDouble(SandLow.Text) >= 20)
                {
                    MessageBox.Show("Please pressure value setpoint Range is >50", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(WaterLOW.Text) <= 0 || Convert.ToDouble(WaterLOW.Text) >= 30)
                {
                    MessageBox.Show("Please pressure value setpoint Range is >50", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (rB_open1.Checked == false)
                {
                    rB_open1.Enabled = true;
                    rB_open2.Enabled = true;
                    rB_open3.Enabled = true;
                    rB_open4.Enabled = true;
                    rB_open5.Enabled = true;
                    MessageBox.Show("Please open valve 1", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (rB_open1.Checked == true)
                {
                    MessageBox.Show("All done here, please press continue2 to to continue", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }

            else if (rB_AutoMode.Checked == true)
            { //for full automode, the system is supposed to calculate and use its own numbers, to do that we can use random values for the inputs.
                // Random GetRandomNumber = new Random();      this create a random number generator
                // Double volume = GetRandomNumber.Next(1000, 5000);     creates a random number called volume between 1000 and 5000
                //Volume_txtB.Text = volume.ToString();     And passes the number to the textbox.

                //But ive decided to use fixed numbers because in automode, the setpoints need to be fixed for the sensors to triger anytime it hits those values
                //to diplay the values, i have added new labels on top of the textboxes. their visibility have been disabled on form load
                //the textboxes that gets the manual values have already been disabled so now i just have to set the lables to visible

                label11.Visible = true;
                label10.Visible = true;
                label9.Visible = true;
                label42.Visible = true;
                label43.Visible = true;
                label44.Visible = true;
                label45.Visible = true;

                label9.Text = "95";
                label42.Text = "10";
                label10.Text = "96";
                label43.Text = "12";
                label11.Text = "45";
                label44.Text = "8";
                label46.Text = "98";
                label45.Text = "55";

                
                //note that these values are of type string, so to use them we need to convert the to the type of choice.
                //that will be done later when we need these values

                timer4.Start();

            }

        }
        private void timer4_Tick(object sender, EventArgs e)
        {
//Automode 
            if (rB_AutoMode.Checked == true)
            {
                //There are two progress bars being used here. 
                //Progress bar 1 moves twice as slow as valve1ctrl.
                //The reason being that the valve 1 should finish moving first before the pannels in the first section of seperation tank starts
                progressBar1.Enabled = true;
                progressBar1.Increment(1);
                valve1ctrl.Enabled = true;
                valve1ctrl.Increment(2);

                string message = "THE FIRST STAGE OF SEPERATION COMPLETE, please press ok to continue";
                string title = "ALL DONE";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                rB_open1.Enabled = true;
                rB_close1.Enabled = false;
                rB_open1.Checked = true;
                rB_close1.Checked = false;

                
                if (progressBar1.Value == 60)
                {
                    panel5.Visible = true;
                    panel5.BackColor = Color.SandyBrown;
                }
                if (progressBar1.Value == 70)
                {
                    panel7.Visible = true;
                    panel7.BackColor = Color.Brown;
                }
                if (progressBar1.Value == 80)
                {
                    panel6.Visible = true;
                    panel6.BackColor = Color.FloralWhite;
                }
                if (progressBar1.Value==90)
                {
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        timer5.Start();
                    }
                }
            }
//Manual mode
            if (rB_ManualMode.Checked==true)
                {
                //There are two progress bars being used here. 
                //Progress bar 1 moves twice as slow as valve1ctrl.
                //The reason being that the valve 1 should finish moving first before the pannels in the first section of seperation tank starts

                progressBar1.Enabled = true;
                progressBar1.Increment(1);
                valve1ctrl.Enabled = true;
                valve1ctrl.Increment(2);

                string message = "THE FIRST STAGE OF SEPERATION COMPLETE, please press to continue3 to procceed";
                string title = "ALL DONE";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                rB_open1.Enabled = true;
                rB_close1.Enabled = false;
                rB_open1.Checked = true;
                rB_close1.Checked = false;

                if (progressBar1.Value == 60)
                {
                    panel5.Visible = true;
                    panel5.BackColor = Color.SandyBrown;
                }
                if (progressBar1.Value == 70)
                {
                    panel7.Visible = true;
                    panel7.BackColor = Color.Brown;
                }
                if (progressBar1.Value == 80)
                {
                    panel6.Visible = true;
                    panel6.BackColor = Color.FloralWhite;                    
                }
                if (progressBar1.Value == 90)
                {
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    //continue 3 is then enabled
                    CONTINUE3.Enabled = true;
                }
            }

        }
        private void CONTINUE2_Click(object sender, EventArgs e)
        {
            //this continue button only works for the manual mode
            timer4.Start();
        }
        private void CONTINUE3_Click(object sender, EventArgs e)
        {
            timer5.Start();
            //this continue button only works for the manual mode
        }
        private void timer5_Tick_1(object sender, EventArgs e)
        {
            //We have to check which mode has been selected
            //automode
                     
            if (rB_AutoMode.Checked==true)
            {
                progressBar8.Enabled = true;
                progressBar8.Increment(1);

                //these codes take in and parse the labeled text into int for use.
                //the numbers will increase an decrease at these points
                sand = int.Parse(label11.Text);
                sandLoW = int.Parse(label44.Text);
                int sandchanger = sand;

                LMVsand.Text = a + "";
                a++;

                if (a >= sand)
                {
                    LMVsand.Text = sand + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }
                if (progressBar8.Value == 6)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                }
                if (progressBar8.Value == 12)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                }
                if (progressBar8.Value == 18)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                }
                if (progressBar8.Value == 24)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                   
                }
                if (progressBar8.Value == 30)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                   }

                if (progressBar8.Value == 36)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                   }
                if (progressBar8.Value == 42)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                   }
                if (progressBar8.Value == 48)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    }
                if (progressBar8.Value == 54)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    }
                if (progressBar8.Value == 60)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Aqua;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Aqua;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Black;
                   }
                if (progressBar8.Value == 65)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Aqua;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Aqua;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Aqua;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Black;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Black;
                    }
                if (progressBar8.Value == 70)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Aqua;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Aqua;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Aqua;
                    water1.Visible = true;
                    water1.BackColor = Color.Aqua;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Black;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Black;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Black;          
                }
                if (progressBar8.Value == 75)
                {

                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Aqua;
                    water4.Visible = true;
                    water4.BackColor = Color.Aqua;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                    }


                if (progressBar8.Value == 80)
                {

                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Aqua;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                }

                if (progressBar8.Value == 85)
                     {
                         oil1.Visible = true;
                         oil1.BackColor = Color.SandyBrown;
                         oil2.Visible = true;
                         oil2.BackColor = Color.SandyBrown;
                         oil3.Visible = true;
                         oil3.BackColor = Color.SandyBrown;
                         oil4.Visible = true;
                         oil4.BackColor = Color.SandyBrown;
                         oil4.Visible = true;
                         oil4.BackColor = Color.Black;
                         oil5.Visible = true;
                         oil5.BackColor = Color.Black;
                         water1.Visible = true;
                         water1.BackColor = Color.Black;
                         water2.Visible = true;
                         water2.BackColor = Color.Black;
                         water3.Visible = true;
                         water3.BackColor = Color.Black;
                         water4.Visible = true;
                         water4.BackColor = Color.Aqua;
                         water5.Visible = true;
                         water5.BackColor = Color.Aqua;
                         panel8.Visible = true;
                         panel8.BackColor = Color.Aqua;
                         panel9.Visible = true;
                         panel9.BackColor = Color.Aqua;
                         panel10.Visible = true;
                         panel10.BackColor = Color.Aqua;
                         panel32.Visible = true;
                         panel32.BackColor = Color.Aqua;
                        

                }
                     if (progressBar8.Value==90)
                     {


                             oil1.Visible = true;
                             oil1.BackColor = Color.SandyBrown;
                             oil2.Visible = true;
                             oil2.BackColor = Color.SandyBrown;
                             oil3.Visible = true;
                             oil3.BackColor = Color.SandyBrown;
                             oil4.Visible = true;
                             oil4.BackColor = Color.SandyBrown;
                             oil4.Visible = true;
                             oil4.BackColor = Color.SandyBrown;
                             oil5.Visible = true;
                             oil5.BackColor = Color.Black;
                             water1.Visible = true;
                             water1.BackColor = Color.Black;
                             water2.Visible = true;
                             water2.BackColor = Color.Black;
                             water3.Visible = true;
                             water3.BackColor = Color.Black;
                             water4.Visible = true;
                             water4.BackColor = Color.Black;
                             water5.Visible = true;
                             water5.BackColor = Color.Aqua;
                             panel8.Visible = true;
                             panel8.BackColor = Color.Aqua;
                             panel9.Visible = true;
                             panel9.BackColor = Color.Aqua;
                             panel10.Visible = true;
                             panel10.BackColor = Color.Aqua;
                             panel32.Visible = true;
                             panel32.BackColor = Color.Aqua;
                            panel33.Visible = true;
                            panel33.BackColor = Color.Aqua;

                }

                if (progressBar8.Value == 95)
                     {

                         oil1.Visible = true;
                         oil1.BackColor = Color.SandyBrown;
                         oil2.Visible = true;
                         oil2.BackColor = Color.SandyBrown;
                         oil3.Visible = true;
                         oil3.BackColor = Color.SandyBrown;
                         oil4.Visible = true;
                         oil4.BackColor = Color.SandyBrown;
                         oil4.Visible = true;
                         oil4.BackColor = Color.SandyBrown;
                         oil5.Visible = true;
                         oil5.BackColor = Color.Black;
                         water1.Visible = true;
                         water1.BackColor = Color.Black;
                         water2.Visible = true;
                         water2.BackColor = Color.Black;
                         water3.Visible = true;
                         water3.BackColor = Color.Black;
                         water4.Visible = true;
                         water4.BackColor = Color.Black;
                         water5.Visible = true;
                         water5.BackColor = Color.Aqua;
                         panel8.Visible = true;
                         panel8.BackColor = Color.Aqua;
                         panel9.Visible = true;
                         panel9.BackColor = Color.Aqua;
                         panel10.Visible = true;
                         panel10.BackColor = Color.Aqua;
                         panel33.Visible = true;
                         panel33.BackColor = Color.Aqua;
                         gas1.Visible = true;
                         gas1.BackColor = Color.Aqua;
                         gas2.Visible = true;
                         gas2.BackColor = Color.Aqua;
                }
                if (progressBar8.Value==94)
                {
                    sandLevelctrl = new Timer();
                    sandLevelctrl.Interval = 100;
                    sandLevelctrl.Tick += new EventHandler(sandLevelctrl_Tick);
                    
                    sandLevelctrl.Start();
                }
                    
            }

            if (rB_ManualMode.Checked == true)
            {
                progressBar8.Enabled = true;
                progressBar8.Increment(1);

                //these variables will take in and parse the labeled text into int for use.
                //the numbers will increase an decrease at these points
                sand = int.Parse(Sand_Level_txtB.Text);
                sandLoW = int.Parse(SandLow.Text);
                int sandchanger = sand;

                LMVsand.Text = a + "";
                a++;

                string message = "THE FIRST STAGE OF SEPERATION IS COMPLETE, please press OK to procceed to reduce the sand level.";
                string title = "ALL DONE";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                if (a >= sandchanger)
                {
                    LMVsand.Text = sandchanger + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }
                if (progressBar8.Value == 6)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                }
                if (progressBar8.Value == 12)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                }
                if (progressBar8.Value == 18)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                }
                if (progressBar8.Value == 24)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;

                }
                if (progressBar8.Value == 30)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                }

                if (progressBar8.Value == 36)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                }
                if (progressBar8.Value == 42)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Black;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                }
                if (progressBar8.Value == 48)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Black;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                }
                if (progressBar8.Value == 54)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                }
                if (progressBar8.Value == 60)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Aqua;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Aqua;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Black;
                }
                if (progressBar8.Value == 65)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.Aqua;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Aqua;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Aqua;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Aqua;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Black;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Black;
                }
                if (progressBar8.Value == 70)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.Aqua;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Aqua;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Aqua;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Aqua;
                    water1.Visible = true;
                    water1.BackColor = Color.Aqua;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Black;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Black;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Black;
                }
                if (progressBar8.Value == 75)
                {

                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.Black;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Aqua;
                    water4.Visible = true;
                    water4.BackColor = Color.Aqua;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                }


                if (progressBar8.Value == 80)
                {

                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Aqua;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                }

                if (progressBar8.Value == 85)
                {
                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.Black;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Aqua;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                    panel32.Visible = true;
                    panel32.BackColor = Color.Aqua;


                }
                if (progressBar8.Value == 90)
                {


                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.SandyBrown;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                    panel32.Visible = true;
                    panel32.BackColor = Color.Aqua;
                    panel33.Visible = true;
                    panel33.BackColor = Color.Aqua;

                }

                if (progressBar8.Value == 95)
                {

                    oil1.Visible = true;
                    oil1.BackColor = Color.SandyBrown;
                    oil2.Visible = true;
                    oil2.BackColor = Color.SandyBrown;
                    oil3.Visible = true;
                    oil3.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.SandyBrown;
                    oil4.Visible = true;
                    oil4.BackColor = Color.SandyBrown;
                    oil5.Visible = true;
                    oil5.BackColor = Color.Black;
                    water1.Visible = true;
                    water1.BackColor = Color.Black;
                    water2.Visible = true;
                    water2.BackColor = Color.Black;
                    water3.Visible = true;
                    water3.BackColor = Color.Black;
                    water4.Visible = true;
                    water4.BackColor = Color.Black;
                    water5.Visible = true;
                    water5.BackColor = Color.Aqua;
                    panel8.Visible = true;
                    panel8.BackColor = Color.Aqua;
                    panel9.Visible = true;
                    panel9.BackColor = Color.Aqua;
                    panel10.Visible = true;
                    panel10.BackColor = Color.Aqua;
                    panel33.Visible = true;
                    panel33.BackColor = Color.Aqua;
                    gas1.Visible = true;
                    gas1.BackColor = Color.Aqua;
                    gas2.Visible = true;
                    gas2.BackColor = Color.Aqua;
                }
                if (progressBar8.Value==99)
                {
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        sandLevelctrl.Start();
                    }
                }
               
                

            }

        }       
        private void sandLevelctrl_Tick(object sender, EventArgs e)
        {
            
            //This timer controls the sand level indicator
            if (rB_AutoMode.Checked == true)
            {
                pBarSandLevel.Enabled = true;
                pBarSandLevel.Increment(1);

                string message = "THE FIRST STAGE OF SEPERATION COMPLETE, please ok to continue";
                string title = "ALL DONE";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                label39.Text = sH + "";
                sH--;

                if (sH <= sandLoW)
                {
                    label39.Text = sandLoW + "";
                }
                if (pBarSandLevel.Value==10)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                }
                if (pBarSandLevel.Value ==20)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value==30)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value==40)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandpnl4.Visible = true;
                    sandpnl4.BackColor = Color.SandyBrown;
                    oil3.BackColor = Color.Black;              
                }
                if (pBarSandLevel.Value==50)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandpnl4.Visible = true;
                    sandpnl4.BackColor = Color.SandyBrown;
                    oil3.BackColor = Color.Black;
                    sandPnl5.Visible = true;
                    sandPnl5.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value==60)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandpnl4.Visible = true;
                    sandpnl4.BackColor = Color.SandyBrown;
                    oil3.BackColor = Color.Black;
                    sandPnl5.Visible = true;
                    sandPnl5.BackColor = Color.SandyBrown;
                    oil2.BackColor = Color.Black;
                    sandPnl6.Visible = true;
                    sandPnl6.BackColor = Color.SandyBrown;
                    oil1.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value==64)
                {
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        timer8.Start(); 
                    }
                }
            }
//manual mode
            if (rB_ManualMode.Checked)
            {
                pBarSandLevel.Enabled = true;
                pBarSandLevel.Increment(1);
                label39.Text = sand + "";
                sand--;

                if (pBarSandLevel.Value == 10)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                }
                if (pBarSandLevel.Value == 20)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value == 30)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value == 40)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandpnl4.Visible = true;
                    sandpnl4.BackColor = Color.SandyBrown;
                    oil3.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value == 50)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandpnl4.Visible = true;
                    sandpnl4.BackColor = Color.SandyBrown;
                    oil3.BackColor = Color.Black;
                    sandPnl5.Visible = true;
                    sandPnl5.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value == 60)
                {
                    sandpnl1.Visible = true;
                    sandpnl1.BackColor = Color.SandyBrown;
                    sandPnl2.Visible = true;
                    sandPnl2.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                    sandPnl3.Visible = true;
                    sandPnl3.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandpnl4.Visible = true;
                    sandpnl4.BackColor = Color.SandyBrown;
                    oil3.BackColor = Color.Black;
                    sandPnl5.Visible = true;
                    sandPnl5.BackColor = Color.SandyBrown;
                    oil4.BackColor = Color.Black;
                    sandPnl6.Visible = true;
                    sandPnl6.BackColor = Color.SandyBrown;
                    oil5.BackColor = Color.Black;
                }
                if (pBarSandLevel.Value == 64)
                {
                    MessageBox.Show("SAND LEVEL HAS BEEN REDUCED, please press continue3 to proceed", "ALL DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CONTINUE4.Enabled = true;
                }
            }

        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            //we check which mode hass been selected
            if(rB_ManualMode.Checked==true)
            {
                string message = "THE SECOND STAGE OF SEPERATION COMPLETE, please press ok then continue5 to proceed";
                string title = "ALL DONE";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                int changer, changer2;  //these values will hold the values of the oil and water levels set by the user.

                oilvalue = int.Parse(Oil_Level_txtB.Text);
                watervalue = int.Parse(Water_Level_txtB.Text);
                oilLoW = int.Parse(SEToilLW.Text);
                waterLoW = int.Parse(WaterLOW.Text);
                pressurevalue = int.Parse(Pressure_SP_txt.Text);
                pressurevalueLoW = int.Parse(pressureLOW.Text);
                pmv = int.Parse(Pressure_SP_txt.Text);
                changer = int.Parse(Oil_Level_txtB.Text);
                changer2 = int.Parse(Water_Level_txtB.Text);
                

                progressBar5.Enabled = true;
                progressBar5.Increment(1);


                PMVlevel.Text = p + "";
                p++;
                LMVoil.Text = j + "";
                j++;
                LMVwater.Text = k + "";
                k++;
                if (j >= changer)
                {
                    LMVoil.Text = changer + "";
                    rB_CV.Checked = true;
                    rB_LIC.Checked = false;
                    rB_PIC.Checked = false;
                }

                if (p >= pmv)
                {
                    PMVlevel.Text = pmv + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false; ;

                }


                if (k >= changer2)
                {
                    LMVwater.Text = changer2 + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }

                if (progressBar5.Value == 0)
                {
                    panel12.Visible = false;
                    panel15.Visible = false;
                    panel14.Visible = false;
                    panel13.Visible = false;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;
                }
                if (progressBar5.Value == 5)
                {
                    panel12.Visible = true;
                    panel15.Visible = false;
                    panel14.Visible = false;
                    panel13.Visible = false;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;


                    panel12.BackColor = Color.Black;

                }
                if (progressBar5.Value == 10)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = false;
                    panel13.Visible = false;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;


                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;


                }
                if (progressBar5.Value == 15)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;


                }
                if (progressBar5.Value == 20)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;

                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;

                }
                if (progressBar5.Value == 25)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;

                }
                if (progressBar5.Value == 30)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;



                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                }
                if (progressBar5.Value == 35)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;


                }
                if (progressBar5.Value == 40)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;


                }
                if (progressBar5.Value == 45)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;


                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;


                }
                if (progressBar5.Value == 50)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;


                }
                if (progressBar5.Value == 55)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;


                }
                if (progressBar5.Value == 60)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;


                }
                if (progressBar5.Value == 65)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;


                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;


                }
                if (progressBar5.Value == 70)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;


                }
                if (progressBar5.Value == 75)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;


                }
                if (progressBar5.Value == 80)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;


                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;


                }
                if (progressBar5.Value == 85)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;


                }
                if (progressBar5.Value == 88)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                }
                if (progressBar5.Value == 91)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                }
                if (progressBar5.Value == 94)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = true;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;

                }
                if (progressBar5.Value == 97)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = true;
                    panel31.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;


                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }
                if (progressBar5.Value==99)
                {
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result== DialogResult.OK)
                    {
                        CONTINUE5.Enabled = true;
                    }
                }
            }
//automode
            if (rB_AutoMode.Checked==true)
            {
                int changer, changer2;

                string message = "THE SECOND STAGE OF SEPERATION COMPLETE, please press OK  to proceed";
                string title = "ALL DONE";
                MessageBoxButtons buttons = MessageBoxButtons.OK;


                oilvalue = int.Parse(label9.Text);
                watervalue = int.Parse(label10.Text);
                oilLoW = int.Parse(label42.Text);
                waterLoW = int.Parse(label43.Text);
                pressurevalue = int.Parse(label46.Text);
                pressurevalueLoW = int.Parse(label45.Text);
                pmv = int.Parse(label46.Text);
                changer = int.Parse(label9.Text);
                changer2 = int.Parse(label10.Text);

                progressBar5.Enabled = true;
                progressBar5.Increment(1);

               

                PMVlevel.Text = p + "";
                p++;
                LMVoil.Text = j + "";
                j++;
                LMVwater.Text = k + "";
                k++;
                if (j >= changer)
                {
                    LMVoil.Text = changer + "";
                    rB_CV.Checked = true;
                    rB_LIC.Checked = false;
                    rB_PIC.Checked = false;
                }

                if (p >= pmv)
                {
                    PMVlevel.Text = pmv + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false; ;

                }


                if (k >= changer2)
                {
                    LMVwater.Text = changer2 + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }

                if (progressBar5.Value == 0)
                {
                    panel12.Visible = false;
                    panel15.Visible = false;
                    panel14.Visible = false;
                    panel13.Visible = false;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;
                }
                 if (progressBar5.Value == 5)
                {
                    panel12.Visible = true;
                    panel15.Visible = false;
                    panel14.Visible = false;
                    panel13.Visible = false;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;


                    panel12.BackColor = Color.Black;

                }
                 if (progressBar5.Value == 10)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = false;
                    panel13.Visible = false;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;


                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;


                }
                 if (progressBar5.Value == 15)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = false;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 20)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = false;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;

                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;

                }
                 if (progressBar5.Value == 25)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = false;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Black;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;

                }
                 if (progressBar5.Value == 30)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = false;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;



                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Black;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                }
                 if (progressBar5.Value == 35)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 40)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Black;
                    panel13.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;


                }
                 if (progressBar5.Value == 45)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = false;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;


                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 50)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = false;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 55)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = false;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 60)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;


                }
                 if (progressBar5.Value == 65)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = false;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;


                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 70)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = false;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;


                }
                 if (progressBar5.Value == 75)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = false;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;


                }
                if (progressBar5.Value == 80)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;


                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;


                }
                if (progressBar5.Value == 85)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = false;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;


                }
                if (progressBar5.Value == 88)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                }
                if (progressBar5.Value == 91)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = false;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                }
                if (progressBar5.Value == 94)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = true;
                    panel31.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;

                }
                if (progressBar5.Value == 97)
                {
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = true;
                    panel31.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Aqua;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;


                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }
                if (progressBar5.Value == 99)
                {
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        timer7.Start();
                    }
                }
            }
            
        }
        private void CONTINUE4_Click(object sender, EventArgs e)
        {
            timer8.Start();
            //this timer controls the NEXT PHASE OF SEPERATION
        }
        private void Continue5_Click(object sender, EventArgs e)
        {
            timer7 = new Timer();
            timer7.Interval = 100;
            timer7.Tick += new EventHandler(timer7_Tick);
            timer7.Start();
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            if (rB_AutoMode.Checked)
            {

                progressBar4.Enabled = true;
                progressBar4.Increment(1);

                pressurevalue = int.Parse(Oil_Level_txtB.Text);
                PMVlevel.Text = pressurevalue + "";
                pressurevalue--;

                LMVOIL2.Text = oilvalue + "";
                oilvalue--;

                label38.Text = watervalue + "";
                watervalue--;

                if (oilvalue <= oilLoW)
                {
                    LMVOIL2.Text = oilLoW + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = true;
                    rB_PIC.Checked = false;
                }

                if (watervalue <= waterLoW)
                {
                    label38.Text = waterLoW + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = false;
                    rB_PIC.Checked = true;
                }
                if (pressurevalue <= pressurevalueLoW)
                {
                    PMVlevel.Text = pressurevalueLoW + "";
                    rB_CV.Checked = false;
                    rB_LIC.Checked = false;
                    rB_PIC.Checked = true;
                }

                if (pressurevalue == pressurevalueLoW)
                {
                    p = 0;
                    MessageBox.Show("THE FINAL STAGE OF SEPARATION COMPLETE", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (progressBar4.Value == 10)
                {
                    rB_close3.Checked = false;
                    rB_open3.Checked = true;
                    rB_close2.Checked = false;
                    rB_open2.Checked = true;
                    rB_open4.Checked = true;
                    rB_close4.Checked = false;

                    rB_CV.Checked = true;
                    rB_LIC.Checked = false;
                    rB_PIC.Checked = false;

                }
                if (progressBar4.Value == 20)
                {
                    oilpnl1.BackColor = Color.Black;
                    waterpnl1.BackColor = Color.Aqua;
                    gaspnl1.BackColor = Color.FloralWhite;
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = true;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = true;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;

                }
                if (progressBar4.Value == 30)
                {
                    oilpnl2.BackColor = Color.Black;
                    waterpnl2.BackColor = Color.Aqua;
                    gaspnl2.BackColor = Color.FloralWhite;
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = true;
                    panel26.Visible = false;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = true;
                    panel31.Visible = false;
                    gaspnl32.Visible = true;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Aqua;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;

                }
                if (progressBar4.Value == 40)
                {
                    oilpnl3.BackColor = Color.Black;
                    waterpnl3.BackColor = Color.Aqua;
                    gaspnl3.BackColor = Color.FloralWhite;
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = true;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;

                }
                if (progressBar4.Value == 50)
                {

                    oilpnl4.BackColor = Color.Black;
                    waterpnl4.BackColor = Color.Aqua;
                    gaspnl4.BackColor = Color.FloralWhite;
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = true;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;
                }
                if (progressBar4.Value == 60)
                {
                    oilpnl5.BackColor = Color.Black;
                    waterpnl5.BackColor = Color.Aqua;
                    gaspnl5.BackColor = Color.FloralWhite;
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = true;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = true;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = true;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Aqua;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;
                }
                if (progressBar4.Value == 70)
                {
                    oilpnl6.BackColor = Color.Black;
                    waterpnl6.BackColor = Color.Aqua;
                    gaspnl6.BackColor = Color.FloralWhite;
                    panel12.Visible = true;
                    panel15.Visible = true;
                    panel14.Visible = true;
                    panel13.Visible = true;
                    panel18.Visible = true;
                    panel17.Visible = true;
                    panel16.Visible = true;
                    panel21.Visible = true;
                    panel20.Visible = false;
                    panel19.Visible = false;
                    panel26.Visible = false;
                    panel23.Visible = true;
                    panel24.Visible = true;
                    panel25.Visible = true;
                    panel22.Visible = true;
                    panel27.Visible = true;
                    panel28.Visible = true;
                    panel29.Visible = false;
                    panel30.Visible = false;
                    panel31.Visible = false;
                    gaspnl32.Visible = false;
                    gaspnl33.Visible = false;
                    gaspnl34.Visible = false;
                    gaspnl35.Visible = false;

                    panel12.BackColor = Color.Aqua;
                    panel15.BackColor = Color.Aqua;
                    panel14.BackColor = Color.Aqua;
                    panel13.BackColor = Color.Black;
                    panel18.BackColor = Color.Black;
                    panel17.BackColor = Color.Black;
                    panel16.BackColor = Color.Black;
                    panel21.BackColor = Color.Black;
                    panel20.BackColor = Color.Black;
                    panel19.BackColor = Color.Black;
                    panel26.BackColor = Color.Black;
                    panel23.BackColor = Color.Black;
                    panel24.BackColor = Color.Black;
                    panel25.BackColor = Color.Black;
                    panel22.BackColor = Color.Black;
                    panel27.BackColor = Color.Black;
                    panel28.BackColor = Color.Black;
                    panel29.BackColor = Color.Black;
                    panel30.BackColor = Color.Black;
                    panel31.BackColor = Color.Black;
                    gaspnl32.BackColor = Color.FloralWhite;
                    gaspnl33.BackColor = Color.FloralWhite;
                    gaspnl34.BackColor = Color.FloralWhite;
                    gaspnl35.BackColor = Color.FloralWhite;
                }

            }

           
            


        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Volume_txtB_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
        

       

