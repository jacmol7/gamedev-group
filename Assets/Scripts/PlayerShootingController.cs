using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    
    private Vector2 aimDirection;
    private GameObject bulletPool;

    void Start()
    {
        bulletPool = GameObject.Find("PlayerBullets");
        if (!bulletPool)
        {
            bulletPool = new GameObject("PlayerBullets");
        }
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject p = Instantiate(projectile, transform.position, transform.rotation, bulletPool.transform);
            p.transform.eulerAngles = new Vector3(0, 0, angle);
            p.GetComponent<Rigidbody2D>().velocity = p.transform.right * projectileSpeed;
        }
    }
}
