using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MainManager : MonoBehaviour
    {
        public static MainManager Instance;
        public GameObject originalPrefab;
        public GameObject arrowFromCToB1;
        public GameObject arrowFromCToB2;
        public GameObject arrowFromCToB3;
        public GameObject arrowFromCToB4;
        public GameObject arrowFromCToA1;
        public GameObject arrowFromCToA2;
        public GameObject arrowFromCToA3;
        public GameObject arrowFromAToB1;
        public GameObject arrowFromAToB2;
        public GameObject arrowFromAToB3;
        public GameObject arrowFromAToC1;
        public GameObject arrowFromAToC2;
        public GameObject arrowFromAToC3;
        public GameObject arrowFromBToC1;
        public GameObject arrowFromBToC2;
        public GameObject arrowFromBToC3;
        public GameObject arrowFromBToC4;
        public GameObject arrowFromBToA1;
        public GameObject arrowFromBToA2;
        public GameObject arrowFromBToA3;
        public GameObject arrowFromBToA4;
        public GameObject arrowFromAToCanteen1;
        public GameObject arrowFromAToCanteen2;
        public GameObject arrowFromCToCanteen1;
        public GameObject arrowFromCToCanteen2;
        public GameObject arrowFromCToCanteen3;
        public GameObject arrowFromCToCanteen4;
        public GameObject arrowFromBToCanteen1;
        public GameObject arrowFromBToCanteen2;
        public GameObject arrowAPrefab;
        public GameObject arrowBPrefab;
        public GameObject arrowCPrefab;
        
        public List<GameObject> arrowsFromCToB = new List<GameObject>();
        public List<GameObject> arrowsFromCToA = new List<GameObject>();
        public List<GameObject> arrowsFromCToCanteen = new List<GameObject>();
        public List<GameObject> arrowsFromAToB = new List<GameObject>();
        public List<GameObject> arrowsFromAToC = new List<GameObject>();
        public List<GameObject> arrowsFromAToCanteen = new List<GameObject>();
        public List<GameObject> arrowsFromBToA = new List<GameObject>();
        public List<GameObject> arrowsFromBToC = new List<GameObject>();
        public List<GameObject> arrowsFromBToCanteen = new List<GameObject>();

        private Dictionary<ArrowType, List<GameObject>> arrowDictionary = new Dictionary<ArrowType, List<GameObject>>();



        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeArrows();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void InitializeArrows()
        {
            arrowDictionary.Add(ArrowType.CToB, new List<GameObject> { arrowFromCToB1, arrowFromCToB2, arrowFromCToB3, arrowFromCToB4 });
            arrowDictionary.Add(ArrowType.CToA, new List<GameObject> { arrowFromCToA1, arrowFromCToA2, arrowFromCToA3 });
            arrowDictionary.Add(ArrowType.CToCanteen, new List<GameObject> { arrowFromCToCanteen1, arrowFromCToCanteen2, arrowFromCToCanteen3, arrowFromCToCanteen4 });
            arrowDictionary.Add(ArrowType.AToB, new List<GameObject> { arrowFromAToB1, arrowFromAToB2, arrowFromAToB3 });
            arrowDictionary.Add(ArrowType.AToC, new List<GameObject> { arrowFromAToC1, arrowFromAToC2, arrowFromAToC3 });
            arrowDictionary.Add(ArrowType.AToCanteen, new List<GameObject> { arrowFromAToCanteen1, arrowFromAToCanteen2 });
            arrowDictionary.Add(ArrowType.BToA, new List<GameObject> { arrowFromBToA1, arrowFromBToA2, arrowFromBToA3, arrowFromBToA4 });
            arrowDictionary.Add(ArrowType.BToC, new List<GameObject> { arrowFromBToC1, arrowFromBToC2, arrowFromBToC3, arrowFromBToC4 });
            arrowDictionary.Add(ArrowType.BToCanteen, new List<GameObject> { arrowFromBToCanteen1, arrowFromBToCanteen2 });
        }
        
        private void ToggleArrows(ArrowType arrowType)
        {
            foreach (GameObject arrow in arrowDictionary[arrowType])
            {
                arrow.SetActive(!arrow.activeSelf);
            }
        }
        

        public void OnToBBlockClicked(CurrentLocations currentLocation)
        {
            if (currentLocation == CurrentLocations.BlockC)
            {
                ToggleArrows(ArrowType.CToB);
            }
            else
            {
                ToggleArrows(ArrowType.AToB);
            }
        }

        public void OnToCBlockClicked(CurrentLocations currentLocation)
        {
            if (currentLocation == CurrentLocations.BlockB)
            {
                ToggleArrows(ArrowType.BToC);
            }
            else if (currentLocation == CurrentLocations.BlockA)
            {
                ToggleArrows(ArrowType.AToC);
            }
            // Handle other cases if needed
        }

        public void OnToABlockClicked(CurrentLocations currentLocation)
        {
            if (currentLocation == CurrentLocations.BlockB)
            {
                ToggleArrows(ArrowType.BToA);
            }
            else if (currentLocation == CurrentLocations.BlockC)
            {
                ToggleArrows(ArrowType.CToA);
            }
            // Handle other cases if needed
        }
        

        public void OnToCanteenClicked(CurrentLocations currentLocation)
        {
            if (currentLocation == CurrentLocations.BlockA)
            {
                ToggleArrows(ArrowType.AToCanteen);
            }
            else if (currentLocation == CurrentLocations.BlockB)
            {
                ToggleArrows(ArrowType.BToCanteen);
            }
            else
            {
                ToggleArrows(ArrowType.CToCanteen);
            }
        }


        public void Clear()
        {
            if(arrowAPrefab.activeSelf) arrowAPrefab.SetActive(false);
            if(arrowBPrefab.activeSelf) arrowBPrefab.SetActive(false);
            if(arrowCPrefab.activeSelf) arrowCPrefab.SetActive(false);
        }
    }
    
    public enum CurrentLocations
    {
        BlockA,
        BlockB,
        BlockC
    }
    public enum ArrowType
    {
        CToB,
        CToA,
        CToCanteen,
        AToB,
        AToC,
        AToCanteen,
        BToA,
        BToC,
        BToCanteen
    }
    
}