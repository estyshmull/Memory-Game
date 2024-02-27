using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class ExerciseCard:Card
    {
        public bool isFirst { get; set; } = false;
        public string exercise { get; set; }
        public double solution { get; set; }

        public static List<ExerciseCard> listCards=new List<ExerciseCard>();

        static Random Random = new Random();
        static ExerciseCard()
        {
            for (int i = 0; i < 12; i++)
            {
                int a = Random.Next(1, 50);
                int b = Random.Next(1, 50);
                string ex=a.ToString()+'+'+b.ToString();
                listCards.Add(new ExerciseCard() { exercise= ex,solution=a+b });
            }
        }
        public override bool Equals(Card card)
        {
            if(card is ExerciseCard exCard)
            {
                return exCard.exercise == this.exercise&&exCard.isFirst!=this.isFirst;
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
            {
                Console.Write(" "+exercise+" ");
            }
            else
            Console.Write(" "+solution+" ");
        }

        public override Card Copy()
        {
            return new ExerciseCard() { solution = solution, exercise = exercise, isFirst = !isFirst };
        }
    }
}
