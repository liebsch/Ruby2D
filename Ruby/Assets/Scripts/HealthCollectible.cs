using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    public ParticleSystem stars;

    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                GameObject.Instantiate(stars, transform.position, transform.rotation);
                Destroy(gameObject);

                controller.PlaySound(collectedClip);
            }
        }
    }
}

