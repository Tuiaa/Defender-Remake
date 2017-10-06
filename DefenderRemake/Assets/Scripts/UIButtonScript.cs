using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *      UI BUTTONS
 *      - All UI buttons
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
