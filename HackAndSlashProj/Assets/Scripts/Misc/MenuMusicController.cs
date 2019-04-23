using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    public SpriteRenderer mySR;
    AudioSource myAS;
    private void Start() {
        myAS = GetComponent<AudioSource>();
    }

    private void Update() {
        myAS.volume = mySR.color.a;
        myAS.pitch = Mathf.Clamp(mySR.color.a,0.0001f, 1f);
    }
}
