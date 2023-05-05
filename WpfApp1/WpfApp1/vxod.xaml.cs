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
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для vxod.xaml
    /// </summary>
    public partial class vxod : Window
    {
        string connectionString;

        public vxod()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw = new MainWindow();
            sw.Show();
            this.Close();
        }

        private void Button_Click_vxod(object sender, RoutedEventArgs e)
        {
            
            
                if (textBoxLogin.Text == "adminn")
                {
                    
                    admin sw = new admin();
                    sw.Show();
                    this.Close();
                    return;
                }

         




            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            if (login.Length <= 3)
            {
                textBoxLogin.ToolTip = "Длина логина должна быть не менее 3 символов";
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
                    String query = $"SELECT * FROM Users  WHERE UserName LIKE '{login}' AND UserPassword LIKE '{pass}'";
                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();

                    if (result.HasRows)
                    {

                        while (result.Read())
                        {
                            String id = result.GetValue(0).ToString();

                            tovari sw = new tovari();
                            sw.Show();
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Данные введены неверно", "Пользователь не найден");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }

            



        }

        private void textBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
