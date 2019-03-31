using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    AudioSource[] myAudioSource;
    AudioSource aud;
    public int sources;
    [SerializeField] List<AudioClip> clips;

    void Start() {
        CleanUpTestSources();
        CreateAudioSourceArray();
    }

    private void Update() {
        for (int i = 0; i < myAudioSource.Length; i++) {
            myAudioSource[i].pitch = Time.timeScale;
        }
    }

    void CleanUpTestSources() {
        if (GetComponents<AudioSource>().Length < sources) {
            for (int i = 0; i < GetComponents<AudioSource>().Length; i++) {
                Destroy(GetComponents<AudioSource>()[0]);
            }
        }
    }

    void CreateAudioSourceArray() {
        myAudioSource = new AudioSource[sources];
        for (int i = 0; i < sources; i++) {
            AudioSource tempSource;
            tempSource = gameObject.AddComponent<AudioSource>();
            myAudioSource[i] = tempSource;
        }
    }

    public void PlayAudioClip(string clipToPlay) {
        bool hasAudioSource = false;
        for (int i = 0; i < myAudioSource.Length; i++) {
            if (!myAudioSource[i].isPlaying) {
                aud = myAudioSource[i];
                hasAudioSource = true;
                break;
            }
        }
        if (!hasAudioSource) {
            Debug.LogError("There are not enough AudioSources to support the PlayAudioClip request");
            return;
        }
        bool playSuccess = false;
        foreach (AudioClip clip in clips) {
            if (clip.name == clipToPlay) {
                aud.PlayOneShot(clip);
                aud = null;
                playSuccess = true;
                break;
            }
        }
        if (!playSuccess) {
            Debug.LogError("There was no clip in clips named " + clipToPlay);
        }
    }
}
