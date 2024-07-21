 using GameHorror.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    public event EventHandler Oninteract_performed;
    public event EventHandler Oninteract_canceled;
    public event EventHandler Onrun_performed;
    public event EventHandler Onrun_canceled;
    private HorrorInput playerinput;

    private void Awake()
    {
        playerinput= new HorrorInput();

        playerinput.InGame.Enable();

        playerinput.InGame.Interact.performed += Interact_performed;

        playerinput.InGame.Interact.canceled += Interact_canceled;

        playerinput.InGame.Run.performed += Run_performed;

        playerinput.InGame.Run.canceled += Run_canceled;

        playerinput.InGame.Pause.performed += pause;           ;
    }

    private void OnDestroy()
    {
        playerinput.InGame.Interact.performed -= Interact_performed;

        playerinput.InGame.Interact.canceled -= Interact_canceled;

        playerinput.InGame.Run.performed -= Run_performed;

        playerinput.InGame.Run.canceled -= Run_canceled;

        playerinput.InGame.Pause.performed -= pause;
    }

    public void StopMovement()
    { 
        playerinput.InGame.Move.Disable();
    }

    public void StartMovement()
    {
        playerinput.InGame.Move.Enable();
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {

        Oninteract_performed?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_canceled(InputAction.CallbackContext obj)
    {

        Oninteract_canceled?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalize()
    {
        Vector2 inputVector = playerinput.InGame.Move.ReadValue<Vector2>();

        //Debug.Log(inputVector);

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public float Scroll()
    {

        if (playerinput.InGame.ItemChoose.ReadValue<float>() > 0)
            return 1;
        else if(playerinput.InGame.ItemChoose.ReadValue<float>() < 0)
            return -1;
        else return 0;
    }


    void pause(InputAction.CallbackContext obj)
    {
        GameManager.Instance.PauseGame();
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {

        Onrun_performed?.Invoke(this, EventArgs.Empty);
    }

    private void Run_canceled(InputAction.CallbackContext obj)
    { 
        Onrun_canceled?.Invoke(this, EventArgs.Empty);
    }
}
