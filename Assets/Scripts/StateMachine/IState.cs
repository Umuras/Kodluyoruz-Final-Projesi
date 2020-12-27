using System;
namespace Game.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
