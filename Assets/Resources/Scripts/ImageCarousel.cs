using System.Collections;
using UnityEngine;

public class ImageCarousel : MonoBehaviour
{
    public Texture[] images; 
    public float interval = 2f; 
    
    private Renderer screenRenderer;
    private int currentImageIndex = 0;

    void Start()
    {
        screenRenderer = GetComponent<Renderer>();
        if (images.Length > 0)
        {
            StartCoroutine(SwitchImages());
        }
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            screenRenderer.material.mainTexture = images[currentImageIndex];
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            yield return new WaitForSeconds(interval);
        }
    }
}
