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
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider Col) {
        if (isEquiped == false && Col.gameObject.tag == "Player") {
            Debug.Log("Coucou");
            player.GetComponent<Inventary>().PickUp(gameObject);
        }
    }
}
