using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] checkPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (UIManager.instance.coinCount == 5)
            {
                checkPoints[1].SetActive(true);
            }
            if (PlayerShooting.instance.diedEnemies == PlayerShooting.instance.reqDiedEnemies)
            {
                checkPoints[0].SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (KillAllEnemies.instance.isAllEnemiesKilled == false)
            {
                checkPoints[2].SetActive(true);
            }
            if (Health.instance.currentHealth < 3)
            {
                checkPoints[3].SetActive(true);
            }
        }
    }
}
