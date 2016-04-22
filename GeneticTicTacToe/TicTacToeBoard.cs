using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticTicTacToe
{
    public partial class TicTacToeBoard : Form
    {

        private bool isPlayerOnesTurn = true;
        private int turnCount = 0;             

        public TicTacToeBoard()
        {
            InitializeComponent();
        }

        //hello

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in Controls)
                {
                    var button = (Button) control;
                    button.TabStop = false;
                }
            }

            catch
            {
                
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnCount = 0;
            isPlayerOnesTurn = true;
            ClearButtons();
            EnableButtons();

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Presented by Jordan Martin", "Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var button = (Button) sender;

            turnCount++;
            button.Text = isPlayerOnesTurn ? "X" : "O";
            button.Enabled = false;
            CheckForWinner(button);
            isPlayerOnesTurn = !isPlayerOnesTurn;
        }

        private void DisableButtons()
        {
            foreach (Control control in Controls)
            {
                try
                {
                    var b = (Button) control;
                    b.Enabled = false;
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void ClearButtons()
        {
            foreach (Control control in Controls)
            {
                try
                {
                    var b = (Button)control;
                    b.Text = "";
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void EnableButtons()
        {
            foreach (Control control in Controls)
            {
                try
                {
                    var b = (Button)control;
                    b.Enabled = true;
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void CheckForWinner(Button button)
        {
            var winnerExists = RowWinExists() || ColumnWinExists() || DiagonalWinExists();
            if (winnerExists)
            {
                DisableButtons();
                MessageBox.Show(isPlayerOnesTurn ? "X Wins!" : "O Wins!", "YAY!");
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("It's a tie!","DRAW");
            }

        }

        private bool DiagonalWinExists()
        {
            return MainDiagonalWinExists() || AntiDiagonalWinExists();
        }

        private bool RowWinExists()
        {
            return TopRowWinExists()||MidRowWinExists()||BotRowWinExists();
        }

        private bool ColumnWinExists()
        {
            return LeftColumnWinExists() || CenterColumnWinExists() || RightColumnWinExists();
        }

        private bool MainDiagonalWinExists()
        {
            return (topLeftButton.Text == midCenterButton.Text) && (midCenterButton.Text == botRightButton.Text) &&
                   (!topLeftButton.Enabled);
            
        }

        private bool AntiDiagonalWinExists()
        {
            return (topRightButton.Text == midCenterButton.Text) && (midCenterButton.Text == botLeftButton.Text) &&
                   (!topRightButton.Enabled);
        }

        private bool LeftColumnWinExists()
        {
            return (topLeftButton.Text == midLeftButton.Text) && (midLeftButton.Text == botLeftButton.Text) &&
                   (!topLeftButton.Enabled); 
        }

        private bool CenterColumnWinExists()
        {
            return (topCenterButton.Text == midCenterButton.Text) && (midCenterButton.Text == botCenterButton.Text) &&
                   (!topCenterButton.Enabled); 
        }

        private bool RightColumnWinExists()
        {
            return (topRightButton.Text == midRightButton.Text) && (midRightButton.Text == botRightButton.Text) &&
                   (!topRightButton.Enabled); 
        }

        private bool TopRowWinExists()
        {
            return (topLeftButton.Text == topCenterButton.Text) && (topCenterButton.Text == topRightButton.Text) &&
                   (!topLeftButton.Enabled); 
        }

        private bool MidRowWinExists()
        {
            return (midLeftButton.Text == midCenterButton.Text) && (midCenterButton.Text == midRightButton.Text) &&
                   (!midLeftButton.Enabled); 
        }

        private bool BotRowWinExists()
        {
            return (botLeftButton.Text == botCenterButton.Text) && (botCenterButton.Text == botRightButton.Text) &&
                   (!botLeftButton.Enabled);
        }
    }
}
