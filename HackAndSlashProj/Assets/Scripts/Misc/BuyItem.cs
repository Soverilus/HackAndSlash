using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyItem : MonoBehaviour {
    [Header("DO NOT ENABLE UNLESS YOU WANT TO DELETE THE ITEM, FOR DEBUG PURPOSES __ONLY__")]
    public bool DELETEITEM = false;
    [Space(20f)]
    public string itemName;
    public bool buyWithGold;
    public int maxItem;
    public int cost;
    public int realCost;
    public int costMultiplier;
    public int costMultAt;
    Button mySelf;
    void Start() {
        realCost = cost;
        mySelf = GetComponent<Button>();
        if (!DELETEITEM) {
            if (!PlayerPrefs.HasKey(itemName)) {
                PlayerPrefs.SetInt(itemName, 0);
            }
            if (!PlayerPrefs.HasKey("Gold")) {
                PlayerPrefs.SetInt("Gold", 0);
            }
            if (!PlayerPrefs.HasKey("Shards")) {
                PlayerPrefs.SetInt("Shards", 0);
            }
        }
        else {
            PlayerPrefs.DeleteKey(itemName);
        }
        PlayerPrefs.Save();
    }

    private void Update() {
        if (PlayerPrefs.HasKey(itemName) && PlayerPrefs.GetInt(itemName) % costMultAt == 0) {
            realCost = cost + costMultiplier * PlayerPrefs.GetInt(itemName);
        }
        if ((PlayerPrefs.GetInt("Gold") < realCost && buyWithGold) ||
        (PlayerPrefs.GetInt("Shards") < realCost && !buyWithGold)||
        PlayerPrefs.GetInt(itemName) >= maxItem) {
            mySelf.interactable = false;
        }
        else {
            mySelf.interactable = true;
        }
    }

    public void Purchase() {
        PlayerPrefs.SetInt(itemName, PlayerPrefs.GetInt(itemName) + 1);
        if (buyWithGold) {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - realCost);
        }
        else {
            PlayerPrefs.SetInt("Shards", PlayerPrefs.GetInt("Shards") - realCost);
        }
    }
}
