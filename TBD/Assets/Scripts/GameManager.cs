using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {get{ return Instance1; }}

    public static GameManager Instance1 { get => instance; set => instance = value; }

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;

    private void Awake()
    {
        Instance1 = this;

        playerOneScore = PlayerPrefs.GetInt("PlayerOneScore");
        playerTwoScore = PlayerPrefs.GetInt("PlayerTwoScore");

        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("PlayerOneScore", playerOneScore);
        PlayerPrefs.SetInt("PlayerTwoScore", playerTwoScore);
    }

    public void EndOfRound()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Restart scene
    }
}
