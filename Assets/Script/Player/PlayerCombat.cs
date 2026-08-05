using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundLayer;

    private bool isFiring;
    private Vector2 fireScreenPosition;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public void InputFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            fireScreenPosition = context.ReadValue<Vector2>();

            UpdateFireDirection(fireScreenPosition);

            StartFire();
        }
        else if (context.performed)
        {
            fireScreenPosition = context.ReadValue<Vector2>();

            UpdateFireDirection(fireScreenPosition);
        }
        else if (context.canceled)
        {
            StopFire();
        }
    }

    private void UpdateFireDirection(Vector2 screenPosition)
    {
        if (mainCamera == null)
            return;

        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            Mathf.Infinity,
            groundLayer))
        {
            Vector3 direction = hit.point - transform.position;

            // Chỉ xoay trên mặt phẳng XZ
            direction.y = 0f;

            if (direction.sqrMagnitude <= 0.001f)
                return;

            direction.Normalize();

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void StartFire()
    {
        if (currentWeapon == null)
            return;

        isFiring = true;
        currentWeapon.SetFireAnimation(true);

        // Bắn ngay lập tức khi tap
        currentWeapon.TryFire();
    }

    public void StopFire()
    {
        isFiring = false;

        if (currentWeapon != null)
        {
            currentWeapon.SetFireAnimation(false);
        }
    }

    private void Update()
    {
        if (isFiring && currentWeapon != null)
        {
            currentWeapon.TryFire();
        }
    }
}
