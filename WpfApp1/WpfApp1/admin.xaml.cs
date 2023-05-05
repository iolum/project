using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        String id;
        string connectionString;

        public object AppData { get; private set; }

        public admin(String id = "")
        {
            InitializeComponent();

            this.id = id;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить?", "Удалить пользователя",
                     MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {

                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    String query = "DELETE FROM Users WHERE UserId = @UserId";

                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@UserId", this.id);

                    sqlCmd.ExecuteReader();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();



                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Vxod = new MainWindow();
            Vxod.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить?", "Удалить пользователя",
                     MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {

                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    String query = "DELETE FROM Users WHERE UserId = @UserId";

                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@UserId", this.id);

                    sqlCmd.ExecuteReader();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();



                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dobavuser Vxod = new dobavuser();
            Vxod.Show();
            Hide();
        }

        private void listOfUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        
    }
}
