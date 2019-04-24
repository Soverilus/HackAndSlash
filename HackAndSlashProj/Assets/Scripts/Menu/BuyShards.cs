using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyShards : MonoBehaviour {
    public GameObject myPanel;
    public GameObject[] shardItems;
    public GameObject[] potionItems;
    public GameObject back;
    public void OpenShardsMenu(string itemType) {
        myPanel.SetActive(true);
        back.SetActive(true);
        switch (itemType) {
            case "Shards":
                for (int i = 0; i < shardItems.Length; i++) {
                    shardItems[i].SetActive(true);
                }
                for (int i = 0; i < potionItems.Length; i++) {
                    potionItems[i].SetActive(false);
                }
                break;
            case "Potions":
                for (int i = 0; i < potionItems.Length; i++) {
                    potionItems[i].SetActive(true);
                }
                for (int i = 0; i < shardItems.Length; i++) {
                    shardItems[i].SetActive(false);
                }
                break;

            default:

                break;
        }
    }
    public void CloseShardsMenu() {
        myPanel.SetActive(false);
        back.SetActive(false);
        for (int i = 0; i < shardItems.Length; i++) {
            shardItems[i].SetActive(false);
        }
        for (int i = 0; i < potionItems.Length; i++) {
            potionItems[i].SetActive(false);
        }
    }
}
