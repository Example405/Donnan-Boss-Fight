using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public float time = 0.0f;


    public void Update() {
        time += Time.deltaTime;
        if (time >= 3.0f) {
            Instantiate(spawn);
            time = 0.0f;
        }
    }
}
