using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public int damage;

    public KeyCode shoot;                   //TODO: Use "keycode shoot" to make players shoot projectiles

    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shoot))
        {
            StartCoroutine(Shoot());
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

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}
