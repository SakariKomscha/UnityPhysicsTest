using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleManager : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform shootPoint;


    public WindManager windManager;
    public float shootSpeed;
    public float gravityForce;
    public float bulletLifeTime;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPref, shootPoint.position, shootPoint.rotation);
        ParabolicBullet bulletScript = bullet.GetComponent<ParabolicBullet>();
        if (bulletScript)
        {
            bulletScript.Initialize(shootPoint, shootSpeed, gravityForce, windManager.GetWind());
        }
        Destroy(bullet, bulletLifeTime);
    }
}
