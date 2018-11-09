using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Library
{
    public partial class add_data : Form
    {
        //string SQL_Database = @"Data Source=(LocalDB)\MSSQLLocalDB;
        //                     Initial Catalog=Library_Book_list;
        //                     AttachDbFilename=|DataDirectory|\Library_Book_list.mdf;
        //                     Integrated Security=True";
        //SqlCommand cmd;
        SQL_using book_sql = new SQL_using();
        string imgPath;
        byte[] img = null;

        public add_data()
        {
            InitializeComponent();
        }

        private void button_add_data2sql_Click(object sender, EventArgs e)
        {
            if(textBox_ISBN.Text != null)
            {
                try
                {
                    //---for image use---
                    if (imgPath != null)
                    {
                        FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);
                    }
                    book_sql.add_sql_data(textBox_ISBN.Text, textBox_bookname.Text, textBox_author.Text, textBox_publishinghouse.Text, img);
                    //-------------------
                    //con.Close();
                    Main_View main_view = new Main_View();
                    this.Visible = false;
                    main_view.Visible = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            Main_View main_view = new Main_View();
            this.Visible = false;
            main_view.Visible = true;
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
