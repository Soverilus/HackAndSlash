using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
public class GoblinController : EnemyController {

    protected override void ActionAIModule() {
        CharState targetState = targetCS.GetState();
        //enum TempState = CharacterStats.CharState;
        if (targetState == CharState.HAttack || targetState == CharState.LAttack) {
            //attempt LightDefend();
        }
        if (targetState == CharState.HDefend || targetState == CharState.Normal || targetState == CharState.Stunned) {
            if (targetState == CharState.HDefend || targetState == CharState.Stunned) {
                //attempt attack special - if enough stamina, half chance to use.
                //attempt normal attack
            }
        }
    }

    public override void LightAttack() {
        Debug.Log(gameObject.name + " Performed LightAttack");
        //start animation
    }

    public override void StartHeavyAttack() {
        LightAttack();
    }

    public override void EndHeavyAttack() {
        //null
    }

    public override void LightDefend() {
        Debug.Log(gameObject.name + " Performed LightDefend");
        //start animation
    }

    public override void StartHeavyDefend() {
        LightDefend();
    }

    public override void EndHeavyDefend() {
        //null
    }

    public override void LightSpecial() {
        Debug.Log(gameObject.name + " Performed LightSpecial");
        //three animations, at the end of each, deal stamina damage on block, and double damage on stunned (stacks with stunned damage)
        //start animation
    }

    public override void StartHeavySpecial() {
        LightSpecial();
    }

    public override void EndHeavySpecial() {
        //null
    }

    public override void Stagger() {
        Debug.Log(gameObject.name + " Performed Stagger");
        //start animation
    }
}
