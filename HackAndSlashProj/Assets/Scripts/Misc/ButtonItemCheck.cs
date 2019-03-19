using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonItemCheck : MonoBehaviour
{
    CharacterStats myCS;
    OnActionPress myActions;
    public string itemName;
    GameLoopController myGLC;
    [SerializeField]
    int potionAmount;

    void Start()
    {
        myCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        myActions = GameObject.FindGameObjectWithTag("Player").GetComponent<OnActionPress>();
        myGLC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopController>();
        if (myGLC.ItemExists(itemName)) {
            gameObject.GetComponentInParent<Button>().interactable = true;
            potionAmount = myGLC.ItemAmount(itemName);
        }
        else {
            gameObject.GetComponentInParent<Button>().interactable = false;
        }
    }

    private void Update() {
        if (myCS.gameObject.GetComponent<PlayerStats>().lives <= 0 && itemName == "RevivePotion") {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void DrinkPotion() {
        Debug.Log("What the fuck is going on");
        myActions.ResetAction();
        myCS.Invoke(itemName, 0);
        potionAmount -= 1;
        if (PlayerPrefs.GetInt(itemName) > 0) {
            PlayerPrefs.SetInt(itemName, PlayerPrefs.GetInt(itemName) - 1);
        }
        if (potionAmount <= 0) {
            gameObject.GetComponent<Button>().interactable = false;
        }
        PlayerPrefs.Save();
    }
}
