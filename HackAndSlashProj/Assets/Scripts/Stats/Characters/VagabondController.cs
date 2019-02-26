using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats), typeof(Animator))]
public class VagabondController : PlayerController
{
    public override void LightAttack() {
        Debug.Log("Performed LightAttack");
        //start animation
    }

    public override void StartHeavyAttack() {
        Debug.Log("Performed StartHeavyAttack");
        //start and freeze animation
    }

    public override void EndHeavyAttack() {
        Debug.Log("Performed EndHeavyAttack");
        //unfreeze animation
    }

    public override void LightDefend() {
        Debug.Log("Performed LightDefend");
        //start animation
    }

    public override void StartHeavyDefend() {
        Debug.Log("Performed StartHeavyDefend");
        //start and freeze animation
    }

    public override void EndHeavyDefend() {
        Debug.Log("Performed EndHeavyDefend");
        //unfreeze animation
    }

    public override void LightSpecial() {
        Debug.Log("Performed LightSpecial");
        //start animation
    }

    public override void StartHeavySpecial() {
        Debug.Log("Performed StartHeavySpecial");
        //start and freeze animation
    }

    public override void EndHeavySpecial() {
        Debug.Log("Performed EndHeavySpecial");
        //unfreeze animation
    }

    public override void Stagger() {
        Debug.Log("Performed Stagger");
        //start animation
    }
}
