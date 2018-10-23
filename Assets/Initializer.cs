using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] Tester _testerPrefab = null;

    void Awake()
    {
        var displays = Display.displays;

        // Display 0
        Instantiate(_testerPrefab).Setup(0);

        for (var i = 1; i < displays.Length; i++)
        {
            displays[i].Activate();
            Instantiate(_testerPrefab).Setup(i);
        }
    }
}
