using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameInfo.NewGame();
        SceneManager.LoadScene("1_Overworld");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }
}
