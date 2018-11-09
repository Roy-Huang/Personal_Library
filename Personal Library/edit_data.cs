using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Library
{
    public partial class edit_data : Form
    {
        SQL_using book_sql = new SQL_using();
        string imgPath;
        byte[] img = null;
        string select_ISBN = "";

        public edit_data(string selectISBN)
        {
            InitializeComponent();
            select_ISBN = selectISBN;
            textBox_ISBN.Text = select_ISBN;
        }

        private void button_edit_data2sql_Click(object sender, EventArgs e)
        {
            try
            {
                //---for image use---
                if(imgPath != null)
                {
                    FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                }
                book_sql.edit_sql_data(select_ISBN, textBox_bookname.Text, textBox_author.Text, textBox_publishinghouse.Text, img);
                //-------------------
                Main_View main_view = new Main_View();
                this.Visible = false;
                main_view.Visible = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //-----------------------------------
        }
        //---upload img and display---
        private void uploadimg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opfile = new OpenFileDialog();
                opfile.Filter = "JPG Files (*.jpg)|*.jpg|All Files(*.*)|*.*";
                opfile.Title = "select image file";
                if (opfile.ShowDialog() == DialogResult.OK)
                {
                    imgPath = opfile.FileName.ToString();
                    pictureBox_BookImage.ImageLocation = imgPath;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //----------------------------
    }
}
