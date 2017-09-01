using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlAccess
{
    public class ColumnData
    {
        public string Name;
        public string Type;
        public bool PrimaryKey;
    }

    public class DBContext 
    {
        public SqlConnection oConn { get; set; } = new SqlConnection();

        // List of all the tables
        public List<string> TableList { get; set; }

        public DBContext(string connection)
        {
             oConn.ConnectionString = connection;
            try
            {
                oConn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error opening database" + e.ToString());
            }

            /*
             * Retrieve a list of all the tables
             */

            TableList = GetTableNames();

            TableList.Sort();
        }

        public DataTable GetTableData(string TableName,string FieldName,string Value,out string Query)
        {
            Query = "";
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = oConn;
                    DataTable dt = new DataTable();
                    cmd.Parameters.Add(new SqlParameter("@value", Value));

                    // This is to pass back for labelling, it doesn't have to work
                    Query = $"select * from [{TableName}] where [{FieldName}] = {Value}";

                    cmd.CommandText = String.Format($"select * from [{TableName}] where [{FieldName}] = @Value");
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        public List<string> GetTableNames()
        {
            DataSet ds = new DataSet();

            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = oConn;
                    cmd.CommandText = "select name from sysobjects where (xtype='U')";
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }

            }

            List<string> tableList = new List<string>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                tableList.Add(dr[0].ToString());
            }

            return tableList;
        }

        public bool IsSystemTable(string tablename)
        {
            if (tablename.StartsWith("sys")) return true;
            if (tablename == "dtproperties") return true;
            return false;
        }

        public bool HasPrimaryKey(string tablename)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = oConn;
                    cmd.CommandText = $"select top 1 * from [{tablename}]";
                    da.SelectCommand = cmd;
                    da.FillSchema(dt, SchemaType.Source);
                }
            }
            /*
             * If there is no primary key return
             */
            if (dt.PrimaryKey.Length == 0) return false;

            return true;
        }

        public List<ColumnData> GetColumnData(string TableName)
        {
            DataTable dt = new DataTable();
            List<ColumnData> ColumnDataList = new List<ColumnData>();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = oConn;
                    //    cmd.Parameters.Add(new SqlParameter("@tablename", TableName));
                    cmd.CommandText = $"select top 1 * from [{TableName}]";  
                    da.SelectCommand = cmd;
                    da.FillSchema(dt, SchemaType.Source);
                }
            }    

            foreach (DataColumn dc in dt.Columns)
            {
                ColumnData cd = new ColumnData();
                ColumnDataList.Add(cd);
                cd.Name = dc.ColumnName;
                cd.Type = dc.DataType.Name;

                if (dt.PrimaryKey.Count() > 0 &&  dt.PrimaryKey[0] == dc)
                {
                    Console.WriteLine("Primary key is " + dc.ColumnName);
                    cd.PrimaryKey = true;
                }
                else
                {
                    cd.PrimaryKey = false;
                }
            }


            return ColumnDataList;

        }
    }
}
