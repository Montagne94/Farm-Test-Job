using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterAnimator))]
public class CharacterMove : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private bool _isMoving;
    private CharacterAnimator _characterAnimator;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _characterAnimator.SetPlant();
                _isMoving = false;
            }
        }
    }

    public void SetTarget(Cell target)
    {
        if (!_isMoving)
        {
            _navMeshAgent.SetDestination(target.transform.position);
            _characterAnimator.SetRun();
            _isMoving = true;
        }
    }
}