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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        string connectionString;
        public reg()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length <= 3)
            {
                textBoxLogin.ToolTip = "Длина логина должна быть не менее 5 символов";
                textBoxLogin.Background = Brushes.IndianRed;

            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Длина пароля должна быть не менее 5 символов";
                passBox.Background = Brushes.IndianRed;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;




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

                vxod Vxod = new vxod();
                Vxod.Show();
                Hide();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vxod Vxod = new vxod();
            Vxod.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow Vxod = new MainWindow();
            Vxod.Show();
            Hide();
        }

        private void textBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
