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

    public float maxHealth = 100.0f;
    public float health = 100.0f;
    public float regeneration = 2.0f;
    public float damageCooldown = 0.1f;
    public bool canBeHit = true;
    private float timeSinceHit = 0.0f;
    public UIScript us;


    public void Update() {
        if (!canBeHit) {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit >= damageCooldown) {
                canBeHit = true;
                timeSinceHit = 0.0f;
            }
        }
    }

    public bool DamagePlayer(float damage) {
        if (canBeHit) {
            canBeHit = false;
            health -= damage;
            StartCoroutine(us.ChangeBar(health/maxHealth, damage/maxHealth));
            if (health <= 0) {
                KillPlayer();
            }
            return true;
        }
        return false;
    }

    private void KillPlayer() {
        //add functionality here
        us.HideBattleButtons();
        us.HideHealthBar();
        us.ShowDeathScreen();
        
        gameObject.SetActive(false);
    }
}
