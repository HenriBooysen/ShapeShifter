using UnityEngine;

public class LightReset : MonoBehaviour
{
    private Light attachedLight;

    // Start is called before the first frame update
    void Start()
    {
        attachedLight = GetComponent<Light>();
        if (attachedLight != null)
        {
            ResetLight();
        }
        else
        {
            Debug.LogWarning("No Light component found on this GameObject.");
        }
    }

    void ResetLight()
    {
        attachedLight.enabled = false;
        attachedLight.enabled = true;
    }
}
