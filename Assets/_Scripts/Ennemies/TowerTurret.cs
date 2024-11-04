using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerTurret : Turrets
{
    protected override bool ShouldShoot()
    {
        Vector2 targetVector = PlayerMain.Instance.transform.position - transform.position;
        if (targetVector.y < -2) return false;
        return base.ShouldShoot();

    }
}
