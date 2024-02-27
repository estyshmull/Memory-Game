using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class UserPlayer : BasicPlayer
    {
        public override int OpenCard(Board board)
        {
            Console.WriteLine("Enter num of card to open 1-"+(board.boardCards.Count));
            int num=int.Parse(Console.ReadLine());
            num--;
            while (!board.PlaceIsValidToOpen(num) || board.boardCards[num].Position!=State.Covered)
            {
                Console.WriteLine("The num is not valid, Enter num of card to open");
                num = int.Parse(Console.ReadLine());
                num--;
            }
            return num;
        }

        public override string SetNamePlayer()
        {
            Console.WriteLine("Enter name player");
            string s = Console.ReadLine();
            return s;
        }
    }
}
