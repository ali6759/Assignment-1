using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp4
{
    public class CLHeaderInvoice
    {
        private SqlConnection cn;
        private SqlCommand cmd;

        public   CLHeaderInvoice
()
        {
            cn = new SqlConnection("Data Source=DESKTOP-S7GORUM\\MSSQLSERVER01;Initial Catalog=DBStore;User ID=sa;password=1;");
            cmd = new SqlCommand();
        }

        public void AddInvoice(  int IDHeaderInvoice, string DateInvoice , Int32 PriceTotal)
        {
            if (cn.State == ConnectionState.Closed) cn.Open();

           
            cmd.CommandText = "INSERT INTO HeaderInvoice(IDHeaderInvoice,DateInvoice,PriceTotal)" +
           " VALUES(" + IDHeaderInvoice + " , '" + DateInvoice + "'," + PriceTotal + ")";


            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
        }


        public int NewIvoiceID()
        {
            Int32 NewID;

            if (cn.State == ConnectionState.Closed) cn.Open();

            cmd.CommandText = "SELECT (isnull(max(IDHeaderInvoice),0) +1) AS NewInvoiceID  FROM HeaderInvoice";
            cmd.Connection = cn;
            NewID = (int)cmd.ExecuteScalar();
            return NewID;
        }

    }
}
