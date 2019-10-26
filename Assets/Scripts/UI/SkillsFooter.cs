using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillsFooter : MonoBehaviour
{
    [SerializeField] private Hero   hero;
    [SerializeField] private TextMeshProUGUI text;
    void Update()
    {
        if (hero.GetSkillsPoints().ToString() != text.text)
            text.text = hero.GetSkillsPoints().ToString();
    }
}
