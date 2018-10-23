using UnityEngine;
using UnityEngine.UI;

public class Tester : MonoBehaviour
{
    [SerializeField] Camera _camera = null;
    [SerializeField] Canvas _canvas = null;
    [SerializeField] Text _label = null;

    public void Setup(int index)
    {
        var display = Display.displays[index];

        _camera.targetDisplay = index;
        _canvas.targetDisplay = index;

        _label.text = string.Format(
            "Display {0}\nResolution: {1}x{2}",
            index, display.systemWidth, display.systemHeight
        );
    }
}
