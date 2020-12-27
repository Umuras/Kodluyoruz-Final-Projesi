using System;
using Game.Controllers;
using Game.Controllers.Character;
using Game.Managers;
using TMPro;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class LevelState : MonoBehaviour, IState
    {
        public PlayerController player;
        public  GameObject tapAnimation;

        private GameManager gameManager;
        private InputManager inputManager;
        private UIController uiController;
        private bool isLevelStarted;

        private void OnEnable()
        {
            gameManager = GameManager.Instance;
            gameManager.SetState(this);
            isLevelStarted = false;
            uiController = FindObjectOfType<UIController>();
        }

        public void Enter()
        {
            inputManager = InputManager.Instance;
            inputManager.OnTap += OnTap;
            inputManager.OnHold += OnHold;
            inputManager.OnRelease += OnRelease;
        }

        public void Exit()
        {
            inputManager.OnHold -= OnHold;
            inputManager.OnRelease -= OnRelease;
        }


        private void OnTap()
        {
            if(!isLevelStarted)
            {
                inputManager.OnTap -= OnTap;
                isLevelStarted = true;
                tapAnimation.SetActive(false);
            }
        }


        private void OnHold()
        {
            if(isLevelStarted)
                player.IsMoving(true);
        }

        private void OnRelease()
        {
            if(isLevelStarted)
                player.IsMoving(false);
        }

        internal void GameOver(bool isWin)
        {
            Debug.Log("Game over: win?" + isWin);
            int playerScore = player.GetScore();
            int highScore = gameManager.GetHighScore();
            if (playerScore > highScore)
                gameManager.SaveNewHighScore(playerScore);

            uiController.ShowGameOverPanel(isWin, playerScore, highScore);
            player.gameObject.SetActive(false);
        }
    }
}
