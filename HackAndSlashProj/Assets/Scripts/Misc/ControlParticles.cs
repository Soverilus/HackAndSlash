using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParticles : MonoBehaviour {
    SpriteRenderer myRend;
    public GameObject[] myParticles;
    ParticleSystem[] myPartics;
    float[] normalRate;
    private void Start() {
        myPartics = new ParticleSystem[myParticles.Length];
        normalRate = new float[myParticles.Length];
        myRend = GetComponent<SpriteRenderer>();
        for (int i = 0; i < myParticles.Length; i++) {
            myPartics[i] = myParticles[i].GetComponent<ParticleSystem>();
            normalRate[i] = myPartics[i].emission.rateOverTime.constant;
        }
    }
    private void Update() {
        if (myRend.color.a > 0f) {
            Time.timeScale = Mathf.Clamp(myRend.color.a, 0, 1);
            for (int i = 0; i < myParticles.Length; i++) {
                myParticles[i].SetActive(true);
                //I couldn't get the below to work correctly, but I'm keeping it because it makeS Particle System stuff a little easier to understand for me.
                /*if (Time.timeScale > 0.1f) {
                    ParticleSystem.EmissionModule myModule = myPartics[i].emission;
                    myModule.rateOverTime = new ParticleSystem.MinMaxCurve(Time.timeScale * normalRate[i]);
                }*/
            }
        }
        else {
            for (int i = 0; i < myParticles.Length; i++) {
                myParticles[i].SetActive(false);
                /*if (Time.timeScale < 0.1f) {
                    ParticleSystem.EmissionModule myModule = myPartics[i].emission;
                    myModule.rateOverTime = new ParticleSystem.MinMaxCurve(Time.timeScale * normalRate[i]);
                }*/
            }
        }
    }
}
