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
            Invoke.BackgroundImage = Image.FromFile("1.png");
            IferInvoke.BackgroundImage = Image.FromFile("2.png");
            ReplaceRepeat.BackgroundImage = Image.FromFile("3.png");
            RemoveConstFromIf.BackgroundImage = Image.FromFile("4.png");
            Comparetor.BackgroundImage = Image.FromFile("5.png");
            Equivalence.BackgroundImage = Image.FromFile("6.png");
            RemoveConst.BackgroundImage = Image.FromFile("7.png");
            IferInvoke.Enabled = false;
            RemoveConstFromIf.Enabled = false;
            ReplaceRepeat.Enabled = false;
            Comparetor.Enabled = false;
            Equivalence.Enabled = false;
            RemoveConst.Enabled = false;
            Form1_SizeChanged(this, new EventArgs());
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            input.Size = new Size((int)(Width * 0.3), (int)(Height * 0.8));
            input.Location = new Point((int)(Width * 0.1), (int)((Height-30) * 0.1));
            output.Size = new Size((int)(Width * 0.3), (int)(Height * 0.8));
            output.Location = new Point((int)(Width * 0.6), (int)((Height-30) * 0.1));
            Invoke.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            Invoke.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.02));
            IferInvoke.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            IferInvoke.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.16));
            ReplaceRepeat.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            ReplaceRepeat.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.30));
            RemoveConstFromIf.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            RemoveConstFromIf.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.44));
            Comparetor.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            Comparetor.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.58));
            Equivalence.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            Equivalence.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.72));
            RemoveConst.Size = new Size((int)(Width * 0.1), (int)(Height * 0.07));
            RemoveConst.Location = new Point((int)(Width * 0.45), (int)((Height - 30) * 0.86));
        }

        private void Invoke_Click(object sender, EventArgs e)
        {
            Params_.root = Params_.Typer(input.Text.Replace(" ", "").Replace("\r","").Replace("\n", ""), null);
            output.Text = Params_.root.Value;
            IferInvoke.Enabled = true;
            RemoveConstFromIf.Enabled = false;
            ReplaceRepeat.Enabled = false;
            Comparetor.Enabled = false;
            Equivalence.Enabled = false;
            RemoveConst.Enabled = false;
            Text = "";
        }

        private void IferInvoke_Click(object sender, EventArgs e)
        {
            Params_.root.Ifer();
            output.Text = Params_.root.Value;
            RemoveConstFromIf.Enabled = false;
            Comparetor.Enabled = false;
            Equivalence.Enabled = false;
            RemoveConst.Enabled = false;
            ReplaceRepeat.Enabled = true;
            if (Params_.root.Truer() && Params_.root.Falser()) Text = "Выразится";
            else Text = "Не выразится";
        }


        private void ReplaceRepeat_Click(object sender, EventArgs e)
        {
            Params_.root.ReplaceRepeatToConst(new List<(char, char)>());
            output.Text = Params_.root.Value;
            Comparetor.Enabled = false;
            Equivalence.Enabled = false;
            RemoveConst.Enabled = false;
            RemoveConstFromIf.Enabled = true;
        }

        private void RemoveConstFromIf_Click(object sender, EventArgs e)
        {
            Params_.root.RemoveConstFromIf();
            output.Text = Params_.root.Value;
            Equivalence.Enabled = false;
            RemoveConst.Enabled = false;
            Comparetor.Enabled = true;
        }

        private void Comparetor_Click(object sender, EventArgs e)
        {
            Params_.root.Comparator();
            output.Text = Params_.root.Value;
            RemoveConst.Enabled = false;
            Equivalence.Enabled = true;
        }

        private void Equivalence_Click(object sender, EventArgs e)
        {
            Params_.root.Equivalence();
            output.Text = Params_.root.Value;
            RemoveConst.Enabled = true;
        }

        private void RemoveConst_Click(object sender, EventArgs e)
        {
            if (!Params_.root.RemoveConst(new List<(char, char)>())) output.Text = "Не выражается";
            else output.Text = Params_.root.Value;
        }
    }
}
