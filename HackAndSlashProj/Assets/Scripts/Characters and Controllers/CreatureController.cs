using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
//this class holds all of the basic globally necessary creature behaviours - Players and Enemies alike
public class CreatureController : MonoBehaviour
{
    protected Animator myAnim;
    protected CharacterStats myCS;
    [SerializeField]
    protected CharacterStats targetCS;

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
        myCS.DamageStamina(staminaAmount);
    }

    //USE THIS TO DETERMINE DAMAGE DEALT BY AN ABILITY ON ANIMATION FRAME
    public virtual void DamageTarget(int zeroForLight) {
        if (zeroForLight != 0) {
            targetCS.Damaged(myCS.baseDamage + chargeLv * 10, gameObject);
            EndHeavyAttack();
        }
        else {
            targetCS.Damaged(myCS.baseDamage, gameObject);
        }
        chargeLv = 1;
        myCS.ChangeState(CharState.Normal);
    }

    public virtual void LightAttack() {
       
    }

    public virtual void StartHeavyAttack() {
        
    }

    public virtual void EndHeavyAttack() {
        
    }

    public virtual void LightDefend() {
        
    }

    public virtual void StartHeavyDefend() {
        
    }

    public virtual void EndHeavyDefend() {
       
    }

    public virtual void LightSpecial() {
        
    }

    public virtual void StartHeavySpecial() {
        
    }

    public virtual void EndHeavySpecial() {
        
    }

    public virtual void Stagger() {
        
    }
}
