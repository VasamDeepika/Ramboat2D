using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    // Movement speed
    [SerializeField]
    private float speed = 5;
    private float time;
    [SerializeField]
    private float timer;
    [SerializeField]
    private GameObject bombPrefab;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        rb.velocity = Vector2.left * speed;//towards left always
        if(time>=timer)
        {
            Instantiate(bombPrefab, transform.position+ new Vector3(-1, 0, 0), Quaternion.identity);
            time = 0;
        }
    }
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
    
}
