using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform targetPoint;
    public float gravity = 9.81f;
    public Rigidbody rigidbody;

    void Start()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Vector3 origin = transform.position;
        Vector3 target = targetPoint.position;

        // Calculate horizontal distance (range)
        float range = Vector3.Distance(origin, target);

        // Calculate initial velocity
        float initialVelocity = CalculateInitialVelocity(range);

        // Calculate launch angle
        float launchAngle = CalculateLaunchAngle(range, initialVelocity);

        // Apply velocity and angle to launch arrow
        LaunchArrow(initialVelocity, launchAngle);
    }

    float CalculateInitialVelocity(float range)
    {
        return Mathf.Sqrt((gravity * range) / Mathf.Sin(2 * CalculateLaunchAngle(range, 1)));
    }

    float CalculateLaunchAngle(float range, float initialVelocity)
    {
        return Mathf.Asin((gravity * range) / (2 * initialVelocity));
    }

    void LaunchArrow(float initialVelocity, float launchAngle)
    {
        // Apply initial velocity and launch angle to the arrow (projectile)
        // For example, apply a force to a Rigidbody component with given velocity and angle
        
    }
}
