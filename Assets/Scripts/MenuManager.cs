using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Option()
    {
        menu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void OptionBack()
    {
        menu.SetActive(true);
        optionMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void UnPause()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
}
