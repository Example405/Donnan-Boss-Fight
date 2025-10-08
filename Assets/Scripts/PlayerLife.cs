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
    public Sprite damagePng;
    public Sprite regularPng;
    public Transform camera;


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
            StartCoroutine(playMusic(pd.hitMusic));
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

    public IEnumerator playMusic(GameObject thing) {
        GameObject thingy = Instantiate(thing);
        float time = 0.0f;
        while (true) {
            time += Time.deltaTime;
            if (time - Mathf.Round(time) <= 0.33f) 
                GetComponent<SpriteRenderer>().sprite = damagePng;
            else
                GetComponent<SpriteRenderer>().sprite = regularPng;

            if (time <= 0.25f) {
                camera.position = new Vector3 (Mathf.Lerp(0.0f, 0.1f, time*4), camera.position.y, camera.position.z);
            }
            else if (time <= 0.5f) {
                camera.position = new Vector3 (Mathf.Lerp(0.1f, -0.1f, (time - 0.25f)*4), camera.position.y, camera.position.z);
            }
            else
                camera.position = new Vector3 (Mathf.Lerp(-0.1f, 0.0f, (time - 0.5f)*4), camera.position.y, camera.position.z);


            if (time >= damageCooldown) {
                GetComponent<SpriteRenderer>().sprite = regularPng;
                camera.position = new Vector3(0.0f, camera.position.y, camera.position.z);
                break;
            }
            yield return null;
        }

        
    }

}
