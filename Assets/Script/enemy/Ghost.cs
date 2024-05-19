using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class Ghost : MonoBehaviour, IWarpTo
{
    public Interact interact { get; private set; }

    [SerializeField]
    private RoomManager roommanager;

    private StateMachine _stateMachine;

    Vector3 _playerPosition;
    public Vector3 _lastPosition { get; private set; }

    bool _canSeePlayer;

    [SerializeField] GameObject _player;

    [SerializeField] float _speed, _searchTime;

    [SerializeField] FieldOfView _fieldofview;

    [SerializeField] LayerMask layer;

    [SerializeField] LayerMask roomLayer; 

    public bool isFaceright { get; private set; } = true;

    public FieldOfView fieldOfView => _fieldofview;

    int defaultview;

    public bool _moveroom { get; private set; }

    public bool _search{get; private set;}

    public Warp warp{get; private set;}


    private void Awake()
    {
        interact = new Interact(GetComponent<Collider2D>(),this,transform);

        var navMeshAgent = GetComponent<NavMeshAgent>();
        var animator = GetComponent<Animator>();
        var audioSource = GetComponent<AudioSource>();

        _stateMachine = new StateMachine();


       var patrol = new GhostPatrolState(this, animator, _speed, transform, layer,isFaceright);
        var search = new GhostSearchState(this, animator, _speed);
        var chase = new GhostChaseState(this, animator, _speed, transform, _player.transform);
        var moveroom = new GhostMoveRoomState(this, animator, _speed, transform, layer, isFaceright);


        At(patrol, chase, HasTarget());
        At(patrol, moveroom, MoveRoom());
        At(moveroom, patrol, BackToPatrol());
        At(moveroom, chase, HasTarget());


        At(chase, search, HasNoTarget());
        At(search, chase, HasTarget());
        At(search, patrol, PatrolSearch());

        _stateMachine.SetState(patrol);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> HasTarget() => () => _canSeePlayer;
        Func<bool> HasNoTarget() => () => !_canSeePlayer;
        Func<bool> MoveRoom() => () => _moveroom;
        Func<bool> BackToPatrol() => () => !_moveroom;
        Func<bool> PatrolSearch() => () => !_canSeePlayer && _search&& !_moveroom;
    }

    public void IsFaceRight(bool face)
    { 
        isFaceright= face;
    }

    void Start()
    {
        fieldOfView.PlayerPos += SeePlayer;
    }

    private void Update() => _stateMachine.Tick();

    public bool CanSeePlayer => _canSeePlayer;

    public bool IsPlayer => false;

    void SeePlayer(Vector3 player, bool canSeePlayer)
    {
        if (canSeePlayer == true)
        {
            _playerPosition = player;
            _canSeePlayer = canSeePlayer;
            return;
        }

        _canSeePlayer = canSeePlayer;
        _lastPosition = _playerPosition;
    }


    public void setMoveRoom(bool condition)
    {
        _moveroom= condition;
    }

    public void WarpTo(Warp warpToPosition)
    {

        transform.position = warpToPosition.Location.position;
        _moveroom = false;
    }

    public void search(bool condition)
    { 
    _search= condition;
    }

    public void GetLocation()
    {
        var Collider = Physics2D.CircleCast(transform.position ,1f, transform.right, 1f,roomLayer);

        warp = roommanager.GetRoom(Collider.transform.parent.GetComponent<Room>().RoomName);
    }

}
