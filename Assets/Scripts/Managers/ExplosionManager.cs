using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private static ExplosionManager _instance;
    [SerializeField] private ParticleSystem _crateExplosion;

    public static void CreateCrateExplosion(Vector3 position)
    {
        var inst = Instantiate(_instance._crateExplosion, position, Quaternion.identity);
        Destroy(inst, 2f);
    }
    private void Awake()
    {
        _instance = this;
    }
}
