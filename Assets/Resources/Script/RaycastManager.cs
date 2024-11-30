using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject manager;
    public bool isInfo = false;
    private ExhibitInteraction exhibitInteraction;

    void Start()
    {
        exhibitInteraction = manager.GetComponent<ExhibitInteraction>();
    }
    
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        Ray mouseRay = mainCamera.ScreenPointToRay(pos);

        if (!isInfo && Input.GetMouseButtonDown(0))
        {
            RaycastHit hitObj;
            if (Physics.Raycast(mouseRay, out hitObj))
            {
                string hitTag = hitObj.collider.gameObject.tag;
                switch (hitTag)
                {
                    case "Exhibits":
                        string objectName = hitObj.transform.parent.gameObject.name;
                        print(objectName);
                        exhibitInteraction.ShowInfoCanvas(objectName);
                        break;
                    case "Multi-commodity":
                        Renderer objRenderer = hitObj.collider.gameObject.GetComponent<Renderer>();
                        ImageCarousel carousel = hitObj.collider.gameObject.GetComponent<ImageCarousel>();
    
                        if (carousel != null)
                        {
                            // 獲取ImageCarousel中的screenRenderer的mainTexture名稱
                            Renderer screenRenderer = carousel.GetComponent<Renderer>();
                            if (screenRenderer != null && screenRenderer.material.mainTexture != null)
                            {
                                string materialName = screenRenderer.material.mainTexture.name;
                                print(materialName);
                                exhibitInteraction.ShowInfoCanvas(materialName);
                            }
                            else
                            {
                                Debug.LogWarning("screenRenderer 中找不到 mainTexture");
                            }
                        }
                        else
                        {
                            Debug.LogWarning("找不到 ImageCarousel");
                        }
                        break;

                    default:
                        Debug.Log($"Unknown tag: {hitTag}");
                        break;
                }
            }
        }
    }
}
