using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] starsList;
    private void Start()
    {
        
    }
    private void Update()
    {
        //print(PlayerShooting.instance.stars);
        switch (PlayerShooting.instance.stars)
        {
            case 1:
                starsList[0].SetActive(true);
                break;
            case 2:
                starsList[0].SetActive(true);
                starsList[1].SetActive(true);
                break;
            case 3:
                starsList[0].SetActive(true);
                starsList[1].SetActive(true);
                starsList[2].SetActive(true);
                break;
        }
    } 
}
