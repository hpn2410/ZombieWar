using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 moveVector;

    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody rb;

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
        Vector3 movement = new Vector3( moveVector.x, 0f, moveVector.y);

        if (movement.sqrMagnitude > 1f)
        {
            movement.Normalize();
        }

        rb.linearVelocity = new Vector3(movement.x * moveSpeed,
            rb.linearVelocity.y, movement.z * moveSpeed);

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
