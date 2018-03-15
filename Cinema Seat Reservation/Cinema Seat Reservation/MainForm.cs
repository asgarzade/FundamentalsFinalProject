using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Seat_Reservation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        void loadSeatSelector()
        {
            SeatSelector mySeatSelector = new SeatSelector();
            this.Hide();
            mySeatSelector.ShowDialog();
            this.Close();
        }

        private void movie1Button_Click(object sender, EventArgs e)
        {
            loadSeatSelector();
            Movie.ID = 1;
        }

        private void movie2Button_Click(object sender, EventArgs e)
        {
            loadSeatSelector();
            Movie.ID = 2;
        }

        private void movie3Button_Click(object sender, EventArgs e)
        {
            loadSeatSelector();
            Movie.ID = 3;
        }

        private void movie4Button_Click(object sender, EventArgs e)
        {
            loadSeatSelector();
            Movie.ID = 4;
        }

        private void movie5Button_Click(object sender, EventArgs e)
        {
            loadSeatSelector();
            Movie.ID = 5;
        }
    }
}

class Movie
{
    public static int ID;
}
