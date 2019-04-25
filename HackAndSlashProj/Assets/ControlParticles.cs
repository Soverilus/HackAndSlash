using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParticles : MonoBehaviour {
    SpriteRenderer myRend;
    public GameObject[] myParticles;
    private void Start() {
        myRend = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if (myRend.color.a > 0f) {
            Time.timeScale = Mathf.Clamp(myRend.color.a, 0, 1);
            for (int i = 0; i < myParticles.Length; i++) {
                myParticles[i].SetActive(true);
            }
        }
        else {
            for (int i = 0; i < myParticles.Length; i++) {
                myParticles[i].SetActive(false);
            }
        }
    }
}
