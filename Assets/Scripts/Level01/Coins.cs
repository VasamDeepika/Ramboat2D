using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static Coins instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CoinCount()
    {
        if (UIManager.instance.coinCount == 5)
        {
            PlayerShooting.instance.stars++;
        }
    }
}
