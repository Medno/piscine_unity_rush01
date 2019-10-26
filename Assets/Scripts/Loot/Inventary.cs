using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public List<GameObject> ownedItems;
    public GameObject equipedWeapon;
    private GameObject player;
    private List<GameObject> prefabs;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        prefabs = GameObject.FindGameObjectWithTag("ItemList").GetComponent<ItemList>().prefabs;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) == true)
            Equip(ownedItems[0]);
        if (Input.GetKeyDown(KeyCode.U) == true)
            Unequip();
        if (Input.GetKeyDown(KeyCode.Q) == true)
            Drop(ownedItems[0]);
    }
    public void PickUp(GameObject obj) {
        Item item = obj.GetComponent<Item>();
        if (ownedItems.Count < 12) {
            ownedItems.Add(prefabs.Find(prefab => prefab.name == obj.name));
            Destroy(obj);
        }
    }
    public void Equip(GameObject obj) {
        Item item = obj.GetComponent<Item>();
        if (item.isEquiped == false) {
            GameObject weapon = Instantiate(obj);
            weapon.name = obj.name;
            item = weapon.GetComponent<Item>();
            item.isEquiped = true;
            weapon.transform.SetParent(GameObject.FindGameObjectWithTag("rightHand").transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
            weapon.transform.localEulerAngles = new Vector3(180, 0, 90);
            equipedWeapon = weapon;
            ownedItems.Remove(obj);
        }
    }
    public void Unequip() {
        Item item = equipedWeapon.GetComponent<Item>();
        if (item.isEquiped == true) {
            item.isEquiped = false;
            ownedItems.Add(prefabs.Find(prefab => prefab.name == equipedWeapon.name));
            Destroy(equipedWeapon);
            equipedWeapon = null;
        }
    }
    public void Drop(GameObject obj) {
        GameObject dropedItem;
        dropedItem = Instantiate(obj, player.transform.position, new Quaternion(0,0,0,0));
        dropedItem.name = prefabs.Find(prefab => prefab.name == obj.name).name;
        GeometryExtensions.SetPositionY(dropedItem.transform, dropedItem.transform.position.y + 0.3f);
        ownedItems.Remove(obj);   
    }
}
