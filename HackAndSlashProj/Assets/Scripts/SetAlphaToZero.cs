using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetAlphaToZero : MonoBehaviour
{
    Image myIMG;
    Text myText;
    void Start()
    {
        myIMG = GetComponent<Image>();
        myText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (myIMG != null) {
            if (myIMG.color.a > 0) {
                myIMG.color = new Color(1f, 1f, 1f, 0f);
            }
        }
        if (myText != null) {
            if (myText.color.a > 0) {
                myText.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }
}
