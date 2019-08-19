using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Missile : MonoBehaviour
{

    #region PROPERTIES

    public float InitialSpeed;
    public Vector2 Direction;
    public int Damage;
    public string targetTag;

    #endregion
    
    private Rigidbody2D _myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Created Missile");
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myRigidBody.velocity = Direction.normalized * InitialSpeed;

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Hittable tagetHittable;
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("Hit succeed");
            tagetHittable = collision.gameObject.GetComponent<Hittable>();
            if(tagetHittable != null)
            {
                Debug.Log("Is hittable!!");
                tagetHittable.ReceiveAttack(Damage, Direction);
            }
            else
            {
                Debug.Log("Is not hittable!!");
            }
            Destroy(gameObject);
        }
    }
}
