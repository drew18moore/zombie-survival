using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject controls;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("QUIT");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        gameObject.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Controls()
    {
        gameObject.SetActive(false);
        controls.SetActive(true);
    }
}
