using UnityEngine;

public class CreamMakeupAnimationPoint
{
    public readonly Vector3 FirstPoint;
    public readonly Vector3 SecondPoint;
    public readonly Vector3 ThirdPoint;

    public CreamMakeupAnimationPoint(Vector3 firstPoint,Vector3 secondPoint,Vector3 thirdPoint)
    {
        FirstPoint = firstPoint;
        SecondPoint = secondPoint;
        ThirdPoint = thirdPoint;
    }
}