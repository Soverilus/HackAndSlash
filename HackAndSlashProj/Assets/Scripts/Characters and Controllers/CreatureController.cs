using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GAV.GlobalCharacterVariables;
public class CreatureController : MonoBehaviour
{
    protected Animator myAnim;
    protected CharacterStats myCS;
    [SerializeField]
    protected CharacterStats targetCS;

    protected void Start() {
        myAnim = GetComponent<Animator>();
        myCS = GetComponent<CharacterStats>();
        targetCS = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterStats>();
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
