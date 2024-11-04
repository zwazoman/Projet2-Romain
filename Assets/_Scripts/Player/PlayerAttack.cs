using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerAttack : MonoBehaviour
{
    public bool CanAttack {get;set;}

    [SerializeField] Animation _attackAnim;

    Collider2D _coll;
    PlayerInputs _inputs;

    private void Awake()
    {
        _coll = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _inputs = PlayerMain.Instance.Inputs;
        _inputs.OnAttack += Attack;
    }

    void Attack()
    {
        _coll.enabled = true;
        _attackAnim.Play();
    }

    /// <summary>
    /// appelé via l'animation
    /// </summary>
    public void StopAttack()
    {
        _coll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9) collision.gameObject.SendMessage("Explode");
    }
}
