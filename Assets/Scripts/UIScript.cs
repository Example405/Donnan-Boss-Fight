using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{   

    public GameObject[] buttons = new GameObject[3];
    public GameObject deathScreen;
    public GameObject healthBar;
    public GameObject battleWorld;
    public Slider healthSlider;

    public void HideBattleButtons() {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
    }

    public void ShowBattleButtons() {
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
    }

    public void ShowDeathScreen() {
        deathScreen.SetActive(true);
    }

    public void HideDeathScreen() {
        deathScreen.SetActive(false);
    }

    public void ShowHealthBar() {
        healthBar.SetActive(true);
    }

    public void HideHealthBar() {
        healthBar.SetActive(false);
    }

    public IEnumerator ChangeBar(float currentHealth, float damage) {
        float time = 0.0f;
        while (time <= 1) {
            healthSlider.value = Mathf.Lerp(currentHealth + damage, currentHealth, time);
            time += Time.deltaTime * 8.0f;
            yield return null;
        }

    }

    public void ExitGame() {
        Application.Quit();
    }

    public void EnterBattleUI() {
        ShowHealthBar();
        ShowBattleButtons();
        battleWorld.SetActive(true);
    }

    public void ExitBattleUI() {
        HideHealthBar();
        HideBattleButtons();
        battleWorld.SetActive(false);
    }

}
