using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerOneScore", 0);
        PlayerPrefs.SetInt("PlayerTwoScore", 0);
        SceneManager.LoadScene("TBD"); 
        //LoadScene
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
        //Universal exit command.
    }
}
