using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : ShootableObject
{
    //public EnemyRagdoll enemyRagdoll;
    public GameObject particlesPrefab;

    public override void OnHit(RaycastHit hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
        if (particleSystem)
        {
            particleSystem.startColor = Color.red;
        }
        //enemyRagdoll.EnableRagdoll();
        Destroy(particleSystem, 2f);
    }
}
