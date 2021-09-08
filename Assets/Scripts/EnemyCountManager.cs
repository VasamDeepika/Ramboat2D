using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountManager : MonoBehaviour
{
    public Text enemyCountText;
    public Text coinCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCountText.text = PlayerShooting.instance.diedEnemies.ToString();
        enemyCountText.text = CoinMovement.instance.coinCount.ToString();
    }
}
