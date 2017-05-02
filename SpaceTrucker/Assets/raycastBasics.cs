using UnityEngine;

public class raycastBasics : MonoBehaviour {
    //Basic Raycasting Script - Modify for shooting/mining

    //Sticking these here for later
    [Header("WeaponOptions")]
    public float fl_Damage = 10;
    public string st_DamageType;
    public float fl_Range = 100f;

    [Header("Raycasting")]
    public Camera cam_Raycast;
	// Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetButton("Fire1"))
        {
            CastRay();
        }

	}
    public void CastRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam_Raycast.transform.position, cam_Raycast.transform.forward, out hit, fl_Range))
        {
            Debug.Log(hit.transform.name);
        }
    }
    void Shoot()
    {
       
    }
}
