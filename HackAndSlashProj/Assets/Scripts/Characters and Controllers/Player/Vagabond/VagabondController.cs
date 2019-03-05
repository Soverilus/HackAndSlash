using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
[RequireComponent(typeof(CharacterStats), typeof(Animator))]
public class VagabondController : PlayerController {

    /*public override void HeavyChargeInc() {
        Mathf.Clamp(chargeLv += 1, 1, 5);
        if (chargeLv >= 5) {
            myAnim.SetBool("HAttack", false);
        }
    }

    public override void DamageTarget(int zeroForLight) {
        if (zeroForLight != 0) {
            targetCS.Damaged(myCS.baseDamage + chargeLv * 10, gameObject);
            EndHeavyAttack();
        }
        else {
            targetCS.Damaged(myCS.baseDamage, gameObject);
        }
        chargeLv = 1;
        myCS.ChangeState(CharState.Normal);
    }*/

    public override void LightAttack() {
        Debug.Log(gameObject.name + " Performed LightAttack");
        myCS.ChangeState(CharState.LAttack);
        myAnim.SetTrigger("LAttack");
        //start animation
    }

    public override void StartHeavyAttack() {
        Debug.Log(gameObject.name + " Performed StartHeavyAttack");
        myCS.ChangeState(CharState.HAttack);
        myAnim.SetBool("HAttack", true);
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public override void EndHeavyAttack() {
        Debug.Log(gameObject.name + " Performed EndHeavyAttack");
        myCS.ChangeState(CharState.Normal);
        myAnim.SetBool("HAttack", false);
        //unfreeze animation
    }

    public override void LightDefend() {
        Debug.Log(gameObject.name + " Performed LightDefend");
        myCS.ChangeState(CharState.LDefend);
        myAnim.SetTrigger("LDefend");
        //start animation
    }

    public override void StartHeavyDefend() {
        Debug.Log(gameObject.name + " Performed StartHeavyDefend");
        myCS.ChangeState(CharState.HDefend);
        myAnim.SetBool("HDefend", true);
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public override void EndHeavyDefend() {
        Debug.Log(gameObject.name + " Performed EndHeavyDefend");
        myCS.ChangeState(CharState.Normal);
        myAnim.SetBool("HDefend", false);
        //unfreeze animation
    }

    public override void LightSpecial() {
        Debug.Log(gameObject.name + " Performed LightSpecial");
        myCS.ChangeState(CharState.LDefend);
        myAnim.SetTrigger("LSpecial");
        //start animation
    }

    public override void StartHeavySpecial() {
        Debug.Log(gameObject.name + " Performed StartHeavySpecial");
        myCS.ChangeState(CharState.HSpecial);
        myAnim.SetBool("HSpecial", true);
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public override void EndHeavySpecial() {
        Debug.Log(gameObject.name + " Performed EndHeavySpecial");
        myCS.ChangeState(CharState.Normal);
        myAnim.SetBool("HSpecial", false);
        //unfreeze animation
    }

    public override void Stagger() {
        Debug.Log(gameObject.name + " Performed Stagger");
        myCS.ChangeState(CharState.Stunned);
        myAnim.SetTrigger("Stun");
        //start animation
    }
}

/*
 * I need to set up an animator that allows me to use these, as well as allowing 
 * for taking damage from myCS and inputting it depending on which type of attack 
 * it is - perhaps determined by the animation itself: however I'd like to be able 
 * to set up the amount of damage and what type of damage is taken via script
 */ 
