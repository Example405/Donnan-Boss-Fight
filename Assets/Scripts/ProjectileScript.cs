using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //your back






    //what did i do...






    //:D

    public bool destroyOnHit = false;
    public float damage = 10.0f;
    private float difficulty = 1.0f;
    private float multiplier = 1.0f;

    public void SetDifficulty(float diff) {
        difficulty = diff;
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            coll.gameObject.transform.GetComponent<PlayerLife>().DamagePlayer(damage * difficulty * multiplier);
        }

        if (destroyOnHit)
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            coll.gameObject.transform.GetComponent<PlayerLife>().DamagePlayer(damage * difficulty * multiplier);
        }

        if (destroyOnHit)
            Destroy(gameObject);
    }
}
