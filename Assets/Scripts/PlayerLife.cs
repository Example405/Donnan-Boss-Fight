using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //why are you here

    //???????

    //i think

    //y

    //stop





    //ok

    public float health = 100.0f;
    public float regeneration = 2.0f;


    public void DamagePlayer(float damage) {
        health -= damage;
        if (health <= 0) {
            KillPlayer();
        }
    }

    private void KillPlayer() {
        //add functionality here
    }
}
