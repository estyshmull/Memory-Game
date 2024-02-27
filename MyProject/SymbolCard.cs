using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class SymbolCard:Card
    {

        public char sign { get; set; }
        public ConsoleColor color { get; set; }
        public static List<SymbolCard> listCards=new List<SymbolCard>();
        public static Random random = new Random();

        static SymbolCard()
        {
            for (int i = 0; i < 10; i++)
            {
                listCards.Add(new SymbolCard() { sign = (char)i, color = (ConsoleColor)random.Next(1, 16) });
            }
        }
        public override bool Equals(Card other)
        {
            if (other is SymbolCard c)
            {
                return c.color==this.color&& c.sign==this.sign;
            }
            return false;
        }
        public override bool isMach(Card card)
        {
            return Equals(card);
        }
        public override void ToDrow()
        {
            Console.BackgroundColor = color;
            Console.Write(" "+sign+" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public override Card Copy()
        {
            return new SymbolCard() { sign=this.sign,color=this.color};
        }
    }
}
