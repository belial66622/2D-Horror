using System.Collections.Generic;
using Unity.VisualScripting;
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
        Debug.Log("roomstate");
    }

    private void HandleMovement()
    {

        Vector2 inputVector = _transform.right;

        if (Vector2.Distance(_ghost.warp.transform.position, _transform.position) < 1f)
        {
            _ghost.interact.CheckCollider();
        }

        if (_ghost.warp.transform.position.x >= _transform.position.x)
        {
           inputVector = _transform.right;
        }

        float movedistance;

        movedistance = Time.deltaTime * _speed;

        _transform.position = Vector3.MoveTowards(_transform.position, _ghost.warp.transform.position, movedistance);
            _transform.right = new Vector3( _ghost.warp.transform.position.x - _transform.position.x, inputVector.y, 0f ); ;


    }


}
