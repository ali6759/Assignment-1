using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SQLite;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Admin
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        public Admin()
        {

            //Data Source=DESKTOP-S7GORUM\MSSQLSERVER01;Initial Catalog=DBStore;Persist Security Info=True;User ID=sa
            //conn = new SQLiteConnection("data source=products.db3");
            cn = new SqlConnection("Password=1;Persist Security Info=True;User ID=sa;Initial Catalog=DBStore;Data Source=DESKTOP-S7GORUM\\MSSQLSERVER01");
            //cn.Open();

            cmd = new SqlCommand();
        }
        public void insert(String productName,int productID,int  amount,double price)
        {
            if (cn.State == ConnectionState.Closed) cn.Open();

            cmd.CommandText = "INSERT INTO ProductTable(productName,productID,Amount,Price)" +
                       " VALUES('"+ productName+ "'," + productID + ", " + amount+ ", " + price+ ")";
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
        }
        public void delete(String productName)
        {
            if (cn.State == ConnectionState.Closed) cn.Open();

            cmd.CommandText = "DELETE FROM ProductTable WHERE productName ='"+productName+"'";
            cmd.ExecuteNonQuery();
        }
        public void updateProductName(String oldName,String newName)
        {
            if (cn.State == ConnectionState.Closed) cn.Open();

            cmd.CommandText = "UPDATE ProductTable set productName= '" + newName + "' where productName='" + oldName + "'";
            cmd.ExecuteNonQuery();
        }
        public void updateProductAmount(String productName, int number)
        {
            if (cn.State == ConnectionState.Closed) cn.Open(); 
            String query = "UPDATE ProductTable set Amount = " + number + " where productName='" + productName + "'"; ;
            cmd.CommandText = query;
            cmd.Connection = cn;
            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
        }
        public DataTable selectStar()
        {


            cmd.CommandText = "SELECT * FROM ProductTable";
            if (cn.State == ConnectionState.Closed) cn.Open();
            cmd.Connection = cn;

            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
           
        }
        public double getPrice(String productName)
        {
            cmd.CommandText = "SELECT Price FROM ProductTable WHERE productName='"+productName+"'";
            cmd.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                double price = 0;
                while (reader.Read())
                {
                    return Convert.ToDouble(reader["price"]);
                }
                return price;
            }
        }
        public bool validAmount(String productName,int amount)
        {
            cmd.CommandText = "SELECT Amount FROM ProductTable WHERE productName='" + productName + "'";
            cmd.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int productAmount= 0;
                while (reader.Read())
                {
                    productAmount = Convert.ToInt32(reader["amount"]);
                    break;
                }
                if (amount <= productAmount)
                    return true;
                else
                    return false;
                
            }
        }

    }
}
