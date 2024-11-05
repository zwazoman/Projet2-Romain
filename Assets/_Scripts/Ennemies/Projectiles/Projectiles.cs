using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [field :SerializeField] 
    public float Speed { get; set; }

    public void BackToPool(Queue<GameObject> pool)
    {
        //si pas déjà de retour dans la pool -> remettre dans la pool
        if (gameObject.activeSelf) ProjectilePoolManager.Instance.ReturnToPool(gameObject,pool);
    }
}
