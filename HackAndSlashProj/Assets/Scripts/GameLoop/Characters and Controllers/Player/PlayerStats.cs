using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStats : CharacterStats {
    public GameLoopController myGLC;
    protected override void CheckHealth() {
        if (health <= 0) {
            health = 0;
            myCC.myAnim.SetTrigger("Death");
            myGLC.OnDefeat();
        }
    }
    protected override void Update() {
        base.Update();
        if (Input.GetKey(KeyCode.A)) {
            PlayerPrefs.SetInt("PlayerHealth", maxHealth);
        }
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));
        }

    }
}
