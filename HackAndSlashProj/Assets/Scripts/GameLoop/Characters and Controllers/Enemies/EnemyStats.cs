using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameLoopController myGLC;
    protected override void CheckHealth() {
        if (health <= 0) {
            health = 0;
            myCC.myAnim.SetTrigger("Death");
            myGLC.OnVictory();
        }
    }
}
