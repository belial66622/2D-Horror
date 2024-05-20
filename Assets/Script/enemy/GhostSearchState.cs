using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GhostSearchState : IState
{
    private readonly float _searchTime;
    private readonly Ghost _ghost;
    private readonly Animator _animator;
    private Vector3 _lastposition;
    private float _speed;
    bool _isFaceRignt;

    Coroutine _search;
    Collider2D _check;

    public GhostSearchState(Ghost ghost, Animator animator, float speed )
    {
        _ghost = ghost;
        _animator = animator;
        _speed = speed;
    }


    public void OnEnter()
    {
        _ghost.Search(true);
        _ghost.setMoveRoom(true);

        _check = Physics2D.OverlapCircle(_ghost._lastPosition, 4f,_ghost.DoorLocation);
    }

    public void OnExit()
    {
        if(_ghost== null)
        _ghost.StopCoroutine(_search);
    }


    public void Tick()
    {

        HandleMovement();
        Debug.Log("search");
    }

    private void HandleMovement()
    {
        if(_check == null)
        {
            _lastposition = _ghost._lastPosition;
        }
        else if (_check.TryGetComponent<ISearchObejctAI>(out ISearchObejctAI warp))
            {
                _lastposition = warp.position.position;
            }




        if (Vector2.Distance(_lastposition, _ghost.transform.position) < 1f)
        {
            if(_search== null)
            _search = _ghost.StartCoroutine(Search());
            _ghost.interact.CheckCollider();
        }

        float movedistance;

        movedistance = Time.deltaTime * _speed;

            _ghost.transform.position = Vector3.MoveTowards(_ghost.transform.position, _lastposition, movedistance);

        _ghost.transform.right = new Vector3(_lastposition.x - _ghost.transform.position.x, 0, 0f); ;


    }

    IEnumerator Search()
    {
        float wait = 1f;
        while (wait < 1)
        { 
            yield return null;
            wait -= Time.deltaTime;
        }

        _ghost.setMoveRoom(false);
    }

}
