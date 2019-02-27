using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats), typeof(Animator))]
public class VagabondController : PlayerController {

    public override void LightAttack() {
        Debug.Log(gameObject.name + " Performed LightAttack");
        //start animation
    }

    public override void StartHeavyAttack() {
        Debug.Log(gameObject.name + " Performed StartHeavyAttack");
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public override void EndHeavyAttack() {
        Debug.Log(gameObject.name + " Performed EndHeavyAttack");
        //unfreeze animation
    }

    public override void LightDefend() {
        Debug.Log(gameObject.name + " Performed LightDefend");
        //start animation
    }

    public override void StartHeavyDefend() {
        Debug.Log(gameObject.name + " Performed StartHeavyDefend");
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public override void EndHeavyDefend() {
        Debug.Log(gameObject.name + " Performed EndHeavyDefend");
        //unfreeze animation
    }

    public override void LightSpecial() {
        Debug.Log(gameObject.name + " Performed LightSpecial");
        //start animation
    }

    public override void StartHeavySpecial() {
        Debug.Log(gameObject.name + " Performed StartHeavySpecial");
        //start and freeze animation
        //chare up action (with feedback for full and partial charge)
    }

    public override void EndHeavySpecial() {
        Debug.Log(gameObject.name + " Performed EndHeavySpecial");
        //unfreeze animation
    }

    public override void Stagger() {
        Debug.Log(gameObject.name + " Performed Stagger");
        //start animation
    }
}

/*
 * I need to set up an animator that allows me to use these, as well as allowing 
 * for taking damage from myCS and inputting it depending on which type of attack 
 * it is - perhaps determined by the animation itself: however I'd like to be able 
 * to set up the amount of damage and what type of damage is taken via script
 */ 
