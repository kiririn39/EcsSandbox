using System.Collections.Generic;
using Project.Src.Interfaces;
using UnityEngine;

namespace Project.Src
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "PrefabsContainer", order = 0)]
    public class PrefabsContainer : ScriptableObject, IPrefabs
    {
        public GameObject[] prefabs;

        
        public IEnumerable<GameObject> Pop()
        {
            var prefs = prefabs;
            prefabs = new GameObject[0];

            return prefs;
        }
    }
}