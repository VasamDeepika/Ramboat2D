using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    int damage = 1;
    public int stars = 0;
    public int diedEnemies = 0;
    public GameObject enemyDeathEffect;
    public GameObject bulletPrefab;
    
    public GameObject coinPrefab;
    public static PlayerShooting instance;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Health.instance.isGameOver == false)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        FindObjectOfType<AudioManager>().PlayAudio("Shoot");
        bulletPrefab.gameObject.SetActive(true);
        if(hit)
        {
            var health = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                
                Instantiate(enemyDeathEffect, hit.point + new Vector2(0, 1), Quaternion.identity);
                if (health.gameObject.tag == "Enemy")
                {
                    Instantiate(coinPrefab, hit.point, Quaternion.identity);
                }
            }
        } 
    }
}