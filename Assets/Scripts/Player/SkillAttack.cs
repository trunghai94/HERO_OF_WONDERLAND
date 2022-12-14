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
                var level = playerManager.instance.GetComponent<PlayerStats>().level;
                healthEnemy.TakeDmg(dmg+(dmg * level));
            }
        }
    }
}
