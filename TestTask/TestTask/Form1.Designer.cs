namespace TestTask
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.PictureBoxTree = new System.Windows.Forms.PictureBox();
            this.ButtonEnter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InfoText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTree)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PictureBoxTree);
            this.panel1.Location = new System.Drawing.Point(28, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 367);
            this.panel1.TabIndex = 3;
            // 
            // PictureBoxTree
            // 
            this.PictureBoxTree.Location = new System.Drawing.Point(-3, 0);
            this.PictureBoxTree.Name = "PictureBoxTree";
            this.PictureBoxTree.Size = new System.Drawing.Size(750, 367);
            this.PictureBoxTree.TabIndex = 2;
            this.PictureBoxTree.TabStop = false;
            // 
            // ButtonEnter
            // 
            this.ButtonEnter.Location = new System.Drawing.Point(700, 27);
            this.ButtonEnter.Name = "ButtonEnter";
            this.ButtonEnter.Size = new System.Drawing.Size(75, 21);
            this.ButtonEnter.TabIndex = 4;
            this.ButtonEnter.Text = "Enter";
            this.ButtonEnter.UseVisualStyleBackColor = true;
            this.ButtonEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(652, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // InfoText
            // 
            this.InfoText.AutoSize = true;
            this.InfoText.Location = new System.Drawing.Point(25, 11);
            this.InfoText.Name = "InfoText";
            this.InfoText.Size = new System.Drawing.Size(0, 13);
            this.InfoText.TabIndex = 6;
            this.InfoText.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InfoText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ButtonEnter);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBoxTree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ButtonEnter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label InfoText;
    }
}

