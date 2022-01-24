using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarProvider : SceneSingleton<HpBarProvider>
{
    public HpBar hpBarPrefab;

    public void ProvideForUnit(Unit unit) {
        var bar = Instantiate(hpBarPrefab, unit.transform);
        bar.RegisterUnit(unit);
    }

}
