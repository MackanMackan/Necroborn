using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour
{
    [SerializeField] private Transform m_crown;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private Ease m_growthEase;
    [SerializeField] private Ease m_shrinkEase;

    [Space]
    [SerializeField] private float m_sizeToGrow;
    [SerializeField] private float m_timeToMax;
    
    [Space]
    [SerializeField] private float m_timeToMin;
    [SerializeField] private float m_timeUntilEnd;


    private void Update()
    {
        RotateCrown();
    }
    
    // Invoked from event
    public void OnLevelUp()
    {
        m_crown.gameObject.SetActive(true);
        m_crown.DOScale(Vector3.one * m_sizeToGrow, m_timeToMax).SetEase(m_growthEase);
        
        Invoke(nameof(EndLevelUp), m_timeUntilEnd);
    }

    private void EndLevelUp()
    {
        m_crown.DOScale(Vector3.zero, m_timeToMin).SetEase(m_shrinkEase).OnComplete(
            () => m_crown.gameObject.SetActive(false));
    }

    private void RotateCrown()
    {
        Quaternion rotation = m_crown.rotation;
        rotation = Quaternion.RotateTowards(rotation, 
            rotation * Quaternion.Euler(0,1,0), m_rotationSpeed);
        m_crown.rotation = rotation;
    }
}
