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
using System.Windows.Shapes;
using SGI;

namespace GalerieArtSGIWin
{
    /// <summary>
    /// Interaction logic for SGIArt.xaml
    /// </summary>
    public partial class SGIArt : Window
    {
        public static string modeTest = "O"; // Mettre a "N" ne pas loadé le DataTest
        static Galerie gal = new Galerie();
        

        private static void LoadDataTest()
        {
            for (int x = 0; x < DataTest.listConservateur.GetLength(0); x++)
            {
                string LeCode = DataTest.listConservateur[x, 0];
                string lePrenom = DataTest.listConservateur[x, 1];
                string leNom = DataTest.listConservateur[x, 2];
                gal.AjouterConservateurs(LeCode, lePrenom, leNom, modeTest);
            }
            for (int x = 0; x < DataTest.listArtiste.GetLength(0); x++)
            {
                string LeCode = DataTest.listArtiste[x, 0];
                string lePrenom = DataTest.listArtiste[x, 1];
                string leNom = DataTest.listArtiste[x, 2];
                string leConservateur = DataTest.listArtiste[x, 3];
                gal.AjouterArtiste(LeCode, lePrenom, leNom, leConservateur, modeTest);
            }

            for (int x = 0; x < DataTest.listOeuvre.GetLength(0); x++)
            {
                string LeCode = (string)DataTest.listOeuvre[x, 0];
                string leTitre = (string)DataTest.listOeuvre[x, 1];
                string leIdArtiste = (string)DataTest.listOeuvre[x, 2];
                int leAnnee = (int)DataTest.listOeuvre[x, 3];
                int leValeur = (int)DataTest.listOeuvre[x, 4];
                gal.AjouterOeuvre(LeCode, leTitre, leAnnee, leValeur, leIdArtiste, modeTest);
            }

            modeTest = "N";
        }

        public SGIArt()
        {
            InitializeComponent();
            LoadDataTest();

            this.dataGridConservateur.ItemsSource = gal.TableauConservateurs;
            this.dataGridArtiste.ItemsSource = gal.TableauArtistes;
            this.DataGridOeuvre.ItemsSource = gal.TableauOeuvres;

        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
