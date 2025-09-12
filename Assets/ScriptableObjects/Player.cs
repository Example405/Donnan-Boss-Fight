using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/PlayerData", order = 2)]
public class Player : ScriptableObject
{
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public float damage = 5.0f;
    public Item[] items = new Item[12];
}
