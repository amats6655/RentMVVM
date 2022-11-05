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
    /// Логика взаимодействия для Equipments.xaml
    /// </summary>
    public partial class Equipments : UserControl
    {
        string connectionString;
        SqlDataAdapter adapter;
        String getEquipment;

        public Equipments()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["equipmentDbConnect"].ConnectionString;
            getEquipment = "SELECT * " +
                       "FROM equipment " +
                       "ORDER BY id " +
                       "OFFSET 0 ROWS " +
                       "FETCH NEXT 999 ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(getEquipment, connection);
                DataTable equipmentsDataTable = new DataTable("users");
                adapter.Fill(equipmentsDataTable);


                foreach (DataRowView dt in equipmentsDataTable.DefaultView)
                {
                    Console.WriteLine(dt.Row[2].ToString());
                }

                EquipmentsDataGrid.ItemsSource = equipmentsDataTable.DefaultView;
            }


        }
    }
}
