using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAV;
public class OnActionPress : MonoBehaviour {
    float width;
    float actTimer = Mathf.Abs(GlobalActionVariables.myActivationTime);
    float timer;
    bool timerStarted = false;
    TouchPhase rightPhase;
    TouchPhase leftPhase;
    bool isHeld;

    bool rightActive;
    bool leftActive;

    void Start() {
        timer = actTimer;
        width = Screen.width / 2f;
    }

    void Update() {
        GetInpTouch();
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            WhichSideCheck();
        }
    }

    void WhichSideCheck() {
        if (rightActive || leftActive) {
            if (rightActive && leftActive) {
                if ((rightPhase == TouchPhase.Stationary || rightPhase == TouchPhase.Moved) &&
                    (leftPhase == TouchPhase.Stationary || leftPhase == TouchPhase.Moved)) {
                    if (!isHeld) {
                        BothSidesTouched(true);
                    }
                }
                else if ((rightPhase == TouchPhase.Canceled || rightPhase == TouchPhase.Ended) ||
                    (leftPhase == TouchPhase.Canceled || leftPhase == TouchPhase.Ended)) {
                    if (isHeld) {
                        BothSidesTouched(true);
                    }
                }
                else {
                    BothSidesTouched(false);
                }
            }
            else if (rightActive) {
                if (rightPhase == TouchPhase.Stationary || rightPhase == TouchPhase.Moved) {
                    if (!isHeld) {
                        RightSideTouched(true);
                    }
                }
                else if (rightPhase == TouchPhase.Canceled || rightPhase == TouchPhase.Ended) {
                    if (isHeld) {
                        RightSideTouched(true);
                    }
                }
                else {
                    RightSideTouched(false);
                }
            }
            else if (leftActive) {
                if (leftPhase == TouchPhase.Stationary || leftPhase == TouchPhase.Moved) {
                    if (!isHeld) {
                        LeftSideTouched(true);
                    }
                }
                else if (leftPhase == TouchPhase.Canceled || leftPhase == TouchPhase.Ended) {
                    if (isHeld) {
                        LeftSideTouched(true);
                    }
                }
                else {
                    LeftSideTouched(false);
                }
            }
        }
    }

    void OnRightPress(bool right, TouchPhase myPhase) {
        if (right && timer > 0f) {
            rightPhase = myPhase;
            if (myPhase == TouchPhase.Began) {
                timerStarted = true;
                rightActive = true;
            }
        }
        if (!right && timer > 0f) {
            leftPhase = myPhase;
            if (myPhase == TouchPhase.Began) {
                timerStarted = true;
                leftActive = true;
            }
        }
    }

    void GetInpTouch() {
        for (int i = 0; i < Input.touches.Length; i++) {
            if (Input.touches[i].position.x >= width) {
                OnRightPress(true, Input.touches[i].phase);
            }

            else if (Input.touches[i].position.x < width) {
                OnRightPress(false, Input.touches[i].phase);
            }
        }
    }

    void RightSideTouched(bool held) {
        if (held) {
            //what info do I need for a heavy attack charge?
            //need:
            if (!isHeld) {
                //Start call
                isHeld = true;
            }
            if (isHeld) {
                //End call
                rightActive = false;
            }
        }
        else {
            //one time call
            rightActive = false;
        }
    }
    void LeftSideTouched(bool held) {
        if (held) {
            //what info do I need for a heavy defend charge?
            //need:
            if (!isHeld) {
                //Start call
                isHeld = true;
            }
            if (isHeld) {
                //End call
                leftActive = false;
            }
        }
        else {
            //one time call
            leftActive = false;
        }
    }
    void BothSidesTouched(bool held) {
        if (held) {
            //what info do I need for a heavy special charge?
            //need:
            if (!isHeld) {
                //Start call
                isHeld = true;
            }
            if (isHeld) {
                //End call
                rightActive = false;
                leftActive = false;
            }
        }
        else {
            //one time call
            rightActive = false;
            leftActive = false;
        }
    }
}
