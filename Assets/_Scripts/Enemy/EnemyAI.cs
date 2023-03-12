using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_aiAgent;
    [SerializeField] private Transform m_target;
    [SerializeField] private AIAnimationController m_animController;

    void Update()
    {
        MoveToTarget();
    }
    private void MoveToTarget()
    {
        if(m_target == null) return;

        m_aiAgent.SetDestination(m_target.position);
        m_animController.RunAnimation(m_aiAgent.velocity);
    }
}
