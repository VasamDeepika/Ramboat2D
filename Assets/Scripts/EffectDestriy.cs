using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestriy : MonoBehaviour
{
    [SerializeField]
    private float time;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > time)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
    }
}
