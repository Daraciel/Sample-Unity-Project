using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public void ShootMissile(Missile missile, float initialSpeed, Vector2 direction, int damage)
    {
        Missile newMissile;
        float rotation;

        rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        newMissile = Instantiate(missile, transform.position, Quaternion.identity);
        //newMissile.gameObject.transform.SetParent(transform);
        newMissile.InitialSpeed = initialSpeed;
        newMissile.Direction = direction;
        newMissile.Damage = damage;
        newMissile.transform.Rotate(0, 0, rotation);
    }

    public void Dash(Vector2 direction, Rigidbody2D body)
    {
        Vector2 speedDirection = direction.normalized * 50;
        body.velocity = speedDirection;
    }
}
