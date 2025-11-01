using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject deathMenu;
    public GameObject invMenu;
    bool paused = false;
    bool pausable = true;



    //execution
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
        if(Input.GetKeyDown(KeyCode.R) && pausable) {
            if(paused){
                Resume();
            } else {
                Inventory();
            }
        }
    }

    //menus on/off
    public void ReturnToMenu(){
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart(){
        SetPaused(false);
        pausable = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume(){
        SetPaused(false);
        pausable = true;
        DeactivateAllMenus();
    }
    public void Death(){
        SetPaused(true);
        pausable = false; //avoid unpausing death!!
        DeactivateAllMenus();
        deathMenu.SetActive(true);
    }
    public void Pause(){
        SetPaused(true);
        pausable = true;
        DeactivateAllMenus();
        pauseMenu.SetActive(true);
    }
    public void Inventory(){
        SetPaused(true);
        pausable = true;
        DeactivateAllMenus();
        invMenu.SetActive(true);
    }

    //common operations
    void DeactivateAllMenus(){
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
        invMenu.SetActive(false);
    }
    void SetPaused(bool value){
        if(value){
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            paused = true;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            paused = false;
        }
    }
}
