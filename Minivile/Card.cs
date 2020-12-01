using System;
using System.Reflection.Metadata.Ecma335;

namespace Miniville
{
	public struct Card
	{
		public int id { get; set; }
		public string color { get; set; }
		public int cost { get; set; }
		public string name { get; set; }
		public string effect { get; set; }
		public int dice { get; set; }
		public int gain { get; set; }


		public Card(int idC, string colorC, int costC, string nameC, string effectC, int diceC, int gainC)
        {
			this.id = idC;
			this.color = colorC;
			this.cost = costC;
			this.name = nameC;
			this.effect = effectC;
			this.dice = diceC;
			this.gain = gainC;
        }

        public override string ToString()
        {
			string sortie = string.Format("{0} ({1} : {2} (sur un {3} du dé)", this.name, this.color, this.effect, this.dice);
			return sortie;
        }
    }



}