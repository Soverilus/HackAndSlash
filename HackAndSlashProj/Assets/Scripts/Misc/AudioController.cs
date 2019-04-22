using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

    public void PlayAudioClip(string clipToPlay, bool isMultiple = true) {
        bool hasAudioSource = false;
        int trueRand = 0;
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
        if (isMultiple) {
            int randNum = 0;
            Regex numFinder = new Regex(@"(\d+)");
            foreach (AudioClip clip in clips) {
                if (clip.name.Contains(clipToPlay) && numFinder.IsMatch(clip.name)) {
                    randNum++;
                }
            }

            trueRand = Random.Range(0, randNum) + 1;
            foreach (AudioClip clip in clips) {
                if (clip.name == clipToPlay + trueRand) {
                    aud.PlayOneShot(clip);
                    aud = null;
                    playSuccess = true;
                    break;
                }
            }
        }
        else {
            foreach (AudioClip clip in clips) {
                if (clip.name.Contains(clipToPlay)) {
                    aud.PlayOneShot(clip);
                    aud = null;
                    playSuccess = true;
                    break;
                }
            }
        }
        if (!playSuccess) {
            foreach (AudioClip clip in clips) {
                if (clip.name == clipToPlay) {
                    aud.PlayOneShot(clip);
                    aud = null;
                    Debug.LogError("There was no clip in clips named " + clipToPlay + trueRand + ", however, there WAS a clip in clips named " + clipToPlay);
                    Debug.LogWarning("Please change the name of the clip currently named " + clipToPlay + " to '" + clipToPlay + "#' where '#' = any int");
                }
                else {
                    Debug.LogError("There was no clip in clips named " + clipToPlay + trueRand + ", nor a clip in clips named " + clipToPlay);
                }
            }
        }
    }
}