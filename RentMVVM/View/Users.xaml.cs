using System.Windows;
using System.Windows.Controls;

namespace RentMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {


        public Users()
        {
            InitializeComponent();
            //UsersDataGrid.ItemsSource = RentMVVM.ViewModel.UsersVM.usersDataTable.DefaultView;


        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }
    }
}
