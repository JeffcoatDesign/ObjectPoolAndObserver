using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.ObjectPool
{
    public class ClientObjectPool : MonoBehaviour
    {
        private DroneObjectPool _pool;

        private void Start()
        {
            _pool = gameObject.AddComponent<DroneObjectPool>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Drones"))
                _pool.Spawn();
        }
    }
}
