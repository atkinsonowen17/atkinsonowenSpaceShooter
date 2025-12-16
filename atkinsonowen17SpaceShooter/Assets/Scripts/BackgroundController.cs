using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BackgroundController : MonoBehaviour
{
    public Material[] skyboxMaterials;

    void Start()
    {
        if (skyboxMaterials.Length == 0) return;

        // Pick a random skybox
        Material chosen = skyboxMaterials[Random.Range(0, skyboxMaterials.Length)];

        // Apply it
        RenderSettings.skybox = chosen;
    }
}
