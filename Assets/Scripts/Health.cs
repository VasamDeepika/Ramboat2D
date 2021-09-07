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
   
    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    private void Awake()
    {
        instance = this;
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
        gameObject.SetActive(false);
    }
}