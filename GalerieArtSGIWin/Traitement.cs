using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SGI;
using GalerieArtSGIWin;

namespace GalerieArtSGIWin
{
    public class Traitement
    {
        public static void SauvegarderFichier(string fname)
        {
            StreamWriter sw = new StreamWriter(fname);
            foreach (Conservateur c in SGIArt.gal.TableauConservateurs)
            {
                sw.WriteLine(string.Format("Conservateur;{0};{1};{2};{3}",c.ID, c.Prenom, c.Nom, c.Commission));
            }

            foreach (Artiste a in SGIArt.gal.TableauArtistes)
            {
                sw.WriteLine(string.Format("Artiste;{0};{1};{2};{3}",a.ID, a.Prenom, a.Nom, a.IDConservateur));
            }

            foreach (Oeuvre o in SGIArt.gal.TableauOeuvres)
            {
                sw.WriteLine(string.Format("Oeuvre;{0};{1};{2};{3};{4}", o.ID, o.Titre, o.Annee, o.ValeurEstimee, o.IDArtiste));
            }
            sw.Close();
        }

        public static void OuvrirFichier(string fname)
        {
            StreamReader sr = new StreamReader(fname);

            string[] tab;

            while (sr.Peek() >= 0)
            {
                string valeur = sr.ReadLine();
                tab = valeur.Split(';');
                if (tab[0] == "Conservateur")
                {
                    string LeCode = tab[1];
                    string lePrenom = tab[2];
                    string leNom = tab[3];
                    SGIArt.gal.AjouterConservateurs(LeCode, lePrenom, leNom, "O");
                }
                if (tab[0] == "Artiste")
                {
                    string LeCode = tab[1];
                    string lePrenom = tab[2];
                    string leNom = tab[3];
                    string leIdConservateur = tab[4];
                    SGIArt.gal.AjouterArtiste(LeCode, lePrenom, leNom, leIdConservateur, "O");
                }
                if (tab[0] == "Oeuvre")
                {
                    string LeCode = tab[1];
                    string leTitre = tab[2];
                    int leAnnee = int.Parse(tab[3]);
                    double leValeur = double.Parse(tab[4]);
                    string leIdArtiste = tab[5];
                    SGIArt.gal.AjouterOeuvre(LeCode, leTitre, leAnnee, leValeur, leIdArtiste, "O");
                }
            }
            sr.Close();
        }

    }
}
