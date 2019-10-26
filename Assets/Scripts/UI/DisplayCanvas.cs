using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCanvas : MonoBehaviour
{
    public GameObject  panel;
    public KeyCode  key;
    private bool    isActive;

    void Start() {
        isActive = false;
        panel.SetActive(false);
    }
    void Update()
    {
        if (!isActive && Input.GetKeyDown(key)) {
            panel.SetActive(true);
            isActive = true;
            Debug.Log("true");
        }
        else if (Input.GetKeyDown(key)) {
            panel.SetActive(false);
            isActive = false;
            Debug.Log("false");
        }
    }
}
