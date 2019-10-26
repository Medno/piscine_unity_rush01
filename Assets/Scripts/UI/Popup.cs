using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject   popUp;
    void Start()
    {

    }
    void OnMouseEnter() {
        Debug.Log("Selecting item");
        popUp.SetActive(true);
        // popUp.rectTransform.anchoredPosition = Input.mousePosition;

    }
    void OnMouseExit() {
        Debug.Log("Quitting selection item");
        popUp.SetActive(false);
    }
    void Update()
    {
        if (popUp.activeSelf)
            popUp.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;

    }
}
