using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class Skill : MonoBehaviour
{
	public int level = 0;
	public int maxLevel = 5;
	public string skillName = "Skill";
	public skillType type;
    [TextArea] public string tooltip = "";
		public bool isLocked = true;
		public Button		skillButton;
		[SerializeField] public GameObject	levelBox;
		[SerializeField] public TextMeshProUGUI		levelText;
		[SerializeField] public Skill	nextSkill;
		[SerializeField] private Hero	hero;

	public enum skillType
	{
		Active,
		Passive,
	}
	void Start() {
		skillButton.onClick.AddListener(LevelUp);
		Debug.Log(hero.GetSkillsPoints());

		Debug.Log("Add Listener");
	}
	public void LevelUp()
	{
		Debug.Log("Clicking...");
		Debug.Log(hero.GetSkillsPoints());
		if (!isLocked && level < maxLevel && hero.GetSkillsPoints() > 0) {
			level += 1;
			hero.UseTalentPoint();
			levelText.text = level.ToString() + " / " + maxLevel.ToString();
			if (level >= maxLevel && nextSkill != null)
				nextSkill.isLocked = false;
		}
	}
	void Update() {
		if (!isLocked && levelBox.activeSelf == false) {
			Debug.Log("Unlock");
			Color32 eraseBackground = new Color32(255, 255, 255, 255);
			skillButton.GetComponent<Image>().color = eraseBackground;
			levelBox.SetActive(true);
			levelText.text = level.ToString() + " / " + maxLevel.ToString();
		}
	}
}
