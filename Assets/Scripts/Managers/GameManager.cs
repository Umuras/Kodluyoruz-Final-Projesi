using System;
using Game.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private IState currentState;
        private InputManager inputManager;
        private int currentLevelIndex = 0;
        private int highScore = 0;

        private void Start()
        {
            inputManager = InputManager.Instance;
            ReadHighScore();

        }

        #region STATE MACHINE
        public void SetState(IState nextState)
        {
            if (currentState == nextState) return;
            if (currentState != null) currentState.Exit();

            currentState = nextState;
            nextState.Enter();
        }

        internal IState GetCurrentState()
        {
            return currentState;
        }

        #endregion

        #region LEVEL LOADING FUNCTIONS

        internal int GetCurrentScene()
        {
            return currentLevelIndex;
        }

        internal void LoadNextLevel()
        {
            currentLevelIndex++;
            if (currentLevelIndex <= SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(currentLevelIndex);
        }

        internal void RestartLevel()
        {
            SceneManager.LoadScene(currentLevelIndex);
        }

        #endregion

        #region READ-WRITE HIGHSCORE

        internal void SaveNewHighScore(int playerScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }

        private void ReadHighScore()
        {
            if (PlayerPrefs.HasKey("highScore"))
                highScore = PlayerPrefs.GetInt("highScore");
            else
                highScore = 0;
        }

        internal int GetHighScore()
        {
            return highScore;
        }
        #endregion

    }
}
