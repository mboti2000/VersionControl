using Factory.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factory
{
    public partial class Form1 : Form
    {
        private List<Ball> _balls = new List<Ball>();
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        public Form1()
        {
            InitializeComponent();
            mainPanel.Width = this.Width;
            Factory = new BallFactory();

    }

       

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var newBall = Factory.CreateNew();
            _balls.Add(newBall);
            newBall.Left = -newBall.Width;
            mainPanel.Controls.Add(newBall);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxposition = 0;
            foreach (var ball in _balls)
            {
                ball.MoveBall();
                if (ball.Left > maxposition) {
                    maxposition = ball.Left;
                }
            }
            if (maxposition > 1000) {
                var firstBall = _balls[0];
                mainPanel.Controls.Remove(firstBall);
                _balls.Remove(firstBall);
            }
        }
    }
}
