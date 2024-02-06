using System;
using System.Collections;
using UnityEngine;

public class BoneResource : MonoBehaviour, IPickUpable
{
    [SerializeField] private Rigidbody m_body;
    [SerializeField] private float m_accelerationToPlayer;
    private bool m_canMoveTowardsPlayer;
    private WaitForSeconds m_timeToWait = new WaitForSeconds(.5f);

    private void OnEnable()
    {
        StartCoroutine(CoCountDownUntilMove());
    }
    private void Update()
    {
        if (!m_canMoveTowardsPlayer) return;

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
       m_body.AddForce((PlayerPickUpArea.Instance.PlayerTransform.position - transform.position).normalized * m_accelerationToPlayer, ForceMode.Acceleration);
    }

    public void OnPickup()
    {
        ResourceManager.Instance.AddBoneResource(1);
        Destroy(gameObject);
    }

    private IEnumerator CoCountDownUntilMove()
    {
        yield return m_timeToWait;

        m_canMoveTowardsPlayer = true;
    }
}
