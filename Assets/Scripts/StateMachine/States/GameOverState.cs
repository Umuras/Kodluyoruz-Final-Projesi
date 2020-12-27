using System;
using Game.Managers;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class GameOverState : MonoBehaviour, IState
    {
        private void OnEnable()
        {
            GameManager.Instance.SetState(this);
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
