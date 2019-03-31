using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyShards : MonoBehaviour {
    public GameObject myPanel;
    public void OpenShardsMenu() {
        myPanel.SetActive(true);
    }
    public void CloseShardsMenu() {
        myPanel.SetActive(false);
    }
}
