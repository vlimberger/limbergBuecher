using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

        private void insBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(IDtb.Text);
                string titel = Titb.Text;
                string author = AUTtb.Text;
                string kurbeschreibung = kuzTb.Text;
                string kategorie = katTb.Text;
                string verlag = Vetb.Text;


                Buecher b = new Buecher (id, titel, author,kurbeschreibung, kategorie, verlag );

                
            }

            catch
            {
                IDtb.Text = "";
                Titb.Text = "";
                AUTtb.Text = "";
                kuzTb.Text = "";
                katTb.Text = "";
                Vetb.Text = "";

                MessageBox.Show("Es müssen Werte eingegeben werden");
            }


            //"INSERT INTO Buecher ([Id],[Titel],[Author],[Kurzbeschreibung],[Kategorie],[Verlag])" + "VALUES('" + IDtb.Text + "','" + Titb.Text + "','" + AUTtb.Text + "','" + kuzTb.Text + "','" + katTb.Text + "','" + Vetb.Text + "')";


        }
    }
}
