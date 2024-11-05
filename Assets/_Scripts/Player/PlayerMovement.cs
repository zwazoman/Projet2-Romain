using UnityEngine;

[RequireComponent(typeof(PlayerMain))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    public bool IsGrounded { get; set; }
    public bool IsLocked { get; set; }
    public float HorizontalDirection { get; private set; }
    public Rigidbody2D RB { get; private set; } 
    public Collider2D Coll { get; private set; }

    public bool IsFacingRight { get; private set; }

    PlayerInputs _inputs;

    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpPower = 16f;
    [SerializeField] private float _sprintFactor = 1.3f;

    private void Awake()
    {
        Coll = GetComponent<Collider2D>();
        RB = GetComponent<Rigidbody2D>();
        IsFacingRight = true;
    }

    private void Start()
    {
        _inputs = PlayerMain.Instance.Inputs;
        _inputs.OnJump += Jump;
        _inputs.OnSprint += Sprint;
    }

    private void FixedUpdate()
    {
        if (IsLocked) return;
        //gère le déplacement
        RB.velocity = new Vector2(_inputs.Horizontal * _speed, RB.velocity.y);

        //gère le sens vers lequel se tourne le personnage
        if(IsFacingRight && _inputs.Horizontal < 0f || !IsFacingRight && _inputs.Horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    /// <summary>
    /// saut du joueur avec l'input system
    /// </summary>
    public void Jump(bool isReleased)
    {
        if(IsLocked) return;

        if (IsGrounded && !isReleased)
        {
            RB.velocity = new Vector2(RB.velocity.x,_jumpPower);
            AudioManager.Instance.PlaySFXClip(Sounds.Jump);
            IsGrounded = false;
        }
        if (isReleased && RB.velocity.y > 0)
        {
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
        }
    }

    public void Sprint(bool sprints)
    {
        if (sprints) _speed *= _sprintFactor; else _speed /= _sprintFactor;
    }
}
