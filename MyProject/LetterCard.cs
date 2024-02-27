using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class LetterCard:Card
    {
        public char letter { get; set; }
        public bool isFirst { get; set; } = false;
        public static List<LetterCard> listCards = new List<LetterCard>();
        Random random = new Random();
        static LetterCard()
        {
            for (int i = 97; i < 124; i++)
            {
                listCards.Add(new LetterCard() { letter = (char)i });
            }
        }
        public override bool Equals(Card other)
        {
            if(other is LetterCard lCard)
            {
                return (int)lCard.letter ==(int)this.letter;
            }
            return false;
        }

        public override bool isMach(Card card)
        {
            return Equals(card);
        }

        public override void ToDrow()
        {
            if(isFirst)
                Console.Write(" "+(char)(letter-32)+" ");
            else
            Console.Write(" "+letter+" ");
        }
        public override Card Copy()
        {
            return new LetterCard() { letter = letter, isFirst = !isFirst };
        }
    }
}
