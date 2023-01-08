using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockBack = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Damageable>(out var damageable))
        {
            Vector2 deliveredKickBack = transform.parent.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            var gotHit = damageable.Hit(attackDamage, deliveredKickBack);

            if (gotHit)
            {
                Debug.LogFormat("{0} hit for {1}", collision.name, attackDamage);
            }
        }
    }
}
