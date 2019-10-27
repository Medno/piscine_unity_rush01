using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup : MonoBehaviour
{
    public Image    itemImg;
    public TextMeshProUGUI     itemName;
    public TextMeshProUGUI     itemDetails;
    public GameObject       win;
    public void SetItemDetails(Sprite sprite, string _itemName, string _itemDetails) {
        itemImg.sprite = sprite;
        itemName.text = _itemName;
        itemDetails.text = _itemDetails;
    }
}
