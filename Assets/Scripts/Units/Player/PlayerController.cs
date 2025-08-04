using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveInput;
    private PlayerMovement _playerMovement;
    private Attack_Player _playerAttack;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<Attack_Player>();
    }
    private void FixedUpdate()
    {
        _playerMovement.Move(moveInput);
    }
    private void OnMove(InputValue value)
    { 
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }
    private void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            _playerAttack.Attack();
        }
    }

}
