using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonItemCheck : MonoBehaviour
{
    public string itemName;
    GameLoopController myGLC;
    int potionAmount;

    void Start()
    {
        myGLC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopController>();
        if (myGLC.ItemExists(itemName)) {
            gameObject.GetComponent<Button>().interactable = true;
            potionAmount = myGLC.ItemAmount(itemName);
        }
        else {
            gameObject.GetComponent<Button>().interactable = false;
        }

    }

    public void DrinkPotion() {
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
