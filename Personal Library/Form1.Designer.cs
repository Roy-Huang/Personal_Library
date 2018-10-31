namespace Personal_Library
{
    partial class Main_View
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
            this.dataGridView_Book_info = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_update_page = new System.Windows.Forms.Button();
            this.button_del_data = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Book_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Book_info
            // 
            this.dataGridView_Book_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Book_info.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Book_info.Name = "dataGridView_Book_info";
            this.dataGridView_Book_info.RowTemplate.Height = 24;
            this.dataGridView_Book_info.Size = new System.Drawing.Size(444, 412);
            this.dataGridView_Book_info.TabIndex = 0;
            this.dataGridView_Book_info.SelectionChanged += new System.EventHandler(this.dataGridView_Book_info_SelectionChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(475, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button_update_page
            // 
            this.button_update_page.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.button_update_page.Location = new System.Drawing.Point(498, 244);
            this.button_update_page.Name = "button_update_page";
            this.button_update_page.Size = new System.Drawing.Size(139, 33);
            this.button_update_page.TabIndex = 2;
            this.button_update_page.Text = "新增書籍";
            this.button_update_page.UseVisualStyleBackColor = true;
            this.button_update_page.Click += new System.EventHandler(this.button_update_page_Click);
            // 
            // button_del_data
            // 
            this.button_del_data.Location = new System.Drawing.Point(498, 305);
            this.button_del_data.Name = "button_del_data";
            this.button_del_data.Size = new System.Drawing.Size(139, 33);
            this.button_del_data.TabIndex = 3;
            this.button_del_data.Text = "刪除書籍";
            this.button_del_data.UseVisualStyleBackColor = true;
            this.button_del_data.Click += new System.EventHandler(this.button_del_data_Click);
            // 
            // Main_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(675, 440);
            this.Controls.Add(this.button_del_data);
            this.Controls.Add(this.button_update_page);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView_Book_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_View";
            this.Text = "Personal Library";
            this.Load += new System.EventHandler(this.Main_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Book_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Book_info;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_update_page;
        private System.Windows.Forms.Button button_del_data;
    }
}

