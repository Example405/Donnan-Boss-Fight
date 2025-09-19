using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 3)]
public class Item : ScriptableObject
{
    public string name = "Empty";
    public float healAmt = 0.0f;
    public float healPercent = 0.0f;
    public float dmgAmt = 0.0f;
    public float dmgPercent = 0.0f;
    public int uses = 1;
    public int maxUses = 1;
    public bool hasDiscoveredItem = false;
    public bool hasItem = false;

}
