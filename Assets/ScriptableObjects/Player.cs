using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/PlayerData", order = 2)]
public class Player : ScriptableObject
{
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public float damage = 15.0f;
    public float regeneration = 2.0f;
    public Item[] items = new Item[12];
    public Bosses currentBoss;
    public bool[] defeatedBosses = new bool[5];
    public GameObject hitMusic;
    public GameObject music;

    public void HealPlayer(float heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        
    }
}
