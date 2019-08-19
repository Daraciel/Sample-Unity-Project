using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(InputEnemy))]
public class EnemyAI : IEnemy
{
    #region CONSTANTS

    private int isRunningHash = Animator.StringToHash("IsRunning");
    private int attackHash = Animator.StringToHash("Attack");
    private int isDeadHash = Animator.StringToHash("IsDead");

    #endregion

    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;

    protected InputEnemy _myInput;
    protected Attacker _myAttacker;
    protected SpriteRenderer _mySpriteRenderer;
    protected Animator _myAnimator;
    protected Ability _myAbility;
    protected bool isDead;
    protected bool isAttacking;
    protected bool isInCombat;

    protected Vector2 attackDirection;

    // Start is called before the first frame update
    public void Start()
    {
        _myInput = GetComponent<InputEnemy>();
        _myAttacker = GetComponent<Attacker>();
        _myAnimator = GetComponent<Animator>();
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myAbility = GetComponent<Ability>();
        PuffObject = Instantiate(PuffObject, transform);
        this.SayName();
        isDead = false;
        isAttacking = false;
        isInCombat = false;
    }

    // Update is called once per frame
    public void Update()
    {
        Behaviour();
    }

    public void SetAttackingFalse()
    {
        isAttacking = false;
    }

    protected virtual void EnemyAttack()
    {
        _myAttacker.Attack(attackDirection, Stats.Attack);
    }

    protected void Behaviour()
    {
        if (!isDead)
        {
            if (!isAttacking && _myInput.PlayerDistance < attackRange)
            {
                setAttackingStatus();
            }
            else if (!isAttacking && (isInCombat || _myInput.PlayerDistance < detectionRange))
            {
                moveToPlayer();
            }
            else
            {
                _myAnimator.SetBool(isRunningHash, false);
            }
        }
    }

    public void Dead()
    {
        isDead = true;
        _myAnimator.SetBool(isDeadHash, true);
    }

    private void setAttackingStatus()
    {
        int attackChance = -1;

        attackChance = UnityEngine.Random.Range(0, 100);
        if (attackChance > 90)
        {
            isAttacking = true;
            isInCombat = true;
            _myAnimator.SetBool(isRunningHash, false);
            _myAnimator.SetTrigger(attackHash);
            attackDirection = _myInput.PlayerDirection;
        }
    }

    private void moveToPlayer()
    {
        _myAnimator.SetBool("IsRunning", true);
        flipSprite();
        transform.position += (Vector3)_myInput.PlayerDirection.normalized * Stats.Speed * Time.deltaTime;
    }

    protected virtual void flipSprite()
    {
        if (_myInput.Horizontal < 0)
        {
            _mySpriteRenderer.flipX = true;
        }
        else
        {
            _mySpriteRenderer.flipX = false;
        }
    }
}
