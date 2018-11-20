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

        DataTable inquire_allData;
        string inquire_isbn = "";
        string inquire_bookname = "";
        string inquire_author = "";
        string inquire_publisginghouse = "";


        public edit_data(int rowIndex, string selectISBN)
        {
            InitializeComponent();
            //---pass selectISBN value---
            select_ISBN = selectISBN;
            //---get select book data---
            inquire_allData = book_sql.inquire_sql_AllBookInfo("ISBN, bookname, author, publishinghouse", "Lib_Table");        
            inquire_isbn = inquire_allData.Rows[rowIndex]["ISBN"].ToString();
            inquire_bookname = inquire_allData.Rows[rowIndex][1].ToString();        //1 is bookname
            inquire_author = inquire_allData.Rows[rowIndex][2].ToString();          //2 is author
            inquire_publisginghouse = inquire_allData.Rows[rowIndex][3].ToString(); //3 is publishinghouse     
            //--------------------------
            //---setup data-------------
            textBox_ISBN.Text = inquire_isbn;
            textBox_bookname.Text = inquire_bookname;
            textBox_author.Text = inquire_author;
            textBox_publishinghouse.Text = inquire_publisginghouse;
            pictureBox_BookImage.Image = Image.FromStream(book_sql.inquire_sql_BookImg(selectISBN));
            //---------------------------
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
