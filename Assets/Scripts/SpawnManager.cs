using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float time;
    private float heliTimer;
    private float timerRun;
    [SerializeField]
    private float difficultyTimer;

    // Update is called once per frame
    void Update()
    {
        difficultyTimer = PlayerPrefsManager.GetDifficulty();
        print(difficultyTimer);
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
                        if (time > difficultyTimer) // spawnrate based on difficulty slider value
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