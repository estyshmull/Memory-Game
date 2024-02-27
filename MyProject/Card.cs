using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public enum State { Covered, Uncoverd, HasTaken }
   
    internal abstract class Card
    {
        public bool isOpen { get; set; }
        public int numCard { get; set; }
        public State Position { get; set; }
        public virtual bool Equals(Card other)
        {
            return this==other;
        }
        public virtual bool isMach(Card card)
        {
            return this.Equals(card);
        }
        public virtual void ToDrow ()
        { 

        }
        public abstract Card Copy();

        public void Print()
        {
            if (this.Position == State.Covered)
                System.Console.Write(" * ");
            else if (this.Position == State.HasTaken)
                System.Console.Write(" ! ");
            else
                this.ToDrow();
        }
      
    }
}
