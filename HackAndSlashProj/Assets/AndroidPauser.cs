using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class AndroidPauser : MonoBehaviour
{
    bool isAndroid;
    public GameObject entireScene;
    private void Start() {
#if UNITY_ANDROID
        isAndroid = true;
#else
        isAndroid = false;
#endif

        if (!isAndroid) {
            Destroy(gameObject);
        }
    }

    private void OnApplicationFocus(bool focus) {
        if (isAndroid) {
            entireScene.SetActive(false);
        }
    }

    private void Update() {
        if (isAndroid) {
            for (int i = 0; i < Input.touches.Length; i++) {
                TouchPhase myTP = Input.touches[i].phase;
                if (myTP == TouchPhase.Began ||
                    myTP == TouchPhase.Moved ||
                    myTP == TouchPhase.Stationary) {
                    entireScene.SetActive(true);
                }
            }
        }
    }
}
