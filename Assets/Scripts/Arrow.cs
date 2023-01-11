using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] ParticleSystem particleGreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag =="ground")
        {
            Instantiate(particleGreen, transform.position, Quaternion.identity);
        }        
    }
}
