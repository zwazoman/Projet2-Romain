using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpPickup : PowerPickup
{
    private void Start()
    {
        _powerUI = PowersUIManager.Instance.SuperJumpUi;
    }
    protected override void OnPickup()
    {
        SuperJump superJump = new SuperJump();
        superJump.pickupItem = this;
        PlayerMain.Instance.Powers.AddPower(superJump);
    }
}
