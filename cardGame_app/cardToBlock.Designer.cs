
namespace cardGame_app
{
    partial class cardToBlock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCap = new System.Windows.Forms.Button();
            this.buttonAmb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCap
            // 
            this.buttonCap.Location = new System.Drawing.Point(62, 94);
            this.buttonCap.Name = "buttonCap";
            this.buttonCap.Size = new System.Drawing.Size(145, 49);
            this.buttonCap.TabIndex = 0;
            this.buttonCap.Text = "Captain";
            this.buttonCap.UseVisualStyleBackColor = true;
            this.buttonCap.Click += new System.EventHandler(this.buttonCap_Click);
            // 
            // buttonAmb
            // 
            this.buttonAmb.Location = new System.Drawing.Point(279, 94);
            this.buttonAmb.Name = "buttonAmb";
            this.buttonAmb.Size = new System.Drawing.Size(145, 49);
            this.buttonAmb.TabIndex = 1;
            this.buttonAmb.Text = "Ambassador";
            this.buttonAmb.UseVisualStyleBackColor = true;
            this.buttonAmb.Click += new System.EventHandler(this.buttonAmb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose a card to block with- :";
            // 
            // cardToBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAmb);
            this.Controls.Add(this.buttonCap);
            this.Name = "cardToBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cardToBlock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCap;
        private System.Windows.Forms.Button buttonAmb;
        private System.Windows.Forms.Label label1;
    }
}