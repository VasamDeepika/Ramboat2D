using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill20Enemies : MonoBehaviour
{
    public static Kill20Enemies instance;
    private void Awake()
    {
        instance = this;
    }
    public void Kill20enemies()
    {
        if (PlayerShooting.instance.diedEnemies == 20)
        {
            print(PlayerShooting.instance.diedEnemies);
            PlayerShooting.instance.stars++;
        }
    }
}
