using System;
using Bardent.ProjectileSystem.DataPackages;
using UnityEngine;

namespace Bardent.ProjectileSystem
{
    /// <summary>
    /// This class is the interface between projectile components and any entity that spawns a projectile.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        // This event is used to notify all projectile components that Init has been called
        public event Action OnInit;
        public event Action OnReset;

        public event Action<ProjectileDataPackage> OnReceiveDataPackage;

        public Rigidbody2D Rigidbody2D { get; private set; }

        public float time = 5;
        public void Init()
        {
            OnInit?.Invoke();
        }

        public void Reset()
        {
            OnReset?.Invoke();
        }

        public void Update()
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                gameObject.SetActive(false);
                
            }
        }
        /* This function is called before Init from the weapon. Any weapon component can use this to function to pass along information that the projectile might need that is
        weapon specific, such as: damage amount, draw length modifiers, etc. */        
        public void SendDataPackage(ProjectileDataPackage dataPackage)
        {
            OnReceiveDataPackage?.Invoke(dataPackage);
        }

        #region Plumbing

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        #endregion
    }
}