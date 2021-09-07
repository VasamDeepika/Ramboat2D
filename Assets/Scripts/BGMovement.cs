using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    Material bgMat;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        bgMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (PlayerMovement.instance.gameSuccess == false)
        {
            bgMat.mainTextureOffset = new Vector2(xOffset * Time.time, 0);
        }
    }
}
