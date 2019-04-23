using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStats : CharacterStats {
    public GameLoopController myGLC;
    public int lives;
    protected override void StartAlt() {
        lives = PlayerPrefs.GetInt("RevivePotion") + PlayerPrefs.GetInt("InfRevivePotion");
    }

    protected override void CheckHealth() {
        if (health <= 0) {
            if (lives > 0) {
                lives -= 1;
                if (PlayerPrefs.GetInt("RevivePotion") > 0) {
                    PlayerPrefs.SetInt("RevivePotion", PlayerPrefs.GetInt("RevivePotion") - 1);
                }
                health = maxHealth;
            }
            else if (!isDead){
                isDead = true;
                health = 0;
                myCC.myAnim.SetTrigger("Death");
                mySPRColor = new Color(0f, 0f, 0f, 0f);
                myGLC.OnDefeat();
            }
        }
    }
    protected override void Update() {
        base.Update();
        if (!isDead) {
            PlayerPrefs.SetInt("PlayerHealth", health);
        }
    }
}
