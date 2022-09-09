using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicBullet : MonoBehaviour
{
    private Vector2 wind;
    private float speed;
    private float gravity;
    private Vector3 startPosition;
    private Vector3 startForward;

    private bool isInitialized = false;
    private float startTime = -1;

    public void Initialize(Transform startPoint, float speed, float gravity, Vector2 wind)
    {
        startPosition = startPoint.position;
        startForward = startPoint.forward.normalized;
        this.speed = speed;
        this.gravity = gravity;
        this.wind = wind;
        isInitialized = true;
        startTime = -1f;
    }

    private Vector3 FindPointOnParabola(float time)
    {
        
        Vector3 movementVec = (startForward * time * speed);
        Vector3 windVec = new Vector3(wind.x, 0, wind.y) * time * time;
        Vector3 gravityVec = Vector3.down * gravity * time * time;
        return startPosition + movementVec + gravityVec + windVec;
    }

    private bool CastRayBetweenPoints(Vector3 startPoint, Vector3 endPoint, out RaycastHit hit)
    {
        return Physics.Raycast(startPoint, endPoint - startPoint, out hit, (endPoint - startPoint).magnitude);
    }

    /*private void OnHit(RaycastHit hit)
    {
        
    }*/

    private void FixedUpdate()
    {
        if (!isInitialized) return;
        if (startTime < 0) startTime = Time.time;

        RaycastHit hit;
        float currentTime = Time.time - startTime;
        
        float nextTime = currentTime + Time.fixedDeltaTime;

        

        Vector3 currentPoint = FindPointOnParabola(currentTime);
        Vector3 nextPoint = FindPointOnParabola(nextTime);

        if(CastRayBetweenPoints(currentPoint, nextPoint, out hit))
        {
            ShootableObject shootableObject = hit.transform.GetComponent<ShootableObject>();
            if (shootableObject)
            {
                shootableObject.OnHit(hit);
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isInitialized || startTime < 0) return;

        float currentTime = Time.time - startTime;
        Vector3 currentPoint = FindPointOnParabola(currentTime);
        transform.position = currentPoint;
    }

}
