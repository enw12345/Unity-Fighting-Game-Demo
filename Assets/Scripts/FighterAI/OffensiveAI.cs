﻿using Fighter;
using UnityEngine;

namespace FighterAI
{
    public class OffensiveAI : AI
    {
        public OffensiveAI(FighterBehaviour fighterAI, FighterBehaviour opponent) : base(fighterAI, opponent)
        {
            _stateMachine.ChangeState(AIStateMachine.States.Offensive);
        }

        protected override void Move()
        {
            switch (_stateMachine.CurrentState)
            {
                case AIStateMachine.States.Offensive when _distanceFromOpponent > maxDistanceFromOpponent:
                    _fighterAI.MoveLeft(0);
                    break;
                case AIStateMachine.States.Defensive when _distanceFromOpponent > maxDistanceFromOpponent:
                    _fighterAI.MoveRight(1);
                    break;
                default:
                    _fighterAI.Idle();
                    break;
            }
        }

        protected override void Attack()
        {
            var randomAttack = Random.Range(0, 2);
            if (timeSinceLastAttack >= attackWaitTime)
            {
                if (randomAttack == 1)
                    _fighterAI.Kick();
                else
                    _fighterAI.Punch();

                timeSinceLastAttack = 0;
            }
        }

        protected override void Defend()
        {
        }

        public override void Sim()
        {
            
            _distanceFromOpponent = Vector3.Distance(_fighterAI.transform.position, _opponent.transform.position);
            Move();

            if (_stateMachine.CurrentState == AIStateMachine.States.Offensive)
            {
                if (damageTakenSinceLastInterval > defensiveDamageThreshold )
                {
                    _stateMachine.ChangeState(AIStateMachine.States.Defensive);
                    damageTakenSinceLastInterval = 0;
                }
            
                if (_distanceFromOpponent <= maxDistanceFromOpponent)
                {
                    Attack();
                
                    timeSinceLastAttack += Time.deltaTime;
                }
            }
            
            else if (_stateMachine.CurrentState == AIStateMachine.States.Defensive)
            {
                timeInDefense += Time.deltaTime;
                if(timeInDefense < defenseTime)
                    Defend();
                else
                {
                    _stateMachine.ChangeState(AIStateMachine.States.Offensive);
                    timeInDefense = 0;
                }
            }

        }
        
    }
}