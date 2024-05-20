using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostPatrolState : IState
{
    private readonly LayerMask _layer;
    private readonly Ghost _ghost;
    private readonly Animator _animator;
    private readonly Transform _transform;
    private int _wayPointPos;
    float _speed,_maxSpeed, patroltime, patroltimedefault=2 ;
    bool _isFaceRignt;

    Coroutine patrol;


    public GhostPatrolState(Ghost ghost, Animator animator, float maxspeed, Transform transform, LayerMask layer, bool isFaceRignt)
    {
        _ghost = ghost;
        _animator = animator;
        _maxSpeed = maxspeed;
        _transform = transform;
        _layer = layer;
        _isFaceRignt = isFaceRignt;
    }

    public void OnEnter()
    {
        _speed = _maxSpeed;
        patrol = _ghost.StartCoroutine(Count());

        GameManager.Instance.Chased(0);
    }

    public void OnExit()
    {
        _ghost.StopCoroutine(patrol);
        _ghost.GetLocation();
        _ghost.Search(false);
    }

    public void Tick()
    {
        HandleMovement();
        Debug.Log("patrol");
    }

    private void HandleMovement()
    {
        Vector2 inputVector = _transform.right;

        if (inputVector == Vector2.zero) return;

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        float movedistance;

            movedistance = Time.deltaTime * _speed;


        bool canMove = !Physics2D.Raycast(_transform.position, _transform.right, 1.1f, _layer);

        if (canMove)
        {
            _transform.position += moveDir * movedistance;
            _transform.right = moveDir;

        }
        else
        {
            _isFaceRignt = !_isFaceRignt;
            _transform.right *= -1;
        }



    }


    IEnumerator Count()
    {
        patroltime = patroltimedefault;
        while (patroltime >0)
        {
            yield return null;
            patroltime-= Time.deltaTime;
        }

        _ghost.setMoveRoom(true);
    }
}
