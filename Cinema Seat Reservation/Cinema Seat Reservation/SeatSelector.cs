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
    public partial class SeatSelector : Form
    {
        List<Button> selectedButtons = new List<Button>();

        public SeatSelector()
        {
            InitializeComponent();
        }

        private void SeatSelector_Load(object sender, EventArgs e)
        {
            int x_offset = 200;
            int y_offset = 190;

            switch (Movie.ID)
            {
                case 1:
                    infoLabel_Seat.Text += "All the Money in the World";
                    break;
                case 2:
                    infoLabel_Seat.Text += "Baby Driver";
                    break;
                case 3:
                    infoLabel_Seat.Text += "Avengers: Infinity War";
                    break;
                case 4:
                    infoLabel_Seat.Text += "Moonlight";
                    break;
                case 5:
                    infoLabel_Seat.Text += "Oldboy";
                    break;
            }
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.Text = (i+1).ToString();
                    btn.Location = new Point(x_offset + i * 120, y_offset + j * 80);
                    btn.TabStop = false;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackgroundImage = Properties.Resources.seat;
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    Controls.Add(btn);
                    selectedButtons.Add(btn);
                    btn.Click += new EventHandler(onClick);
                }   
            }
        }
        void onClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Lime)
            {
                btn.BackColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Lime;
            }
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            foreach (Button btn in selectedButtons)
            {
                if (btn.BackColor == Color.Lime)
                {
                    btn.BackColor = Color.Black;
                    btn.Enabled = false;
                }
            }
        }
    }
}
