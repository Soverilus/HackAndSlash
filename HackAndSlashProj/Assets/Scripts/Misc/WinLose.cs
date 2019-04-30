using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinLose : MonoBehaviour{
    bool wasVictorious = false;
    public GameObject[] winOrLose;
    GameLoopController myGLC;
    public bool activeNow = false;

    float goldCount;
    float shardCount;
    float currentGCount = 0;
    float currentSCount = 0;
    public Text myGoldCount;
    public Text myShardCount;
    float myCountUp = 0.001f;
    float myCountMisc = 0f;
    float myCountActual = 0f;

    void Update() {
        if (activeNow) {
            myCountActual = myCountUp * myCountMisc;
            if (currentGCount < goldCount) {
                currentGCount = Mathf.Clamp(currentGCount + myCountActual * goldCount, 0, goldCount);
            }
            if (currentSCount < shardCount) {
                currentSCount = Mathf.Clamp(currentSCount + myCountActual * shardCount, 0, shardCount);
            }
            if (goldCount > 0)
                myGoldCount.text = "+ " + currentGCount.ToString("F0");
            else {
                myGoldCount.text = "0";
            }
            if (shardCount > 0)
                myShardCount.text = "+ " + currentSCount.ToString("F0");
            else {
                myShardCount.text = "0";
            }
            myCountMisc += 1f;
        }
    }

    public void SetVictory(bool won) {
        wasVictorious = won;
        if (won) {
            winOrLose[0].SetActive(true);
        }
        else {
            winOrLose[1].SetActive(true);
        }
    }

    public void SetGoldAndShardCounts(float gold, float shards) {
        goldCount = gold;
        shardCount = shards;
    }

    public void SetGLC(GameLoopController thisGLC) {
        myGLC = thisGLC;
    }

    public void ButtonContinue() {
        myGLC.TrueLoadScene();
    }
}
