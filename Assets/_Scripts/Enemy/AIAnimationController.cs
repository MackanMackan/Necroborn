using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int m_animSpeed = Animator.StringToHash("Speed");
 
    public void RunAnimation(Vector3 velocity)
    {
        animator.SetFloat(m_animSpeed, velocity.sqrMagnitude);
    }
}
