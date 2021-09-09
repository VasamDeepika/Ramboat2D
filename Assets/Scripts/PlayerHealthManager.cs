using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject[] healthSprites;
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>().currentHealth;
        if (playerHealth==2)
        {
            healthSprites[2].gameObject.SetActive(false);
        }
        if (playerHealth == 1)
        {
            healthSprites[1].gameObject.SetActive(false);
        }
        if (playerHealth == 0)
        {
            healthSprites[0].gameObject.SetActive(false);
        }
    }
}
