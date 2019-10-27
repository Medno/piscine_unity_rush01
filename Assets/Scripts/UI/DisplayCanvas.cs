using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCanvas : MonoBehaviour
{
    public GameObject  panel;
    public KeyCode  key;
    private bool    isActive;
    private Popup   popUp;

    void Start() {
        isActive = false;
        panel.SetActive(false);
        popUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Popup>();
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
            if (popUp.win && popUp.win.activeSelf)
                popUp.win.gameObject.SetActive(false);
            Debug.Log("false");
        }
    }
}
