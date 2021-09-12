using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    // Movement speed
    [SerializeField]
    private float speed = 5;
    bool hitGround = false;
    Rigidbody2D rb;
    int damage=1;
    public static BombMovement instance;
    public GameObject bombFailEffect;
    public bool isGameOver = false;
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
            hitGround = true;
            Instantiate(bombFailEffect, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayAudio("FailExplosion");
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(bombFailEffect, transform.position + new Vector3(0,-1,0), Quaternion.identity);
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
            }
        }
        if (collision.gameObject.tag == "LeftBorder")
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}