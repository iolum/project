using System;
using System.Collections.Generic;
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
using System.Configuration;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для dobavuser.xaml
    /// </summary>
    public partial class dobavuser : Window
    {
        string connectionString;
        public dobavuser()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Vxod = new MainWindow();
            Vxod.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = textBoxLoginnoviy.Text.Trim();
            string pass = pass2Boxnoviy.Password.Trim();

            if (login.Length <= 3)
            {
                textBoxLoginnoviy.ToolTip = "Длина логина должна быть не менее 5 символов";
                textBoxLoginnoviy.Background = Brushes.IndianRed;

            }
            else if (pass.Length < 5)
            {
                pass2Boxnoviy.ToolTip = "Длина пароля должна быть не менее 5 символов";
                pass2Boxnoviy.Background = Brushes.IndianRed;
            }

            else
            {
                textBoxLoginnoviy.ToolTip = "";
                textBoxLoginnoviy.Background = Brushes.Transparent;
                pass2Boxnoviy.ToolTip = "";
                pass2Boxnoviy.Background = Brushes.Transparent;




                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    String query = "INSERT INTO Users (UserName, UserPassword) VALUES (@Name, @Pass)";
                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Name", login);
                    sqlCmd.Parameters.AddWithValue("@Pass", pass);

                    var result = sqlCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }




                MessageBox.Show("Пользователь зарегистрирован");
            }
        }

        private void textBoxLogin_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            admin Vxod = new admin();
            Vxod.Show();
            Hide();
        }
    }
}
