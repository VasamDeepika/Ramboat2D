using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float time;
    private float heliTimer;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.gameSuccess == false && GameEnd.instance.flagCame == false)
        {
            if (Health.instance.isGameOver == false)
            {
                time += Time.deltaTime;
                heliTimer += Time.deltaTime;

                if (Random.Range(0, 100) < 5)
                {
                    GameObject en = Pool.instance.Get("Enemy");
                    if (en != null)
                    {
                        en.transform.position = new Vector3(8, Random.Range(1.2f, 4f), 0);
                        if (time > 1f) // 2 seconds of time gap between each enemy
                        {
                            time = 0;
                            en.SetActive(true);
                        }
                    }
                    GameObject helicoptor = Pool.instance.Get("Helicopter");
                    if (helicoptor != null)
                    {
                        helicoptor.transform.position = this.transform.position;
                        if (heliTimer > 5f)
                        {
                            heliTimer = 0;
                            helicoptor.SetActive(true);
                        }
                    }
                }
            }
        }
    }
    
}