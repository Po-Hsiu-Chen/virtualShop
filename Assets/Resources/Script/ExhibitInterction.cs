using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class ExhibitInteraction : MonoBehaviour
{
    public GameObject manager;
    public GameObject[] descriptionCanvas; 
    private GameObject player;
    private RaycastManager raycastManager;

    void Start()
    {
        foreach (GameObject canvas in descriptionCanvas)
        {
            canvas.SetActive(false);
        }
        raycastManager = manager.GetComponent<RaycastManager>();
    }

    public void ShowInfoCanvas(string objectName)
    {
        foreach (GameObject canvas in descriptionCanvas)
        {
            if (canvas.name == objectName)
            {
                canvas.SetActive(true);
                player = GameObject.Find("PlayerArmature 1(Clone)");
                raycastManager.isInfo = true;
                player.SetActive(false);
                return;
            }
            else
            {
                canvas.SetActive(false);
            }
        }
    }

    public void HideInfoCanvas()
    {
        foreach (GameObject canvas in descriptionCanvas)
        {
            canvas.SetActive(false);
        }

        player.SetActive(true);
        raycastManager.isInfo = false;
    }

    public void ShowVideoCanvas(string objectName)
    {
        player = GameObject.Find("PlayerArmature 1(Clone)");
        raycastManager.isInfo = true;
        player.SetActive(false);
    }

}
