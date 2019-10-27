using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
    public List<GameObject> Talents;
    public List<GameObject> Slots;
    // Start is called before the first frame update
    public GameObject talentSelected;
    public GameObject slotSelected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (talentSelected == null)
                talentSelected = Talents.Find(talent => talent.GetComponent<OverItem>().isInsideBox == true);
            else
                slotSelected = Slots.Find(slot => slot.GetComponent<OverSlot>().isInsideBox == true);
            if (talentSelected != null && slotSelected != null) {
                talentSelected = null;
                slotSelected = null;
            }
        }
    }
}
