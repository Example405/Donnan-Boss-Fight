using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bosses", menuName = "ScriptableObjects/Boss", order = 1)]
public class Bosses : ScriptableObject
{
    //blah blah blah just add
    //ebverything bro bro

    GameObject[] attackPrefabs = new GameObject[3];
    //add animations or sometihng
    GameObject[] enemyParts = new GameObject[1];
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public string targetScene = "WorldWorld";
    //Add strings for dialogue
    //Add uhhhhhhhhhhh
}
