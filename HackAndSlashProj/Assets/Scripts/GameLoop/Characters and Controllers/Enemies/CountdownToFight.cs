using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownToFight : MonoBehaviour
{
    Text myText;
    public float myTimeRemaining;
    EnemyController myEC;

    private void Start() {
        myText = GetComponent<Text>();
        myEC = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        myEC.EnableAI(false);
    }
    void Update()
    {
        myTimeRemaining -= Time.deltaTime;
        myText.text = myTimeRemaining.ToString("F0");
        if (myTimeRemaining <= 0) {
            myEC.EnableAI(true);
            Destroy(gameObject);
        }
    }
}
