namespace AdidasBackdoor
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
            this.textBox_Sitekey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Size = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Sku = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_atc = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_CaptchaCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Sitekey
            // 
            this.textBox_Sitekey.Location = new System.Drawing.Point(99, 13);
            this.textBox_Sitekey.Name = "textBox_Sitekey";
            this.textBox_Sitekey.Size = new System.Drawing.Size(402, 29);
            this.textBox_Sitekey.TabIndex = 0;
            this.textBox_Sitekey.Text = "6Le4AQgUAAAAAABhHEq7RWQNJwGR_M-6Jni9tgtA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "SiteKey:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(195, 899);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(172, 92);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size:";
            // 
            // textBox_Size
            // 
            this.textBox_Size.Location = new System.Drawing.Point(69, 72);
            this.textBox_Size.Name = "textBox_Size";
            this.textBox_Size.Size = new System.Drawing.Size(132, 29);
            this.textBox_Size.TabIndex = 4;
            this.textBox_Size.Text = "9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sku:";
            // 
            // textBox_Sku
            // 
            this.textBox_Sku.Location = new System.Drawing.Point(69, 127);
            this.textBox_Sku.Name = "textBox_Sku";
            this.textBox_Sku.Size = new System.Drawing.Size(132, 29);
            this.textBox_Sku.TabIndex = 6;
            this.textBox_Sku.Text = "S81834";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 229);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(773, 664);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // button_atc
            // 
            this.button_atc.Location = new System.Drawing.Point(618, 899);
            this.button_atc.Name = "button_atc";
            this.button_atc.Size = new System.Drawing.Size(172, 92);
            this.button_atc.TabIndex = 8;
            this.button_atc.Text = "Open";
            this.button_atc.UseVisualStyleBackColor = true;
            this.button_atc.Click += new System.EventHandler(this.button_atc_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(17, 899);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(172, 92);
            this.button_stop.TabIndex = 9;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Reponse:";
            // 
            // label_CaptchaCount
            // 
            this.label_CaptchaCount.AutoSize = true;
            this.label_CaptchaCount.Location = new System.Drawing.Point(173, 184);
            this.label_CaptchaCount.Name = "label_CaptchaCount";
            this.label_CaptchaCount.Size = new System.Drawing.Size(23, 25);
            this.label_CaptchaCount.TabIndex = 11;
            this.label_CaptchaCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 1003);
            this.Controls.Add(this.label_CaptchaCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_atc);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox_Sku);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Sitekey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Sitekey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Sku;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_atc;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_CaptchaCount;
    }
}

