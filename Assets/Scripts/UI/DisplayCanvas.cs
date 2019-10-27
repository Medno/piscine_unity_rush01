using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // public GameObject  panel;
    public KeyCode  key;
    private bool    isActive;
    private Popup   popUp;
	[SerializeField] private UserInput inputManager = null;
    private Canvas canvas;

    void Start() {
        isActive = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        popUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Popup>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        inputManager.canControl = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inputManager.canControl = true;
    }
    void Update()
    {
        if (!isActive && Input.GetKeyDown(key)) {
            // panel.SetActive(true);
            canvas.enabled = true;
            isActive = true;
            Debug.Log("Display canvas");
        }
        else if (Input.GetKeyDown(key)) {
            canvas.enabled = false;
            // panel.SetActive(false);
            isActive = false;
            // if (popUp.win && popUp.win.activeSelf)
            //     popUp.win.gameObject.SetActive(false);
            Debug.Log("Display canvas");
        }
    }
}
