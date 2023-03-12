using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateWithBezierCurve : MonoBehaviour
{
    [Header("Positions For The Bezier Curve Equation")]
    [SerializeField]
    Transform pos1;

    [SerializeField]
    Transform pos2;

    [SerializeField]
    Transform pos3;

    [SerializeField]
    Transform pos4;

    [Header("What Curves Will You Use")]
    [SerializeField]
    bool usePositionCurve = true;
    [SerializeField]
    bool useRotationCurve = true;

    [Header("What Easings Will You Use")]
    [SerializeField]
    bool usePositionEasing = true;
    [SerializeField]
    bool useRotationEasing = true;

    [SerializeField]
    [Header("Easings")]
    Easings.Easing positionEasing = Easings.Easing.EaseInSine;
    [SerializeField]
    Easings.Easing rotationEasing = Easings.Easing.EaseInSine;

    [Header("Timer")]
    [SerializeField]
    float timeUntilFinished = 1.0f;

    void Start()
    {
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    IEnumerator Animate()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime / timeUntilFinished;
            if (usePositionCurve && usePositionEasing) { transform.position = BezierCurve.DoCurvePosition(pos1, pos2, pos3, pos4, Easings.GetEasing(positionEasing, time)); }
            else if (usePositionCurve) { transform.position = BezierCurve.DoCurvePosition(pos1, pos2, pos3, pos4, time); }

            if(useRotationCurve && useRotationEasing) { transform.rotation = BezierCurve.DoCurveRotation(pos1, pos2, pos3, pos4, Easings.GetEasing(rotationEasing, time)); }
            else if (useRotationCurve) { transform.rotation = BezierCurve.DoCurveRotation(pos1, pos2, pos3, pos4, time); }

            yield return 0;
        }
    }
}
