using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour, IDamageable
{
    public float explodeRadius;
    public int explodeDamage;
    [SerializeField] private Color _gizmoColor;
    [SerializeField] private AudioClip takeDamageSound;
    [SerializeField] private bool hasExploded;

    public void TakeDamage(int damage)
    {
        if (!hasExploded)
        {
            hasExploded = true;
            AudioManager.instance?.PlaySfx(takeDamageSound, this.transform.position);
            Collider[] cols = Physics.OverlapSphere(transform.position, explodeRadius);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].GetComponent<IDamageable>() != null && cols[i].gameObject != this.gameObject)
                {
                    cols[i].GetComponent<IDamageable>().TakeDamage(explodeDamage);
                }
            }

            Destroy(gameObject);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(transform.position, explodeRadius);
        //Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }


}
