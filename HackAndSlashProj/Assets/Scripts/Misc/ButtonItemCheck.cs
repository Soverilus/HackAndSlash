using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonItemCheck : MonoBehaviour
{
    [SerializeField]
    Sprite[] mySprites;
    CharacterStats myCS;
    OnActionPress myActions;
    public string itemName;
    GameLoopController myGLC;
    Text myText;
    [SerializeField]
    int potionAmount;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
        myText.color = Color.yellow;
        myCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        myActions = GameObject.FindGameObjectWithTag("Player").GetComponent<OnActionPress>();
        myGLC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopController>();
        if (PlayerPrefs.HasKey("Inf" + itemName)) {
            potionAmount += PlayerPrefs.GetInt("Inf" + itemName);
        }
        if (myGLC.ItemExists(itemName)) {
            gameObject.GetComponentInParent<Button>().interactable = true;
            potionAmount = myGLC.ItemAmount(itemName);
            if (PlayerPrefs.HasKey("Inf" + itemName)) {
                potionAmount += PlayerPrefs.GetInt("Inf" + itemName);
            }
        }
        else {
            gameObject.GetComponentInParent<Button>().interactable = false;
        }
    }

    private void Update() {
        myText.text = potionAmount.ToString("F0");
        if (myCS.gameObject.GetComponent<PlayerStats>().lives <= 0 && itemName == "RevivePotion") {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void DrinkPotion() {
        //Debug.Log("What the fuck is going on");
        myActions.ResetAction();
        myCS.Invoke(itemName, 0);
        potionAmount -= 1;
        if (potionAmount <= 0) {
            myText.text = 0.ToString("F0");
            myText.color = Color.black;
        }
        if (PlayerPrefs.GetInt(itemName) > 0) {
            PlayerPrefs.SetInt(itemName, PlayerPrefs.GetInt(itemName) - 1);
        }
        if (potionAmount <= 0) {
            gameObject.GetComponent<Button>().interactable = false;
        }
        PlayerPrefs.Save();
    }
}
