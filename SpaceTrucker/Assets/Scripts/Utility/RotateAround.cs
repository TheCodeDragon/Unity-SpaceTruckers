using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
    //Utility script to simply have something orbit around another thing.
    public Vector3 RotationVector;
    public GameObject OrbitFocus;
    public float RotationSpeed;
    // Use this for initialization
    void Update()
    {
        transform.RotateAround(OrbitFocus.transform.position, RotationVector, RotationSpeed * Time.deltaTime);
    }


}
