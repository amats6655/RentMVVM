using RentMVVM.Utilites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        string connectionString;
        SqlDataAdapter adapter;
        String getOrder;

        public Orders()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["equipmentDbConnect"].ConnectionString;
            getOrder = "SELECT * " +
                       "FROM [order] " +
                       "ORDER BY id " +
                       "OFFSET 0 ROWS " +
                       "FETCH NEXT 999 ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(getOrder, connection);
                DataTable ordersDataTable = new DataTable("users");
                adapter.Fill(ordersDataTable);
                ordersDataTable.Columns.Add("BgColor", typeof(Brush));
                ordersDataTable.Columns.Add("Status", typeof(string));


                foreach (DataRowView dt in ordersDataTable.DefaultView)
                {
                    if (dt.Row[8].ToString() == "False")
                    {
                        Brush BgColor = GetBrush.getBrush('D');
                        string Status = "Долг";
                        dt.Row[10] = BgColor;
                        dt.Row[11] = Status;
                    }
                    else
                    {
                        string s = dt.Row[8].ToString();
                        Brush BgColor = GetBrush.getBrush('R');
                        string Status = "Возвращено";
                        dt.Row[10] = BgColor;
                        dt.Row[11] = Status;
                    }
                    
                }

                OrdersDataGrid.ItemsSource = ordersDataTable.DefaultView;
            }


        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.ShowDialog();
        }
    }
}
