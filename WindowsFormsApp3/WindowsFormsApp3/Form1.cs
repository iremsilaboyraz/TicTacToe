using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        private Player currentPlayer;
        private Player playerSymbol;
        private Random random = new Random();
        private int playerWinCount = 0;
        private int CPUWinCount = 0;
        private List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            currentPlayer = Player.X;
        }

        private void ChooseSymbol(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (button.Text == "X")
            {
                playerSymbol = Player.X;
                currentPlayer = Player.X;
            }
            else
            {
                playerSymbol = Player.O;
                currentPlayer = Player.O;
            }

            MessageBox.Show($"Seçilen harf: {playerSymbol}");
            button.Enabled = false;
        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = playerSymbol == Player.X ? Player.O : Player.X;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.PaleGreen;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null || !button.Enabled) return;

            button.Text = playerSymbol.ToString();
            button.BackColor = Color.PeachPuff;
            button.Enabled = false;

            CheckGame();
            CPUTimer.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
              || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
              || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
              || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
              || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
              || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
              || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
              || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTimer.Stop();
                MessageBox.Show("Kazandın!");
                playerWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUTimer.Stop();
                MessageBox.Show("Bilgisayar Kazandı!");
                CPUWinCount++;
                label2.Text = "CPU Wins:" + CPUWinCount;
                RestartGame();
            }
        }

        public void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
