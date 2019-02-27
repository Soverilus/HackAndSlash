using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class exists only to hold all enemy character controllers AS WELL AS creating the basic AI structure for said enemy character controllers.
public class EnemyController : CreatureController
{
    protected float myTimer;
    protected float actionDC;

    protected virtual void SetactionDC() {
        actionDC = 6f;
    }
    private void Update() {
        CoreAIModule();
    }

    void CoreAIModule() {
        if (myCS != null) {
            if (targetCS != null) {
                int myStamina = myCS.GetStamina();
                int maxStamina = myCS.GetMaxStamina();
                if (myStamina == maxStamina) {
                    myTimer += Time.deltaTime*6f;
                }
                if (myStamina < maxStamina && myStamina > 0f) {
                    myTimer += Time.deltaTime;
                }
                if (myTimer+Random.Range(0.01f,5f) >= actionDC) {
                    ActionAIModule();
                }
            }
            else targetCS = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        }
        else myCS = GetComponent<CharacterStats>();
    }

    protected virtual void ActionAIModule() {
        //attemmpt actions in here - should not work if in the middle of a previous action. can only be done when an animation is idle
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
