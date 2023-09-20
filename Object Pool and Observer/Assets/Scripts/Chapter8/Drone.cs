using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Pool { get; set; }

        public float currentHealth;

        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _timeToSelfDestruct = 3.0f;

        void Start()
        {
            currentHealth = _maxHealth;
        }

        void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        void OnDisable()
        {
            ResetDrone();
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(_timeToSelfDestruct);
            TakeDamage(_maxHealth);
        }

        private void ReturnToPool()
        {
            Pool.Release(this);
        }
        private void ResetDrone()
        {
            currentHealth = _maxHealth;
        }

        public void AttackPlayer()
        {
            Debug.Log("Attack Player!");
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0f)
                ReturnToPool();
        }
    }
}