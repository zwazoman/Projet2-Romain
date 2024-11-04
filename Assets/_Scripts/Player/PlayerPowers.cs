using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMain))]
public class PlayerPowers : MonoBehaviour
{
    public event Action OnPowerUse;
    public event Action OnPowerAdd;

    // je sais que tu veux une file Romain mais je préfère une pile ;)
    public Stack<Powers> PossessedPowers = new Stack<Powers>();

    PlayerInputs _inputs;

    private void Start()
    {
        _inputs = PlayerMain.Instance.Inputs;
        _inputs.OnPower += UsePower;
    }

    void UsePower()
    {
        if(PossessedPowers.Count <= 0) return;
        Powers currentPower = PossessedPowers.Peek();
        if (!currentPower.IsUsable()) return;
        PossessedPowers.Pop();
        currentPower.Activate();
        OnPowerUse?.Invoke();
        StartCoroutine(ReActivate(currentPower.pickupItem.gameObject));
    }

    public void AddPower(Powers power)
    {
        PossessedPowers.Push(power);
        OnPowerAdd?.Invoke();
    }

    IEnumerator ReActivate(GameObject activateObject)
    {
        yield return new WaitForSeconds(1.5f);
        activateObject.SetActive(true);
    }
}
