using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalerieArtSGIWin
{
    public static class DataTest
    {
        // liste des conservateurs avec data test
        public static string[,] listConservateur = {{"ABCDE", "Roger",  "Conservateur", "0"},
                                                    {"BCDEF", "Steve",  "Curateur", "0"},
                                                    {"CDEFG", "Pascal", "Musée", "0"},
                                                    {"DEFGH", "Stéphane", "Gallerie", "0"}
                                                    };

        // liste des artistes avec data test 
        public static string[,] listArtiste = {{"ABC01", "Pablo", "Picasso", "ABCDE"},
                                               {"ABC02", "Leonardo", "da Vinci", "ABCDE"},
                                               {"ABC03", "Rembrandt", "van Rijn", "BCDEF"},
                                               {"ABC04", "Paul", "Cézanne", "BCDEF"},
                                               {"ABC05", "Claude", "Monet", "CDEFG"},
                                               {"ABC06", "Paul", "Gauguin", "CDEFG"},
                                               {"ABC07", "Vincent", "van Gogh", "DEFGH"}
                                              };

        //liste des oeuvres avec data test 
        public static object[,] listOeuvre = {{"PAI01", "Femme à la résille", "ABC01", 1938, 67400000, 0, "E"},
                                              {"PAI02", "Peasant Woman Against a Background of Wheat", "ABC02", 1890, 68900000, 0, "E"},
                                              {"PAI03", "Femme aux Bras Croisés", "ABC01", 1902, 55000000, 0, "E"},
                                              {"PAI04", "Rideau, Cruchon et Compotier", "ABC04", 1894, 60500000, 0, "E"},
                                              {"PAI05", "Le Bassin aux Nymphéas", "ABC05", 1919, 0, 80500000, "V"},
                                              {"PAI06", "Salvator Mundi", "ABC02", 1519, 127500000, 0, "E"},
                                              {"PAI07", "Portrait of Jan Six", "ABC03", 1654, 0, 180000000, "V"},
                                              {"PAI08", "Judas returning the 30 pieces of silver", "ABC03", 1629, 70000000, 0, "N"},
                                              {"PAI09", "When Will You Marry Me?", "ABC06", 1892, 263100000, 0, "N"},
                                             };


        
    }


}
