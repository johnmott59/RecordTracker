using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SqlAccess;
using System.Configuration;

namespace RecordTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public DBContext context { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            
            context = new DBContext(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

            foreach (string s in context.TableList) {
                cmbTableName.Items.Add(s);
            }
        }

        private void btnFindRecords_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Build a query to get these records
             */
             string table = cmbTableName.SelectedValue.ToString();
             string field = cmbFieldNames.SelectedValue.ToString();
             if (field[0] == '*') field = field.Substring(1);
             string value = txtFieldValue.Text;

            string query = "";
            DataTable dt = context.GetTableData(table, field, value, out query);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No records found to match this criteria");
            }
            else
            {
                ShowRecords win = new ShowRecords(query, dt);
                win.Show();
            }
        }

        private void cmbTableName_Selected(object sender, RoutedEventArgs e)
        {
            List<ColumnData> ColumnDataList = context.GetColumnData(cmbTableName.SelectedValue.ToString());

            cmbFieldNames.Items.Clear();

            foreach (ColumnData cd in ColumnDataList)
            {
                cmbFieldNames.Items.Add((cd.PrimaryKey ? "*" : "") + cd.Name);
            }
        }

        private void btnConnectSql_Click(object sender, RoutedEventArgs e)
        {
            string str = txtConnectionString.Text;
            if (String.IsNullOrWhiteSpace(str))
            {
                str = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            if (String.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show("Unable to find connection string");
            }
            context = new DBContext(str);

            if (context.oConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Connection to database not open");
                return;
            }

            btnFindRecords.IsEnabled = true;
            btnConnectSql.IsEnabled = false;
            lblConnectionStatus.Content = "Open";


        }
    }
}
