using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEnd : MonoBehaviour {
    public PlayerController myPC;
    public void OnAttackEnd() {
        //deal damage;
        myPC.skillLock = false;
    }

    public void OnDefendPerfect() {

    }

    public void OnDefendEnd() {
        myPC.skillLock = false;
    }

    public void OnSpecialEnd() {
        myPC.skillLock = false;
    }
}
