using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]  // позволяет 
    private Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(StartGame);
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void OnDestroy()
    {
        startBtn.onClick.RemoveAllListeners();
    }
}
