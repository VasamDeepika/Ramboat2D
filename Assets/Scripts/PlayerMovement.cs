using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpVelocity;
    [SerializeField]
    private GameObject levelDialogBox; // GameEnd panel
    [SerializeField]
    private float moveSpeed; // player movement speed

    private bool grounded = true;
    public bool gameSuccess = false; // if player reaches destination
    Animator anim;
    Rigidbody2D playerRB;
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameSuccess == false && Health.instance.isGameOver == false && Conversation.instance.isDialogueOver == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (grounded == true)
                {
                    playerRB.velocity = new Vector2(moveSpeed, 0);
                    anim.SetTrigger("Run");
                }
            }
            /*else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (grounded)
                {
                    print(grounded);
                    Jump();
                }
            }*/
            else            {
                // if no key is pressed player moves
                // backward with 1/4 of movement speed
                playerRB.velocity = new Vector2(-(moveSpeed / 4), 0);
            }
        }
    }   
    private void Jump()
    {
        grounded = false;
        playerRB.velocity = new Vector2(0, jumpVelocity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            gameSuccess = true;
            
            if (SceneManager.GetActiveScene().buildIndex == 3) // level 1
            {
                PlayerShooting.instance.stars++;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4) // level 2
            {
                PlayerShooting.instance.stars = 2;
                PlayerShooting.instance.stars++;
                if (KillAllEnemies.instance.isAllEnemiesKilled == false) // if any enemy escapes one star decremented
                {
                    PlayerShooting.instance.stars--;
                }
                if (Health.instance.currentHealth <3) // if player gets hit by enemy star decremented
                {
                    PlayerShooting.instance.stars--;
                }
            }
            anim.SetTrigger("Win"); // when player reaches flag(destination) win animation plays
            levelDialogBox.SetActive(true); // end screen panel
        }
    }
}