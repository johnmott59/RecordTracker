using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SqlAccess;

namespace RecordTracker
{
    /// <summary>
    /// Interaction logic for ShowRecords.xaml
    /// </summary>
    public partial class ShowRecords : Window
    {
        public string MyTitle {get;set;}

        public ShowRecords(string Query,DataTable result)
        {
            MyTitle = Query;
            InitializeComponent();
            gridEmployees.DataContext = result.DefaultView;        
        }

    }
}
