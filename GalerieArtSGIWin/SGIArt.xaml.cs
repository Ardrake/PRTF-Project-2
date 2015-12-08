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
        public static string modeTest = "O"; // Mettre a "N" pour ne pas loadé le DataTest
        static Galerie gal = new Galerie();

        
        public SGIArt()
        {
            InitializeComponent();
            LoadDataTest();

            this.dataGridConservateur.ItemsSource = gal.TableauConservateurs;
            this.dataGridArtiste.ItemsSource = gal.TableauArtistes;
            this.DataGridOeuvre.ItemsSource = gal.TableauOeuvres;
            LoadComboBoxConservateur();
        }



        private void LoadComboBoxConservateur()
        { 
            foreach (Conservateur c in gal.TableauConservateurs )
            {
                comboBoxArtiste.Items.Add(c.ID + ": " + c.Prenom + " " + c.Nom);
            }
        }

        private void buttonAjouterConservateur_Click(object sender, RoutedEventArgs e)
        {
            string conservateurID = textBoxConservateurID.Text;
            string conservateurPrenom = textBoxConservateurPrenom.Text;
            string conservateurNom = textBoxConservateurNom.Text;
            //MessageBox.Show("Clicker BoutonAjouterConservateur");
            if (conservateurID != "" && conservateurPrenom != "" && conservateurNom != "")
            {
                if (conservateurID.Length == 5)
                {
                    Conservateur c = gal.TableauConservateurs.TrouveParID(conservateurID);
                    if (c == null)
                    {
                        // ajouté conservateur au tableau / collection
                        gal.AjouterConservateurs(conservateurID, conservateurPrenom, conservateurNom, "O");
                        // Refresh du datagrid
                        this.dataGridConservateur.ItemsSource = null;
                        this.dataGridConservateur.ItemsSource = gal.TableauConservateurs;
                        // rajoute le nouveau conservateur dans le combobox de artiste
                        comboBoxArtiste.Items.Add(conservateurID + ": " + conservateurPrenom + " " + conservateurNom);
                        //clean / vide les text box pour prochaine entrée
                        textBoxConservateurID.Text = "";
                        textBoxConservateurPrenom.Text = "";
                        textBoxConservateurNom.Text = "";
                        textBoxConservateurID.Background = Brushes.White;
                        textBoxConservateurPrenom.Background = Brushes.White;
                        textBoxConservateurNom.Background = Brushes.White;
                        
                    }
                    else
                    {
                        MessageBox.Show("ID " + conservateurID + " existe déja pour le conservateur: " + c.Prenom + " " + c.Nom);
                    }
                }
                else
                {
                    MessageBox.Show("Le ID du conservateur doit avoir 5 characteres");
                    textBoxConservateurID.Background = Brushes.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoire");
                if (textBoxConservateurID.Text == "") textBoxConservateurID.Background = Brushes.OrangeRed;
                if (textBoxConservateurPrenom.Text == "") textBoxConservateurPrenom.Background = Brushes.OrangeRed;
                if (textBoxConservateurNom.Text == "") textBoxConservateurNom.Background = Brushes.OrangeRed;
            }
        }

        private void buttonAjouterArtiste_Click(object sender, RoutedEventArgs e)
        {
            string artisteID = textBoxArtisteID.Text;
            string artistePrenom = textBoxArtistePrenom.Text;
            string artisteNom = textBoxArtisteNom.Text;
            string conservateurSelection = comboBoxArtiste.Text;
            string conservateurID = conservateurSelection.Substring(0,5);
            //MessageBox.Show("Clicker BoutonAjouterArtiste");
            if (artisteID != "" && artistePrenom != "" && artisteNom != "")
            {
                if (artisteID.Length == 5)
                {
                    Conservateur c = gal.TableauConservateurs.TrouveParID(conservateurID);
                    Artiste a = gal.TableauArtistes.TrouveParID(artisteID);
                    if (a == null && c != null)
                    {
                        // ajouté artiste au tableau / collection
                        gal.AjouterArtiste(artisteID, artistePrenom, artisteNom, conservateurID, "O");
                        // Refresh du datagrid
                        this.dataGridArtiste.ItemsSource = null;
                        this.dataGridArtiste.ItemsSource = gal.TableauArtistes;
                        //clean / vide les text box pour prochaine entrée
                        textBoxArtisteID.Text = "";
                        textBoxArtistePrenom.Text = "";
                        textBoxArtisteNom.Text = "";
                        textBoxArtisteID.Background = Brushes.White;
                        textBoxArtistePrenom.Background = Brushes.White;
                        textBoxArtisteNom.Background = Brushes.White;
                    }
                    else if (a != null)
                    {
                        MessageBox.Show("ID " + artisteID + " existe déja pour l'artiste: " + a.Prenom + " " + a.Nom);
                    }
                    else if (c == null)
                    {
                        MessageBox.Show("Veuillez choisir un Conservateur pour cette artiste");
                    }
                }
                else
                {
                    MessageBox.Show("Le ID de l'artiste doit avoir 5 characteres");
                    textBoxArtisteID.Background = Brushes.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoire");
                if (textBoxArtisteID.Text == "") textBoxArtisteID.Background = Brushes.OrangeRed;
                if (textBoxArtistePrenom.Text == "") textBoxArtistePrenom.Background = Brushes.OrangeRed;
                if (textBoxArtisteNom.Text == "") textBoxArtisteNom.Background = Brushes.OrangeRed;
            }
        }




        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Aurevoir");
            System.Environment.Exit(1);
        }


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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
