using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
[RequireComponent(typeof(CreatureController))]
public class CharacterStats : MonoBehaviour {
    CharState myState = CharState.Normal;

    protected int maxHealth;
    protected int health;
    protected int maxStamina;
    protected int stamina;

    private void Start() {
        GetComponent<CharacterController>();
    }

    public void ChangeState(CharState state) {
        myState = state;
        SettleStats();
    }

    public CharState GetState() {
        return myState;
    }

    void SettleStats() {
        if (maxHealth <= 0 || maxStamina <= 0) {
            SetMaxHealth();
            SetMaxStamina();
            health = maxHealth;
            stamina = maxStamina;
        }
    }

    public int GetMaxHealth() {
        return maxHealth;
    }
    public int GetMaxStamina() {
        return maxStamina;
    }
    public int GetHealth() {
        return health;
    }
    public int GetStamina() {
        return stamina;
    }

    public virtual void SetMaxHealth() {
        maxHealth = 1;
    }
    public virtual void SetMaxStamina() {
        maxStamina = 1;
    }
    //protected virtual void SetHealth() { }
    //protected virtual void SetStamina() { }

    //myAttacker is for potential counter damage
    public void Damaged(int damage, GameObject myAttacker) {
        switch (myState) {
            case CharState.Normal:
                health -= Mathf.Abs(damage);
                break;

            case CharState.Stunned:
                health -= Mathf.Abs(damage * 3);
                break;

            case CharState.LAttack:
                LAttackDamage(damage, myAttacker);
                break;

            case CharState.HAttack:
                HAttackDamage(damage, myAttacker);
                break;

            case CharState.LDefend:
                LDefendDamage(damage, myAttacker);
                break;

            case CharState.HDefend:
                HDefendDamage(damage, myAttacker);
                break;

            case CharState.LSpecial:
                LSpecialDamage(damage, myAttacker);
                break;

            case CharState.HSpecial:
                HSpecialDamage(damage, myAttacker);
                break;

            default:
                health -= Mathf.Abs(damage);
                break;
        }
    }

    protected virtual void LAttackDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
    }
    protected virtual void HAttackDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
    }
    protected virtual void LDefendDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
    }
    protected virtual void HDefendDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
    }
    protected virtual void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
    }
    protected virtual void HSpecialDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
    }
}
