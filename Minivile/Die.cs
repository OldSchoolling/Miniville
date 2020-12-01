using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville
{
    class Die
    {

        public int nbFace; /// Nombre de faces

        public int face; /// Face sur laquelle un lancer va tomber lors d'un lancer

        public Die() : this(6) { } ///Constructeur chainé donnant comme valeur de base 6

        public Die(int faces) { nbFace = faces; } /// Constructeur qui définit le nombre de faces 
        
        public void Lancer() /// Méthode qui attribue à la variable face un nombre aléatoire entre 1 et la nombre de faces du dé
        {
            Random rand = new Random();

            face = rand.Next(1, nbFace + 1);
        } 

    }
}
