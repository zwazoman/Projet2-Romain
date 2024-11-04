using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Shield : Powers
{
    public override bool IsUsable()
    {
        return !PlayerMain.Instance.Shield.activeSelf;
    }

    public override async void Activate()
    {
        await StartShielding();
    }

    async Task StartShielding()
    {
        ActiveShield();
        await Task.Delay(2000);
        ActiveShield(false);
    }
}
