using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    [SerializeField]
    private float jumpVelocity;
    private bool grounded = true;
    [SerializeField]
    private float moveSpeed;
    public static PlayerMovement instance;
    private bool rightPressed = false;

    public bool gameSuccess = false;
    Animator anim;
    public GameObject levelDialogBox;
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
        /*if (Input.GetKey(KeyCode.UpArrow))
            {
                if (grounded)
                {
                    Jump();
                }
            }*/
        
        if (gameSuccess == false && Health.instance.isGameOver == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (grounded == true)
                {
                    rightPressed = true;
                    playerRB.velocity = new Vector2(moveSpeed, 0);
                }
            }
            else
            {
                rightPressed = false;
                playerRB.velocity = new Vector2(-(moveSpeed / 4), 0);
            }
        }
    }   
    private void Jump()
    {
        grounded = false;
        playerRB.velocity = new Vector2(0, jumpVelocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            gameSuccess = true;
            PlayerShooting.instance.stars++;
            anim.SetTrigger("Win");
            levelDialogBox.SetActive(true);
        }
    }
}