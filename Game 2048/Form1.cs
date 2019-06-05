using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Media;
namespace game2048
{
    public partial class Game2048 : Form
    {
       
        SoundPlayer sound = new SoundPlayer(Application.StartupPath+"/andiem.wav");
        SoundPlayer sound2 = new SoundPlayer(Application.StartupPath+"/blip.wav");
        Random Rd = new Random();
        bool RepeatGame = true;
        static ArrayList sequence1 = new ArrayList();
        
        public Game2048()
        {
            
           
            InitializeComponent();
            
        }
      
        public void colors()
        {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if(Game[i,j].Text==""){
                        Game[i, j].BackColor = System.Drawing.Color.DimGray;
                    }
                    if (Game[i, j].Text == "2")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Silver;
                        Game[i, j].ForeColor = System.Drawing.Color.Black;

                    }
                    if (Game[i, j].Text == "4")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.SlateGray;
                        Game[i, j].ForeColor = System.Drawing.Color.Black;
                    }
                    if (Game[i, j].Text == "8")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Yellow;
                        Game[i, j].ForeColor = System.Drawing.Color.Black;
                    }
                    if (Game[i, j].Text == "16")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Orange;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "32")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.OrangeRed;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "64")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Red;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "128")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.DarkRed;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "256")
                    {
                        Game[i, j].BackColor = Color.DarkRed;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "512")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.LightBlue;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "1024")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Blue;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "2048")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Green;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "4096")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gray;
                        Game[i, j].ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                    }
                    if (Game[i, j].Text == "8192")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gray;
                        Game[i, j].ForeColor = System.Drawing.Color.Yellow;
                    }
                }
            }
            
        }

        public void Contact()
        {
            sequence1.Clear();

            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++)
                {
                    if(Game[i,j].Text==""){
                        sequence1.Add(i * 4 + j + 1);
                    }
                }
            }

            if (sequence1.Count > 0)
            {

                int numberfilling = int.Parse(sequence1[Rd.Next(0, sequence1.Count - 1)].ToString());
                int i0 = (numberfilling - 1) / 4;
                int j0 = (numberfilling - 1) - i0 * 4;
                int sequences2 = Rd.Next(1, 10);
                if (sequences2 == 1 || sequences2 == 2 || sequences2 == 3 || sequences2 == 4 || sequences2 == 5 || sequences2 == 6)
                {
                    Game[i0, j0].Text = "2";
                }
                else { 
                    Game[i0,j0].Text="4";
                }

            }
            colors();
        } 
        public void UpwardMovement() {
            bool UpControl = true;
            bool boiler1 = false;
            bool newnumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                int total = 0;
                for (int j = 0; j < 4;j++ )
                {
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                boiler1 = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        total++;
                    }
                    else {
                        for (int m = j; m >= 0;m-- )
                        {
                            if(Game[m,i].Text==""){
                                newnumber = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        UpControl = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();//score
                                        newnumber = true;
                                        extrasayi = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if (total != 0)
                                        {
                                            Game[j - total, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                       
                                        break;
                                        
                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && total != 0)
                            {
                                UpControl = false;
                                Game[j - total, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else {
                            if (total != 0)
                            {
                                UpControl = false;
                                Game[j - total, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        
                       
                    }
                }
            }
            if (UpControl == false && boiler1 == true)
            {
                sound.Play();
            }
            if (UpControl == false && boiler1 == false)
            {
                sound2.Play();
            }
            if (newnumber == true)
            {

                Contact();
            }
            
        }
       
        public void Form1_Load(object sender, EventArgs e)
        {

            Contact();
            Contact();
            
        }
        public void DownMovement()
        {
            bool ControlDown = true;
            bool boiler1 = false;
            bool newnumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int total = 0;
                for (int j = 3; j >=0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                boiler1 = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        total++;
                    }
                    else
                    {
                        for (int m = j+1; m <= 3; m++)
                        {
                            if (Game[m, i].Text == "")
                            {
                                newnumber = true;
                                break;
                            }
                        }
                        if (j-1>=0)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j -1 ; k >= 0; k--)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        ControlDown = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();

                                        newnumber = true;
                                        extrasayi = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if (total != 0)
                                        {
                                            Game[j + total, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && total != 0)
                            {
                                ControlDown = false;
                                Game[j + total, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (total != 0)
                            {
                                ControlDown = false;
                                Game[j + total, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }


                    }
                }
            }
            if (ControlDown == false && boiler1 == true)
            {
                sound.Play();
            }
            if (ControlDown == false && boiler1 == false)
            {
                sound2.Play();
            }
            if (newnumber == true)
            {
                Contact();
            }
        }
        public void solHaraket()
        {
            bool solKontrol=true;
            bool boiler1 = false;
            bool newnumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int total = 0;
                for (int j =0; j <4; j++)
                {

                    for (int k = j + 1; k < 4;k++ )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                boiler1 = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        total++;
                    }
                    else
                    {
                        for (int m = j-1; m >= 0; m--)
                        {
                            if (Game[i, m].Text == "")
                            {
                                newnumber = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j + 1; k <4; k++)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        solKontrol = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();

                                        newnumber = true;
                                        extrasayi = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (total != 0)
                                        {
                                            Game[i, j - total].Text = Game[i, j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && total != 0)
                            {
                                solKontrol = false;
                                Game[i, j - total].Text = Game[i, j].Text;
                                Game[i,j].Text = "";
                               
                            }
                        }
                        else
                        {
                            if (total != 0)
                            {
                                solKontrol = false;
                                Game[i, j - total].Text = Game[i, j].Text;
                                Game[i,j].Text = "";
                                
                            }
                        }


                    }
                }
            }
            if (solKontrol == false && boiler1 == true)
            {
                sound.Play();
            }
            if (solKontrol == false && boiler1 == false)
            {
                sound2.Play();
            }
            if (newnumber == true)
            {
                Contact();
            }
        }
        public void sagHaraket()
        { 
            bool sagKontrol = true;
            bool boiler1 = false;
            bool newnumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int total = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,k].Text==Game[i,j].Text){
                                boiler1 = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        total++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (Game[i,m].Text == "")
                            {
                                newnumber = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool extrasayi = true;
                            
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        sagKontrol = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();

                                        newnumber = true;
                                        extrasayi = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (total != 0)
                                        {
                                            Game[i, j + total].Text = Game[i, j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extrasayi == true && total != 0)
                            {
                                sagKontrol = false;
                                Game[i, j + total].Text = Game[i, j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (total != 0)
                            {
                                sagKontrol = false;
                                Game[i, j + total].Text = Game[i, j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                    }
                }
            }
            if (sagKontrol == false && boiler1 == true)
            {
                sound.Play();
            }
            if (sagKontrol == false && boiler1 == false)
            {
                sound2.Play();
            }
            if (newnumber == true)
            {
                Contact();
            }
        }
        public bool sayiYaz() {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    if(Game[i,j].Text==""){
                        return false;
                    }
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[i,j].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game[j, i].Text == "")
                    {
                        return false;
                    }
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (Game[k,i].Text != "")
                        {
                            if (Game[j,i].Text == Game[k,i].Text)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sayiYaz() == false)
            {
                if (e.KeyCode == Keys.Up)
                {
                    UpwardMovement();

                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMovement();
                }
                if (e.KeyCode == Keys.Left)
                {
                    solHaraket();
                }
                if (e.KeyCode == Keys.Right)
                {
                    sagHaraket();
                }
               

            }
            else {
               // continueToolStripMenuItem.Visible = false;
               lblGameOver.Text = "Game Over!";
                RepeatGame = false;
                lblGameOver.Visible = true;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
                btnExit.Enabled = true;
                btnNewGame.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
           
        }

        public void btnNewGame_Click(object sender, EventArgs e)
        { 
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            lblScore.Text = "0";
            Label[,] Game = {  //16 labels
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            RepeatGame = true;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    Game[i, j].Text = "";
                }
            }
            Contact();
            Contact();
            Contact();
            
        }

        public void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //label1.Visible = true;
            //continueToolStripMenuItem.Visible = true;
            lblAbout.Visible = false;
            label2.Visible = true;
            lblScore.Visible = true;

            if (RepeatGame == false)
            {
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
            RepeatGame = true;
            lblScore.Text = "0";
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = true;
                    Game[i, j].Text = "";
                }
            }
            Contact();
            Contact();
            Contact();
        }

        public void continueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //label1.Visible = true;
            lblAbout.Visible = false;
            label2.Visible = true;
            lblScore.Visible = true;

            if (RepeatGame == false)
            {
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
            Label[,] Game = {
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = true;
                }
            }
        }

        public void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btnNewGame_MouseHover(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.Green;//button
        }

        private void btnNewGame_MouseLeave(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.Orange;//button
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.Green;//button
        }

        public void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.Orange;//button
        }

        private void ptbImage_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
