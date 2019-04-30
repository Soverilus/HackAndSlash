using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundSFX : MonoBehaviour {
    Vector3 originalTran;
    float magnitude = 0.1f;
    void Start() {
        originalTran = transform.position;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, originalTran + new Vector3(Random.Range(-magnitude, magnitude), Random.Range(-magnitude, magnitude), 0), 0.1f);
    }
}
