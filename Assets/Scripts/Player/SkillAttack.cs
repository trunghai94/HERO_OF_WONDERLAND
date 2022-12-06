using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private List<ParticleCollisionEvent> particleCollisionEvents;
    public float dmg;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        particleCollisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(_particleSystem, other, particleCollisionEvents);
        

        for(int i = 0; i < particleCollisionEvents.Count; i++)
        {
            var collider = particleCollisionEvents[i].colliderComponent;
            if (collider.CompareTag("Enemy"))
            {
                var healthEnemy = collider.GetComponent<EnemyStat>();

                healthEnemy.TakeDmg(dmg + (20*playerManager.instance.GetComponent<PlayerStats>().level));
            }
        }
    }
}
