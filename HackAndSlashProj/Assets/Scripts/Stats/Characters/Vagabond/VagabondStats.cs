using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagabondStats : CharacterStats
{
    public override void SetMaxHealth() {
        maxHealth = 15;
    }

    public override void SetMaxStamina() {
        maxStamina = 18;
    }
/*
    protected override void HAttackDamage(int damage, GameObject myAttacker) {

    }

    protected override void LAttackDamage(int damage, GameObject myAttacker) {

    }

    protected override void HDefendDamage(int damage, GameObject myAttacker) {

    }
    */
    protected override void LDefendDamage(int damage, GameObject myAttacker) {
        stamina = Mathf.RoundToInt(stamina -= damage / 2);
        myAttacker.GetComponent<CharacterStats>().Damaged(Mathf.RoundToInt(damage / 5), gameObject);
    }

    protected override void HSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }

    protected override void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }
}
