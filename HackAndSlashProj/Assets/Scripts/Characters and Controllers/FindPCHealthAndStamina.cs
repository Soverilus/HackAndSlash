using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FindPCHealthAndStamina : MonoBehaviour
{
    public Slider myHP;
    public Slider mySta;
    public CharacterStats myCS;

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

    void Update()
    {
        myHP.value = myCS.GetHealth();
        mySta.value = myCS.GetStamina();
    }
}
