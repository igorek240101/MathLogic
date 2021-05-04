
namespace MathLogic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.Invoke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(30, 12);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(293, 377);
            this.input.TabIndex = 0;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(467, 12);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(266, 364);
            this.output.TabIndex = 1;
            // 
            // Invoke
            // 
            this.Invoke.Location = new System.Drawing.Point(367, 98);
            this.Invoke.Name = "Invoke";
            this.Invoke.Size = new System.Drawing.Size(53, 40);
            this.Invoke.TabIndex = 2;
            this.Invoke.UseVisualStyleBackColor = true;
            this.Invoke.Click += new System.EventHandler(this.Invoke_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Invoke);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button Invoke;
    }
}

