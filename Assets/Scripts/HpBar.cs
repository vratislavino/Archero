using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    [SerializeField]
    private Image hpBackground;
    [SerializeField]
    private Image hpValue;
    [SerializeField]
    private List<ColorLevel> colorLevels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RegisterUnit(Unit unit) {
        unit.HpChanged += OnHpChanged;
    }

    private void OnHpChanged(Unit unit) {
        float perc = (float) unit.Hp / unit.MaxHp;
        hpValue.fillAmount = perc;
        hpValue.color = ColorLevel.GetColorByLevel(perc, colorLevels);
    }
}

[Serializable]
public class ColorLevel
{
    [SerializeField]
    private float level;

    [SerializeField]
    private Color color;

    public static Color GetColorByLevel(float level, List<ColorLevel> levels) {
        for (int i = 0; i < levels.Count; i++) {
            if (level > levels[i].level)
                return levels[i].color;
        }
        return Color.green;
    }
}