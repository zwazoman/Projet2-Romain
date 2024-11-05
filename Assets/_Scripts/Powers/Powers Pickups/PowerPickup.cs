using UnityEngine;

public abstract class PowerPickup : MonoBehaviour
{
    public GameObject _powerUI { get; protected set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) Pickup();
    }

    void Pickup()
    {
        gameObject.SetActive(false);
        OnPickup();
    }

    protected abstract void OnPickup();
}
