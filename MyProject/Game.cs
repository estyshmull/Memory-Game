using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{

    internal class Game
    {
        public List<BasicPlayer> playerList { get; set; }=new List<BasicPlayer> ();
        public Dictionary<EtypeCard, List<Card>> dicCard { get; }
        public int indexPlayer { get; set; } = 0;
        public EtypeCard typeGame { get; set; }

        public Board boardGame = new Board();

        public Game()
        {
            typeGame=boardGame.InitBoard();
            InitPlayer();
            BaginGame();
        }
        public void InitPlayer()
        {
            Console.WriteLine("Enter number of players>1");
            int sumPlayer = int.Parse(Console.ReadLine());
            while (sumPlayer<=0)
            {
                Console.WriteLine("The number is not valid! Enter number of players > 1");
                sumPlayer = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < sumPlayer; i++)
            {
                playerList.Add(new UserPlayer());
            }
            Console.WriteLine("Do you want computer player? enter 1 else :0");
            int flagComputer=int.Parse(Console.ReadLine());
            if(flagComputer == 1)
            {
                playerList.Add(new ComputerPlater());
            }
        }

        public void BaginGame()
        {
            int i = 0,g=0, times = boardGame.boardSize * 2; bool flagPare = false;
            while(i<times)
            {
                for ( g = 0; g < 999999999; g++) ;
                if (typeGame == EtypeCard.exerciseCard)
                {
                    for (g = 0; g < 999999999; g++) ;
                    for (g = 0; g < 999999999; g++) ;
                }
                Console.Clear();
                Console.WriteLine(playerList[indexPlayer].namePlayer+" your up");
                boardGame.ToDrow();
                int card1 = playerList[indexPlayer].OpenCard(boardGame);
                boardGame.boardCards[card1].Position = State.Uncoverd;
                Console.Clear();
                boardGame.ToDrow();
                int card2 = playerList[indexPlayer].OpenCard(boardGame);
                boardGame.boardCards[card2].Position = State.Uncoverd;
                Console.Clear();
                boardGame.ToDrow();
                flagPare=FindPare(boardGame.boardCards[card1], boardGame.boardCards[card2]);
                if(!flagPare)
                {
                    boardGame.boardCards[card1].Position = State.Covered;
                    boardGame.boardCards[card2].Position = State.Covered;
                }
                else
                {
                    boardGame.boardCards[card1].Position = State.HasTaken;
                    boardGame.boardCards[card2].Position = State.HasTaken;
                    boardGame.boardCards.Remove(boardGame.boardCards[card1]);
                    if(card1>card2)
                       boardGame.boardCards.Remove(boardGame.boardCards[card2]);
                    else
                       boardGame.boardCards.Remove(boardGame.boardCards[card2-1]);
                    i += 2;
                }
                if (indexPlayer >= playerList.Count-1)
                    indexPlayer = 0;
                else indexPlayer++;
            }
            Console.WriteLine("Game is finish!!!!!!!!!!!!!!!!!!!!!!!!");
            DisplayWinner();
        }
        public bool FindPare(Card card1, Card card2)
        {
            if (card1.isMach(card2))
            {
                playerList[indexPlayer].listCards.Add(card1);
                playerList[indexPlayer].listCards.Add(card2);
                playerList[indexPlayer].numPoints ++;
                return true;
            }
            return false;

        }
        public void DisplayWinner()
        {
            int max = 0, index = 0 ;
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].numPoints>max)
                {
                    max = playerList[i].numPoints;
                    index = i;
                }
            }
            
            Console.WriteLine("The winner: "+ playerList[index].namePlayer);
            Console.WriteLine("Your score is: "+max);
            Console.WriteLine("Your cards:");
            foreach (var item in playerList[index].listCards)
            {
                item.ToDrow();
            }
        }



    }
}
