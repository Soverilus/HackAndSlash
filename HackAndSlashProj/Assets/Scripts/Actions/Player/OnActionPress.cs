using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAV;
public class OnActionPress : MonoBehaviour {
    [SerializeField] bool isUsingAndroid = true;
    [Space(20f)]
    [Header("Misc Attributes")]
    [SerializeField] float timer;
    [SerializeField] float width;
    [SerializeField] float actTimer = Mathf.Abs(GlobalActionVariables.myActivationTime);

    [SerializeField] bool timerStarted = false;
    [SerializeField] TouchPhase rightPhase;
    [SerializeField] TouchPhase leftPhase;
    [SerializeField] bool isHeld;

    [SerializeField] bool rightActive;
    [SerializeField] bool leftActive;

    void Start() {
        timer = actTimer;
        width = Screen.width / 2f;
    }

    void Update() {
        if (isUsingAndroid) {
            GetInpTouch();
        }
        else {
            GetInpPress();
        }
        if (timerStarted) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f) {
            WhichSideTouch();
        }
    }

    void GetInpTouch() {
        for (int i = 0; i < Input.touches.Length; i++) {
            if (Input.touches[i].position.x >= width) {
                OnRightTouch(true, Input.touches[i].phase);
            }

            else if (Input.touches[i].position.x < width) {
                OnRightTouch(false, Input.touches[i].phase);
            }
        }
    }

    void GetInpPress() {
        if (Input.GetMouseButtonDown(0)) {
            OnRightTouch(false, TouchPhase.Began);
        }
        if (Input.GetMouseButtonUp(0)) {
            OnRightTouch(false, TouchPhase.Ended);
        }
        if (Input.GetMouseButton(0)) {
            OnRightTouch(false, TouchPhase.Stationary);
        }
        if (Input.GetMouseButtonDown(1)) {
            OnRightTouch(true, TouchPhase.Began);
        }
        if (Input.GetMouseButtonUp(1)) {
            OnRightTouch(true, TouchPhase.Ended);
        }
        if (Input.GetMouseButton(1)) {
            OnRightTouch(true, TouchPhase.Stationary);
        }
    }

    void OnRightTouch(bool right, TouchPhase myPhase) {
        if (right) {
            rightPhase = myPhase;
            if (timer > 0f) {
                if (myPhase == TouchPhase.Began) {
                    timerStarted = true;
                    rightActive = true;
                }
                if ((myPhase == TouchPhase.Ended || myPhase == TouchPhase.Canceled) && leftActive) {
                    rightActive = false;
                }
            }

        }
        if (!right) {
            leftPhase = myPhase;
            if (timer > 0f) {
                if (myPhase == TouchPhase.Began) {
                    timerStarted = true;
                    leftActive = true;
                }
                if ((myPhase == TouchPhase.Ended || myPhase == TouchPhase.Canceled) && rightActive) {
                    leftActive = false;
                }
            }
        }
    }

    void WhichSideTouch() {
        if (rightActive || leftActive) {
            if (rightActive && leftActive) {
                if ((rightPhase == TouchPhase.Stationary || rightPhase == TouchPhase.Moved) &&
                    (leftPhase == TouchPhase.Stationary || leftPhase == TouchPhase.Moved)) {
                    if (!isHeld) {
                        BothSidesTouched(true, false);
                    }
                }
                else if ((rightPhase == TouchPhase.Canceled || rightPhase == TouchPhase.Ended) ||
                    (leftPhase == TouchPhase.Canceled || leftPhase == TouchPhase.Ended)) {
                    if (isHeld) {
                        BothSidesTouched(true, true);
                    }
                    else {
                        BothSidesTouched(false, false);
                    }
                }
            }
            else if (rightActive) {
                if (rightPhase == TouchPhase.Stationary || rightPhase == TouchPhase.Moved) {
                    if (!isHeld) {
                        RightSideTouched(true, false);
                    }
                }
                else if (rightPhase == TouchPhase.Canceled || rightPhase == TouchPhase.Ended) {
                    if (isHeld) {
                        RightSideTouched(true, true);
                    }
                    else {
                        RightSideTouched(false, false);
                    }
                }
            }
            else if (leftActive) {
                if (leftPhase == TouchPhase.Stationary || leftPhase == TouchPhase.Moved) {
                    if (!isHeld) {
                        LeftSideTouched(true, false);
                    }
                }
                else if (leftPhase == TouchPhase.Canceled || leftPhase == TouchPhase.Ended) {
                    if (isHeld) {
                        LeftSideTouched(true, true);
                    }
                    else {
                        LeftSideTouched(false, false);
                    }
                }
            }
        }
        else {
            ResetAction();
        }
    }

    void RightSideTouched(bool held, bool end) {
        if (held) {
            //what info do I need for a heavy attack charge?
            //need:
            if (!isHeld) {
                //Start call
                Debug.Log("Start Right");
                isHeld = true;
            }
            if (isHeld && end) {
                //End call
                Debug.Log("End Right");
                ResetAction();
                rightActive = false;
            }
        }
        else {
            //one time call
            Debug.Log("Light Right");
            ResetAction();
            rightActive = false;
        }
    }
    void LeftSideTouched(bool held, bool end) {
        if (held) {
            //what info do I need for a heavy defend charge?
            //need:
            if (!isHeld) {
                //Start call
                Debug.Log("Start Left");
                isHeld = true;
            }
            if (isHeld && end) {
                //End call
                Debug.Log("End Left");
                ResetAction();
                leftActive = false;
            }
        }
        else {
            //one time call
            Debug.Log("Light Left");
            ResetAction();
            leftActive = false;
        }
    }
    void BothSidesTouched(bool held, bool end) {
        if (held) {
            //what info do I need for a heavy special charge?
            //need:
            if (!isHeld) {
                //Start call
                Debug.Log("Start Both");
                isHeld = true;
            }
            if (isHeld && end) {
                //End call
                Debug.Log("End Both");
                rightActive = false;
                leftActive = false;
                ResetAction();
            }
        }
        else {
            //one time call
            Debug.Log("Light Both");
            rightActive = false;
            leftActive = false;
            ResetAction();
        }
    }

    void ResetAction() {
        timerStarted = false;
        timer = actTimer;
        rightPhase = TouchPhase.Began;
        leftPhase = TouchPhase.Began;
        isHeld = false;
    }
}
