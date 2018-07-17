namespace MovingAverage
{
    partial class MovingAverage
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
            this.txt_WindowSize = new System.Windows.Forms.TextBox();
            this.txt_DblArr = new System.Windows.Forms.TextBox();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.rtxt_MovAvg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Window Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Double Array";
            // 
            // txt_WindowSize
            // 
            this.txt_WindowSize.Location = new System.Drawing.Point(90, 10);
            this.txt_WindowSize.Name = "txt_WindowSize";
            this.txt_WindowSize.Size = new System.Drawing.Size(152, 20);
            this.txt_WindowSize.TabIndex = 2;
            // 
            // txt_DblArr
            // 
            this.txt_DblArr.Location = new System.Drawing.Point(90, 39);
            this.txt_DblArr.Name = "txt_DblArr";
            this.txt_DblArr.Size = new System.Drawing.Size(278, 20);
            this.txt_DblArr.TabIndex = 3;
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Location = new System.Drawing.Point(293, 10);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_Calculate.TabIndex = 4;
            this.btn_Calculate.Text = "Calculate";
            this.btn_Calculate.UseVisualStyleBackColor = true;
            this.btn_Calculate.Click += new System.EventHandler(this.btn_Calculate_Click);
            // 
            // rtxt_MovAvg
            // 
            this.rtxt_MovAvg.Location = new System.Drawing.Point(12, 65);
            this.rtxt_MovAvg.Name = "rtxt_MovAvg";
            this.rtxt_MovAvg.Size = new System.Drawing.Size(356, 163);
            this.rtxt_MovAvg.TabIndex = 5;
            this.rtxt_MovAvg.Text = "";
            // 
            // MovingAverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.rtxt_MovAvg);
            this.Controls.Add(this.btn_Calculate);
            this.Controls.Add(this.txt_DblArr);
            this.Controls.Add(this.txt_WindowSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MovingAverage";
            this.Text = "Moving Average";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_WindowSize;
        private System.Windows.Forms.TextBox txt_DblArr;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.RichTextBox rtxt_MovAvg;
    }
}

