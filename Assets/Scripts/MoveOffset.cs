using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Material ActualMaterial;
    [SerializeField] private float speed;
    private float offset;

    void Start()
    {
        ActualMaterial = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        offset += 0.01f;

        ActualMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
