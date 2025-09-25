using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool shouldAppear = true;
    public Player pd;
    public int bossNum;

    public void Start() {
        if (pd.defeatedBosses[bossNum] == true)
            shouldAppear = false;

        if (shouldAppear == false) {
            Destroy(gameObject);
        }
    }
}
