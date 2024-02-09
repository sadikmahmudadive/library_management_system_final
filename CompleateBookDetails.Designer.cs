namespace lib_managemenet_system
{
    partial class CompleateBookDetails
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
            this.threeColorGradientPanel1 = new ThreeColorGradientPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.threeColorGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // threeColorGradientPanel1
            // 
            this.threeColorGradientPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(221)))), ((int)(((byte)(243)))));
            this.threeColorGradientPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(146)))), ((int)(((byte)(177)))));
            this.threeColorGradientPanel1.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(48)))), ((int)(((byte)(180)))));
            this.threeColorGradientPanel1.Controls.Add(this.dataGridView2);
            this.threeColorGradientPanel1.Controls.Add(this.label1);
            this.threeColorGradientPanel1.Controls.Add(this.dataGridView1);
            this.threeColorGradientPanel1.Controls.Add(this.label4);
            this.threeColorGradientPanel1.Location = new System.Drawing.Point(-1, 0);
            this.threeColorGradientPanel1.Name = "threeColorGradientPanel1";
            this.threeColorGradientPanel1.Size = new System.Drawing.Size(958, 538);
            this.threeColorGradientPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(43)))), ((int)(((byte)(58)))));
            this.label4.Location = new System.Drawing.Point(378, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "Issue Books";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(215)))), ((int)(((byte)(202)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(36)))), ((int)(((byte)(103)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(935, 235);
            this.dataGridView1.TabIndex = 36;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(215)))), ((int)(((byte)(202)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(36)))), ((int)(((byte)(103)))));
            this.dataGridView2.Location = new System.Drawing.Point(12, 303);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(935, 224);
            this.dataGridView2.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(43)))), ((int)(((byte)(58)))));
            this.label1.Location = new System.Drawing.Point(378, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 37;
            this.label1.Text = "Return Books";
            // 
            // CompleateBookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 538);
            this.Controls.Add(this.threeColorGradientPanel1);
            this.Name = "CompleateBookDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "compleate_book_details";
            this.Load += new System.EventHandler(this.CompleateBookDetails_Load);
            this.threeColorGradientPanel1.ResumeLayout(false);
            this.threeColorGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ThreeColorGradientPanel threeColorGradientPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}