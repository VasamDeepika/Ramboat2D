using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; // point where ray is coming from
    public Transform firePoint2; // rotated empty game object for bullet animation

    public GameObject enemyDeathEffect;
    public GameObject enemyDeathEffect2;
    public GameObject bulletPrefab;
    public GameObject coinPrefab;

    int damage = 1;
    public int stars = 0;
    public int diedEnemies = 0;
    public int reqDiedEnemies;
    
    public static PlayerShooting instance;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Health.instance.isGameOver == false && Conversation.instance.isDialogueOver == true)//player can't shoot after death
        {
            Shoot();
        }
    }
    void Shoot()
    {
        /*Player shoot in upward direction
         * if player hits enemies, destroy enemy, 
         * instantiate a coin prefab, shoot audio, enemy death effect
         */
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        FindObjectOfType<AudioManager>().PlayAudio("Shoot");
        bulletPrefab.gameObject.SetActive(true);
        if(hit)
        {
            var health = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                if (health.gameObject.tag == "Enemy")
                {
                    health.TakeDamage(damage);
                    Instantiate(enemyDeathEffect, hit.point + new Vector2(0, 1), Quaternion.identity);
                    
                    diedEnemies++;
                    if(diedEnemies==reqDiedEnemies && SceneManager.GetActiveScene().buildIndex == 3) 
                    {
                        stars++;
                    }
                    Instantiate(coinPrefab, hit.point, Quaternion.identity);
                }
                //player can shoot helicopter only if he kills all the normal enemies that comes before
                else if(health.gameObject.tag == "Helicopter")
                {
                    if(KillAllEnemies.instance.isAllEnemiesKilled == true)
                    {
                        health.TakeDamage(damage);
                        Instantiate(enemyDeathEffect, hit.point + new Vector2(0, 1), Quaternion.identity);
                        Instantiate(enemyDeathEffect2, hit.point + new Vector2(0, 1), Quaternion.identity);
                    }
                }
            }
        } 
    }
}