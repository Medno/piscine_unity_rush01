using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverItem : MonoBehaviour
{
    public Popup   popUp;
    void Start()
    {

    }
    void OnMouseEnter() {
        Debug.Log("Selecting item");
        popUp.gameObject.SetActive(true);
        popUp.SetItemDetails(GetComponent<Image>(), "Epee de l'ecole de la chouette", "L'epee la plus puissante jamais cree, chaque monstre fuit en voyant cette arme.");
    }
    void OnMouseExit() {
        Debug.Log("Quitting selection item");
        popUp.gameObject.SetActive(false);
    }
    void Update()
    {
        if (popUp.gameObject.activeSelf)
            popUp.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;

    }
}
