using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    
    public float speed = 4.0f;
    private Rigidbody2D rb;
    public Animator anim;
    float horizontal = 0.0f;
    float vertical = 0.0f;
    int lookingState = 4;
    bool alreadyLooking = false;

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            horizontal -= 1.0f * speed;
            if (!alreadyLooking) {
                lookingState = 1;
                alreadyLooking = true;
            }
        }
        if (Input.GetKey(KeyCode.D)) {
            horizontal += 1.0f * speed;
            if (!alreadyLooking) {
                lookingState = 2;
                alreadyLooking = true;
            }
        }
        if (Input.GetKey(KeyCode.W)) {
            vertical += 1.0f * speed;
            if (!alreadyLooking) {
                lookingState = 3;
                alreadyLooking = true;
            }
        }
        if (Input.GetKey(KeyCode.S)) {
            vertical -= 1.0f * speed;
            if (!alreadyLooking) {
                lookingState = 4;
                alreadyLooking = true;
            }
        }

        if (horizontal != 0 || vertical != 0)
            rb.velocity = new Vector2(horizontal, vertical);
        else {
            rb.velocity = new Vector2(0.0f, 0.0f);
            if (lookingState <= 4)
                if (!alreadyLooking) {
                    lookingState += 4;
                    alreadyLooking = true;
                }

        }
        horizontal = 0.0f;
        vertical = 0.0f;
        alreadyLooking = false;
        anim.SetInteger("WalkingState", lookingState);
    }
}
