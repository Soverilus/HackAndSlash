using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoopController : MonoBehaviour {
    PlayerStats myCS;
    EnemyStats enemyCS;
    CountdownToFight myAdvert;
    string loadScene;
    public int rewardTier;
    bool died = false;
    void SetAdvertisementRound() {
        PlayerPrefs.SetInt("DispAdvert", Random.Range(3, 7) + PlayerPrefs.GetInt("GameRound"));
    }
    public void Start() {
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
            loadScene = "Menu";
            Invoke("LoadScene", 3f);
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
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + (PlayerPrefs.GetInt("GameRound") + Random.Range(1, 11)) * rewardTier);
    }

    public void OnVictory() {
        died = true;
        AddGold();
        PlayerPrefs.SetInt("PlayerHealth", myCS.GetHealth());
        if (PlayerPrefs.HasKey("GameRound")) {
            PlayerPrefs.SetInt("GameRound", PlayerPrefs.GetInt("GameRound") + 1);
        }
        else {
            PlayerPrefs.SetInt("GameRound", 1);
        }
            loadScene = "GoblinFight";
            Invoke("LoadScene", 3f);
    }
    public void OnDefeat() {
        died = true;
        PlayerPrefs.SetInt("GameRound", 1);
        SetAdvertisementRound();
        PlayerPrefs.SetInt("PlayerHealth", myCS.GetMaxHealth());
        loadScene = "Menu";
        Invoke("LoadScene", 3f);
    }

    void LoadScene() {
        PlayerPrefs.Save();
        SceneManager.LoadScene(loadScene);
    }
}
