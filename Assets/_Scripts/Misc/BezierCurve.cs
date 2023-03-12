using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BezierCurve
{
    public static Vector3 DoCurvePosition(Transform transform1, Transform transform2, Transform transform3, Transform transform4, float time)
    {
        Vector3 position1 = transform1.position;
        Vector3 position2 = transform2.position;
        Vector3 position3 = transform3.position;
        Vector3 position4 = transform4.position;

        Vector3 A = Vector3.Lerp(position1, position2, time);
        Vector3 B = Vector3.Lerp(position2 , position3, time);
        Vector3 C = Vector3.Lerp(position4, position4 , time);
        Vector3 D = Vector3.Lerp(A , B , time);
        Vector3 E = Vector3.Lerp(B , C, time);
        Vector3 P = Vector3.Lerp(D , E , time);

        return P;
    }
    public static Quaternion DoCurveRotation(Transform transform1, Transform transform2, Transform transform3, Transform transform4, float time)
    {
        Quaternion position1 = transform1.rotation;
        Quaternion position2 = transform2.rotation;
        Quaternion position3 = transform3.rotation;
        Quaternion position4 = transform4.rotation;

        Quaternion A = Quaternion.Lerp(position1, position2, time);
        Quaternion B = Quaternion.Lerp(position2, position3, time);
        Quaternion C = Quaternion.Lerp(position4, position4, time);
        Quaternion D = Quaternion.Lerp(A, B, time);
        Quaternion E = Quaternion.Lerp(B, C, time);
        Quaternion P = Quaternion.Lerp(D, E, time);

        return P;
    }
}
