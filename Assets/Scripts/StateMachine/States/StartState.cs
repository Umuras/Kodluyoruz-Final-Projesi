using Game.Managers;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class LaunchState : MonoBehaviour, IState
    {
        private void OnEnable()
        {
            GameManager.Instance.SetState(this);
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
