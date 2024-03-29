﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public int damage;

    public KeyCode shoot; 

    public LineRenderer lineRenderer;

    public AudioClip shootSound;

    private AudioSource source;

    public float volLowRange;

    public float volHighRange;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shoot) && !PauseMenu.gameIsPaused)
        {
            StartCoroutine(Shoot());
            float vol = Random.Range(volLowRange, volHighRange); //Randomizes the shootSound volume slightly to sound less same-y
            source.PlayOneShot(shootSound, vol);
        }
    }

    IEnumerator Shoot()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            PlayerController player = hitInfo.transform.GetComponent<PlayerController>();
            if(player != null)
            {
                player.TakeDamage(damage);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f); //Waits for 20ms before can shoot again.

        lineRenderer.enabled = false;
    }
}
