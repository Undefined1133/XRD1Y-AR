using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class NewBehaviourScript : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private GameObject objectToInstantiate;
    public GameObject instantiatedGameObject;

    public Camera camera;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        objectToInstantiate = MainManager.Instance.originalPrefab;
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                Pose pose = hits[0].pose;
                if (instantiatedGameObject == null)
                {
                    instantiatedGameObject = Instantiate(objectToInstantiate, pose.position, pose.rotation);
                    foreach (var plane in planeManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Destroy(instantiatedGameObject);
                }
            }
        }
    }
}
