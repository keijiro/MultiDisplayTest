using UnityEngine;

public class ScreenActivator : MonoBehaviour
{
    void Start()
    {
        for (var i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();
    }
}
