using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPickup : PowerPickup
{
    private void Start()
    {
        _powerUI = PowersUIManager.Instance.DashUi;
    }

    protected override void OnPickup()
    {
        Dash dash = new Dash();
        dash.pickupItem = this;
        PlayerMain.Instance.Powers.AddPower(dash);
    }
}
