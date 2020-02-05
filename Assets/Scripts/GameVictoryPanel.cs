using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVictoryPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;

    [SerializeField]
    private Text yourScoreText, bestScoreText;

    [SerializeField]
    private Button nextLevelBtn, mainMenuBtn;

    void Start()
    {
        // отключаем панель на старте игры
        root.gameObject.SetActive(false);
        // назначаем обработчики нажатий кнопок
        nextLevelBtn.onClick.AddListener(OnNextLevelClick);
        mainMenuBtn.onClick.AddListener(OnMainMenuClick);
    }

    // Update is called once per frame
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

    private void OnNextLevelClick()
    {
        Debug.Log("Next level click.");
    }

    private void OnMainMenuClick()
    {
        Debug.Log("Main menu click.");
    }
    private void OnDestroy()
    {
        nextLevelBtn.onClick.RemoveAllListeners();
        mainMenuBtn.onClick.RemoveAllListeners();
    }

}
