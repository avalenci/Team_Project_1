using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!RollABall.gameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector3.left * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector3.right * speed);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(Vector3.forward * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(Vector3.back * speed);
            }
        }
    }
}
