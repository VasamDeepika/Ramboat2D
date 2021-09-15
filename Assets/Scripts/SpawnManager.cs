using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float time;
    private float heliTimer;
    private float timerRun;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.gameSuccess == false && GameEnd.instance.flagCame == false
            && Conversation.instance.isDialogueOver == true && PlayerMovement.instance.isPlayerMoving == true)
        {
            if (Health.instance.isGameOver == false)
            {
                time += Time.deltaTime;
                heliTimer += Time.deltaTime;
                timerRun += Time.deltaTime;

                if (Random.Range(0, 100) < 5)
                {
                    GameObject en = Pool.instance.Get("Enemy");
                    if (en != null)
                    {
                        en.transform.position = new Vector3(8, Random.Range(1.2f, 4f), 0);
                        if (time > 1f) // 1 second of time gap between each enemy
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