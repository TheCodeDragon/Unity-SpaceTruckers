using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    //Laser?

    private LineRenderer line;
    public float fl_range;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit mHit;

        if (Physics.Raycast(transform.position, transform.forward, out mHit))
        {
            if (mHit.collider)
            {
                line.SetPosition(1, new Vector3(0, 0, mHit.distance));
                Debug.Log("hit distance: "+ mHit.distance);
            }
        }
        else
        {
            line.SetPosition(1, new Vector3(0, 0, fl_range));
        }
        
	}
}
