using System;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form2 : Form
    {
        bool exit;

        public Form2()
        {
            InitializeComponent();
            this.AcceptButton = btnPlay;
            //exit = true;   
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (txtBoxPlayer1Name.Text == string.Empty || txtBoxPlayer2Name.Text == string.Empty)
            {
                MessageBox.Show("Please enter the name of the players!", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxPlayer1Name.Text = string.Empty;
                txtBoxPlayer2Name.Text = string.Empty;
            }
            else
            {
                Form1.SetPlayerNames(txtBoxPlayer1Name.Text, txtBoxPlayer2Name.Text);
                this.Hide();
            }
        }

        //Check if the button "X" has been clicked and close the app
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Do you want to exit Tic Tac Toe?", "Tic Tac Toe",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        //// Alternatively, add this event for the TextBoxPlayer2's KeyPress event 
        //private void play_keyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar.ToString() == "\r")
        //    {
        //        btnPlay.PerformClick();
        //    }
        //}

    }
}
