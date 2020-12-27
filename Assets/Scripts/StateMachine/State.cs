using System;
using UnityEngine;

namespace Game.StateMachine
{
    [System.Serializable]
    public class State
    {
        public StateType stateType;
        public MonoBehaviour stateScript;
    }

    public delegate void Callback();
}