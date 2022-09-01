using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    private void Start()
    {
        BoxManager.AddBox(this);
    }
}
