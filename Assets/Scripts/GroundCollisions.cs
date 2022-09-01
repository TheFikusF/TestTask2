using UnityEngine;

public class GroundCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            GameStateManager.EndGame(0, GameResult.Lose);
        }

        if (collision.gameObject.TryGetComponent(out Box box))
        {
            BoxManager.RemoveBox(box);
        }
    }
}
