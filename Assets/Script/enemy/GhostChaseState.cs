using UnityEngine;
using UnityEngine.AI;

public class GhostChaseState : IState
{
    private readonly LayerMask _layer;
    private readonly Ghost _ghost;
    private readonly Animator _animator;
    private readonly Transform _transform;
    private readonly Transform _player;
    private int _wayPointPos;
    float _speed, _maxSpeed;
    bool _isFaceRignt;

    public GhostChaseState(Ghost ghost, Animator animator, float maxspeed, Transform transform, Transform player)
    {
        _ghost = ghost;
        _animator = animator;
        _maxSpeed = maxspeed;
        _transform = transform;
        _player = player;
    }
    public void Tick()
    {
       HandleMovement();

        Debug.Log("chase");
    }


    private void HandleMovement()
    {

        Vector2 inputVector = _transform.right;



        if (_ghost.warp.transform.position.x >= _transform.position.x)
        {
            inputVector = _transform.right;
        }

        float movedistance;

        movedistance = Time.deltaTime * _speed*2;

        if (_isFaceRignt)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _player.transform.position + Vector3.left, movedistance);
            if (Vector3.Distance(_transform.position, _player.transform.position + Vector3.left) < .7f)
            {
                _isFaceRignt = !_isFaceRignt;
            }
            _transform.right = new Vector3(_player.transform.position.x + Vector3.left.x - _transform.position.x, inputVector.y, 0f); ;

        }
        else
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _player.transform.position + Vector3.right, movedistance);
            if (Vector3.Distance(_transform.position, _player.transform.position + Vector3.right) < .7f)
            {
                _isFaceRignt = !_isFaceRignt;
            }

            _transform.right = new Vector3(_player.transform.position.x + Vector3.right.x - _transform.position.x, inputVector.y, 0f); ;
        }



    }


    public void OnEnter()
    {
        _speed = _maxSpeed;
        _ghost.fieldOfView.fullradius();
        GameManager.Instance.Chased(2);
    }

    public void OnExit()
    {
        _ghost.fieldOfView.PatrolRadius();

        GameManager.Instance.Chased(1);
    }
}
