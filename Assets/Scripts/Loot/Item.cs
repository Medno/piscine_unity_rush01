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
    }

    void OnTriggerEnter(Collider Col) {
        if (isEquiped == false && Col.gameObject.tag == "Player") {
            Debug.Log("Coucou");
            player.GetComponent<Inventary>().PickUp(gameObject);
        }
    }
}
