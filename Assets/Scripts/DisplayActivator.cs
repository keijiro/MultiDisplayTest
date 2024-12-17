using UnityEngine;
using UnityEngine.UIElements;

public sealed class DisplayActivator : MonoBehaviour
{
    [SerializeField] GameObject _monitorPrefab = null;

    Color GetColorForIndex(int i)
      => new Color((i & 1) != 0 ? 0.2f : 0.1f,
                   (i & 2) != 0 ? 0.2f : 0.1f,
                   (i & 4) != 0 ? 0.2f : 0.1f);

    void Start()
    {
        var displays = Display.displays;

        for (var i = 0; i < displays.Length; i++)
        {
            var disp = displays[i];
            if (!disp.active) disp.Activate();

            var text = $"Display: {i + 1}";
            text += $"\nResolution: {disp.systemWidth} x {disp.systemHeight}";
            text += $"\nRendering: {disp.renderingWidth} x {disp.renderingHeight}";

            var root = Instantiate(_monitorPrefab);

            var camera = root.GetComponentInChildren<Camera>();
            camera.targetDisplay = i;
            camera.backgroundColor = GetColorForIndex(i + 1);

            var doc = root.GetComponentInChildren<UIDocument>();
            var label = doc.rootVisualElement.Q<Label>("label");
            label.text = text;

            var panel = Instantiate(doc.panelSettings);
            panel.targetDisplay = i;
            doc.panelSettings = panel;
        }
    }
}
