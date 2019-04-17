using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
[RequireComponent(typeof(CharacterStats), typeof(Animator))]
public class VagabondController : PlayerController {

    public override void DamageTargetStamina(int stamina) {
        int stamDamage = stamina;
        switch (targetCS.GetState()) {
            case CharState.HAttack:
                stamDamage *= 1000;
                break;

            case CharState.HDefend:
                stamDamage = 0;
                break;

            case CharState.HSpecial:
                stamDamage *= 5;
                break;

            case CharState.LAttack:
                stamDamage *= 1000;
                break;

            case CharState.LDefend:
                stamDamage *= 1;
                break;

            case CharState.LSpecial:
                stamDamage *= 5;
                break;

            case CharState.Normal:
                Mathf.RoundToInt(stamDamage * 0.25f);
                break;

            case CharState.Stunned:
                stamDamage = 0;
                break;

            default:
                Debug.LogError("targetState is out of bounds!");
                break;
        }
        targetCS.DamageStamina(stamDamage);
    }
    public override void HeavyChargeInc() {
        base.HeavyChargeInc();
        myCS.mySPR.color = Color.blue;
    }/*

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
    /*
    public override void LightAttack() {

    }

    public override void StartHeavyAttack() {

    }

    public override void EndHeavyAttack() {

    }

    public override void LightDefend() {

    }

    public override void StartHeavyDefend() {

    }

    public override void EndHeavyDefend() {

    }

    public override void LightSpecial() {

    }
    */
    public override void StartHeavySpecial() {
        myAnim.SetBool("HSpecial", true);
    }
    /* 
    
    public override void EndHeavySpecial() {
    }

    public override void Stagger() {

    }
    */
}
