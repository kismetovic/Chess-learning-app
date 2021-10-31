using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessBoardModeling;

namespace ChessTutorialGUI
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public Form1()
        {
            InitializeComponent();
            populateGrid();
            this.exitBtn.FlatAppearance.MouseOverBackColor = exitBtn.BackColor;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.BackColorChanged += (sender, e) =>
            {
                this.exitBtn.FlatAppearance.MouseOverBackColor = this.exitBtn.BackColor;
            };
            this.MinimizeBtn.FlatAppearance.MouseOverBackColor = MinimizeBtn.BackColor;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.BackColorChanged += (sender, e) =>
            {
                this.MinimizeBtn.FlatAppearance.MouseOverBackColor = this.MinimizeBtn.BackColor;
            };
        }

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;
            bool choosenPiece = string.IsNullOrEmpty(comboBox1.Text);
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].BackColor = Color.RoyalBlue;
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;
                    btnGrid[i, j].Click += Grid_Button_Click;
                    panel1.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    btnGrid[i, j].Text = (char)(i + 65) + "|" + (j + 1);
                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int x = location.X;
            int y = location.Y;
            Cell currentCell = myBoard.theGrid[x, y];
            string piece = (string)comboBox1.SelectedItem;
            if (comboBox1.SelectedIndex > -1)
            {
                myBoard.MarkNextLegalMoves(currentCell, piece);

                for (int i = 0; i < myBoard.Size; i++)
                {
                    for (int j = 0; j < myBoard.Size; j++)
                    {
                        btnGrid[i, j].Text = "";
                        btnGrid[i, j].BackColor = Color.RoyalBlue;
                        btnGrid[i, j].ForeColor = Color.White;
                        if (myBoard.theGrid[i, j].LegalNextMove == true)
                        {
                            btnGrid[i, j].Text = "Legal";
                            btnGrid[i, j].BackColor = Color.LightBlue;
                        }
                        else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                        {
                            //btnGrid[i, j].ForeColor = Color.White;
                            btnGrid[i, j].Text = piece;
                            btnGrid[i, j].BackColor = Color.BlueViolet;
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
