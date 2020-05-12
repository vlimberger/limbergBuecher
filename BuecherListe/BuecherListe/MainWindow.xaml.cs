using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BuecherListe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Buecher> buecherliste;
        private readonly string connString = ConfigurationManager.ConnectionStrings["BuecherListe.Properties.Settings.BuecherConnectionString"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            BuecherListe.BuecherDataSet buecherDataSet = ((BuecherListe.BuecherDataSet)(this.FindResource("buecherDataSet")));
            // Lädt Daten in Tabelle "Tabl". Sie können diesen Code nach Bedarf ändern.
            BuecherListe.BuecherDataSetTableAdapters.TablTableAdapter buecherDataSetTablTableAdapter = new BuecherListe.BuecherDataSetTableAdapters.TablTableAdapter();
            buecherDataSetTablTableAdapter.Fill(buecherDataSet.Tabl);
            System.Windows.Data.CollectionViewSource tablViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tablViewSource")));
            tablViewSource.View.MoveCurrentToFirst();
            // Lädt Daten in Tabelle "Buecher". Sie können diesen Code nach Bedarf ändern.
            BuecherListe.BuecherDataSetTableAdapters.BuecherTableAdapter buecherDataSetBuecherTableAdapter = new BuecherListe.BuecherDataSetTableAdapters.BuecherTableAdapter();
            buecherDataSetBuecherTableAdapter.Fill(buecherDataSet.Buecher);
            System.Windows.Data.CollectionViewSource buecherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("buecherViewSource")));
            buecherViewSource.View.MoveCurrentToFirst();
        }

   
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(); 
            con.ConnectionString = connString;
           
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * from [buecherliste]";
                cmd.Connection = con;
                SqlDataAdapter daadapt = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                daadapt.Fill(data);
                buecherDataGrid.ItemsSource = data.DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
            }
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();

                
                cmd.CommandText = "UPDATE [Id],[Titel],[Author],[Kurzbeschreibung],[Kategorie],[Verlag])" + "VALUES('" + IDtb.Text + "','" + Titb.Text + "','" + AUTtb.Text + "','" + kuzTb.Text + "','" + katTb.Text + "','" + Vetb.Text + "')";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Update");
            }

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();

                //Hier wird die Zeile von einer Bestimmten ID gelöscht
                cmd.CommandText = "DELETE FROM Buecher WHERE Id=" + IDtb.Text;

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during delete");
            }

        }

        private void insBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connString); 
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Buecher [Id],[Titel],[Author],[Kurzbeschreibung],[Kategorie],[Verlag])" + "VALUES('" + IDtb.Text + "','" + Titb.Text + "','" + AUTtb.Text + "','" + kuzTb.Text + "','" + katTb.Text + "','" + Vetb.Text + "')";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Error during insert");
            }
        }

        private void buecherDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = buecherDataGrid.SelectedItem as DataRowView;
            if (item != null)
            {
                IDtb.Text = item.Row.ItemArray[0].ToString();
                Titb.Text = item.Row.ItemArray[1].ToString();
                AUTtb.Text = item.Row.ItemArray[2].ToString();
                kuzTb.Text = item.Row.ItemArray[3].ToString();
                katTb.Text = item.Row.ItemArray[4].ToString();
                Vetb.Text = item.Row.ItemArray[5].ToString();

            }
            DisplayData(); 

        }
    }
}

