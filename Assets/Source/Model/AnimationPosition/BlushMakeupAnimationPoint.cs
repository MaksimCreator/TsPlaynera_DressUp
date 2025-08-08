using UnityEngine;

public class BlushMakeupAnimationPoint
{
    public readonly Vector3 FacePosition; 
    public readonly Vector3 LeftPoint;
    public readonly Vector3 RightPoint;

    public BlushMakeupAnimationPoint(Vector3 facePosition,Vector3 leftPoint, Vector3 rightPoint)
    {
        FacePosition = facePosition;
        LeftPoint = leftPoint;
        RightPoint = rightPoint;
    }
}
