using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
public class GoblinController : EnemyController {

    
    protected override void SetactionDC() {
        actionDC = 3f;
        staminaAIActivate = 0.25f;
    }
    protected override void ActionAIModuleCalc(CharState targetState) {
        myActions = ReturnActionArray();
        int myIndex = -101;
        int maxValue = 0;
        switch (targetState) {
            case CharState.HAttack:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 25;
                myActions[(int)Actions.LDefend] += 75;
                myActions[(int)Actions.LSpecial] += 5;
                myActions[(int)Actions.Nothing] += 5;
                break;

            case CharState.HDefend:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 25;
                myActions[(int)Actions.LDefend] += -15;
                myActions[(int)Actions.LSpecial] += 50;
                myActions[(int)Actions.Nothing] += 25;
                break;

            case CharState.HSpecial:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 50;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 25;
                myActions[(int)Actions.Nothing] += 25;
                break;

            case CharState.LAttack:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 5;
                myActions[(int)Actions.LDefend] += 50;
                myActions[(int)Actions.LSpecial] += 5;
                myActions[(int)Actions.Nothing] += 5;
                break;

            case CharState.LDefend:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 10;
                myActions[(int)Actions.LDefend] += 5;
                myActions[(int)Actions.LSpecial] += 25;
                myActions[(int)Actions.Nothing] += 50;
                break;

            case CharState.LSpecial:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 50;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 25;
                myActions[(int)Actions.Nothing] += 25;
                break;

            case CharState.Normal:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 75;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 25;
                myActions[(int)Actions.Nothing] += 5;
                break;

            case CharState.Stunned:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 75;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 10;
                myActions[(int)Actions.Nothing] += -25;
                break;

            default:
                Debug.LogError("targetState is out of bounds!");
                break;
        }

        myActions[(int)Actions.HAttack] += -101;
        myActions[(int)Actions.HDefend] += -101;
        myActions[(int)Actions.HSpecial] += -101;
        for (int i = 0; i < (int)Actions.numEntries; i++) {
            if (myActions[i] > maxValue) {
                maxValue = myActions[i];
                myIndex = i;
            }
        }
        // output result
        if (myIndex >= 0) {
            switch (myIndex) {
                case (int)Actions.LAttack:
                    LightAttack();
                    break;

                case (int)Actions.LDefend:
                    LightDefend();
                    break;

                case (int)Actions.LSpecial:
                    LightSpecial();
                    break;

                case (int)Actions.Nothing:
                    Debug.Log(gameObject.name + " is lazing about..!");
                    break;

                default:
                    Debug.LogError(gameObject.name + " is doing something mysterious...?");
                    break;
            }
        }
    }

    public override void DamageTargetStamina(int stamina) {
        int stamDamage = stamina;
        if (myCS.GetState() == CharState.LSpecial) {
            switch (targetCS.GetState()) {
                case CharState.HAttack:

                    break;

                case CharState.HDefend:
                    stamDamage *= 50;
                    break;

                case CharState.HSpecial:
                    stamDamage *= 50;
                    break;

                case CharState.LAttack:

                    break;

                case CharState.LDefend:

                    break;

                case CharState.LSpecial:

                    break;

                case CharState.Normal:

                    break;

                case CharState.Stunned:

                    break;

                default:
                    Debug.LogError("targetState is out of bounds!");
                    break;
            }
        }
        targetCS.DamageStamina(stamDamage);
    }

    public override void StartHeavyAttack() {
        //null
    }

    public override void EndHeavyAttack() {
        //null
    }

    public override void StartHeavyDefend() {
        //null
    }

    public override void EndHeavyDefend() {
        //null
    }

    public override void StartHeavySpecial() {
        //null
    }

    public override void EndHeavySpecial() {
        //null
    }
}
