using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMoveRoomState : IState
{
    private readonly LayerMask _layer;
    private readonly Ghost _ghost;
    private readonly Animator _animator;
    private readonly Transform _transform;
    private int _wayPointPos;
    float _speed,_maxSpeed;
    bool _isFaceRignt;

    public GhostMoveRoomState(Ghost ghost, Animator animator, float maxspeed, Transform transform, LayerMask layer, bool isFaceRignt)
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
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = _transform.right;

        if (inputVector == Vector2.zero) return;

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        float movedistance;

            movedistance = Time.deltaTime * _speed;


        float playerHeight = 2.0f;
//        bool canMove = !Physics2D.Raycast(_transform.position, _transform.right, 1.1f, _layer);

            _transform.position += moveDir * movedistance;
            _transform.right = moveDir;

    }

    void flip()
    { 

    }

}
