using UnityEngine;

[ExecuteAlways]
public class ColorPropertyBlock : MonoBehaviour
{
    [SerializeField] private Color _objectColor = Color.white;

    private Renderer renderer;
    private MaterialPropertyBlock mpb;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
        ApplyColor(_objectColor);
    }

    // private void OnValidate()
    // {
    //     if (renderer == null)
    //     {
    //         renderer = GetComponent<Renderer>();
    //         mpb = new MaterialPropertyBlock();
    //     }
    //
    //     ApplyColor(_objectColor);
    // }

    private void ApplyColor(Color newColor)
    {
        mpb.SetColor("_Color", newColor);
        renderer.SetPropertyBlock(mpb);
    }
}