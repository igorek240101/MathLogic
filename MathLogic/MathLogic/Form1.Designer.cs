
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
            this.IferInvoke = new System.Windows.Forms.Button();
            this.RemoveConstFromIf = new System.Windows.Forms.Button();
            this.ReplaceRepeat = new System.Windows.Forms.Button();
            this.Comparetor = new System.Windows.Forms.Button();
            this.Equivalence = new System.Windows.Forms.Button();
            this.RemoveConst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input.Location = new System.Drawing.Point(26, 10);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(252, 327);
            this.input.TabIndex = 0;
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.output.Location = new System.Drawing.Point(400, 10);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(229, 316);
            this.output.TabIndex = 1;
            // 
            // Invoke
            // 
            this.Invoke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Invoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Invoke.Location = new System.Drawing.Point(315, 12);
            this.Invoke.Name = "Invoke";
            this.Invoke.Size = new System.Drawing.Size(45, 35);
            this.Invoke.TabIndex = 2;
            this.Invoke.UseVisualStyleBackColor = true;
            this.Invoke.Click += new System.EventHandler(this.Invoke_Click);
            // 
            // IferInvoke
            // 
            this.IferInvoke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IferInvoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IferInvoke.Location = new System.Drawing.Point(315, 53);
            this.IferInvoke.Name = "IferInvoke";
            this.IferInvoke.Size = new System.Drawing.Size(45, 35);
            this.IferInvoke.TabIndex = 3;
            this.IferInvoke.UseVisualStyleBackColor = true;
            this.IferInvoke.Click += new System.EventHandler(this.IferInvoke_Click);
            // 
            // RemoveConstFromIf
            // 
            this.RemoveConstFromIf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoveConstFromIf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveConstFromIf.Location = new System.Drawing.Point(315, 135);
            this.RemoveConstFromIf.Name = "RemoveConstFromIf";
            this.RemoveConstFromIf.Size = new System.Drawing.Size(45, 35);
            this.RemoveConstFromIf.TabIndex = 4;
            this.RemoveConstFromIf.UseVisualStyleBackColor = true;
            this.RemoveConstFromIf.Click += new System.EventHandler(this.RemoveConstFromIf_Click);
            // 
            // ReplaceRepeat
            // 
            this.ReplaceRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReplaceRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceRepeat.Location = new System.Drawing.Point(315, 94);
            this.ReplaceRepeat.Name = "ReplaceRepeat";
            this.ReplaceRepeat.Size = new System.Drawing.Size(45, 35);
            this.ReplaceRepeat.TabIndex = 5;
            this.ReplaceRepeat.UseVisualStyleBackColor = true;
            this.ReplaceRepeat.Click += new System.EventHandler(this.ReplaceRepeat_Click);
            // 
            // Comparetor
            // 
            this.Comparetor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Comparetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Comparetor.Location = new System.Drawing.Point(315, 176);
            this.Comparetor.Name = "Comparetor";
            this.Comparetor.Size = new System.Drawing.Size(45, 35);
            this.Comparetor.TabIndex = 6;
            this.Comparetor.UseVisualStyleBackColor = true;
            this.Comparetor.Click += new System.EventHandler(this.Comparetor_Click);
            // 
            // Equivalence
            // 
            this.Equivalence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Equivalence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Equivalence.Location = new System.Drawing.Point(315, 217);
            this.Equivalence.Name = "Equivalence";
            this.Equivalence.Size = new System.Drawing.Size(45, 35);
            this.Equivalence.TabIndex = 7;
            this.Equivalence.UseVisualStyleBackColor = true;
            this.Equivalence.Click += new System.EventHandler(this.Equivalence_Click);
            // 
            // RemoveConst
            // 
            this.RemoveConst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoveConst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveConst.Location = new System.Drawing.Point(315, 258);
            this.RemoveConst.Name = "RemoveConst";
            this.RemoveConst.Size = new System.Drawing.Size(45, 35);
            this.RemoveConst.TabIndex = 8;
            this.RemoveConst.UseVisualStyleBackColor = true;
            this.RemoveConst.Click += new System.EventHandler(this.RemoveConst_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.RemoveConst);
            this.Controls.Add(this.Equivalence);
            this.Controls.Add(this.Comparetor);
            this.Controls.Add(this.ReplaceRepeat);
            this.Controls.Add(this.RemoveConstFromIf);
            this.Controls.Add(this.IferInvoke);
            this.Controls.Add(this.Invoke);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.MinimumSize = new System.Drawing.Size(345, 265);
            this.Name = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button Invoke;
        private System.Windows.Forms.Button IferInvoke;
        private System.Windows.Forms.Button RemoveConstFromIf;
        private System.Windows.Forms.Button ReplaceRepeat;
        private System.Windows.Forms.Button Comparetor;
        private System.Windows.Forms.Button Equivalence;
        private System.Windows.Forms.Button RemoveConst;
    }
}

