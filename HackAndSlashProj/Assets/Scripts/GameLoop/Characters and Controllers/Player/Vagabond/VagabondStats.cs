using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagabondStats : PlayerStats {
    public override void SetMaxHealth() {
        maxHealth = 160;
    }

    public override void SetMaxStamina() {
        maxStamina = 220;
    }

    public override void SetBaseDamage() {
        baseDamage = 20;
    }
    /*
        protected override void HAttackDamage(int damage, GameObject myAttacker) {

        }

        protected override void LAttackDamage(int damage, GameObject myAttacker) {

        }
        */
    protected override void LDefendDamage(int damage, GameObject myAttacker) {
        myAttacker.GetComponent<CharacterStats>().DamageStamina(damage * 5);
    }

    protected override void HDefendDamage(int damage, GameObject myAttacker) {
        equivStamina -= damage;
        myAC.PlayAudioClip("ShieldHit1", false);
    }

    protected override void HSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }

    protected override void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }
}
