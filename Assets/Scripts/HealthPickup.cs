using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotationSpeed = new(0, 180, 0);

    AudioSource pickupAudioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        pickupAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable)
        {
            if (damageable.Heal(healthRestore))
            {
                if (pickupAudioSource != null)
                {
                    AudioSource.PlayClipAtPoint(pickupAudioSource.clip, gameObject.transform.position, pickupAudioSource.volume);
                }

                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }
}
