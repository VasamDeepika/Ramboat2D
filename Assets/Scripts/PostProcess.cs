using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcess : MonoBehaviour
{   [SerializeField]
    private GameObject post;
    // Start is called before the first frame update
    void Start()
    {
        post.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.instance.isGameOver == true)
        {
            post.SetActive(true);
        }
    }
}
