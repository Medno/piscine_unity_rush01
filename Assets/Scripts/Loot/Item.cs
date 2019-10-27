using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Equippable
{
    public Sprite Skin;
    public bool isEquiped = false;
    public string nameItem;
    public string description;
    public int scarcity;
    private GameObject player;
    public int damageBuff;
    public float speedAttack;
    public bool hasBeenDrop = false;
    private OverItem over;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        over = GetComponent<OverItem>();
        SetItem();
    }

    void Update()
    {

    }
    void SetItem() {
        over.SetSprite(Skin);
        over.SetName(nameItem);
        // Generate description with damage, dps, description
        over.SetDetails(description);
        over.SetScarcityColor(GetItemColor());
    }

    void OnTriggerEnter(Collider Col) {
        if (isEquiped == false && Col.gameObject.tag == "Player" && hasBeenDrop == false) {
            player.GetComponent<Inventary>().PickUp(gameObject);
            if (over.popUp.CanvasIsEnabled())
                over.popUp.DisableCanvas();
        }
    }
    void OnTriggerExit(Collider Col) {
        if (isEquiped == false && Col.gameObject.tag == "Player" && hasBeenDrop == true) {
            hasBeenDrop = false;
        }
    }
    Color GetItemColor() {
        Color color;
        if (scarcity == 0)
            ColorUtility.TryParseHtmlString("#95a5a6ff", out color);
        else if (scarcity == 1)
            ColorUtility.TryParseHtmlString("#27ae60ff", out color);
        else if (scarcity == 2)
            ColorUtility.TryParseHtmlString("#2980b9ff", out color);
        else if (scarcity == 3)
            ColorUtility.TryParseHtmlString("#8E44ADFF", out color);
        else
            ColorUtility.TryParseHtmlString("#f1c40fff", out color);
        return color;
    }
}
