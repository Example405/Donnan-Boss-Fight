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
    bool hasAttacked = false;
    int buttonOn = 1;
    int itemOn = 1;
    float timeBeforeRestart = 5.0f;
    float barTime = 2.5f;
    float timeAdd = 0.0f;
    float attackbarStartingPoint = -875.0f;
    float attackbarEndingPoint = 875.0f;
    public GameObject attackBar;
    public GameObject attackMusic;
    public Player pd;
    public Bosses boss;
    private GameObject currentAttack;
    private GameObject bossBody;
    private GameObject bossMusic;
    private GameObject bossMusicTemp;
    private int currentAttackNum;
    private bool deathbool = false;


    public int testing = 0;

    public UIScript us;


    public void Start()
    {      
        Destroy(GameObject.Find("Lobby(Clone)"));
        boss = pd.currentBoss;
        us.ExitBattleUI();
        us.SelectButton(buttonOn - 1, buttonOn - 1);
        for (int i = 0; i < pd.items.Length; i++)
        {
            pd.items[i].uses = pd.items[i].maxUses;
            if (pd.items[i].hasDiscoveredItem == true)
                pd.items[i].hasItem = true;
        }
        pd.health = pd.maxHealth;
        boss.health = boss.maxHealth;
        bossBody = Instantiate(boss.body);
        bossMusic = Instantiate(boss.music[0]);
    }

    void Update() {
        if (turn == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                int tempButton = buttonOn;
                buttonOn -= 1;
                if (buttonOn <= 0)
                    buttonOn = 3;
                us.SelectButton(buttonOn - 1, tempButton - 1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                int tempButton = buttonOn;
                buttonOn += 1;
                if (buttonOn >= 4)
                    buttonOn = 1;
                us.SelectButton(buttonOn - 1, tempButton - 1);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                turn = buttonOn + 1;
                itemOn = 1;
                if (buttonOn != 2)
                    us.LoadButtonMenu(buttonOn - 1);
                else
                    us.LoadButtonMenu(buttonOn - 1, pd.items);
            }
        }

        else if (turn == 2)
        {
            //add battle functionality
            timeAdd += Time.deltaTime;
            attackBar.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Lerp(attackbarStartingPoint, attackbarEndingPoint, timeAdd / barTime), 0.0f);
            /*
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                us.HideButtonMenu(0);
                turn = 1;
            } */
            if (timeAdd >= barTime)
            {
                attackBar.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(attackbarStartingPoint, 0.0f);
                us.HideAttackBar();
                timeAdd = 0.0f;
                turn = 5;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {      
                float dam = pd.damage;
                if (timeAdd < (barTime/5) || timeAdd > ((barTime/5) * 4)) {
                    dam = pd.damage/2;
                }
                else if (timeAdd < ((barTime/5 * 2)) || timeAdd > ((barTime/5) * 3)) {
                    dam = pd.damage;
                }
                else
                    dam = pd.damage * 2;

                Debug.Log("Damage Done" + dam);

                //attack
                us.HideAttackBar();
                timeAdd = 0.0f;
                turn = 5;
                if (boss.DamageBoss(dam))
                    EndFight();
                StartCoroutine(us.ChangeBossBar(boss.health/boss.maxHealth, pd.damage/boss.maxHealth));
                playMusic(attackMusic);
            }
        }
        else if (turn == 3)
        {
            //add item functionality
            if (Input.GetKeyDown(KeyCode.A))
            {
                int tempOn = itemOn;
                itemOn -= 4;
                if (itemOn <= 0)
                    itemOn += 12;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                int tempOn = itemOn;
                itemOn += 4;
                if (itemOn >= 13)
                    itemOn -= 12;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                int tempOn = itemOn;
                itemOn -= 1;
                if (itemOn % 4 == 0)
                    itemOn += 4;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                int tempOn = itemOn;
                if (itemOn % 4 == 0)
                    itemOn -= 3;
                else
                    itemOn += 1;
                us.SelectItem(itemOn - 1, tempOn - 1);
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                us.HideButtonMenu(1);
                turn = 1;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Item item = pd.items[itemOn - 1];
                if (item.hasItem)
                {
                    pd.HealPlayer(item.healAmt);
                    if (boss.DamageBoss(boss.maxHealth * (item.dmgPercent / 100)))

                    if (boss.DamageBoss(item.dmgAmt))
                        EndFight();
                    StartCoroutine(us.ChangeBossBar(boss.health/boss.maxHealth, item.dmgAmt/boss.maxHealth));
                    item.uses -= 1;
                    if (item.uses == 0)
                    {
                        item.hasItem = false;
                    }
                    us.HideItemMenu();
                    turn = 5;
                }

            }
        }
        else if (turn == 4)
        {
            /*add spare functionality
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                us.HideButtonMenu(2);
                turn = 1;
            } */
            SceneManager.LoadScene("WorldWorld");
        }
        else if (turn == 5)
        {
            Debug.Log("Turn Going On 5");
            turn = 6;
            us.ShowBattleWorld();
            us.ShowHealthBar();
            us.healthSlider.value = pd.health / pd.maxHealth;
            currentAttackNum = ((int) Random.Range(0,boss.attackPrefabs.Length));
            //((int) Random.Range(0,4));
            if (boss.attackPrefabs[currentAttackNum] != null)
                currentAttack = Instantiate(boss.attackPrefabs[currentAttackNum]);
            else
                currentAttack = null;
            timeBeforeRestart = boss.attackEndTimes[currentAttackNum];
            if (boss.animNames[currentAttackNum] != "null") {
                bossBody.GetComponent<Animator>().SetBool("IsAttacking", true);
                bossBody.GetComponent<Animator>().SetBool(boss.animNames[currentAttackNum], true);
            }
            if (boss.music[currentAttackNum] != null && currentAttackNum != 0) {
                StartCoroutine(playBossMusicProj(currentAttackNum));
            }

            GameObject.Find("BattlePlayer").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BattlePlayer").GetComponent<PlayerLife>().regularPng;
        }
        else if (turn == 6)
        {
            timeAdd += Time.deltaTime;

            if (timeAdd >= boss.attackTimes[currentAttackNum] && hasAttacked == false) {
                if (currentAttack != null)
                    currentAttack.SetActive(true);
                hasAttacked = true;
            }

            if (timeAdd >= timeBeforeRestart || pd.health <= 0)
            {
                turn = 1;
                us.HideBattleWorld();
                us.ShowBattleButtons();
                us.SelectButton(0, buttonOn - 1);
                buttonOn = 1;
                timeAdd = 0.0f;
                Destroy(currentAttack);
                hasAttacked = false;
                if (pd.health <= 0) {
                    turn = 7;
                    deathbool = false;
                    us.ChangeDeathButton(false);
                }
                if (boss.animNames[currentAttackNum] != "null") {
                bossBody.GetComponent<Animator>().SetBool("IsAttacking", false);
                bossBody.GetComponent<Animator>().SetBool(boss.animNames[currentAttackNum], false);
                }
            }

        }
        else if (turn == 7) {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                deathbool = !deathbool;
                us.ChangeDeathButton(deathbool);
            }

            if (Input.GetKeyDown(KeyCode.Return)) {
                if (!deathbool)
                    us.ChangeScene("WorldWorld");
                else
                    us.ExitGame();
            }
            
        }
    }   

    public void EndFight() {
        turn = 999;
        pd.defeatedBosses[boss.bossNum] = true;
        StartCoroutine(us.ChangeScene(boss.targetScene));
        
    }

    public IEnumerator playBossMusicProj(int nmbr) {
        bossMusicTemp = Instantiate(boss.music[nmbr]);
        float time = 0.0f;
        while (true) {
            time += Time.deltaTime;
            if (time <= boss.attackEndTimes[nmbr])
                yield return null;
            else {
                Destroy(bossMusicTemp);
                break;
            }
        }
    }

    public void playMusic(GameObject thingy) {
        GameObject thingyy = Instantiate(thingy);
    }

    public IEnumerator playMusic(GameObject thingy, float timer) {
        GameObject thingyy = Instantiate(thingy);
        float time = 0.0f;
        for (int i = 0; i < 10000; i++) {
            if (time < timer) {
                time += Time.deltaTime;
                yield return null;
            }
            else {
                Destroy(thingyy);
                break;
            }
        }
    }
}
