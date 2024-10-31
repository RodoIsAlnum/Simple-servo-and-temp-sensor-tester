namespace rum_rum
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.connectLabel = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.bttnConnect = new System.Windows.Forms.Button();
            this.bttnDisconnect = new System.Windows.Forms.Button();
            this.tbTempLimit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Temperature Limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Temperature";
            // 
            // connectLabel
            // 
            this.connectLabel.AutoSize = true;
            this.connectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectLabel.ForeColor = System.Drawing.Color.MediumPurple;
            this.connectLabel.Location = new System.Drawing.Point(85, 246);
            this.connectLabel.Name = "connectLabel";
            this.connectLabel.Size = new System.Drawing.Size(214, 33);
            this.connectLabel.TabIndex = 2;
            this.connectLabel.Text = "No connection";
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempLabel.ForeColor = System.Drawing.Color.Navy;
            this.tempLabel.Location = new System.Drawing.Point(496, 172);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(125, 73);
            this.tempLabel.TabIndex = 3;
            this.tempLabel.Text = "0.0";
            // 
            // bttnConnect
            // 
            this.bttnConnect.ForeColor = System.Drawing.Color.SeaGreen;
            this.bttnConnect.Location = new System.Drawing.Point(91, 322);
            this.bttnConnect.Name = "bttnConnect";
            this.bttnConnect.Size = new System.Drawing.Size(174, 68);
            this.bttnConnect.TabIndex = 4;
            this.bttnConnect.Text = "Connect";
            this.bttnConnect.UseVisualStyleBackColor = true;
            this.bttnConnect.Click += new System.EventHandler(this.bttnConnect_Click);
            // 
            // bttnDisconnect
            // 
            this.bttnDisconnect.ForeColor = System.Drawing.Color.Crimson;
            this.bttnDisconnect.Location = new System.Drawing.Point(464, 322);
            this.bttnDisconnect.Name = "bttnDisconnect";
            this.bttnDisconnect.Size = new System.Drawing.Size(174, 68);
            this.bttnDisconnect.TabIndex = 5;
            this.bttnDisconnect.Text = "Disconnect";
            this.bttnDisconnect.UseVisualStyleBackColor = true;
            this.bttnDisconnect.Click += new System.EventHandler(this.bttnDisconnect_Click);
            // 
            // tbTempLimit
            // 
            this.tbTempLimit.Location = new System.Drawing.Point(91, 157);
            this.tbTempLimit.Name = "tbTempLimit";
            this.tbTempLimit.Size = new System.Drawing.Size(180, 31);
            this.tbTempLimit.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbTempLimit);
            this.Controls.Add(this.bttnDisconnect);
            this.Controls.Add(this.bttnConnect);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.connectLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label connectLabel;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Button bttnConnect;
        private System.Windows.Forms.Button bttnDisconnect;
        private System.Windows.Forms.TextBox tbTempLimit;
    }
}

