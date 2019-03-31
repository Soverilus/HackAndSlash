using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFeedback : MonoBehaviour {
    Vector3 initialPosition;
    float shakeMagnitude;
    float shakeDuration = 0;

    private void OnEnable() {
        initialPosition = transform.position;
    }

    private void Update() {
        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.unscaledDeltaTime;
            shakeMagnitude *= 0.85f;
        }
    }

    public void SetShakeMagnitudeAndDuration(float m, float d) {
        shakeMagnitude = m;
        shakeDuration = d;
    }
}
