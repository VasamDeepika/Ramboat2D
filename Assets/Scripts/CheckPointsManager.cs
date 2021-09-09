using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    public GameObject[] checkPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManager.instance.coinCount == 5)
        {
            checkPoints[1].SetActive(true);
        }
        if(PlayerShooting.instance.diedEnemies == 20)
        {
            checkPoints[0].SetActive(true);
        }
    }
}
