using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StraightProjectileBehaviour : Projectiles
{
    private void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

}
