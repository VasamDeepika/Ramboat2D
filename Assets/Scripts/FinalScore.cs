using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalScore : MonoBehaviour
{
    [SerializeField]
    private Text coinText;
    [SerializeField]
    private Text allCoinsText;
    // Start is called before the first frame update
    void Start()
    {
        allCoinsText.text = TotalCoins.instance.allCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = UIManager.instance.coinCount.ToString();
        allCoinsText.text = TotalCoins.instance.allCoins.ToString();
    }
}
