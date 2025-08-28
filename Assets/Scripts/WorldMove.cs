using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    
    public float speed = 4.0f;
    private Rigidbody2D rb;
    float horizontal = 0.0f;
    float vertical = 0.0f;

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            horizontal -= 1.0f * speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            horizontal += 1.0f * speed;
        }
        if (Input.GetKey(KeyCode.W)) {
            vertical += 1.0f * speed;
        }
        if (Input.GetKey(KeyCode.S)) {
            vertical -= 1.0f * speed;
        }

        if (horizontal != 0 || vertical != 0)
            rb.velocity = new Vector2(horizontal, vertical);
        else
            rb.velocity = new Vector2(0.0f, 0.0f);
        horizontal = 0.0f;
        vertical = 0.0f;
    }
}
