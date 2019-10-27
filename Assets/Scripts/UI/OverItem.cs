using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OverItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Popup   popUp;
    private ItemInventory   itemInventory;
    private Sprite  sprite;
    private string  itemName;
    private string  itemDetails;
    private bool  isEmpty;
    void Start()
    {
        popUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Popup>();
        isEmpty = true;
        itemInventory = GetComponent<ItemInventory>();
    }
    public void SetSprite(Sprite _sprite) {
        isEmpty = false;
        sprite = _sprite;
    }
    public void SetName(string _name) {
        itemName = _name;
    }
    public void SetDetails(string _details) {
        itemDetails = _details;
    }
    public void OnPointerEnter(PointerEventData eventData)
      {
        if(!isEmpty) {
            print("OnMouseEnter");
            popUp.win.gameObject.SetActive(true);
            popUp.SetItemDetails(sprite, itemName, itemDetails);
        }
      }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("OnMouseExit");
        if(!isEmpty) {
            popUp.win.gameObject.SetActive(false);
        }
    }
    void OnMouseEnter() {
        isEmpty = false;
        Debug.Log("Selecting item");
        popUp.win.gameObject.SetActive(true);
        popUp.SetItemDetails(sprite, itemName, itemDetails);
    }
    void OnMouseExit() {
        isEmpty = true;
        Debug.Log("Quitting selection item");
        popUp.win.gameObject.SetActive(false);
    }
    void Update()
    {
        if (!isEmpty && popUp.win && popUp.win.gameObject.activeSelf)
            popUp.win.gameObject.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition + (Vector3.up * 5f);
    }
}
