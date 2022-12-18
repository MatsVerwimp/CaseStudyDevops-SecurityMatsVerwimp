using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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


namespace CaseStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source = DataFile.db";

        private void Submit_Click(object sender, RoutedEventArgs e)
        {


           using (SqliteConnection con = new SqliteConnection(connectionString)) 
            {
                con.Open();
                SqliteCommand cmd = new SqliteCommand();
                cmd.CommandText = @"INSERT INTO Users (Wishlist) VALUES (@Wishlist)";
                cmd.Connection= con;
                cmd.Parameters.Add(new SqliteParameter("@Wishlist", Wishlisttext.Text));
                cmd.ExecuteNonQuery();
                

            
            }

            GrantAccess();
            Close();
        }


        public void GrantAccess()
        {
            MainPage main = new MainPage();
            main.Show();
        }
    }
}
