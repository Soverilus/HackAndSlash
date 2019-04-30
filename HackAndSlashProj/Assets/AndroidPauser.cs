using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class AndroidPauser : MonoBehaviour
{
    public GameObject entireScene;
    private void Start() {
        
    }

    private void OnApplicationFocus(bool focus) {
        entireScene.SetActive(false);
    }

    private void Update() {
        for (int i = 0; i < Input.touches.Length; i++) {
            TouchPhase myTP = Input.touches[i].phase;
            if (myTP == TouchPhase.Began||
                myTP == TouchPhase.Moved||
                myTP == TouchPhase.Stationary){
                entireScene.SetActive(true);
            }
        }
    }
}
