using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (CreatureController))]
public class CharacterStats : MonoBehaviour
{
    public enum MyState { Norm, Vulnerable, LAttack, HAttack, LDefend, HDefend, LSpecial, HSpecial }
    MyState myState = MyState.Norm;

    int maxHealth;
    int health;
    int maxStamina;
    int stamina;

    private void Start() {
        GetComponent<CharacterController>();
    }

    public void ChangeState(MyState state) {
        myState = state;
    }

    public void Damaged(int damage) {
        switch (myState) {
            case MyState.Norm:
                health -= Mathf.Abs(damage);
                break;

            case MyState.Vulnerable:
                health -= Mathf.Abs(damage * 2);
                break;

            case MyState.LAttack:
                LAttackDamage(damage);
                break;

            case MyState.HAttack:
                HAttackDamage(damage);
                break;

            case MyState.LDefend:
                LDefendDamage(damage);
                break;

            case MyState.HDefend:
                HDefendDamage(damage);
                break;

            case MyState.LSpecial:
                LSpecialDamage(damage);
                break;

            case MyState.HSpecial:
                HSpecialDamage(damage);
                break;

            default:
                health -= Mathf.Abs(damage);
                break;
        }
    }

    protected virtual void LAttackDamage(int damage) { }
    protected virtual void HAttackDamage(int damage) { }
    protected virtual void LDefendDamage(int damage) { }
    protected virtual void HDefendDamage(int damage) { }
    protected virtual void LSpecialDamage(int damage) { }
    protected virtual void HSpecialDamage(int damage) { }
}
