using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownToFight : MonoBehaviour {
    Text myText;
    public GameObject destroyThis;
    public Button myButton;
    public float myTimeRemaining;
    EnemyController myEC;
    OnActionPress myPC;

   // CharacterStats[] myCharacters;

    private void Start() {
        //myCharacters = FindObjectsOfType<CharacterStats>();
        myText = GetComponent<Text>();
        myEC = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        myEC.EnableAI(false);
        myPC = GameObject.FindGameObjectWithTag("Player").GetComponent<OnActionPress>();
        myPC.enabled = false;
    }
    void Update() {
        if (PlayerPrefs.HasKey("NoAdverts")) {
            ExitCombatAdvert();
        }
        myTimeRemaining -= Time.deltaTime;
        myText.text = myTimeRemaining.ToString("F0");
        if (myTimeRemaining <= 0) {
            myButton.interactable = true;
            myText.enabled = false;
            //myEC.EnableAI(true);
            //myPC.enabled = true;
            //Destroy(gameObject);
        }
    }

    public void ExitCombatAdvert() {
        myEC.EnableAI(true);
        myPC.enabled = true;
        Destroy(destroyThis);
    }
}
