using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour , IWarpTo
{
    Interact interact;

    #region Variable
    private Control gameInput;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _runSpeedModifier;

    [SerializeField]
    private float maxStamina = 100;

    private float stamina;

    [SerializeField]
    private AnimationControl animcontrol;

    [SerializeField]
    LayerMask obstacle;

    bool running = false;

    Collider2D _collider;

    IItemDes[] _itemList;

    IInteractable interaction;

    private bool _delayStamina;

    private float _delayStaminaCount;
    
    [SerializeField]
    private float delayStaminaDefaultCount ;

    private bool addStamina = false;

    public bool IsPlayer => true;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        _collider = this.GetComponent<Collider2D>();
        if (TryGetComponent<Control>(out Control control)) { gameInput = control; }
        gameInput.Oninteract_performed += GameInput_OninteractAction;
        gameInput.Oninteract_canceled += GameInput_OninteractActioncanceled;
        gameInput.Onrun_performed += GameInput_OnrunAction;
        gameInput.Onrun_canceled += GameInput_OnrunActioncanceled;
        stamina = maxStamina;
        interact = new (_collider,this,transform);
    }


    private void GameInput_OninteractAction(object sender, System.EventArgs e)
    {
        interact.CheckCollider();
    }

    private void GameInput_OninteractActioncanceled(object sender, System.EventArgs e)
    {
        interact.CancelInteraction();
    }

    private void GameInput_OnrunAction(object sender, System.EventArgs e)
    {
        running = true;
    }

    private void GameInput_OnrunActioncanceled(object sender, System.EventArgs e)
    {
        running = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        DelayStamina();
        AddStamina();
    }

    #endregion

    #region Main

    public void StopMovement()
    { 
        gameInput.StopMovement();
    }

    public void StartMovement()
    { 
        gameInput.StartMovement();
    }


    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();

        if (inputVector == Vector2.zero) {

            animcontrol.SetSpeed(0);
            return;
    }
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
        float movedistance;

        if (running && stamina > 0)
        {
            movedistance = Time.deltaTime * _speed * _runSpeedModifier;
            stamina -=  Time.deltaTime;
            EventContainer.Instance.StaminaBarEvent(stamina/maxStamina);
            _delayStamina = true;
            addStamina = false; 
            _delayStaminaCount = delayStaminaDefaultCount;
            animcontrol.SetSpeed(6);
        }
        else
        {
            movedistance = Time.deltaTime * _speed;
            animcontrol.SetSpeed(2);
        }

        float playerHeight = 1.0f;

        bool canMove = !Physics2D.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, CapsuleDirection2D.Vertical, 0,transform.right, movedistance,obstacle);


        if (canMove)
        {
            transform.position += moveDir * movedistance;
        }

           // transform.right = moveDir;
            if (inputVector.x > 0)
            {
                animcontrol.flip(false);
            }

            else
            { 
                animcontrol.flip(true);
            }


    }

    void DelayStamina()
    {
        if (_delayStamina && _delayStaminaCount > 0)
        {
            _delayStaminaCount -= Time.deltaTime;
        }
        else
        {
            if (stamina < maxStamina)
            {
                addStamina = true;
            }
        }
    }


    void AddStamina()
    {
        if (addStamina)
        {
            stamina += Time.deltaTime;
            EventContainer.Instance.StaminaBarEvent(stamina / maxStamina);
            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
                addStamina = false ;
            }
        }
    }

    #endregion

    #region IWarpTo

    public void WarpTo(Warp warpToPosition)
    {
        
        transform.position= warpToPosition.Location.position;
    }


    #endregion

}
