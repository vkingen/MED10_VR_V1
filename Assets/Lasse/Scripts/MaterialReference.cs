using UnityEngine;

public class MaterialReference : MonoBehaviour
{
    public Material material;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    private void Awake()
    {
        material = skinnedMeshRenderer.material;
    }
}
