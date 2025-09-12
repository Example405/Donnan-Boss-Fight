using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   

    public float speed = 4.0f;
    private Rigidbody2D rb;
    float horizontal = 0.0f;
    float vertical = 0.0f;
    bool canMove = true;

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {   

        //Method 1:
        /*
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {

            horizontal = Input.GetAxis("Horizontal") * speed;
            vertical = Input.GetAxis("Vertical") * speed;

            rb.velocity = new Vector2(horizontal, vertical);
            Debug.Log(horizontal + " " + vertical);
        }
        else
            rb.velocity = new Vector2(0.0f, 0.0f);
        */

        //Method 2
        if (canMove) {
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
}
