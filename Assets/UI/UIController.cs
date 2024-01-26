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
    private bool isGameOver;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;

    public float HoleWarningTime = -Mathf.Infinity;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        // Set new instance if we have no players.
        if (instance == null)
        {
            instance = this;

            // Tell the instance not to destroy itself on a new level/restarted scene.
            // This will carry over our same character and data on loading a scene.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for pause.
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            PauseUnPause();
        }

        Game.Player.HoleWarning.SetActive(Time.time <= HoleWarningTime);
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
        isGameOver = true;

        // Stop time, bring up the UI, and bring back the mouse.
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        // If user clicks Restart, then we want to remove
        // the Game Over screen and remove the mouse.
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGameOver = false;

        // Destroy this current UI instance.
        instance = null;
        Destroy(gameObject);

        // Restart the scene.
        SceneManager.LoadScene(gameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
