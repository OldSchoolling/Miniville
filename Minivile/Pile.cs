using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Miniville
{
    class Pile
    {
        public List<Card> pileCards = new List<Card>();

        //Création d'une liste qui comprend toutes les sortes de cartes disponibles

        public Pile()
        {
            pileCards = new List<Card>();

            pileCards.Add(new Card(1, "Bleu", 1, "Champs de blé", "Recevez 1 pièce", 1, 1));
            pileCards.Add(new Card(2, "Bleu", 2, "Ferme", "Recevez 1 pièce", 1, 1));
            pileCards.Add(new Card(3, "Vert", 1, "Boulangerie", "Recevez 2 pièces", 2, 2));
            pileCards.Add(new Card(4, "Rouge", 2, "Café", "Recevez 1 pièce du joueur qui a lancé le dé", 3, 1));
            pileCards.Add(new Card(5, "Vert", 2, "Superette", "Recevez 3 pièces", 4, 3));
            pileCards.Add(new Card(6, "Bleu", 2, "Forêt", "Recevez 1 pièce", 5, 1));
            pileCards.Add(new Card(7, "Rouge", 4, "Restaurant", "Recevez 2 pièces du joueur qui a lancé le dé", 5, 2));
            pileCards.Add(new Card(8, "Bleu", 6, "Stade", "Recevez 4 pièce", 6, 4));
        }
        
        

    }
}
