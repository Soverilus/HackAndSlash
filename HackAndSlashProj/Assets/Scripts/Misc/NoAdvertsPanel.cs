using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoAdvertsPanel : MonoBehaviour {
    void Update() {
        if (PlayerPrefs.HasKey("NoAdverts")) {
            GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
