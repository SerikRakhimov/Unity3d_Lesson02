using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameVictoryPanel gameVictoryPanel;
    [SerializeField]
    private GameOverPanel gameOverPanel;


    // Start is called before the first frame update
    //private void Start()
    //{

    //}

    public void WinGame()
    {

    }

    public void GameVictory(int score)
    {
        gameVictoryPanel.SetPanelActive(true);
        gameVictoryPanel.SetScoreText(score);
    }
    public void GameOver(int score)
    {
        gameOverPanel.SetPanelActive(true);
        gameOverPanel.SetScoreText(score);
    }

}
