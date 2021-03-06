using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    float timer=0;
    [SerializeField]
    private GameObject flag;
    public static GameEnd instance;
    Animator anim;
    public bool flagCame = false;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Conversation.instance.isDialogueOver == true)
        {
            timer = timer + Time.deltaTime;
            if (timer > 30.0f && Health.instance.isGameOver == false)
            {
                flag.gameObject.SetActive(true);
                flagCame = true;
                TotalCoins.instance.SetData();
            }
        }
    }
}
