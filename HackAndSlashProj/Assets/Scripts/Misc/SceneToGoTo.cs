using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneToGoTo : MonoBehaviour
{
    SceneManager mySC;

    public void Progress() {
        SceneManager.LoadScene("GoblinFight");
    }
}
