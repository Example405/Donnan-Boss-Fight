using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorwayScript : MonoBehaviour
{   

    public string sceneName = "";
    public Bosses boss;
    public Player player;

    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            if (sceneName == "BattleWorld") 
                player.currentBoss = boss;
            StartCoroutine(GameObject.Find("UIManager").GetComponent<UIScript>().ChangeScene(sceneName));
            //SceneManager.LoadScene(sceneName);

        }
    }
}
