using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Snake
{
    public partial class Form1 : Form
    {
        int offset_x = 100;
        int offset_y = 300;
        int width = 40;
        int height = 40;
        int snake_x = 10;
        int snake_y = 10;
        int target_x = 0;
        int target_y = 0;
        int random_x = 0;
        int random_y = 0;
        int last_snake_node_top = 700;
        int last_snake_node_left = 500;
        int snake_size = 0;
        sbyte snake_direction = 2;
        
        Button target = new Button();
        List<Button> fullSnake = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            snake_size = 0;
            Graphics g = CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 5);
            Rectangle rect = new Rectangle(offset_x - 3, offset_y - 3, 805, 805);
            g.DrawRectangle(blackPen, rect);
            fullSnake.Clear();
            GenerateTarget();
            CreateSnakeNode();
            scoreLabel.Text = "Score: " + snake_size;
            GameTimer.Enabled = true;
        }

        void GenerateTarget()
        {
            RandomNumberGenerator();
            for (int i = 0; i < snake_size; i++)
            {
                if (fullSnake[i].Left == (offset_x + random_x * 40) && fullSnake[i].Top == (offset_y + random_y * 40))
                {
                    GenerateTarget();
                    break;
                }
            }
            target.Width = width;
            target.Height = height;
            target.TabStop = false;
            target.FlatStyle = FlatStyle.Flat;
            target.FlatAppearance.BorderSize = 0;
            target.BackColor = Color.Blue;
            target.Location = new Point((offset_x + random_x * 40), (offset_y + random_y * 40));
            Controls.Add(target);
        }

        void CreateSnakeNode()
        {
            Button snake = new Button();
            snake.Width = width;
            snake.Height = height;
            snake.TabStop = false;
            snake.FlatStyle = FlatStyle.Flat;
            snake.FlatAppearance.BorderSize = 0;
            snake.BackColor = Color.Black;
            snake.Left = last_snake_node_left; 
            snake.Top = last_snake_node_top;
            fullSnake.Add(snake);
            Controls.Add(fullSnake[snake_size]);
            snake_size++;
        }

        void goLeft()
        {
            if (CheckSnakeCollision())
            {
                GameTimer.Enabled = false;
                MessageBox.Show("Game Over");
            }
            if (snake_x>0) 
            {
                last_snake_node_top = fullSnake[snake_size - 1].Top;
                last_snake_node_left = fullSnake[snake_size - 1].Left;
                for (int i = snake_size - 1; i > 0; i--)
                {
                    fullSnake[i].Top = fullSnake[i - 1].Top;
                    fullSnake[i].Left = fullSnake[i - 1].Left;
                }
                snake_x--;
                fullSnake[0].Left = offset_x + snake_x * 40;
                if (snake_x == target_x && snake_y == target_y)
                {
                    scoreLabel.Text = "Score: " + snake_size;
                    GenerateTarget();
                    CreateSnakeNode();
                }
            }
        }

        void goRight()
        {
            if (CheckSnakeCollision())
            {
                GameTimer.Enabled = false;
                MessageBox.Show("Collison");
            }
            if (snake_x<19)
            {
                last_snake_node_top = fullSnake[snake_size - 1].Top;
                last_snake_node_left = fullSnake[snake_size - 1].Left;
                for (int i = snake_size - 1; i > 0; i--)
                {
                    fullSnake[i].Top = fullSnake[i - 1].Top;
                    fullSnake[i].Left = fullSnake[i - 1].Left;
                }
                snake_x++;
                fullSnake[0].Left = offset_x + snake_x * 40;
                if (snake_x == target_x && snake_y == target_y)
                {
                    scoreLabel.Text = "Score: " + snake_size;
                    GenerateTarget();
                    CreateSnakeNode();
                }
            }
        }

        void goUp()
        {
            if (CheckSnakeCollision())
            {
                GameTimer.Enabled = false;
                MessageBox.Show("Collison");
            }
            if (snake_y>0)
            {
                last_snake_node_top = fullSnake[snake_size - 1].Top;
                last_snake_node_left = fullSnake[snake_size - 1].Left;
                for (int i = snake_size - 1; i > 0; i--)
                {
                    fullSnake[i].Top = fullSnake[i - 1].Top;
                    fullSnake[i].Left = fullSnake[i - 1].Left;
                }
                snake_y--;
                fullSnake[0].Top = offset_y + snake_y * 40;
                if (snake_x == target_x && snake_y == target_y)
                {
                    scoreLabel.Text = "Score: " + snake_size;
                    GenerateTarget();
                    CreateSnakeNode();
                }
            }
        }

        void goDown()
        {
            if (CheckSnakeCollision())
            {
                GameTimer.Enabled = false;
                MessageBox.Show("Collison");
            }
            if (snake_y<19)
            { 
                last_snake_node_top = fullSnake[snake_size - 1].Top;
                last_snake_node_left = fullSnake[snake_size - 1].Left;
                for (int i = snake_size - 1; i > 0; i--)
                {
                    fullSnake[i].Top = fullSnake[i - 1].Top;
                    fullSnake[i].Left = fullSnake[i - 1].Left;
                }
                snake_y++;
                fullSnake[0].Top = offset_y + snake_y * 40;
                if (snake_x == target_x && snake_y == target_y)
                {
                    scoreLabel.Text = "Score: " + snake_size;
                    GenerateTarget();
                    CreateSnakeNode();
                }
            }
        }

        bool CheckSnakeCollision()
        {
            for (int i = 1; i < snake_size; i++)
            {
                if (fullSnake[i].Top == fullSnake[0].Top && fullSnake[i].Left == fullSnake[0].Left) return true;
            }
            return false;
        } 

        bool CheckWallCollision()
        {
            if (snake_x >= 0 && snake_x < 20 && snake_y >= 0 && snake_y < 20) return false;
            else return true;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            switch (snake_direction)
            {
                case 1:
                    goUp();
                    break;
                case 2:
                    goRight();
                    break;
                case 3:
                    goDown();
                    break;
                case 4:
                    goLeft();
                    break;
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (snake_direction == 2 || snake_direction == 4)
            {
                snake_direction = 1;
            }
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (snake_direction == 1 || snake_direction == 3)
            {
                snake_direction = 4;
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (snake_direction == 1 || snake_direction == 3)
            {
                snake_direction = 2;
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (snake_direction == 2 || snake_direction == 4)
            {
                snake_direction = 3;
            }
        }

        void Reset()
        {

        }

        void RandomNumberGenerator()
        {
            Random rnd = new Random();
            random_x = rnd.Next(20);
            random_y = rnd.Next(20);
            target_x = random_x;
            target_y = random_y;
        }

        void form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (snake_direction == 2 || snake_direction == 4)
                    {
                        snake_direction = 1;
                    }
                    break;
                case Keys.D:
                    if (snake_direction == 1 || snake_direction == 3)
                    {
                        snake_direction = 2;
                    }
                    break;
                case Keys.S:
                    if (snake_direction == 2 || snake_direction == 4)
                    {
                        snake_direction = 3;
                    }
                    break;
                case Keys.A:
                    if (snake_direction == 1 || snake_direction == 3)
                    {
                        snake_direction = 4;
                    }
                    break;
            }
        }

        //void form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Down:
        //        case Keys.Up:
        //        case Keys.Left:
        //        case Keys.Right:
        //            e.IsInputKey = true;
        //            break;
        //    }
        //}
    }
}
