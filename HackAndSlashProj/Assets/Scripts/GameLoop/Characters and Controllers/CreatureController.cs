using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
//this class holds all of the basic globally necessary creature behaviours - Players and Enemies alike
public class CreatureController : MonoBehaviour {
    public Animator myAnim;
    protected CharacterStats myCS;
    [SerializeField]
    protected CharacterStats targetCS;
    protected int myStamBoundary = 1;

    protected virtual void Start() {
        myAnim = GetComponent<Animator>();
        myCS = GetComponent<CharacterStats>();

    }
    protected virtual void Staggerable(bool isBool) {
        if (isBool) {
            myAnim.SetBool("Staggerable", true);
        }
        else {
            myAnim.SetBool("Staggerable", false);
        }
    }
    protected int chargeLv = 1;
    protected int maxChargeLv = 5;

    public virtual void HeavyChargeInc() {
        Mathf.Clamp(chargeLv += 1, 1, maxChargeLv);
        if (chargeLv >= maxChargeLv) {
            myAnim.SetBool("HAttack", false);
        }
    }

    //USE THIS IN ANIMATOR FRAMES AS A FUNCTION TO DETERMINE ABILITY STAMINA COST
    public virtual void StaminaCost(int staminaAmount) {
        myCS.StaminaCost(staminaAmount);
    }

    //USE THIS IN ANIMATOR FRAMES AS A FUNCTION TO DETERMINE STAMINA DAMAGE
    public virtual void DamageTargetStamina(int stamina) {
        int stamDamage = stamina;
        switch (targetCS.GetState()) {
            case CharState.HAttack:

                break;

            case CharState.HDefend:

                break;

            case CharState.HSpecial:

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
        targetCS.DamageStamina(stamDamage);
    }

    //USE THIS TO DETERMINE DAMAGE DEALT BY AN ABILITY ON ANIMATION FRAME
    public virtual void DamageTarget(float percentageDamage) {
        targetCS.Damaged(Mathf.RoundToInt(myCS.baseDamage * chargeLv * percentageDamage), gameObject);
        EndHeavyAttack();
        chargeLv = 1;
    }

    public virtual void LightAttack() {
        //Debug.Log(gameObject.name + " Performed LightAttack");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetTrigger("LAttack");
        }
        //start animation
    }

    public virtual void StartHeavyAttack() {
        //Debug.Log(gameObject.name + " Performed StartHeavyAttack");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetBool("HAttack", true);
        }
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public virtual void EndHeavyAttack() {
        // Debug.Log(gameObject.name + " Performed EndHeavyAttack");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetBool("HAttack", false);
        }
        //unfreeze animation
    }

    public virtual void LightDefend() {
        //Debug.Log(gameObject.name + " Performed LightDefend");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetTrigger("LDefend");
        }
        //start animation
    }

    public virtual void StartHeavyDefend() {
        //Debug.Log(gameObject.name + " Performed StartHeavyDefend");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetBool("HDefend", true);
        }
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public virtual void EndHeavyDefend() {
        //Debug.Log(gameObject.name + " Performed EndHeavyDefend");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetBool("HDefend", false);
        }
        //unfreeze animation
    }

    public virtual void LightSpecial() {
        // Debug.Log(gameObject.name + " Performed LightSpecial");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetTrigger("LSpecial");
        }
        //start animation
    }

    public virtual void StartHeavySpecial() {
        //Debug.Log(gameObject.name + " Performed StartHeavySpecial");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetBool("HSpecial", true);
        }
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public virtual void EndHeavySpecial() {
        //Debug.Log(gameObject.name + " Performed EndHeavySpecial");
        if (myStamBoundary <= myCS.GetStamina()) {
            myAnim.SetBool("HSpecial", false);
        }
        //unfreeze animation
    }

    public virtual void Stagger() {
        //Debug.Log(gameObject.name + " Performed Stagger");
        if (myCS.GetState() != CharState.Stunned) {
            myCS.ChangeState(CharState.Stunned);
            ResetForStunned();
            myAnim.SetTrigger("Stunned");
        }
        //start animation
    }

    public virtual void ResetForStunned() {
        string[] myTriggers = new string[] { "HSpecial", "LSpecial", "HDefend", "LDefend", "HAttack", "LAttack" };
        for (int i = 0; i < myTriggers.Length; i++) {
            myAnim.ResetTrigger(myTriggers[i]);
        }
    }
}
