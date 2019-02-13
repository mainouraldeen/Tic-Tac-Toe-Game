using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true => X turn , false => O turn
        int turn_count = 0; //will help us in tie case

        public Form1()
        {
            InitializeComponent();
        }

        //about
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Summer Project '17.", "Tic Tac Toe About.");
        }

        //exit 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //a function to manage the button click event
        private void button_click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn; //to change the player turn

            b.Enabled=false; //disable the clicked button

            turn_count++;
     
            CheckForWinner(); //each click we should check if there is a winner 

        }//end button_click function

        //a function to check for the winner
        private void CheckForWinner()
        {
            bool  there_is_a_winner =false;

            //check rows
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled)
                there_is_a_winner = true;
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled)    
                there_is_a_winner = true;                                       
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled)
                there_is_a_winner = true;

            //check columns
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled)
                there_is_a_winner = true;
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled)
                there_is_a_winner = true;
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled)
                there_is_a_winner = true;

            //check diagonals
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled)
                there_is_a_winner = true;
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled)
                there_is_a_winner = true;


            //announce winner
            if (there_is_a_winner)
            {
                disable_buttons();
                string winner;
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " Wins !", "yay !");

            }
            else
            {
                if(turn_count==9)
                    MessageBox.Show("It's a Tie ! ", "Gameover");
            }

        }//end check for winner function

        //a function to disable all buttons if there is a winner to force the player to start a newgame or exit 
        private void disable_buttons()
        {
            try //as we try to cast the menu strip which is not a button to a button
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;

                    b.Enabled = false;
                }
            }
            catch { } //do nothing if found an exception

        }//end disable buttons function

        //a function to start a newgame & initialize all the app.
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try //as we try to cast the menu strip which is not a button to a button
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { } //do nothing if found an exception

        }//end newgame function
    }
}
