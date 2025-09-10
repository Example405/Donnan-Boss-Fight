using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    //1 == Players Turn; 2 == attack; 3 == item; 4 == spare;
    //5 == Enemy's turn; 6 == player move
    int turn = 1;
    //1 == attack, 2 == item, 3 == spare
    int buttonOn = 1;
    int itemOn = 1;
    float timeBeforeRestart = 5.0f;
    float barTime = 2.5f;
    float timeAdd = 0.0f;
    float attackbarStartingPoint = -875.0f;
    float attackbarEndingPoint = 875.0f;
    public GameObject attackBar;
    public Player pd;


    public int testing = 0;

    public UIScript us;


    public void Start() {
        us.ExitBattleUI();
        us.SelectButton(buttonOn - 1, buttonOn - 1);
    }

    void Update() {
        if (turn == 1) {
            if (Input.GetKeyDown(KeyCode.A)) {
                int tempButton = buttonOn;
                buttonOn -= 1;
                if (buttonOn <= 0)
                    buttonOn = 3;
                us.SelectButton(buttonOn - 1, tempButton - 1);
            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                int tempButton = buttonOn;
                buttonOn += 1;
                if (buttonOn >= 4)
                    buttonOn = 1;
                us.SelectButton(buttonOn - 1, tempButton - 1);
            }

            if (Input.GetKeyDown(KeyCode.Return)) {
                turn = buttonOn + 1;
                if (buttonOn != 2)
                    us.LoadButtonMenu(buttonOn - 1);
                else  
                    us.LoadButtonMenu(buttonOn - 1, pd.items);
            } 
        }

        else if (turn == 2) {
            //add battle functionality
            timeAdd += Time.deltaTime;
            attackBar.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Lerp(attackbarStartingPoint, attackbarEndingPoint, timeAdd/barTime), 0.0f);
            /*
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                us.HideButtonMenu(0);
                turn = 1;
            } */
            if (timeAdd >= barTime) {
                attackBar.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(attackbarStartingPoint, 0.0f);
                us.HideAttackBar();
                timeAdd = 0.0f;
                turn = 5;
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                //attack
                us.HideAttackBar();
                timeAdd = 0.0f;
                turn = 5;
                testing += 1;
                if (testing == 2) {
                    LeaveBattleScene();
                }
            }
        }
        else if (turn == 3) {
            //add item functionality
            if (Input.GetKeyDown(KeyCode.A)) {
                int tempOn = itemOn;
                itemOn -= 4;
                if (itemOn <= 0)
                    itemOn += 12;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                int tempOn = itemOn;
                itemOn += 4;
                if (itemOn >= 13)
                    itemOn -= 12;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }
            else if (Input.GetKeyDown(KeyCode.W)) {
                int tempOn = itemOn;
                itemOn -= 1;
                if (itemOn % 4 == 0)
                    itemOn += 4;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }
            else if (Input.GetKeyDown(KeyCode.S)) {
                int tempOn = itemOn;
                if (itemOn % 4 == 0)
                    itemOn -= 3;
                else
                    itemOn += 1;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }

            if (Input.GetKeyDown(KeyCode.Backspace)) {
                us.HideButtonMenu(1);
                turn = 1;
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                us.HideItemMenu();
                turn = 5;
            }
        }
        else if (turn == 4) {
            //add spare functionality
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                us.HideButtonMenu(2);
                turn = 1;
            }
        }
        else if (turn == 5) {
            Debug.Log("Turn Going On 5");
            turn = 6;
            us.ShowBattleWorld();
            us.ShowHealthBar();
        }
        else if (turn == 6) {
            timeAdd += Time.deltaTime;
            //Choose random attack here
            //Set time based on scriptableobject attack
            if (timeAdd >= timeBeforeRestart) {
                turn = 1;
                us.HideBattleWorld();
                us.HideHealthBar();
                us.ShowBattleButtons();
                us.SelectButton(0, 0);
                timeAdd = 0.0f;
            }

        }
    }   

    public void LeaveBattleScene () {
        SceneManager.LoadScene("WorldWorld");
    }
}
