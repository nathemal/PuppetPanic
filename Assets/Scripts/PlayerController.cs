using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;

    Rigidbody2D playerRigidBody2D;

    Vector2 playerMovement;
    Vector2 lookDirection;
    float playerDirection;

    public float playerMovementSpeed = 1;

    private void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    public void MovePlayer()
    {
        playerMovement = moveAction.ReadValue<Vector2>() * playerMovementSpeed;

        playerRigidBody2D.AddForce(playerMovement);
    }

    public void RotatePlayer()
    {

    }

}
