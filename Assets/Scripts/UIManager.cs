using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            enemyCountText.text = PlayerShooting.instance.diedEnemies.ToString();
            coinCountText.text = coinCount.ToString();
        }
    }
}
