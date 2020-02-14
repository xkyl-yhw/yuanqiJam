using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassPoint : MonoBehaviour
{
    public Transform tf;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = tf.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
