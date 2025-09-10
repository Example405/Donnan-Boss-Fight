using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{   

    public GameObject[] buttons = new GameObject[3];
    public Sprite[] buttonAssets = new Sprite[6];
    public Sprite heartSprite;
    public GameObject deathScreen;
    public GameObject healthBar;
    public GameObject battleWorld;
    public GameObject attackBar;
    public GameObject heart;
    public Transform iM;
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

    public void SelectButton(int newButton, int pastButton) {
        buttons[pastButton].transform.GetComponent<Image>().sprite = buttonAssets[pastButton];
        buttons[newButton].transform.GetComponent<Image>().sprite = buttonAssets[newButton + 3];
    }

    public void ShowAttackBar() {
        attackBar.SetActive(true);
    }

    public void HideAttackBar() {
        attackBar.SetActive(false);
    }

    public void ShowItemMenu(Item[] items) {
        iM.gameObject.SetActive(true);
        for (int i = 0; i < 12; i++) {
            iM.GetChild(i).GetComponent<TextMeshProUGUI>().text = items[i].name;
        }
    }

    public void HideItemMenu() {
        iM.gameObject.SetActive(false);
    }

    public void SelectItem(int item, int oldItem) {
        iM.GetChild(oldItem).GetComponent<TextMeshProUGUI>().color = Color.black;
        iM.GetChild(item).GetComponent<TextMeshProUGUI>().color = Color.yellow;
    }

    public void ShowSpareMenu() {
        //TBD
    }

    public void HideSpareMenu() {
        //TBD
    }

    public void LoadButtonMenu(int button) {
        if (button == 0) {
            HideBattleButtons();
            ShowAttackBar();
        }
        else if (button == 1) {
            HideBattleButtons();
            ShowItemMenu(null);
        }
        else {
            HideBattleButtons();
            ShowSpareMenu();
        }

    }

    public void LoadButtonMenu(int button, Item[] items) {
        if (button == 0) {
            HideBattleButtons();
            ShowAttackBar();
        }
        else if (button == 1) {
            HideBattleButtons();
            ShowItemMenu(items);
        }
        else {
            HideBattleButtons();
            ShowSpareMenu();
        }

    }

    public void HideButtonMenu(int button) {
        if (button == 0) {
            ShowBattleButtons();
            //HideAttackBar();
        }
        else if (button == 1) {
            ShowBattleButtons();
            HideItemMenu();
        }
        else {
            ShowBattleButtons();
            HideSpareMenu();
        }
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

    public void ShowBattleWorld() {
        battleWorld.SetActive(true);
    }

    public void HideBattleWorld() {
        battleWorld.SetActive(false);
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
        //ShowBattleButtons();
        HideBattleButtons();
        ShowBattleWorld();
        ShowHealthBar();
    }

    public void ExitBattleUI() {
        //HideBattleButtons();
        ShowBattleButtons();
        HideBattleWorld();
        HideHealthBar();
    }

    

}
