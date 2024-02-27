using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public enum EtypeCard
    {
        SymbolCard=1,
        letterCard,
        exerciseCard
    }
    internal class Board
    {
        public int boardSize { get; set; }
        public List<Card> boardCards { get; set; } = new List<Card>();
        public Random random = new Random();
        public EtypeCard etypeCard { get; set; }
        public EtypeCard InitBoard()
        {
            Console.WriteLine("Enter size of cards");
            boardSize=int.Parse(Console.ReadLine());

            Console.WriteLine("Choose which game do you want?");
            Console.WriteLine("symbol cards: enter 1");
            Console.WriteLine("letter cards: enter 2");
            Console.WriteLine("excercises cards: enter 3");
            int x = int.Parse(Console.ReadLine());
            while(x>3)
            {
                Console.WriteLine("The number is not valid! Choose which game do you want:");
                Console.WriteLine("symbol cards: enter 1");
                Console.WriteLine("letter cards: enter 2");
                Console.WriteLine("excercises cards: enter 3");
                x = int.Parse(Console.ReadLine());
            }
            EtypeCard y = (EtypeCard)x;
            List<Card> optionalCards = new List<Card>();
            EtypeCard etype=EtypeCard.SymbolCard;
            switch (y)
            {
                case EtypeCard.SymbolCard:
                    optionalCards=SymbolCard.listCards.ConvertAll(c=>(Card)c);
                    etype= EtypeCard.SymbolCard;
                    break;
                case EtypeCard.letterCard:
                    optionalCards = LetterCard.listCards.ConvertAll(c => (Card)c);
                    etype = EtypeCard.letterCard;
                    break;
                case EtypeCard.exerciseCard:
                    optionalCards = ExerciseCard.listCards.ConvertAll(c => (Card)c);
                    etype = EtypeCard.exerciseCard;
                    break;
                default:
                    break;
            }

            int j = 0;
            for (int i = 0; i < boardSize*2-1; i+=2)
            {
                if (j >= optionalCards.Count)
                    j = 0;
                boardCards.Add(optionalCards[j]);
                boardCards.Add(optionalCards[j].Copy());
                j++;
            }
            boardCards = boardCards.OrderBy(c => random.Next()).ToList();
            return etype;
        }

        public void ToDrow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int j = 0; j < boardCards.Count; j++)
            {
                if(j%5==0&&j!=0)
                    Console.WriteLine();
                boardCards[j].Print();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool PlaceIsValidToOpen(int num)
        {
            return num >= 0 && num < boardCards.Count;
        }

        public bool CardsInGame()
        {
            foreach (var item in boardCards)
            {
                if(item.Position==State.Covered)
                    return true;
            }
            return false;
        }
    }
}
