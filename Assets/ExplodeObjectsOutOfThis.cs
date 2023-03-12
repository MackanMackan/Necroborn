using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObjectsOutOfThis : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> m_bodies;
    [SerializeField] private float m_force;
    private void OnEnable()
    {
        foreach(Rigidbody body in m_bodies)
        {
            body.gameObject.SetActive(true);
            body.AddForceAtPosition((body.position - transform.position).normalized * m_force, transform.position,ForceMode.VelocityChange);
        }
    }
}
