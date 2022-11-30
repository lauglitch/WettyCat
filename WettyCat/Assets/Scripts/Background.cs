using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    Renderer renderer;

    void Start()
    {
        speed = 0.2f;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 translation = new Vector2(Mathf.Repeat(Time.time * speed, 1), 0.0f);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", translation);
        //renderer.GetComponent<Material>().SetTextureOffset("_MainTex", translation);
    }
}
