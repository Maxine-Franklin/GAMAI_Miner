using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyLight : MonoBehaviour
{
    public Transform Target;
    public Quaternion Force;


    // Update is called once per frame
    void FixedUpdate()
    {
        /*Vector3 relativePos = (Target.position + Force) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(0, 0, 3 * Time.deltaTime);*/

        // -->transform.Rotate(transform.rotation.x + 1, transform.rotation.y, transform.rotation.z);

        //transform.LookAt(Target);
        //GetComponent<Rigidbody>().AddRelativeForce(Force);
    }
}
