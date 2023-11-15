using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public Material redMaterial;

    public Material greenMaterial;

    public Material yellowMaterial;
    
    private GameObject viaPrefab;
    public delegate void BlockScannedEventHandler(CurrentLocations location);
    public static event BlockScannedEventHandler BlockScanned;



    private void Start()
    { 
        viaPrefab = MainManager.Instance.originalPrefab;
    }


    public void OnABlockScanned()
    {
        Transform child = viaPrefab.transform.Find("Block A");

        Renderer renderer = child.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = redMaterial;
        }
        if (BlockScanned != null)
        {
            BlockScanned(CurrentLocations.BlockA);
        }
    }
    
    public void OnBBlockScanned()
    {
        Transform child = viaPrefab.transform.Find("Block B");

        Renderer renderer = child.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = greenMaterial;
        }
        if (BlockScanned != null)
        {
            BlockScanned(CurrentLocations.BlockB);
        }
    }
    
    public void OnCBlockScanned()
    {
        Transform child = viaPrefab.transform.Find("Block C");

        Renderer renderer = child.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = yellowMaterial;
        }
        if (BlockScanned != null)
        {
            BlockScanned(CurrentLocations.BlockC);
        }
    }
    
    
}
