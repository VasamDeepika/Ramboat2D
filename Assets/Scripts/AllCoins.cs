using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCoins : MonoBehaviour
{
    [SerializeField]
    private Text allCoinsText;
    int coin = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allCoinsText.text = TotalCoins.instance.allCoins.ToString();
    }
}
