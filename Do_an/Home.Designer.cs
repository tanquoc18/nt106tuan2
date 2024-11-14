namespace Do_an
{
    partial class Home
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(416, 58);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 0;
            label1.Text = "Tùy Chọn";
            // 
            // label2
            // 
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(156, 188);
            label2.Name = "label2";
            label2.Size = new Size(213, 52);
            label2.TabIndex = 0;
            label2.Text = "Chọn nếu bạn muốn máy tính bản thân được điều khiển";
            // 
            // label3
            // 
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(598, 188);
            label3.Name = "label3";
            label3.Size = new Size(238, 52);
            label3.TabIndex = 0;
            label3.Text = "Chọn nếu bạn muốn điều khiển máy tính khác";
            // 
            // button1
            // 
            button1.Location = new Point(187, 132);
            button1.Name = "button1";
            button1.Size = new Size(132, 53);
            button1.TabIndex = 1;
            button1.Text = "Server";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(626, 132);
            button2.Name = "button2";
            button2.Size = new Size(132, 53);
            button2.TabIndex = 1;
            button2.Text = "Client";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(998, 412);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Home";
            Text = "Remote Desktop ";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}