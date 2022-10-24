using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    internal class Program
    {
        List<string> mots = new List<string>();
        static void Main(string[] args)
        {
            List<string> mots = new List<string>();

            mots.Add("un");
            mots.Add("deux");
            mots.Add("cinq");
            mots.Add("rouge");
            mots.Add("membre");
            mots.Add("conseil");
            mots.Add("donner");
            mots.Add("reponse");
            mots.Add("etat");
            mots.Add("son");
            mots.Add("armement");
            mots.Add("peu");
            mots.Add("apres");
            mots.Add("vacances");
            mots.Add("annonce");
            mots.Add("mercredi");
            mots.Add("evident");
            mots.Add("regime");
            mots.Add("affirmer");
            mots.Add("arme");
            mots.Add("peu");

            string motSaisi = "";
            string rejouer = "o";



            // Tant que l'utilisateur que l'utlisateur tape sur o pour rejouer
            while (rejouer.ToLower().Equals("o")){
                // Un mot provenant de la liste "mots" sera tiré au hasard et sera stocké dans la variable "motCache"
                string motCache = ChoisirMot(mots);
                // Le mot a decouvrir sera caché par des étoiles
                var motADecouvrir = new string('*', motCache.Length);
                int coup = 10;
                bool gagne = false;

                Console.WriteLine("Bienvenue sur le jeu du pendu");
                Console.WriteLine("Le but de ce jeu est de deviner les lettres du mot qui les composent");
                Console.WriteLine("");

                //Le programme sera mis en pause pendant 5 secondes
                System.Threading.Thread.Sleep(5000);
                while (coup > 0 && gagne == false)
                {
                    Console.WriteLine("Il vous reste " + coup + " coups a jouer");
                    Console.WriteLine("Voici le mot cache : " + motADecouvrir);
                    Console.WriteLine("Proposer une lettre : ");
                    motSaisi = Console.ReadLine();

                   
                    if (motCache.Contains(motSaisi))
                    {
                        //Conversion du string motSaisi en char
                        char lettre = char.Parse(motSaisi);
                        // Boucle for qui va parcourir le motCache
                        for (int i = 0; i < motCache.Length; i++)
                        {
                            if (lettre == motCache[i])
                            {
                                char[] letters = motADecouvrir.ToCharArray();
                                letters[i] = lettre;
                                motADecouvrir = string.Join("", letters);

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erreur");
                        coup -= 1;
                    }
                    // Utilisation de la méthode testGagne pour savoir si le motCache a été decouvert
                    gagne = testGagne(motADecouvrir, motCache);
                }

                    //Si le joueur a decouvert le mot
                    if (gagne)
                    {
                        Console.WriteLine("Bravo, vous avez gagné !");
                        Console.WriteLine("Le mot caché etait " + motCache);
                        Console.WriteLine("Voulez-vous rejouer ? (o/n)");
                        rejouer = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Il vous reste 0 coups a jouer");
                        Console.WriteLine("Le mot caché etait " + motCache);
                        Console.WriteLine("Voulez-vous rejouer ?");
                        rejouer = Console.ReadLine();
                    }


                
            }
        }


        static int GetNombreAleatoire()
        {
            Random aleatoire = new Random();
            int nb = aleatoire.Next(20);
            return nb;
        }

        static string ChoisirMot(List<string> mots)
        {
            int nb = GetNombreAleatoire();
            string motChoisi = mots[nb];
            return motChoisi;
        }

        static bool testGagne(string motCache, string motADecouvrir)
        {
            if (motCache == motADecouvrir)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
