using System;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X's turn, false = O's turn
        int turn_count = 0;
        static string player1, player2;

        //bool isPlayer2Computer = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var frm = new Form2())
            {
                frm.ShowDialog();
                lblPlayer1NameCount.Text = player1;
                lblPlayer2NameCount.Text = player2;
            }
        }

        public static void SetPlayerNames(string playerName1, string playerName2)
        {
            player1 = playerName1;
            player2 = playerName2;
        }


        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe Game! \n©2014-2015");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            foreach (var item in Controls)
            {
                try
                {
                    var btn = (Button)item;
                    btn.Enabled = true;
                    btn.Text = "";
                }
                catch { }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (turn)
                btn.Text = "X";
            else
                btn.Text = "O";

            turn = !turn;
            btn.Enabled = false;
            turn_count++;

            if (turn_count >= 5)
                CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool there_is_a_winner = false;

            // Horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            // Vertical check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //Diagonal Check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                DisableButtons();
                string winner = "";
                if (turn)
                {
                    winner = player2;
                    lblOWinCount.Text = (int.Parse(lblOWinCount.Text) + 1).ToString();

                }
                else
                {
                    winner = player1;
                    lblXWinCount.Text = (int.Parse(lblXWinCount.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DisableButtons();
                if (turn_count == 9)
                {
                    lblDrawCount.Text = (int.Parse(lblDrawCount.Text) + 1).ToString();
                    MessageBox.Show("It's a Draw!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DisableButtons()
        {
            foreach (var item in Controls)
            {
                try
                {
                    Button btn = (Button)item;
                    btn.Enabled = false;
                }
                catch (Exception)
                {

                }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button btn_enter = (Button)sender;

            if (btn_enter.Enabled)
            {
                if (turn)
                    btn_enter.Text = "X";
                else
                    btn_enter.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button btn_leave = (Button)sender;
            if (btn_leave.Enabled)
                btn_leave.Text = "";
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblXWinCount.Text = "0";
            lblDrawCount.Text = "0";
            lblOWinCount.Text = "0";
        }
    }
}
