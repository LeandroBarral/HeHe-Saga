using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        Vector3 originalScale = projectile.transform.localScale;

        projectile.transform.localScale = new(originalScale.x * transform.localScale.x > 0 ? 1 : -1, originalScale.y, originalScale.z);
    }
}
