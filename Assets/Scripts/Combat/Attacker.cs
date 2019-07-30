using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public bool DebugLines;
    public float Gap = 1f;
    public Vector2 HitBox = new Vector2(1, 1);
    public LayerMask layerAttack;

    private Vector2 auxAttackVector;
    private Vector2 origin;
    private Vector2 endpoint;
    private float hitBoxReductionFactor = 0.5f;
    private Collider2D[] attackColliders = new Collider2D[10];
    private ContactFilter2D attackFilter;

    private void Start()
    {
        attackFilter = new ContactFilter2D();
        attackFilter.layerMask = layerAttack;
    }

    private void Update()
    {
        if(DebugLines)
        {
            Debug.DrawLine(transform.position, (Vector2)transform.position + auxAttackVector, Color.yellow);
            Debug.DrawLine(origin, endpoint, Color.red);
        }
    }

    public void Attack(Vector2 attackDirection, int damage)
    {
        int hits = -1;
        attackDirection.Normalize();
        createHitbox(attackDirection);

        if (attackDirection != Vector2.zero)
        {
            hits = Physics2D.OverlapArea(origin, endpoint, attackFilter, attackColliders);
            Debug.Log("attacked elements = " + hits);
            for(int i = 0; i < hits; i++)
            {
                tryAttackObject(attackColliders[i]);
            }
        }

    }

    private void tryAttackObject(Collider2D objective)
    {
        Hittable attackedObject;
        attackedObject = objective.gameObject.GetComponent<Hittable>();
        if (attackedObject != null)
        {
            attackedObject.ReceiveAttack();
        }
    }

    private void createHitbox(Vector2 attackDirection)
    {
        Vector2 scale;
        Vector2 scaledHitbox;
        if (attackDirection != Vector2.zero)
        {
            scale = transform.lossyScale;
            scaledHitbox = Vector2.Scale(HitBox, scale);
            auxAttackVector = Vector2.Scale(attackDirection * Gap, scale);
            origin = ((Vector2)transform.position + auxAttackVector) - scaledHitbox * hitBoxReductionFactor;
            endpoint = (origin + scaledHitbox);
        }
    }
}
