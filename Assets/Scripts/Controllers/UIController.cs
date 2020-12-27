using Game.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controllers
{
    public class UIController : MonoBehaviour
    {
        public GameObject gameOverPanel;

        private Button nextLevelButton;
        private Button restartButton;
        private Button exitButton;
        private Text highScoreText;
        private Text gameOverText;
        private GameObject winImages;

        private  void Start()
        {
            nextLevelButton = gameOverPanel.transform.GetChild(0).GetComponent<Button>();
            nextLevelButton.onClick.AddListener(() => OnNextLevelButtonClicked());

            restartButton = gameOverPanel.transform.GetChild(1).GetComponent<Button>();
            restartButton.onClick.AddListener(() => OnRestartButtonClicked());

            exitButton = gameOverPanel.transform.GetChild(2).GetComponent<Button>();
            exitButton.onClick.AddListener(() => OnExitButtonClicked());

            highScoreText = gameOverPanel.transform.GetChild(3).GetComponent<Text>();
            gameOverText = gameOverPanel.transform.GetChild(4).GetComponent<Text>();

            winImages = gameOverPanel.transform.GetChild(5).gameObject;

            gameOverPanel.SetActive(false);
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
        }

        private void OnRestartButtonClicked()
        {
            GameManager.Instance.RestartLevel();
        }

        private void OnNextLevelButtonClicked()
        {
            GameManager.Instance.LoadNextLevel();
        }

        public void ShowGameOverPanel(bool isWin, int score, int highscore)
        {
            highScoreText.text = "SCORE: " + score.ToString() + "\n\nHIGH SCORE: " + highscore.ToString();
            if(!isWin)
            {
                gameOverText.text = "GAME OVER\n\nFAIL!";
            }
            else
            {
                gameOverText.text = "GAME OVER\n\nWIN!";
            }

            nextLevelButton.gameObject.SetActive(isWin);
            winImages.SetActive(isWin);
            restartButton.gameObject.SetActive(!isWin);

            gameOverPanel.gameObject.SetActive(true);
        }
    }
}

