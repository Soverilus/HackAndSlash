using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrencyTextCounter : MonoBehaviour
{
    Text myText;
    public bool trueForGold;
    private void Start() {
        myText = GetComponent<Text>();
    }
    private void Update() {
        if (trueForGold) {
            myText.text = PlayerPrefs.GetInt("Gold").ToString("F0");
        }
        else {
            myText.text = PlayerPrefs.GetInt("Shards").ToString("F0");
        }
    }
}
