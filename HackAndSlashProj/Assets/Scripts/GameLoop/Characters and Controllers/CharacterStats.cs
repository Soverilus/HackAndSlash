using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
[RequireComponent(typeof(CreatureController))]
public class CharacterStats : MonoBehaviour {
    CharState myState = CharState.Normal;
    protected int maxHealth;
    [SerializeField]
    protected int health;
    protected int maxStamina;
    [SerializeField]
    protected int stamina;
    public float staminaRegMult = 10f;
    protected float equivStamina;
    protected float staminaRegTimer = 3f;
    float timer;
    public int baseDamage;
    protected CreatureController myCC;
    public bool isDead = false;

    private void Start() {
        StartAlt();
        myCC = GetComponent<CreatureController>();
        SettleStats();
        LateStartAlt();
    }

    protected virtual void StartAlt() {
        //this has been left empty on purpose
    }

    protected virtual void LateStartAlt() {
        //this has been left empty on purpose
    }

    public void SetHealth(int myHealth) {
        health = myHealth;
    }
    public void EnumFromString(string myString) {
        CharState newState = (CharState)System.Enum.Parse(typeof(CharState), myString);
        myState = newState;
    }
    public void ResetState() {
        myState = CharState.Normal;
    }
    public void ChangeState(CharState state) {
        myState = state;
    }
    protected virtual void Update() {
        if (health > maxHealth) {
            health = maxHealth;
        }
        if (equivStamina > maxStamina) {
            equivStamina = maxStamina;
        }
        stamina = Mathf.FloorToInt(equivStamina);
        if (stamina < maxStamina) {
            if (timer < staminaRegTimer) {
                timer += Time.deltaTime;
            }
            if (timer >= staminaRegTimer) {
                myCC.myAnim.ResetTrigger("Stunned");
                equivStamina += staminaRegMult * Time.deltaTime;
            }
        }
    }
    public CharState GetState() {
        return myState;
    }

    void SettleStats() {
        if (health <= 0 || stamina <= 0) {
            health = maxHealth;
            stamina = maxStamina;
            equivStamina = maxStamina;
        }
        if (maxHealth <= 0 || maxStamina <= 0) {
            SetMaxHealth();
            SetMaxStamina();
            SetBaseDamage();
            health = maxHealth;
            stamina = maxStamina;
            equivStamina = maxStamina;
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
        maxHealth = 150;
    }
    public virtual void SetMaxStamina() {
        maxStamina = 100;
    }
    public virtual void SetBaseDamage() {
        baseDamage = 25;
    }
    public void HealStam(int stamAmount) {
        equivStamina += Mathf.Abs(stamAmount);
    }
    public void Heal(int HPamount) {
        health += Mathf.Abs(HPamount);
    }
    //myAttacker is for potential counter damage
    public virtual void DamageStamina(int damage) {
        stamina -= damage;
        equivStamina -= damage;
        if (equivStamina <= 0) {
            equivStamina = 0;
            myCC.Stagger();
        }
        timer = 0;
    }
    public virtual void StaminaCost(int cost) {
        stamina -= cost;
        equivStamina -= cost;
        if (equivStamina < 0) {
            equivStamina = 0;
        }
        timer = 0;
    }
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
        CheckHealth();
    }

    protected virtual void CheckHealth() {
        if (health <= 0) {
            myCC.myAnim.SetTrigger("Death");
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

    public virtual void HealthPotion() {
        Heal(maxHealth / 2);
    }
    public virtual void StaminaPotion() {
        HealStam(maxStamina);
    }
    public virtual void PowerPotion() {
        baseDamage += 10;
    }
}
