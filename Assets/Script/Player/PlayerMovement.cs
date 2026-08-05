using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void InputPlayer(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(
            moveVector.x,
            0f,
            moveVector.y
        );

        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            rb.linearVelocity.y,
            movement.z * moveSpeed
        );

        HandleAnimation(movement);
    }

    private void HandleAnimation(Vector3 movement)
    {
        if (movement.sqrMagnitude > 0.01f)
        {
            PlayerAnimationHandle.Instance.PlayerRun();
        }
        else
        {
            PlayerAnimationHandle.Instance.PlayerIdle();
        }
    }
}
