using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Vector2 moveSpeed = new(3f, 0);
    public Vector2 knockBack = new(0, 0);

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Damageable>(out var damageable))
        {
            Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockBack : new(-knockBack.x, knockBack.y);
            var gotHit = damageable.Hit(damage, deliveredKnockBack);

            if (gotHit)
            {
                Debug.LogFormat("{0} hit for {1}", collision.name, damage);
                Destroy(gameObject);
            }
        }
    }
}
