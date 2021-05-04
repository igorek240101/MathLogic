using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace MathLogic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_SizeChanged(this, new EventArgs());
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            input.Size = new Size((int)(Width * 0.3), (int)(Height * 0.8));
            input.Location = new Point((int)(Width * 0.1), (int)((Height-30) * 0.1));
            output.Size = new Size((int)(Width * 0.3), (int)(Height * 0.8));
            output.Location = new Point((int)(Width * 0.6), (int)((Height-30) * 0.1));
            Invoke.Size = new Size((int)(Width * 0.1), (int)(Height * 0.2));
            Invoke.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.4));
        }

        private void Invoke_Click(object sender, EventArgs e)
        {
            Params_ root = Params_.Typer(input.Text);
            output.Text = root.Value;
        }
    }
}
