using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastSystem
{
    private GraphicRaycaster _graphicRaycaster;
    private EventSystem _eventSystem;

    public RaycastSystem(GraphicRaycaster graphicRaycaster, EventSystem eventSystem)
    {
        _graphicRaycaster = graphicRaycaster;
        _eventSystem = eventSystem;
    }

    public bool TryGetCharacterView(Vector2 position,out CharacterView characterView)
    {
        characterView = default;

        PointerEventData pointerData = new PointerEventData(_eventSystem)
        {
            position = position,
        };

        List<RaycastResult> results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(pointerData, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.TryGetComponent(out characterView))
                return true;
        }

        return false;
    }
}