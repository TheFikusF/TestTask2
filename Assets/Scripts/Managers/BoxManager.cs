using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxManager : MonoBehaviour
{
    private static BoxManager _instance;

    private List<Box> _boxes = new List<Box>();

    public static int BoxCound => _instance._boxes.Count;

    [SerializeField] private UnityEvent<Vector3> OnBoxDestroyed;
    [SerializeField] private UnityEvent OnBoxesEmpty;

    public static void AddBox(Box box)
    {
        _instance._boxes.Add(box);
    }

    public static void RemoveBox(Box box)
    {
        if (!_instance._boxes.Contains(box)) return;
        
        _instance._boxes.Remove(box);
        _instance.OnBoxDestroyed.Invoke(box.transform.position);
        Destroy(box.gameObject);
        if(_instance._boxes.Count == 0) _instance.OnBoxesEmpty.Invoke();
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        OnBoxesEmpty.AddListener(() => GameStateManager.EndGame(0, GameResult.Win));
    }
}
