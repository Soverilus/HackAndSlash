using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDisableCanvas : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            gameObject.SetActive(false);
        }
    }
}
