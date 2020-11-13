﻿using Factory.Abstractions;
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
        private List<Toy> _toys = new List<Toy>();
        private Toy _nextToy;
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                DisplayNext();
            }
        }
        public Form1()
        {
            InitializeComponent();
            mainPanel.Width = this.Width;
            Factory = new CarFactory();

    }

       

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var newToy = Factory.CreateNew();
            _toys.Add(newToy);
            newToy.Left = -newToy.Width;
            mainPanel.Controls.Add(newToy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxposition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxposition) {
                    maxposition = toy.Left;
                }
            }
            if (maxposition > 1000) {
                var firstToy = _toys[0];
                mainPanel.Controls.Remove(firstToy);
                _toys.Remove(firstToy);
            }
        }

        private void BallButon_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void CarButton_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void DisplayNext() {
            if (_nextToy != null) {
                Controls.Remove(_nextToy);
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }
    }
}
