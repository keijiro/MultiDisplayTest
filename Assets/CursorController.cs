using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] RectTransform _mouseCursor;
    [SerializeField] RectTransform[] _touchCursors;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseCursor.anchoredPosition = Input.mousePosition;
            _mouseCursor.gameObject.SetActive(true);
        }
        else
        {
            _mouseCursor.gameObject.SetActive(false);
        }

        var touches = Input.touches;
        var i = 0;

        for (; i < touches.Length; i++)
        {
            _touchCursors[i].anchoredPosition = touches[i].position;
            _touchCursors[i].gameObject.SetActive(true);
        }

        for (; i < _touchCursors.Length; i++)
            _touchCursors[i].gameObject.SetActive(false);
    }
}
