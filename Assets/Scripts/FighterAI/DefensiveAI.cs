using System;
using Fighter;

namespace FighterAI
{
    public class DefensiveAI : AI
    {
        public DefensiveAI(FighterBehaviour fighterAI, FighterBehaviour opponent) : base(fighterAI, opponent)
        {
        }

        protected override void Move()
        {
            throw new NotImplementedException();
        }

        protected override void Attack()
        {
            throw new NotImplementedException();
        }

        protected override void Defend()
        {
            throw new NotImplementedException();
        }

        public override void Sim()
        {
            throw new NotImplementedException();
        }
    }
}