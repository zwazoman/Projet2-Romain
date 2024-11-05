using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public event Action<bool> OnJump;
    public event Action OnMove;
    public event Action<bool> OnSprint;
    public event Action OnAttack;
    public event Action OnPower;

    public float Horizontal { get; private set; }

    /// <summary>
    /// déplacements du joueur avec l'input system
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        if (context.started) OnMove?.Invoke();
        Horizontal = context.ReadValue<Vector2>().x;
    }

    /// <summary>
    /// saut du joueur avec l'input system
    /// </summary>
    /// <param name="context"></param>
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started) OnJump?.Invoke(false);
        if (context.canceled) OnJump?.Invoke(true);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.started) OnSprint?.Invoke(true);
        if(context.canceled) OnSprint?.Invoke(false);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started) OnAttack?.Invoke();
    }

    public void UsePower (InputAction.CallbackContext context)
    {
        if(context.started) OnPower?.Invoke();
    }
}
