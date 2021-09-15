using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinMovement : MonoBehaviour
{
    // Movement speed
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private GameObject coinEffect;
    [SerializeField]
    private GameObject coinEffect2;
    public int reqCoins;
    bool hitGround = false;
    Rigidbody2D rb;
    public static CoinMovement instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * speed;
        if(hitGround == true)
        {
            rb.velocity = Vector2.left * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(coinEffect2, transform.position, Quaternion.identity);
            hitGround = true;
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(coinEffect, transform.position, Quaternion.identity);
            UIManager.instance.coinCount++;
            TotalCoins.instance.allCoins += 1;
            if(UIManager.instance.coinCount==reqCoins)
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PlayerShooting.instance.stars++;
                }
            }
            FindObjectOfType<AudioManager>().PlayAudio("CoinCollision");
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "LeftBorder")
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
