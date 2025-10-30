using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject DeathMenu;
    public GameObject InvMenu;
    bool paused = false;
    bool pausable = true;
    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Resume();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && pausable) {
            if(paused){
                Resume();
            } else {
                Pause();
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && pausable) {
            if(paused){
                Resume();
            } else {
                Inv();
            }
        }
    }

    // menus on/off
    public void ReturnToMenu(){
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    public void Pause(){
        Cursor.lockState = CursorLockMode.None;
        DeactivateMenus();
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        pausable = true;
    }
    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        DeactivateMenus();
        Time.timeScale = 1f;
        paused = false;
        pausable = true;
    }
    public void Death(){
        Cursor.lockState = CursorLockMode.None;
        DeactivateMenus();
        DeathMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        pausable = false;
    }
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Inv(){
        Cursor.lockState = CursorLockMode.None;
        DeactivateMenus();
        InvMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        pausable = true;
    }
    void DeactivateMenus(){
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(false);
        InvMenu.SetActive(false);
    }
}
