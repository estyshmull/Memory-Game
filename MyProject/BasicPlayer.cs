using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal abstract class BasicPlayer
    {
        public int numPoints { get; set; }
        public List <Card> listCards= new List<Card>();
        public string namePlayer { get; }

        public abstract string SetNamePlayer();
        public abstract int OpenCard(Board board);
        public void ShowCards() 
        {
            foreach (var item in listCards)
            {
                item.Position=State.Uncoverd;
                Console.Write(" ");
                item.Print();
            }
        }

        public BasicPlayer()
        {
            namePlayer=SetNamePlayer();
        }
    }
}
