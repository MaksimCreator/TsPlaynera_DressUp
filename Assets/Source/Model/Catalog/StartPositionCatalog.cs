using UnityEngine;

public class StartPositionCatalog
{
    public readonly Vector3 StartPositionHand;
    public readonly Vector3 StartPositionDragMove;

    public StartPositionCatalog(Vector3 startPositionHand, Vector3 startPositionDragMove)
    {
        StartPositionHand = startPositionHand;
        StartPositionDragMove = startPositionDragMove;
    }
}
