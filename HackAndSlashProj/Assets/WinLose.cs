using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinLose : MonoBehaviour{
    bool wasVictorious = false;
    public GameObject[] winOrLose;
    GameLoopController myGLC;

    float goldCount;
    float shardCount;
    float currentGCount = 0;
    float currentSCount = 0;
    public Text myGoldCount;
    public Text myShardCount;

    void Update() {
        if (currentGCount < goldCount) {
            currentGCount = Mathf.Clamp(currentGCount + 0.05f * goldCount, 0, goldCount);
        }
        if (currentSCount < shardCount) {
            currentSCount = Mathf.Clamp(currentSCount + 0.1f * shardCount, 0, shardCount);
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
