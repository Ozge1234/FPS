using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  
    [Header("Prefernce")]
    [SerializeField] GunData gunData;
    [SerializeField] private Transform muzzle;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
    }

    private bool CanShoot() => !gunData.reLoading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    private void Shoot()
    {
        if(gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                Debug.Log("fire!");
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }

        }

    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);

    }

        private void OnGunShot() 
    {
       
    
    }
}
