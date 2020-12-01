using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville
{
    class Game
    {
        //Les deux objets Joueurs
        public Player joueurHumain;
        public Player joueurMachine;

        //Création du dé, de la pile de carte à jouer, et des deux mains (plateaux de jeu) des joueurs
        public Die de = new Die();
        public Pile pile = new Pile();
        public List<Card> mainJoueur;
        public List<Card> mainMachine;

        public Game()
        {
            //Création des deux objets joueurs, et remplissage des deux mains avec les deux cartes de début.
            mainJoueur = new List<Card>();
            mainJoueur.Add(new Card(1, "Bleu", 1, "Champs de blé", "Recevez 1 pièce", 1, 1));
            mainJoueur.Add(new Card(3, "Vert", 1, "Boulangerie", "Recevez 2 pièces", 2, 2));
            joueurHumain = new Player("humain", 3, mainJoueur);

            mainMachine = new List<Card>();
            mainMachine.Add(new Card(1, "Bleu", 1, "Champs de blé", "Recevez 1 pièce", 1, 1));
            mainMachine.Add(new Card(3, "Vert", 1, "Boulangerie", "Recevez 2 pièces", 2, 2));
            joueurMachine = new Player("ia", 3, mainMachine);
        }
            
        public void Run()
        {
            while (joueurHumain.argent <= 20 || joueurMachine.argent <= 20) {
                //tour Joueur
                Console.Clear();
                Lancer();

                Tour(joueurHumain);
                Resultats(joueurHumain);

                joueurHumain.Jouer(pile.pileCards);


                //tour IA
                Lancer();

                Tour(joueurMachine);
                Resultats(joueurMachine);

                joueurMachine.Jouer(pile.pileCards);

            }

            Console.Clear();

            //Victoire ! Mais de qui ?
            if (joueurHumain.argent >= 20 && joueurMachine.argent < 20)
            {
                Console.WriteLine("LE JOUEUR {0} GAGNE LA PARTIE AVEC {1} PIECE", joueurHumain.joueur.ToUpper(), joueurHumain.argent);
            }
            else if (joueurMachine.argent >= 20 && joueurHumain.argent < 20)
            {
                Console.WriteLine("LE JOUEUR {0} GAGNE LA PARTIE AVEC {1} PIECE", joueurMachine.joueur.ToUpper(), joueurMachine.argent);
            }
            else if (joueurMachine.argent > joueurHumain.argent)
            {
                Console.WriteLine("LE JOUEUR {0} GAGNE LA PARTIE AVEC {1} PIECE", joueurMachine.joueur.ToUpper(), joueurMachine.argent);
            }
            else if (joueurHumain.argent > joueurMachine.argent)
            {
                Console.WriteLine("LE JOUEUR {0} GAGNE LA PARTIE AVEC {1} PIECE", joueurHumain.joueur.ToUpper(), joueurHumain.argent);
            }
            else
            {
                Console.WriteLine("LE JEU SE CONCLUE SUR UNE EGALITE !? RT SI C TRIST");
            }

        }

        public int Lancer()
        {
            //Lancer le dé pour ce tour
            de.Lancer();
            return de.face;
        }

        //Récapitulatif du tour en cours
        public void Resultats(Player player)
        {
            Console.Clear();
            if (player == joueurHumain)
            {
                Console.WriteLine("---                     C'est à votre tour !                     ---");
                Console.WriteLine("---                     LE DE A FAIT UN {0} !                    ---\n", de.face);
                joueurMachine.Regarder(de.face, "vert", joueurHumain);
                Console.WriteLine();
                joueurHumain.Regarder(de.face, "rouge", joueurMachine);
                Console.WriteLine("\nAppuyer sur entrée pour finir le tour !");
                
            }
            else
            {
                Console.WriteLine("---                     C'est le tour de L'IA !                     ---");
                Console.WriteLine("---                     LE DE A FAIT UN {0} !                       ---\n", de.face);
                joueurHumain.Regarder(de.face, "vert", joueurMachine);
                Console.WriteLine();
                joueurMachine.Regarder(de.face, "rouge", joueurHumain);
                Console.WriteLine("\nAppuyer sur entrée pour finir le tour !");
                
            }

            Console.ReadLine();

        }

        //Affichage du plateau de jeu
        public void Tour(Player player) 
        {
            Console.Clear();
            if (player == joueurHumain)
            {
                Console.WriteLine("---                     C'est à votre tour !                     ---\n");
                Console.WriteLine("> Votre argent : {0}                       - L'Argent de l'IA : {1}\n", joueurHumain.argent, joueurMachine.argent);
                Console.WriteLine("> Vos cartes actives :");
                foreach(Card c in joueurHumain.main)
                {
                    Console.WriteLine(" - " + c.ToString());
                }
                Console.WriteLine("\n\nAppuyer sur entrée pour commencer votre tour !\n");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("---                     C'est au tour de L'IA !                     ---\n");
                Console.WriteLine("> Votre argent : {0}                       - L'Argent de l'IA : {1}\n", joueurHumain.argent, joueurMachine.argent);
                Console.WriteLine("> SES cartes actives :");
                foreach (Card c in joueurMachine.main)
                {
                    Console.WriteLine(" - " + c.ToString());
                }
                Console.WriteLine("\n\nAppuyer sur entrée pour commencer SON tour !\n");
                Console.ReadLine();
            }
        }
    }
}
