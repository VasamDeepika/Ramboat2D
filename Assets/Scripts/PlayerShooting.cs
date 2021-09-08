using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    int damage = 40;
    public GameObject enemyDeathEffect;
    public GameObject bulletPrefab;
    public int diedEnemies=0;
    public static PlayerShooting instance;
    public GameObject coinPrefab;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        bulletPrefab.gameObject.SetActive(true);
        if(hit)
        {
            var health = hit.collider.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                diedEnemies++;
            }
            Instantiate(enemyDeathEffect, hit.point + new Vector2(0,1), Quaternion.identity);
            Instantiate(coinPrefab, hit.point, Quaternion.identity);
        } 
    }
}
