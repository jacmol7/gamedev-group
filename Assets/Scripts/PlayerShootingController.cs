using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate;

    public AudioClip shootSound;
    
    private Vector2 aimDirection;
    private GameObject bulletPool;
    private bool canShoot;

    void Start()
    {
        bulletPool = GameObject.Find("PlayerBullets");
        if (!bulletPool)
        {
            bulletPool = new GameObject("PlayerBullets");
        }

        canShoot = true;
    }

    void Update()
    {
        // Disable shooting if the game is paused for any reason;
        if (Time.timeScale == 0f)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("shoot");
        }
    }

    private IEnumerator shoot()
    {
        if (canShoot)
        {
            canShoot = false;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            aimDirection = (mousePos - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            
            GameObject p = Instantiate(projectile, transform.position, transform.rotation, bulletPool.transform);
            p.transform.eulerAngles = new Vector3(0, 0, angle);
            p.GetComponent<Rigidbody2D>().velocity = p.transform.right * projectileSpeed;

            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
    }
}
