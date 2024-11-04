using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPickup : PowerPickup
{
    private void Start()
    {
        _powerUI = PowersUIManager.Instance.DoubleJumpUI;
    }

    protected override void OnPickup()
    {
        DoubleJump doubleJump = new DoubleJump();
        doubleJump.pickupItem = this;
        PlayerMain.Instance.Powers.AddPower(doubleJump);
    }
}
