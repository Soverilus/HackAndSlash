using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStats : EnemyStats {
    public override void SetMaxHealth() {
        maxHealth = 60;
    }

    public override void SetMaxStamina() {
        maxStamina = 60;
        staminaRegMult = 20;
    }

    protected override void SetRewardTier() {
        myGLC.rewardTier += 1;
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