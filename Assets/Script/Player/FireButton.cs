using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerCombat playerCombat;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerCombat.StartFire();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerCombat.StopFire();
    }
}
