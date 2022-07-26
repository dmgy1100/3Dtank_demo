using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_display : MonoBehaviour
{
    public ParticleSystem shellExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        shellExplosion.transform.parent = null;
        if (shellExplosion != null)
        {
            shellExplosion.Play();
            Destroy(shellExplosion.gameObject, shellExplosion.duration);
        }
        Destroy(this.gameObject);
    }
}
