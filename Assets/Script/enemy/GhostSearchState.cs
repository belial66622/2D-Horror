using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GhostSearchState : IState
{
    private readonly float _searchTime;
    private readonly Ghost _ghost;
    private readonly Animator _animator;
    private readonly Vector3 _lastposition;
    private float _speed;
    bool _isFaceRignt;

    public GhostSearchState(Ghost ghost, Animator animator, float speed)
    {
        _ghost = ghost;
        _animator = animator;
        _speed = speed;
    }


    public void OnEnter()
    {
        _ghost.search(true);
        _ghost.setMoveRoom(true);
        IsFaceRight();
    }

    public void OnExit()
    {

    }
    public void Tick()
    {

        HandleMovement();
        Debug.Log("search");
    }

    private void HandleMovement()
    {


        if (Vector2.Distance(_ghost._lastPosition, _ghost.transform.position) < .1f)
        {
            _ghost.interact.CheckCollider();
        }

        float movedistance;

        movedistance = Time.deltaTime * _speed;

        if (_isFaceRignt)
            _ghost.transform.position = Vector3.MoveTowards(_ghost.transform.position, _ghost._lastPosition + Vector3.right*2, movedistance);
        else
        {
            _ghost.transform.position = Vector3.MoveTowards(_ghost.transform.position, _ghost._lastPosition + Vector3.left *2, movedistance);
        }
        _ghost.transform.right = new Vector3(_ghost._lastPosition.x - _ghost.transform.position.x, 0, 0f); ;

        Debug.Log(_lastposition);

    }


    private void IsFaceRight()
    {
        if (_ghost.transform.position.x - _ghost._lastPosition.x < 0)
        {
            _isFaceRignt= true;
        }
        else
        {
            _isFaceRignt = false;
        }
    }

}
