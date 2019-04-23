using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
[RequireComponent(typeof(CreatureController))]
public class CharacterStats : MonoBehaviour {
    protected CharState myState = CharState.Normal;
    protected bool istrueDead = false;
    protected CameraFeedback myCF;
    public SpriteRenderer mySPR;
    protected Color mySPRColor;
    public AudioController myAC;
    protected int previousStamina;
    public int PreviousStamina { get => previousStamina; }
    protected int previousHealth;
    public int PreviousHealth { get => previousHealth; }
    protected int maxHealth;
    [SerializeField]
    protected int health;
    protected int maxStamina;
    public int MaxStamina { get => maxStamina; }
    [SerializeField]
    protected int stamina;
    public int Stamina { get => stamina; }
    public float staminaRegMult = 10f;
    protected float equivStamina;
    protected float staminaRegTimer = 3f;
    protected float timer;
    public int baseDamage;
    protected CreatureController myCC;
    public bool isDead = false;
    protected bool hasStateChanged = false;
    Animator bgAnimator;

    private void Start() {
        StartAlt();
        bgAnimator = GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>();
        myAC = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        mySPR = GetComponent<SpriteRenderer>();
        mySPRColor = mySPR.color;
        myCF = Camera.main.GetComponent<CameraFeedback>();
        myCC = GetComponent<CreatureController>();
        SettleStats();
        previousHealth = health;
        LateStartAlt();
    }
    public virtual void StartingStamina() {
        stamina = Mathf.RoundToInt(0.5f * stamina);
        equivStamina = stamina;
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
        ChangeState(newState);
    }
    public void ResetState() {
        myState = CharState.Normal;
    }
    public void ChangeState(CharState state) {
        myState = state;
        hasStateChanged = true;
    }

    protected virtual void OnStateChange() {
        switch (myState) {
            case CharState.Normal:
                break;

            case CharState.Stunned:
                break;

            case CharState.LAttack:
                break;

            case CharState.HAttack:
                break;

            case CharState.LDefend:
                break;

            case CharState.HDefend:
                break;

            case CharState.LSpecial:
                break;

            case CharState.HSpecial:
                break;

            default:
                break;
        }
        hasStateChanged = false;
    }

    protected virtual void Update() {
            ColorChange();
        if (hasStateChanged) {
            OnStateChange();
        }
        previousStamina = stamina;
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

    void ColorChange() {
        if (mySPRColor != mySPR.color) {
            mySPR.color = Color.Lerp(mySPR.color, mySPRColor, 0.05f);
        }
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
        previousHealth = health;
        health += Mathf.Abs(HPamount);
    }
    //myAttacker is for potential counter damage
    public virtual void DamageStamina(int damage) {
        if (damage <= 0) {
            return;
        }
        bgAnimator.SetTrigger("HIT");
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
    public virtual void Damaged(int damage, GameObject myAttacker) {
        previousHealth = health;
        switch (myState) {
            case CharState.Normal:
                health -= Mathf.Abs(damage);
                NormalDamage(damage, myAttacker);
                break;

            case CharState.Stunned:
                StunnedDamage(damage, myAttacker);
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
        CheckHealthAlt(damage);
        CheckHealth();
    }

    protected virtual void CheckHealth() {
        if (health <= 0) {
            myCC.myAnim.SetTrigger("Death");
            mySPRColor = new Color(0f, 0f, 0f, 0f);
        }
    }

    protected void CheckHealthAlt(float magnitude) {
        if (previousHealth != health) {
            if (health > 0) {
                bgAnimator.SetTrigger("HIT");
                mySPR.color = Color.red;
                myCC.myAnim.SetTrigger("Hurt");
            }
            else {
                bgAnimator.SetTrigger("HIT");
            }
            if (!istrueDead) {
                Time.timeScale = 0f;
                myCF.SetShakeMagnitudeAndDuration(Mathf.Clamp01((magnitude) / 10f), magnitude * 0.15f);
            }
        }
    }

    public void DisableDeath() {
        myCC.myAnim.speed = 0;
        istrueDead = true;
    }

    protected virtual void LAttackDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void HAttackDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void LDefendDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void HDefendDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void LSpecialDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void HSpecialDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void NormalDamage(int damage, GameObject myAttacker) {
        health -= Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
    }
    protected virtual void StunnedDamage(int damage, GameObject myAttacker) {
        health -= 3*Mathf.Abs(damage);
        myAC.PlayAudioClip("HIT");
        myAC.PlayAudioClip("HIT");
    }

    public virtual void HealthPotion() {
        previousHealth = health;
        Heal(maxHealth / 2);
        myAC.PlayAudioClip("POTION", false);
    }
    public virtual void StaminaPotion() {
        HealStam(maxStamina);
        myAC.PlayAudioClip("POTION", false);
    }
    public virtual void PowerPotion() {
        baseDamage += 10;
        myAC.PlayAudioClip("POTION", false);
    }
}