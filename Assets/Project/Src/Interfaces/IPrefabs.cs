using System.Collections.Generic;
using UnityEngine;

namespace Project.Src.Interfaces
{
    public interface IPrefabs
    {
        IEnumerable<GameObject> Pop();
    }
}