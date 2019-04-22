using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;

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

    protected override void OnStateChange() {
        switch (myState) {
            case CharState.Normal:
                break;

            case CharState.Stunned:
                myAC.PlayAudioClip("STUN", false);
                break;

            case CharState.LAttack:
                break;

            case CharState.HAttack:
                myAC.PlayAudioClip("HATKS", false);
                break;

            case CharState.LDefend:
                break;

            case CharState.HDefend:
                break;

            case CharState.LSpecial:
                break;

            case CharState.HSpecial:
                break;

            default:
                break;
        }
        hasStateChanged = false;
    }
    /*
        protected override void HAttackDamage(int damage, GameObject myAttacker) {

        }

        protected override void LAttackDamage(int damage, GameObject myAttacker) {

        }
        */
    protected override void LDefendDamage(int damage, GameObject myAttacker) {
        myAttacker.GetComponent<CharacterStats>().DamageStamina(damage * 5);
        myAC.PlayAudioClip("BLOCK");
    }

    protected override void HDefendDamage(int damage, GameObject myAttacker) {
        equivStamina -= damage;
        myAC.PlayAudioClip("BLOCK");
    }

    protected override void HSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }

    protected override void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
    }
}
