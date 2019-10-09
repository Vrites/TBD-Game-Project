using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource bgm;

    private void Awake()
    {
        GameObject currentBGM = GameObject.FindGameObjectWithTag("BGM");
        if (currentBGM == null)
        {
            AudioSource spawned = Instantiate(bgm);
            spawned.Play();
            DontDestroyOnLoad(spawned);
        }
    }
}
