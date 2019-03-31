using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicController : MonoBehaviour
{
    float timer = 0f;
    AudioSource myAud;
    float originalVolume;
    void Start()
    {
        myAud = GetComponent<AudioSource>();
        originalVolume = myAud.volume;
        myAud.volume = 0f;
    }

    void Update()
    {
        if (myAud.volume < originalVolume) {
            myAud.volume = Mathf.Lerp(myAud.volume, originalVolume, timer);
            timer += 0.5f * Time.deltaTime;
        }
        else if (myAud.volume >= originalVolume && timer > 0f){
            myAud.volume = originalVolume;
            timer = 0f;
        }
        myAud.pitch = Time.timeScale;
    }
}
