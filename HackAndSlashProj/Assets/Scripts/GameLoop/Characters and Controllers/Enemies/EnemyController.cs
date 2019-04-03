using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
//this class exists only to hold all enemy character controllers AS WELL AS creating the basic AI structure for said enemy character controllers to override if needed.
public class EnemyController : CreatureController {
    protected enum Actions {
        Nothing, LAttack, HAttack, LDefend, HDefend, LSpecial, HSpecial,
        numEntries // we use this as marker for the number of entries
    }
    protected float chanceToDoNothing;
    protected int[] myActions;
    protected float myTimer;
    protected float actionDC;
    bool AIEnabled = true;
    float AIActiveTimer = 0f;
    protected float staminaAIActivate;

    protected virtual void SetactionDC() {
        //Time before the AI attempts another action
        //override this to increase enemy AI attack speed
        actionDC = 10f;
    }

    protected override void Start() {
        base.Start();
        SetactionDC();
    }

    void Update() {
        CoreAIModule();
    }

    void CoreAIModule() {
        if (myCS != null) {
            if (targetCS != null && myCS.GetHealth() > 0) {
                int myStamina = myCS.GetStamina();
                int maxStamina = myCS.GetMaxStamina();
                if (myStamina == maxStamina) {
                    myTimer += Time.deltaTime * actionDC;
                }
                if (myStamina < maxStamina && myStamina > 0f) {
                    if (myStamina > staminaAIActivate * maxStamina) {
                        myTimer += Time.deltaTime;
                    }
                    if (myStamina <= staminaAIActivate * maxStamina) {
                        myTimer += 0.1f * Time.deltaTime;
                    }
                }
                if (myTimer + Random.Range(0.01f, 0.5f * actionDC) >= actionDC && AIEnabled) {
                    ActionAIModule();
                    //Debug.Log(myTimer);
                    myTimer = 0f;
                    AIActiveTimer += Time.deltaTime;
                }
            }
            else targetCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        }
        else myCS = GetComponent<CharacterStats>();
    }

    public void EnableAI(bool isTrue) {
        AIEnabled = isTrue;
    }

    protected virtual void ActionAIModule() {
        if (myCS.GetState() == CharState.Normal) {
            CharState targetState = targetCS.GetState();
            ActionAIModuleCalc(targetState);
        }
    }

    protected virtual void DoNothingStamina() {
        if (AIActiveTimer >= 0.5f) {
            chanceToDoNothing = (Mathf.Pow(25 + ((float)myCS.Stamina / (float)myCS.MaxStamina) * 100, 2) / -100 + 100);
        }
        else {
            chanceToDoNothing = 200f;
        }
        //Debug.Log(chanceToDoNothing);
    }

    protected virtual void ActionAIModuleCalc(CharState targetState) {
        myActions = ReturnActionArray();
        int myIndex = -101;
        int maxValue = 0;
        switch (targetState) {
            case CharState.HAttack:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.HDefend:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.HSpecial:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.LAttack:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.LDefend:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.LSpecial:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.Normal:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            case CharState.Stunned:
                myActions[(int)Actions.HAttack] += 0;
                myActions[(int)Actions.HDefend] += 0;
                myActions[(int)Actions.HSpecial] += 0;
                myActions[(int)Actions.LAttack] += 0;
                myActions[(int)Actions.LDefend] += 0;
                myActions[(int)Actions.LSpecial] += 0;
                myActions[(int)Actions.Nothing] += 0;
                break;

            default:
                //Debug.LogError("targetState is out of bounds!");
                break;
        }
        DoNothingStamina();
        myActions[(int)Actions.Nothing] += Mathf.RoundToInt(chanceToDoNothing*100);
        for (int i = 0; i < (int)Actions.numEntries; i++) {
            if (myActions[i] > maxValue) {
                maxValue = myActions[i];
                myIndex = i;
            }
        }

        // output result
        if (myIndex >= 0) {
            switch (myIndex) {
                case (int)Actions.HAttack:
                    StartHeavyAttack();
                    //Debug.Log(gameObject + " has performed a StartHeavyAttack");
                    break;

                case (int)Actions.HDefend:
                    StartHeavyDefend();
                    //Debug.Log(gameObject + " has performed a StartHeavyDefend");
                    break;

                case (int)Actions.HSpecial:
                    StartHeavySpecial();
                    //Debug.Log(gameObject + " has performed a StartHeavySpecial");
                    break;

                case (int)Actions.LAttack:
                    LightAttack();
                    //Debug.Log(gameObject + " has performed a LightAttack");
                    break;

                case (int)Actions.LDefend:
                    LightDefend();
                    // Debug.Log(gameObject + " has performed a LightDefend");
                    break;

                case (int)Actions.LSpecial:
                    LightSpecial();
                    // Debug.Log(gameObject + " has performed a LightSpecial");
                    break;

                case (int)Actions.Nothing:
                    // Debug.Log(gameObject + " is lazing about..!");
                    break;

                default:
                    break;
            }
        }
    }

    protected virtual int[] ReturnActionArray() {
        int[] myArray;
        myArray = new int[(int)Actions.numEntries];
        for (int i = 0; i < myArray.Length; i++) {
            myArray[i] = Random.Range(0, 101);
        }
        return myArray;
    }
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

    public override void StartHeavySpecial() {

    }      

    public override void EndHeavySpecial() {

    }      

    public override void Stagger() {

    }
    */
}
