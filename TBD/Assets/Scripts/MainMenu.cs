using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(""); 
        /*LoadScene("tähän tulee itse peli scene nimi tai numero build managerissä") 
        mutta koska meillä on vielä tbd nimi ja ei olla buildattu niin jätän tyhjäksi.*/
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
        //Universaali exit käsky
    }
}
