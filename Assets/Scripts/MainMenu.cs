using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject howToScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainScreen();
    }

    public void Play(){
        //load game
        SceneManager.LoadScene("Game");
    }

    public void Quit(){
        //quit game
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void MainScreen(){
        howToScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
    public void HowToScreen(){
        howToScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
}
