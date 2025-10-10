using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    public Sprite onme;
    public Sprite otwo;
    bool isOnText = true;

    public void ChangeText() {
        if (isOnText) {
            GetComponent<SpriteRenderer>().sprite = otwo;
            isOnText = false;
        }
    }
}
