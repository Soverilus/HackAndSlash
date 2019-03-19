using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameLoopController myGLC;
    protected override void CheckHealth() {
        if (health <= 0) {
            health = 0;
            SetRewardTier();
            MiscOnDeath();
            myCC.myAnim.SetTrigger("Death");
            myGLC.OnVictory();
        }
    }
    protected virtual void SetRewardTier() {
        myGLC.rewardTier += 0;
    }
    protected virtual void MiscOnDeath() {
        //This has been left empty on purpose
    }
}
