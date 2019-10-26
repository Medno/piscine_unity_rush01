using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Image    itemImg;
    public Text     itemName;
    public Text     itemDetails;
    public void SetItemDetails(Image img, string _itemName, string _itemDetails) {
        itemImg.sprite = img.sprite;
        itemName.text = _itemName;
        itemDetails.text = _itemDetails;
    }
}
