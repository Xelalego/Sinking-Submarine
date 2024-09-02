using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string newGameLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNewGameLevel()
    {
        // Set everything back to moving.
        Time.timeScale = 1f;

        SceneManager.LoadScene(newGameLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
