using System;
using System.Collections.Generic;
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
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace TodoApp
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
      
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            bool state = false;

            using var con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["todoDB"].ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from creditentials";


            SqlDataReader dbReader = cmd.ExecuteReader();
            while (dbReader.Read())
            {
                if (dbReader[1].ToString() == emailinput.Text)
                {
                    state = true;
                }

                else
                {
                    state = false;
                }
            }

            if(state == true)
            {
                MessageBox.Show("Email Found,");
            }
        }
    }
}