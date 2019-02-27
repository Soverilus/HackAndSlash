using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStats : CharacterStats {
    public override void SetMaxHealth() {
        maxHealth = 6;
    }

    public override void SetMaxStamina() {
        maxStamina = 6;
    }

    //protected override void HAttackDamage(int damage, GameObject myAttacker) { }

    //protected override void LAttackDamage(int damage, GameObject myAttacker) { }

    //protected override void HDefendDamage(int damage, GameObject myAttacker) { }

    protected override void LDefendDamage(int damage, GameObject myAttacker) {
        health -= damage * 0;
    }

    //protected override void HSpecialDamage(int damage, GameObject myAttacker) { }

    protected override void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }
}