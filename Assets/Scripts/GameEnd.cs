using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    float timer=0;
    public GameObject flag;
    public static GameEnd instance;
    Animator anim;
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
        timer = timer + Time.deltaTime;
        if(timer>200.0f)
        {
            flag.gameObject.SetActive(true);
        }
    }
    
}
