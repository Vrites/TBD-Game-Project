using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour //This class restarts the current scene.
{
    private Scene scene;
    public bool isTriggered = false;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene.name);
            isTriggered = true;
        } else
        {

        }
    }
}
