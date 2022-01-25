using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : SceneSingleton<SkillManager>
{
    private List<Skill> aquiredSkills = new List<Skill>();

    private float xp = 0;
    private float nextXpLevel = 100;
    private float newLevelMultiplier = 1.2f;

    [SerializeField]
    private GameObject SkillGui;

    public void AddXp(float amount) {
        xp += amount;
        if(xp >= nextXpLevel) {
            AddLevel();
        }
    }

    public void AddLevel() {
        xp -= nextXpLevel;
        nextXpLevel *= newLevelMultiplier;

        SkillGui.SetActive(true);
        Time.timeScale = 0;

    }

    public void PlayNext() {
        Time.timeScale = 1;
        SkillGui.SetActive(false);
    }

    public void AddSkill(Skill skill) {
        aquiredSkills.Add(skill);
    }
}
