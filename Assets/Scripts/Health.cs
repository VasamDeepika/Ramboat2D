using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    int startHealth = 5;
    [SerializeField]
    int currentHealth;
    public static Health instance;
    Animator anim;
    public bool isGameOver = false;
   
    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if(gameObject.tag == "Player")
        {
            anim.SetTrigger("Dead");
            isGameOver = true;
        }
        if(gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}