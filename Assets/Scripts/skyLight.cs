using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class skyLight : MonoBehaviour
{
    //public Transform Target;
    //public Quaternion Force;

    [SerializeField] float moveSpeed, radius;
    float angle;
    [SerializeField] Transform target;
    Vector3 _target;
    //static readonly Color dayColour = "FFF4D6";

    [SerializeField] Color dayColour;
    [SerializeField] Color nightColour;

    private void Start()
    {
        _target = target.position;
        radius *= transform.position.y - _target.y;
    }

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

        angle += moveSpeed/(radius*Mathf.PI*2f) * Time.deltaTime;
        transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        /*if (transform.position.y < _target.y)
            GetComponent<Light>().color = nightColour;
        else
            GetComponent<Light>().color = dayColour;*/
    }
}
