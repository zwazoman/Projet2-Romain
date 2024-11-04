using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPickup : PowerPickup
{
    private void Start()
    {
        _powerUI = PowersUIManager.Instance.ShootUI;
    }

    protected override void OnPickup()
    {
        Shoot shoot = new Shoot();
        shoot.pickupItem = this;
        PlayerMain.Instance.Powers.AddPower(shoot);
    }
}
