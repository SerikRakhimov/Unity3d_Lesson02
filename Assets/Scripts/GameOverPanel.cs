using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;

    [SerializeField]
    private Text yourScoreText, bestScoreText;

    [SerializeField]
    private Button restartBtn, exitBtn;
    // Start is called before the first frame update
    
    private void Start()
    {
        // отключаем панель на старте игры
        root.gameObject.SetActive(false);
        // назначаем обработчики нажатий кнопок
        restartBtn.onClick.AddListener(OnRestartClick);
        exitBtn.onClick.AddListener(OnExitClick);
    }

    public void SetPanelActive(bool state)
    {
        root.gameObject.SetActive(state);
    }

    public void SetScoreText(int yourScore)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        /*
         написать код для обновления лучшего результата персонажа
         если набрал меньше, то вывести значение, которое уже хранится в реестре
         Если больше, вывести его на экран и обновить хранилище
         */
        
        if (yourScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", yourScore);
            bestScore = yourScore;
        }

        yourScoreText.text = "Your Score: " + yourScore; 
        bestScoreText.text = "Best Score: " + bestScore;

    }

    private void OnRestartClick()
    {
        Debug.Log("Restart click.");
    }

    private void OnExitClick()
    {
        Debug.Log("Exit click.");
    }
    private void OnDestroy()
    {
        restartBtn.onClick.RemoveAllListeners();
        exitBtn.onClick.RemoveAllListeners();
    }
}
