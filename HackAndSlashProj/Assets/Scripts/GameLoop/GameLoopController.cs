using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoopController : MonoBehaviour {
    PlayerStats myCS;
    EnemyStats enemyCS;
    string loadScene;
    //Score keeping - currency and gold prize for winning
    //Maybe have a playerprefs controller?
    //User settings script?
    //money script..?
    //win detection
    //Need an option to watch advertisements to gain gold button
    //buy Fragments with moneyyyyy

    public void Start() {
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

    public void OnVictory() {
        PlayerPrefs.SetInt("PlayerHealth", myCS.GetHealth());
        //determine score increase from enemy type and time and chance
        //chance to add currency based on round count
        //chance for item reward based on round count
        loadScene = "GoblinFight";
        Invoke("LoadScene", 3f);
    }

    public void OnDefeat() {
        PlayerPrefs.SetInt("PlayerHealth", myCS.GetMaxHealth());
        //determine final score - highscore
        //add total currency
        //total scores
        loadScene = "Menu";
        Invoke("LoadScene", 3f);
    }

    void LoadScene() {
        SceneManager.LoadScene(loadScene);
    }
}
