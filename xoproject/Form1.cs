using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xoproject.Properties;

namespace xoproject
{
    public partial class form : System.Windows.Forms.Form
    {
        public form()
        {
            InitializeComponent();
        }

        Color clr = Color.FromArgb(0, 255, 0);
        int countSteps = 0;
        bool isTheGameEnd = false;
        enum enPlayerTurn { playerOne, playerTwo};

        enPlayerTurn playerTurn = enPlayerTurn.playerOne;

        private void form_Paint(object sender, PaintEventArgs e)
        {
            
            Pen whitePen = new Pen(clr);
            whitePen.Width = 15;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);
        }

        bool checkValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    answinner.Text = "Player One";
                    MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    answinner.Text = "Player Two";
                    MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
                return false;
        }

        bool checkWinner ()
        {
            if (checkValues(button1, button2, button3))
                return true;
            if (checkValues(button4, button5, button6))
                return true;
            if (checkValues(button7, button8, button9))
                return true;
            if (checkValues(button1, button4, button7))
                return true;
            if (checkValues(button2, button5, button8))
                return true;
            if (checkValues(button3, button6, button9))
                return true;
            if (checkValues(button1, button5, button9))
                return true;
            if (checkValues(button3, button5, button7))
                return true;
            if (countSteps == 9) return true; 
            return false;

        }

        void endTheGame ()
        {
            isTheGameEnd = true;
            if (countSteps == 9)
            {
                answinner.Text = "Draw";
                MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void changeTurn(Button btn)
        {
            if (isTheGameEnd) MessageBox.Show("Game is Overed, Please Restart The Game", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (btn.Tag.ToString() == "?")
            {
                switch (playerTurn)
                {
                    case enPlayerTurn.playerOne:
                        countSteps++;
                        btn.Tag = "X";
                        btn.Image = Resources.X;
                        ansturn.Text = "Player Two";
                        playerTurn = enPlayerTurn.playerTwo;
                        if (checkWinner()) endTheGame();
                        break;
                    case enPlayerTurn.playerTwo:   
                        countSteps++;
                        btn.Tag = "O";
                        btn.Image = Resources.O;
                        ansturn.Text = "Player One";
                        playerTurn = enPlayerTurn.playerOne;
                        if (checkWinner()) endTheGame(); ;
                        break;
                }
            }
            else
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Click(object sender, EventArgs e)
        {
            changeTurn((Button)sender);
        }

        void resetAll (Button btn)
        {
            btn.Tag = "?";
            btn.Image = Resources.questionmark;
            ansturn.Text = "Player One";
            playerTurn = enPlayerTurn.playerOne;
            if (rbdark.Checked)
                btn.BackColor = Color.Black;
            else btn.BackColor = Color.Wheat;
        }
        private void lbresetgame_Click(object sender, EventArgs e)
        {
            countSteps = 0;
            isTheGameEnd = false;
            answinner.Text = "Progress";
            resetAll(button1);
            resetAll(button2);
            resetAll(button3);
            resetAll(button4);
            resetAll(button5);
            resetAll(button6);
            resetAll(button7);
            resetAll(button8);
            resetAll(button9);
        }

        private void rbdark_CheckedChanged(object sender, EventArgs e)
        {
            clr = Color.FromArgb(0, 255, 0);
            this.BackColor = Color.Black;
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Black;
            button3.BackColor = Color.Black;
            button4.BackColor = Color.Black;
            button5.BackColor = Color.Black;
            button6.BackColor = Color.Black;
            button7.BackColor = Color.Black;
            button8.BackColor = Color.Black;
            button9.BackColor = Color.Black;
        }

        private void rblight_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            clr = Color.FromArgb(255, 0, 0);
            button1.BackColor = Color.Wheat;
            button2.BackColor = Color.Wheat;
            button3.BackColor = Color.Wheat;
            button4.BackColor = Color.Wheat;
            button5.BackColor = Color.Wheat;
            button6.BackColor = Color.Wheat;
            button7.BackColor = Color.Wheat;
            button8.BackColor = Color.Wheat;
            button9.BackColor = Color.Wheat;
        }  
    }
}
