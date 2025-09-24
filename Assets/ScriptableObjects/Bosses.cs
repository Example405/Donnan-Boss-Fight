using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bosses", menuName = "ScriptableObjects/Boss", order = 1)]
public class Bosses : ScriptableObject
{
    //blah blah blah just add
    //ebverything bro bro

    public GameObject[] attackPrefabs = new GameObject[3];
    public float[] attackTimes = new float[3];
    public float[] attackEndTimes = new float[3];
    //add animations or sometihng
    GameObject[] enemyParts = new GameObject[1];
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public string targetScene = "WorldWorld";
    //Add strings for dialogue
    //Add uhhhhhhhhhhh

    public bool DamageBoss(float damage)
    {
        health -= damage;
        if (health <= 0)
            return true;
        return false;
    }
}
