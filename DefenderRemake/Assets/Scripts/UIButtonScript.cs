using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *      MAIN MENU UI BUTTONS
 *      - UI buttons from main menu
 */
public class UIButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(GameStrings.GAME_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(GameStrings.MAIN_MENU_SCENE);
    }
}
