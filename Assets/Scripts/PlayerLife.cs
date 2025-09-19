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
    public Player pd;
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
            pd.health -= damage;
            StartCoroutine(us.ChangeBar(pd.health/pd.maxHealth, damage/pd.maxHealth));
            if (pd.health <= 0) {
                KillPlayer();
            }
            return true;
        }
        return false;
    }

    private void KillPlayer()
    {
        //add functionality here
        us.HideBattleButtons();
        us.HideHealthBar();
        us.ShowDeathScreen();

        gameObject.SetActive(false);
    }
}
