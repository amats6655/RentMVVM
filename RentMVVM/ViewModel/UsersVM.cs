using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using RentMVVM.Model;
using RentMVVM.Utilites;

namespace RentMVVM.ViewModel
{
    class UsersVM : Utilites.ViewModelBase
    {

        string connectionString;
        SqlDataAdapter adapter;
        public string getUsers;


        public UsersVM()
        {
            connectionString = ConfigurationManager.ConnectionStrings["equipmentDbConnect"].ConnectionString;
            getUsers = "SELECT * " +
                       "FROM users " +
                       "ORDER BY id " +
                       "OFFSET 0 ROWS " +
                       "FETCH NEXT 999 ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(getUsers, connection);
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
                //UsersDataGrid.ItemsSource = usersDataTable.DefaultView;
            }
        }
    }
}
