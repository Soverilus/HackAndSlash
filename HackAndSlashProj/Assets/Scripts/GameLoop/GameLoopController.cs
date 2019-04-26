using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoopController : MonoBehaviour {
    PlayerStats myCS;
    EnemyStats enemyCS;
    CountdownToFight myAdvert;
    public GameObject myWinLose;
    WinLose myWL;
    string loadScene;
    public int rewardTier;
    bool died = false;
    void SetAdvertisementRound() {
        PlayerPrefs.SetInt("DispAdvert", Random.Range(3, 7) + PlayerPrefs.GetInt("GameRound"));
    }
    public void Start() {
        myWL = myWinLose.GetComponent<WinLose>();
        myAdvert = GameObject.FindGameObjectWithTag("Advertisement").GetComponent<CountdownToFight>();
        if (!PlayerPrefs.HasKey("GameRound")) {
            PlayerPrefs.SetInt("GameRound", 1);
        }
        //I am aware of the issue of using a playerpref as a method of checking whether or not the player has bought add-free version, however, for the purposes of the assignment, 
        //I am NOT making an online service just for someone to be able to login to check this one thing.
        if (!PlayerPrefs.HasKey("NoAdverts")) {
            if (!PlayerPrefs.HasKey("DispAdvert")) {
                SetAdvertisementRound();
            }
            if (PlayerPrefs.GetInt("DispAdvert") <= PlayerPrefs.GetInt("GameRound")) {
                myAdvert.myTimeRemaining = 5f;
                //Display Advert here.
                SetAdvertisementRound();
            }
            else {
                myAdvert.ExitCombatAdvert();
            }
        }
        else {
            myAdvert.ExitCombatAdvert();
        }
        if (GameObject.FindGameObjectWithTag("Player") && GameObject.FindGameObjectWithTag("Enemy")) {
            myCS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            enemyCS = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
            myCS.myGLC = GetComponent<GameLoopController>();
            enemyCS.myGLC = GetComponent<GameLoopController>();
            if (PlayerPrefs.HasKey("PlayerHealth")) {
                myCS.SetHealth(PlayerPrefs.GetInt("PlayerHealth"));
            }
            else {
                PlayerPrefs.SetInt("PlayerHealth", myCS.GetMaxHealth());
            }
        }
        else {
            Debug.LogWarning("No enemy or player found");
        }
    }

    private void Update() {
        if (Time.timeScale != 1f) {
            if (died) {
                Time.timeScale += 0.25f * Time.unscaledDeltaTime;
            }
            else {
                Time.timeScale += 2f * Time.unscaledDeltaTime;
            }
            if (Time.timeScale >= 1f) {
                Time.timeScale = 1f;
            }
        }
    }

    public bool ItemExists(string myItemName) {
        bool myBool = false;
        if (PlayerPrefs.HasKey("Inf" + myItemName)) {
            if (PlayerPrefs.GetInt("Inf" + myItemName) > 0) {
                myBool = true;
            }
        }
        if (PlayerPrefs.HasKey(myItemName)) {
            if (PlayerPrefs.GetInt(myItemName) > 0) {
                myBool = true;
            }
        }
        return myBool;
    }
    public int ItemAmount(string myItemName) {
        int myItem = 0;
        if (PlayerPrefs.HasKey(myItemName)) {
            myItem = PlayerPrefs.GetInt(myItemName) + PlayerPrefs.GetInt("Inf" + myItemName);
        }
        return myItem;
    }

    void AddGold() {
        myWL.SetGLC(this);
        float goldInc = (PlayerPrefs.GetInt("GameRound") + Random.Range(1, 11)) * rewardTier;
        float shardInc = Mathf.Clamp(Random.Range(-10, 1),0,1) * ((PlayerPrefs.GetInt("GameRound") + Random.Range(1, 11)) * rewardTier);
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + Mathf.RoundToInt(goldInc));
        PlayerPrefs.SetInt("Shards", PlayerPrefs.GetInt("Shards") + Mathf.RoundToInt(shardInc));
        myWL.SetGoldAndShardCounts(Mathf.Round(goldInc), Mathf.Round(shardInc));
    }

    public void OnVictory() {
        myWL.SetVictory(true);
        DisableAllCharacter();
        loadScene = "GoblinFight";
        Invoke("LoadScene", 3f);
        died = true;
        
        PlayerPrefs.SetInt("PlayerHealth", myCS.GetHealth());
        if (PlayerPrefs.HasKey("GameRound")) {
            PlayerPrefs.SetInt("GameRound", PlayerPrefs.GetInt("GameRound") + 1);
        }
        else {
            PlayerPrefs.SetInt("GameRound", 1);
        }
    }
    public void OnDefeat() {
        myWL.SetVictory(false);
        DisableAllCharacter();
        loadScene = "Menu";
        Invoke("LoadScene", 3f);
        died = true;
        rewardTier = 0;
        PlayerPrefs.SetInt("GameRound", 1);
        SetAdvertisementRound();
        PlayerPrefs.SetInt("PlayerHealth", myCS.GetMaxHealth());
    }

    void DisableAllCharacter() {
        myCS.gameObject.GetComponent<OnActionPress>().enabled = false;
        enemyCS.GetComponent<EnemyController>().EnableAI(false);
    }

    void LoadScene() {
        myWinLose.SetActive(true);
        AddGold();
        PlayerPrefs.Save();
    }

    public void TrueLoadScene() {
        SceneManager.LoadScene(loadScene);
    }
}
