using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{   

    public GameObject[] buttons = new GameObject[3];
    public GameObject[] deathButtons = new GameObject[2];
    public Sprite[] buttonAssets = new Sprite[6];
    public Sprite[] deathButtonAssets = new Sprite[4];
    public Sprite heartSprite;
    public GameObject deathScreen;
    public GameObject healthBar;
    public GameObject battleWorld;
    public GameObject attackBar;
    public GameObject heart;
    public GameObject fade;
    public Transform iM;
    public Slider healthSlider;
    public Slider bossHealthSlider;
    public bool isInWorld = true;
    public bool isLobby = true;
    public Player pd;

    public void Start() {
        if (isInWorld) {
            StartCoroutine(RidFade());
        }
        if (GameObject.Find("Lobby(Clone)") == null && GameObject.Find("BattleSystem") == null)
            Instantiate(pd.music);

    }

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
            if (items[i].hasItem)
                iM.GetChild(i).GetComponent<TextMeshProUGUI>().text = items[i].name;
            else
                iM.GetChild(i).GetComponent<TextMeshProUGUI>().text = "Not Discovered";
        }
        SelectItem(0, 0);
    }

    public void HideItemMenu() {
        iM.gameObject.SetActive(false);
    }

    public void SelectItem(int item, int oldItem) {
        iM.GetChild(oldItem).GetComponent<TextMeshProUGUI>().color = Color.white;
        iM.GetChild(item).GetComponent<TextMeshProUGUI>().color = Color.yellow;
    }

    public void ShowSpareMenu()
    {
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

    public IEnumerator ChangeBossBar(float currentHealth, float damage) {
        float time = 0.0f;
        while (time <= 1) {
            bossHealthSlider.value = Mathf.Lerp(currentHealth + damage, currentHealth, time);
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

    public void ChangeDeathButton(bool ant) {
        if (ant) {
            deathButtons[0].transform.GetComponent<Image>().sprite = deathButtonAssets[0];
            deathButtons[1].transform.GetComponent<Image>().sprite = deathButtonAssets[3];
        }
        else {
            deathButtons[0].transform.GetComponent<Image>().sprite = deathButtonAssets[2];
            deathButtons[1].transform.GetComponent<Image>().sprite = deathButtonAssets[1];
        }
    }

    public void ExitBattleUI() {
        //HideBattleButtons();
        ShowBattleButtons();
        HideBattleWorld();
    }

    public IEnumerator ChangeScene(string sceneName) {
        float time = 0.0f;
        float intendedTime = 0.5f;
        while (time <= intendedTime) {
            Color spriteColor = fade.GetComponent<Image>().color;
            spriteColor.a = Mathf.Lerp(0.0f, 1.0f, time/intendedTime);
            fade.GetComponent<Image>().color = spriteColor;
            time += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator RidFade() {
        float time = 0.0f;
        float intendedTime = 0.5f;
        while (time <= intendedTime) {
            Color spriteColor = fade.GetComponent<Image>().color;
            spriteColor.a = Mathf.Lerp(1.0f, 0.0f, time/intendedTime);
            fade.GetComponent<Image>().color = spriteColor;
            time += Time.deltaTime;
            yield return null;
        }
    }

}
