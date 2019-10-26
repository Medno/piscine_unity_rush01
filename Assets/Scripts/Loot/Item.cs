using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image Skin;
    public bool isEquiped = false;
    public string nameItem;
    public string description;
    public int scarcity;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter() {
        Debug.Log("Coucou");
        if (isEquiped == false)
            player.GetComponent<Inventary>().PickUp(gameObject);
    }
}
