using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForMariaDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection("Server=192.168.0.2;User ID=xamarin;Password=0152;Database=test"))
            {
                connection.Open();

                using (var command = new MySqlCommand("select * from test.emp;", connection))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(0));
                        Console.WriteLine(reader.GetString(1));
                    }
            }
        }
    }
}
