using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float time;

    // Update is called once per frame
    void Update()
    {
            time += Time.deltaTime;
        if (Random.Range(0, 100) < 5)
        {
            GameObject en = Pool.instance.Get("Enemy");
            if (en != null)
            {
                en.transform.position = this.transform.position + new Vector3(8, Random.Range(0f, 1f), 0);
                if (time > 2f) // 2 seconds of time gap between each enemy
                {
                    time = 0;
                    en.SetActive(true);
                }
            }
        }
        
    }
    
}