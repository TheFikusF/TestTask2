using UnityEngine;

public class DisableControls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player))
        {
            player.CanControl = false;
        }
    }
}
