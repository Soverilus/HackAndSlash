using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVariables;
using static GlobalVariables.GVSkills;

public class PlayerController : MonoBehaviour {
    [Header("Misc")]
    public Animator myAnim;
    int skillUsed = 0;

    [HideInInspector]
    public bool skillLock = false;

    int oldSkillUsed = -999;
    float skillTimer;

    void Start() {
        activationTime = 0.5f;
    }

    void Update() {
        SkillInputs();
        SkillController();
    }

    void SkillController() {
        switch (skillUsed) {
            case 1:
                //attack
                Debug.Log("AttackStart");
                if (Input.GetAxis("Fire1") > 0) {
                    myAnim.SetTrigger("SwitchToAttack");
                    //damage build up ++
                    //flash every time you build up damage
                }
                else {
                    myAnim.speed = 1;
                }
                /*
                 * on Animaton finish, set skillLock to false and deal damage
                */
                break;

            case 2:
                //defend
                Debug.Log("DefendStart");
                if (Input.GetAxis("Fire2") > 0) {
                    myAnim.SetTrigger("SwitchToDefend");
                    /*
                     * start Defend animation, set state to "Defending"
                     * freeze on first frame of animation
                     * play rest of animation on button release
                     * on Animaton finish, set skillLock to false
                    */
                }
                    break;

            case 3:
                //special
                Debug.Log("SpecialStart");
                /*
                 * start attack animation, set state to "Special"
                 * special effect
                 * on Animaton finish, set skillLock to false
                */
                break;

            default:
                //do nothing
                break;
        }
    }

    void SkillInputs() {
        if (!skillLock) {
            if (Input.GetAxis("Fire1") > 0) {
                skillUsed = 1;
            }
            else if (Input.GetAxis("Fire2") > 0) {
                skillUsed = 2;
            }
            else if (Input.GetAxis("Fire1") > 0 && Input.GetAxis("Fire2") > 0) {
                skillUsed = 3;
                skillLock = true;
            }
            else {
                skillUsed = 0;
            }
            if (oldSkillUsed == skillUsed) {
                if (skillUsed != 0) {
                    skillTimer += Time.deltaTime;
                }
            }
            else {
                skillTimer = 0;
            }
            oldSkillUsed = skillUsed;
            SkillLockCheck();
        }
    }

    void SkillLockCheck() {
        switch (skillUsed) {
            case 1:
            case 2:
            case 3:
                if (skillTimer >= activationTime) {
                    skillLock = true;
                }
                break;

            default:

                break;
        }
    }
}
