using UnityEngine;

public class StraightProjectileBehaviour : Projectiles
{
    private void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

}
