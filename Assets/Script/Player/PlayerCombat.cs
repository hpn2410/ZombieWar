using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private PlayerAnimationHandle animationHandle;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundLayer;

    private bool isFiring;
    private Vector2 fireScreenPosition;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!isFiring)
            return;

        Weapon weapon = weaponManager.CurrentWeapon;

        if (weapon != null)
        {
            weapon.TryFire();
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

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.001f)
                return;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void StartFire()
    {
        Weapon weapon = weaponManager.CurrentWeapon;

        if (weapon == null)
            return;

        isFiring = true;

        animationHandle.SetFireLayer(weapon.Type, true);

        weapon.TryFire();
    }

    private void StopFire()
    {
        isFiring = false;

        Weapon weapon = weaponManager.CurrentWeapon;

        if (weapon == null)
            return;

        animationHandle.SetFireLayer(weapon.Type, false);
    }

    public void OnSwitchWeaponClicked()
    {
        Weapon weapon = weaponManager.SwitchWeapon();

        if (isFiring)
        {
            animationHandle.SetFireLayer(weapon.Type, true);
        }
    }
}