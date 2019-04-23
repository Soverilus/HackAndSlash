using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;

public class GoblinStats : EnemyStats {
    public override void SetMaxHealth() {
        maxHealth = 60 * Mathf.Clamp(PlayerPrefs.GetInt("GameRound"), 2, int.MaxValue);
    }

    public override void SetMaxStamina() {
        maxStamina = 60 * Mathf.Clamp(PlayerPrefs.GetInt("GameRound") / 5, 1, int.MaxValue);
        staminaRegMult = 50 * Mathf.Clamp(PlayerPrefs.GetInt("GameRound") / 4, 1, int.MaxValue);
    }

    protected override void SetRewardTier() {
        myGLC.rewardTier += 1;
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
    //protected override void HAttackDamage(int damage, GameObject myAttacker) { }

        //protected override void LAttackDamage(int damage, GameObject myAttacker) { }

        //protected override void HDefendDamage(int damage, GameObject myAttacker) { }

    protected override void LDefendDamage(int damage, GameObject myAttacker) {
        health -= damage * 0;
    }

    //protected override void HSpecialDamage(int damage, GameObject myAttacker) { }

    protected override void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= damage * 2;
        myAC.PlayAudioClip("HIT");
    }
}