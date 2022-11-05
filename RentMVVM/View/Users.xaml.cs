using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using RentMVVM.Model;
using RentMVVM.Utilites;

namespace RentMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        string connectionString;
        SqlDataAdapter adapter;
        string getUsersFirst;
        string getUsersDouble;




        public Users()
        {
            InitializeComponent();
            var converter = new BrushConverter();

            connectionString = ConfigurationManager.ConnectionStrings["equipmentDbConnect"].ConnectionString;
            getUsersFirst = "SELECT * " +
                       "FROM users " +
                       "ORDER BY id " +
                       "OFFSET 0 ROWS " +
                       "FETCH NEXT 999 ROWS ONLY;";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(getUsersFirst, connection);
                DataTable usersDataTable = new DataTable("users");
                adapter.Fill(usersDataTable);
                usersDataTable.Columns.Add("BgColor", typeof(Brush));
                usersDataTable.Columns.Add("Character", typeof(string));
                
                foreach (DataRowView dt in usersDataTable.DefaultView)
                {
                    string name = dt.Row[1].ToString().ToUpper();
                    char character = name[0];
                    Brush BgColor = GetBrush.getBrush(character);
                    dt.Row[5] = character;
                    dt.Row[4] = BgColor;
                }

                UsersDataGrid.ItemsSource = usersDataTable.DefaultView;
            }


        }

        private void Button_Click_num2(object sender, RoutedEventArgs e)
        {
            getUsersDouble = "SELECT * " +
           "FROM users " +
           "ORDER BY id " +
           "OFFSET 17 ROWS " +
           "FETCH NEXT 17 ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(getUsersDouble, connection);
                DataTable usersDataTable = new DataTable("users");
                adapter.Fill(usersDataTable);
                usersDataTable.Columns.Add("BgColor", typeof(Brush));
                usersDataTable.Columns.Add("Character", typeof(string));

                foreach (DataRowView dt in usersDataTable.DefaultView)
                {
                    string name = dt.Row[1].ToString().ToUpper();
                    char character = name[0];
                    Brush BgColor = GetBrush.getBrush(character);
                    dt.Row[5] = character;
                    dt.Row[4] = BgColor;
                }
                UsersDataGrid.ItemsSource = usersDataTable.DefaultView;
            }
        }
    }
}
