using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    GameObject ruby;
    Vector3 rubyPosition;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        ruby = GameObject.Find("Ruby");
        rubyPosition = ruby.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

//        if (transform.position.magnitude > 1000.0f)
        if (Vector3.Distance(rubyPosition, this.transform.position) > 10.0f)
        {
                Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
