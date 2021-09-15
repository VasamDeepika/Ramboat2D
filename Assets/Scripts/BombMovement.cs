using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    // Movement speed
    [SerializeField]
    int damage=1;
    public static BombMovement instance;
    [SerializeField]
    private GameObject bombFailEffect;
    [SerializeField]
    private GameObject bombFailEffect1;
    public bool isGameOver = false;
    Rigidbody2D rb;
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

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(bombFailEffect, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayAudio("FailExplosion");
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(bombFailEffect1, transform.position + new Vector3(0,-1,0), Quaternion.identity);
            FindObjectOfType<AudioManager>().PlayAudio("FailExplosion");
            Destroy(gameObject);

            var health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            if(health.currentHealth<=0)
            {
                Health.instance.isGameOver = true;
                TotalCoins.instance.SetData();
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
