using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text enemyCountText;
    public Text coinCountText;
    public int coinCount = 0;
    public static UIManager instance;
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
        while (PlayerShooting.instance.diedEnemies <= 20)
        {
            enemyCountText.text = PlayerShooting.instance.diedEnemies.ToString();
        }
        while (coinCount <= 5)
        {
            coinCountText.text = coinCount.ToString();
        }
    }
}
