using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    // Main Menu UI variables
    public string mainMenuScene;
    public string gameScene;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;

    private void Awake()
    {
        // Set new instance if we have no players.
        if (instance == null)
        {
            instance = this;
            // Tell the instance not to destroy itself on a new level/restarted scene.
            // This will carry over our same character and data on loading a scene.
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for pause.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if (!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Game.Player.CameraController.TextPrompt.enabled = false;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            pauseScreen.SetActive(false);
            Game.Player.CameraController.TextPrompt.enabled = true;
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        // Set everything back to moving.
        Time.timeScale = 1f;

        // Destroy all objects on DoNotDestroyOnLoad.
        instance = null;
        Destroy(gameObject);

        SceneManager.LoadScene(mainMenuScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(gameScene);

        // If user clicks Restart, then we want to remove
        // the Game Over screen.
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
