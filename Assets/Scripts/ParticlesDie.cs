using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyer());
    }
    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
