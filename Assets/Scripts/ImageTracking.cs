using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{
    private ARTrackedImageManager _trackedImagesManager;
    private ColorManager _colorManager;
    public GameObject[] ArPrefabs;
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        _colorManager = GetComponent<ColorManager>();
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            var imageName = trackedImage.referenceImage.name;

            foreach (var curPrefab in ArPrefabs)
            {
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    if(imageName.Equals("A")) _colorManager.OnABlockScanned();
                    if(imageName.Equals("B")) _colorManager.OnBBlockScanned();
                    if(imageName.Equals("C")) _colorManager.OnCBlockScanned();

                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (_instantiatedPrefabs.ContainsKey(trackedImage.referenceImage.name))
            {
                Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
                _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            }
        }
    }
}
