using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class ComputerPlater:BasicPlayer
    {
        public string nameComputerPlayer{ get; }
        public ComputerPlater()
        {
            nameComputerPlayer = "computer";
        }

        public override int OpenCard(Board board)
        {
            Random random = new Random();
            int num = random.Next(1, board.boardCards.Count);
            while (board.boardCards[num].Position!=State.Covered)
            {
                num = random.Next(1, board.boardCards.Count);
            }
            return num;
        }

        public override string SetNamePlayer()
        {
            return nameComputerPlayer;
        }
    }
}
