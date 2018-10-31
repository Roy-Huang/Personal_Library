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
    public partial class Main_View : Form
    {
        //string SQL_Database = @"Data Source=(LocalDB)\MSSQLLocalDB;
        //                     Initial Catalog=Library_Book_list;
        //                     AttachDbFilename=|DataDirectory|\Library_Book_list.mdf;
        //                     Integrated Security=True";
        //SqlCommand sqlcmd;
        //SqlConnection con2sql;

        SQL_using book_sql = new SQL_using();

        public Main_View()
        {
            InitializeComponent();
        }

        private void Main_View_Load(object sender, EventArgs e)
        {
            update_GridView_loadData();
        }
        private void dataGridView_Book_info_SelectionChanged(object sender, EventArgs e)
        {
            //---get selected row index number---
            int rowIndex = dataGridView_Book_info.CurrentRow.Index;
            try
            {
                //---get index number cell 0 value(type is object)---
                string selectISBN = Convert.ToString(dataGridView_Book_info.Rows[rowIndex].Cells[0].Value); //cells[0] is ISBN position

                pictureBox1.Image = Image.FromStream(book_sql.inquire_sql_BookImg(selectISBN));
               // con2sql.Close();
            }catch (Exception ex)
            {
                pictureBox1.Image = null;
                Console.WriteLine(ex.Message);
               //MessageBox.Show(ex.Message);
            }
        }

        private void button_update_page_Click(object sender, EventArgs e)
        {
            add_data add_data_view = new add_data();
            this.Visible = false;
            add_data_view.Visible = true;
        }
        private void button_del_data_Click(object sender, EventArgs e)
        {
            //---get selected row index number---
            int rowIndex = dataGridView_Book_info.CurrentRow.Index;
            string selectISBN = Convert.ToString(dataGridView_Book_info.Rows[rowIndex].Cells[0].Value);    //cells[0] is ISBN position
            book_sql.del_sql_data(selectISBN);
            update_GridView_loadData();
        }

        public void update_GridView_loadData()
        {
            try
            {
                DataTable return_inquire_data = book_sql.inquire_sql_AllBookInfo("ISBN, bookname, author, publishinghouse", "Lib_Table");
                this.dataGridView_Book_info.DataSource = return_inquire_data;
               // con2sql.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
               // MessageBox.Show(ex.Message);
            }
        }
    }
}
