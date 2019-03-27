using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FindPCHealthAndStamina : MonoBehaviour
{
    public Slider myHP;
    public Slider mySta;
    public CharacterStats myCS;

    float previousHPVal;
    float previousStaVal;

    public bool player;
    void Start()
    {
        if (player) {
            myCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        }
        else {
            myCS = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterStats>();
        }
        myHP.maxValue = myCS.GetMaxHealth();
        mySta.maxValue = myCS.GetMaxStamina();
    }

    void Update() {
        previousHPVal = myHP.value;
        previousStaVal = mySta.value;

        myHP.value = Mathf.Lerp(previousHPVal, myCS.GetHealth(), 0.1f);
        mySta.value = Mathf.Lerp(previousStaVal, myCS.GetStamina(), 0.1f);
    }
}
