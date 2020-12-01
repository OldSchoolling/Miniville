using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville
{
    class Player
    {
        public string joueur; // humain ou Ia
        public int argent;
        

        public List<Card> main; // correspond aux cartes jouées par le joueur

        public Player(string type, int dollar, List<Card> mains)
        {
            this.joueur = type;
            this.argent = dollar;
            main = mains;

        }


        public void Jouer(List<Card> pile)
        {
            //regarder la pile de carte, entrer l'index de la carte qu'on veut jouer
            string i;

            while (true)
            {
                //Si le joueur est humain, lui laisser le choix
                if (joueur == "humain")
                {
                    Console.Clear();
                    Console.WriteLine("--- Entrez l'index correspondant à la carte que vous voulez jouer ---");
                    Console.WriteLine("---               Ou entrez 0 pour passer votre tour              ---\n");

                    Console.WriteLine("> Votre argent : {0}\n", argent);
                    foreach (Card c in pile)
                    {
                        Console.WriteLine("{0} || {1} : {2} ( {3} - Sur un {4} du dé ) || Coût : {5} $", c.id, c.name, c.effect, c.color, c.dice, c.cost);
                    }

                    Console.Write("\n> Entrez votre choix :");
                    i = Console.ReadLine();
                }
                else
                {
                    //Choix IA
                    Random rand = new Random();
                    i = (rand.Next(0, 9).ToString());
                }
                

                //Si i est égal à 0, on passe le tour du joueur
                if (i == "0")
                {
                    break;
                }
                else
                {
                    //Si on a l'argent nécessaire, on sort de la boucle (-1 parce que "0" ne fais pas partie de la liste)
                    if (this.argent - pile[int.Parse(i) - 1].cost >= 0)
                    {
                        //On ajoute la nouvelle carte à la main, en utilisant l'index de cette dernière
                        var carte = pile[int.Parse(i) - 1];
                        this.main.Add(new Card(carte.id, carte.color, carte.cost, carte.name, carte.effect, carte.dice, carte.gain));
                        this.argent -= carte.cost;
                        Console.WriteLine("\nL'{0} Achète sa carte !", this.joueur);
                        Console.ReadLine();

                        break;
                    }
                }
            }  
        }

        public void Regarder(int faceDe, string couleurInterdite, Player ennemi)
        {
            Console.WriteLine("> {0} :", this.joueur.ToUpper());

            //Regarde la main du joueur en cours.        
            foreach (Card c in main)
            {
                //Pour chaque carte, si la mauvaise couleur n'est pas présente et qu'il s'agit du bon dé, son effet s'applique.
                if (c.dice == faceDe && couleurInterdite != c.color)
                {
                    switch (c.id) //On applique les différents effets selon l'identifiant des cartes possédés
                    {
                        case 1:
                            this.argent += 1;
                            Console.WriteLine(" - Les Champs de blé rapportent 1 pièce !", this.joueur);
                            break;
                        case 2:
                            this.argent += 1;
                            Console.WriteLine(" - La Ferme rapporte 1 pièce !", this.joueur);
                            break;
                        case 3:
                            this.argent += 2;
                            Console.WriteLine(" - La Boulangerie rapporte 2 pièces !", this.joueur);
                            break;
                        case 4:
                            this.argent += 1;
                            ennemi.argent -= 1;
                            Console.WriteLine(" - Le Café vole 1 pièce à l'ennemi !", this.joueur);
                            break;
                        case 5:
                            this.argent += 3;
                            Console.WriteLine(" - La Superette rapporte 3 pièces !", this.joueur);
                            break;
                        case 6:
                            this.argent += 1;
                            Console.WriteLine(" - La Forêt rapporte 1 pièce !", this.joueur);
                            break;
                        case 7:
                            this.argent += 2;
                            ennemi.argent -= 2;
                            Console.WriteLine(" - Le Restaurant vole 2 pièces !", this.joueur);
                            break;
                        case 8:
                            this.argent += 4;
                            Console.WriteLine(" - Le Stade rapporte 4 pièces !", this.joueur);
                            break;
                        default:
                            break;

                    }
                }
            }
            

        }
    }
}
