using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
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
            LoadcomboBoxOeuvreArtiste();
        }



        private void LoadComboBoxConservateur()
        { 
            foreach (Conservateur c in gal.TableauConservateurs )
            {
                comboBoxArtiste.Items.Add(c.ID + ": " + c.Prenom + " " + c.Nom);
            }
        }


        private void LoadcomboBoxOeuvreArtiste()
        {
            foreach (Artiste c in gal.TableauArtistes)
            {
                comboBoxOeuvreArtiste.Items.Add(c.ID + ": " + c.Prenom + " " + c.Nom);
            }
        }


        private void buttonAjouterConservateur_Click(object sender, RoutedEventArgs e)
        {
            string conservateurID = textBoxConservateurID.Text;
            string conservateurPrenom = textBoxConservateurPrenom.Text;
            string conservateurNom = textBoxConservateurNom.Text;
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
            string conservateurID = "";
            string artisteID = textBoxArtisteID.Text;
            string artistePrenom = textBoxArtistePrenom.Text;
            string artisteNom = textBoxArtisteNom.Text;
            string conservateurSelection = comboBoxArtiste.Text;
            try { conservateurSelection.Substring(0, 5); } catch { conservateurID = ""; }
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
                        // rajoute le nouveau conservateur dans le combobox de artiste
                        comboBoxOeuvreArtiste.Items.Add(artisteID + ": " + artistePrenom + " " + artisteNom);
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

         
        private void buttonAjouterOeuvre_Click(object sender, RoutedEventArgs e)
        {
            string artisteID = "";
            string oeuvreID = "";
            int OeuvreAnnee = 0;
            string oeuvreTitre = textBoxOeuvreTitre.Text;
            string oeuvreAnnéé = textBoxOeuvreAnnee.Text;
            string oeuvrePrixEstimee = textBoxOeuvrePrixEstimee.Text;
            int.TryParse(textBoxOeuvreAnnee.Text, out OeuvreAnnee);
            double valeurOeuvre = 0;
            double.TryParse(oeuvrePrixEstimee, out valeurOeuvre);
            string oeuvreSelection = comboBoxOeuvreArtiste.Text;
            oeuvreID = textBoxOeuvreID.Text;
            try { artisteID = oeuvreSelection.Substring(0, 5); } catch { artisteID = ""; }
    
            //MessageBox.Show("Clicker BoutonAjouterOuevre");
            if (oeuvreID != "" && oeuvreTitre != "" && OeuvreAnnee != 0)
            {
                if (oeuvreID.Length == 5)
                {
                    Oeuvre o = gal.TableauOeuvres.TrouveParID(oeuvreID);
                    Artiste a = gal.TableauArtistes.TrouveParID(artisteID);
                    if (o == null && a != null)
                    {
                        // ajouté artiste au tableau / collection
                        gal.AjouterOeuvre(oeuvreID, oeuvreTitre, OeuvreAnnee, valeurOeuvre, artisteID, "O");
                        // Refresh du datagrid
                        this.DataGridOeuvre.ItemsSource = null;
                        this.DataGridOeuvre.ItemsSource = gal.TableauOeuvres;
                        //clean / vide les text box pour prochaine entrée
                        textBoxOeuvreID.Text = "";
                        textBoxOeuvreTitre.Text = "";
                        textBoxOeuvreAnnee.Text = "";
                        textBoxOeuvreID.Background = Brushes.White;
                        textBoxOeuvreTitre.Background = Brushes.White;
                        textBoxOeuvreAnnee.Background = Brushes.White;
                    }
                    else if (o != null)
                    {
                        MessageBox.Show("ID " + oeuvreID + " existe déja pour l'oeuvre: " + o.Titre);
                    }
                    else if (a == null)
                    {
                        MessageBox.Show("Veuillez choisir un Artiste pour cette oeuvre");
                    }
                    if (OeuvreAnnee == 0)
                    {
                        MessageBox.Show("La date doit etre un nombre de 4 chiffre (ex. 1700)");
                        textBoxOeuvreAnnee.Background = Brushes.OrangeRed;
                    }
                }
                else
                {
                    MessageBox.Show("Le ID de l'oeuvre doit avoir 5 characteres");
                    textBoxOeuvreID.Background = Brushes.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoire");
                if (textBoxOeuvreID.Text == "") textBoxOeuvreID.Background = Brushes.OrangeRed;
                if (textBoxOeuvreTitre.Text == "") textBoxOeuvreTitre.Background = Brushes.OrangeRed;
                if (OeuvreAnnee == 0) textBoxOeuvreAnnee.Background = Brushes.OrangeRed;
                if (artisteID == "") comboBoxOeuvreArtiste.Background = Brushes.OrangeRed;
            }
        }


        private void ImageVendreClick(object sender, RoutedEventArgs e)
        {
            Oeuvre ouvreSelectionner = null;
            bool ouevretrouver = false;
            double prixVente = 0;
            try
            {
                ouvreSelectionner = (Oeuvre)DataGridOeuvre.SelectedCells[0].Item;
                ouevretrouver = true;
            }
            catch
            {
                MessageBox.Show("Veuillez selectionnez l'oeuvre a vendre dans le tableau ");
            }
            if (ouevretrouver && ouvreSelectionner.Etat != "V")
            {
                string input = Interaction.InputBox(ouvreSelectionner.ID + " " + ouvreSelectionner.Titre + "\n\nLe prix de vente doit etre supérieur a la valeur estimée " + ouvreSelectionner.ValeurEstimee + "\n\n Incrire le prix de vente si-dessous", "Vendre une Ouevre", "", -1, -1);
                double.TryParse(input, out prixVente);
                if (prixVente > ouvreSelectionner.ValeurEstimee)
                {
                    gal.VendreOeuvre(ouvreSelectionner, prixVente, false);
                    // Refresh du datagrid oeuvre
                    this.DataGridOeuvre.ItemsSource = null;
                    this.DataGridOeuvre.ItemsSource = gal.TableauOeuvres;
                    // Refresh du datagrid conservateur
                    this.dataGridConservateur.ItemsSource = null;
                    this.dataGridConservateur.ItemsSource = gal.TableauConservateurs;
                    MessageBox.Show("Oeuvre vendu et commission assigné au conservateur");
                }
  
                else if (prixVente == 0)
                {
                    MessageBox.Show("Vente non effectué");
                }
                else
                {
                    MessageBox.Show("Prix de vente sous la valeur esitmée vente non permise");
                }
            }
            else if (ouevretrouver && ouvreSelectionner.Etat == "V")
            {
                MessageBox.Show("Cette oeuvre est déja vendu!");
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
