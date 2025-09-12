using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorwayScript : MonoBehaviour
{   

    public string sceneName = "";

    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            SceneManager.LoadScene(sceneName);
        }
    }
}
