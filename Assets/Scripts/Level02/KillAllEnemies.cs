using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemies : MonoBehaviour
{
    public static KillAllEnemies instance;
    public bool isAllEnemiesKilled = true;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="LeftBorder")
        {
            print("LeftBorder");
            isAllEnemiesKilled = false;
        }
    }
}
