using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    /// <summary>
    /// Starting position for de parallax game object
    /// </summary>
    Vector2 startingPosition;

    /// <summary>
    /// Start Z value of the parallax game object
    /// </summary>
    float startingZ;

    // Distance that the camera has moved from the starting position of the parallax object
    Vector2 CamMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float ZDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    float ClippingPlane => cam.transform.position.z + (ZDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane);

    float ParallaxFactor => Mathf.Abs(ZDistanceFromTarget) / ClippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // When the target moves, move the parallax object the same distance times a multiplier
        Vector2 newPosition = startingPosition + CamMoveSinceStart * ParallaxFactor;

        // The X/Y position changes based on target travel speed times the parallax factor, but Z stays consistent
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}