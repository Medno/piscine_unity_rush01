using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    public int  index;
    private Inventary  inventory;
    public Item item;
    public Button buttonItem;

    private OverItem over;
    void Start()
    {
        buttonItem.gameObject.SetActive(false);
        buttonItem.GetComponent<Image>().sprite = null;
        item = null;
        over = GetComponent<OverItem>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventary>();
    }

    void SetItem() {
        over.SetSprite(item.Skin);
        over.SetName(item.nameItem);
        // Generate description with damage, dps, description
        over.SetDetails(item.description);
        buttonItem.GetComponent<Image>().sprite = item.Skin;
        buttonItem.gameObject.SetActive(true);
    }
    void Update()
    {
        if (inventory.ownedItems.Count > index) {
            item = inventory.ownedItems[index].GetComponent<Item>();
            SetItem();
        }
    }
}
