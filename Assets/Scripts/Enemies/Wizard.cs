using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EnemyAI
{

    public Missile Missile;

    protected override void EnemyAttack()
    {
        _myAbility.ShootMissile(Missile, Missile.InitialSpeed, _myInput.PlayerDirection, Stats.Attack);
        //Debug.DrawLine(transform.position, _myInput.PlayerDirection, Color.green);
    }

    protected override void flipSprite()
    {
        if (_myInput.Horizontal < 0)
        {
            _mySpriteRenderer.flipX = false;
        }
        else
        {
            _mySpriteRenderer.flipX = true;
        }
    }
}
