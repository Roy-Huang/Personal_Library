using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library
{
    class SQL_using
    {
        string SQL_Database = @"Data Source=(LocalDB)\MSSQLLocalDB;
                             Initial Catalog=Library_Book_list;
                             AttachDbFilename=|DataDirectory|\Library_Book_list.mdf;
                             Integrated Security=True";
        SqlCommand sqlcmd;
        SqlConnection con2sql;
        MemoryStream ms;          //Create MemoryStram to save img(byte[])
        DataTable table_bookinfo; //Create DataTable to save bookinfo

        public void add_sql_data(string ISBN, string bookname, string author, string publishinghouse, byte[] img)
        {
            con2sql = new SqlConnection(SQL_Database);
            sqlcmd = new SqlCommand("insert into Lib_Table(ISBN, bookname, author, publishinghouse, bookimage) " +
                        "values(@isbn, @bookname, @author, @publishinghouse, @bookimage)", con2sql);
            con2sql.Open();
            sqlcmd.Parameters.AddWithValue("@isbn", ISBN);
            sqlcmd.Parameters.AddWithValue("@bookname", bookname);
            sqlcmd.Parameters.AddWithValue("@author",author);
            sqlcmd.Parameters.AddWithValue("@publishinghouse", publishinghouse);
            if (img == null)
            {
                sqlcmd.Parameters.Add("@bookimage", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("@bookimage", img);
            }
            sqlcmd.ExecuteNonQuery();
            con2sql.Close();
        }
        public void del_sql_data(string del_isbn)
        {
            string sql_del_cmd = "Delete From Lib_Table Where ISBN = '" + del_isbn + "'";          //delete command 
            try
            {
                con2sql = new SqlConnection(SQL_Database);
                con2sql.Open();
                sqlcmd = new SqlCommand(sql_del_cmd, con2sql);
                sqlcmd.ExecuteNonQuery();
                con2sql.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable inquire_sql_AllBookInfo(string inquire_item, string inquire_datatable)
        {
            con2sql = new SqlConnection(SQL_Database);           
            con2sql.Open();
            string sql_inquireInfo_cmd = "select " + inquire_item + " From " + inquire_datatable; //Inquire command   
            sqlcmd = new SqlCommand(sql_inquireInfo_cmd, con2sql);                                //use sqlcommand ,so... need sql open before
            SqlDataReader reader_bookinfo = sqlcmd.ExecuteReader();
            table_bookinfo = new DataTable();
            table_bookinfo.Load(reader_bookinfo);
            //---rename to chinsese---
            table_bookinfo.Columns["bookname"].ColumnName = "書名";
            table_bookinfo.Columns["author"].ColumnName = "作者";
            table_bookinfo.Columns["publishinghouse"].ColumnName = "出版社";
            //------------------------  
            return table_bookinfo;         
        }
        public MemoryStream inquire_sql_BookImg(string selectISBN)
        {
            con2sql = new SqlConnection(SQL_Database);
            string sql_inquireImg_cmd = "select bookimage From Lib_Table where ISBN in ('" + selectISBN + "')";
            con2sql.Open();
            sqlcmd = new SqlCommand(sql_inquireImg_cmd, con2sql);                       //use sqlcommand ,so... need sql open before
            SqlDataReader reader_bookimg = sqlcmd.ExecuteReader();
            reader_bookimg.Read();
            byte[] img = (byte[])(reader_bookimg[0]);
            ms = new MemoryStream(img);
            return ms;
        }

        //public Tuple<DataTable, MemoryStream> inquire_sql(string selectISBN, string inquire_item, string inquire_datatable)
        //{
        //    try
        //    {
        //        SqlConnection con2sql = new SqlConnection(SQL_Database);
        //        con2sql.Open();
        //        string Sql_bookinfo_str = "select " + inquire_item + " From " + inquire_datatable; //Inquire command    
        //        string Sql_img_str = "select bookimage From "+ inquire_datatable +" where ISBN in ('" + selectISBN + "')"; ;                                                                         // SqlDataAdapter da = new SqlDataAdapter(Sqlstr, con2sql);
        //        sqlcmd = new SqlCommand(Sql_bookinfo_str, con2sql);
        //        SqlDataReader reader_bookinfo = sqlcmd.ExecuteReader();
        //        DataTable table_bookinfo = new DataTable();
        //        table_bookinfo.Load(reader_bookinfo);

        //        sqlcmd = new SqlCommand(Sql_img_str, con2sql);
        //        SqlDataReader reader_bookimg = sqlcmd.ExecuteReader();
        //        byte[] img = (byte[])(reader_bookimg[0]);
        //        MemoryStream ms = new MemoryStream(img);
   
        //        return new Tuple<DataTable, MemoryStream>(table_bookinfo, ms);
        //    }catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
    }
}
