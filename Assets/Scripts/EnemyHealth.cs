using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startHealth = 5;
    [SerializeField]
    private GameObject playerdeathEffect;
    Animator anim;
    public int currentHealth;
    public bool isGameOver = false;
    public static EnemyHealth instance;

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
        if (gameObject.tag == "Enemy" || gameObject.tag == "Helicopter")
        {
            gameObject.SetActive(false);
        }
    }
}