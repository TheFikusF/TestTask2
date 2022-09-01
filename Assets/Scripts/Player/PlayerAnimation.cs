using System.Linq;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    
    [Header("Models")]
    [SerializeField] private GameObject _normalModel;
    [SerializeField] private GameObject _ragdollModel;

    public void BecomeRagdoll()
    {
        _normalModel.SetActive(false);
        _ragdollModel.SetActive(true);
    }
    
    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.sqrMagnitude);
        _animator.SetBool("Box", 
            Physics.OverlapSphere(_rigidbody.transform.position, 0.7f)
                .Any(x => x.GetComponent<Box>() != null));
    }
}
