using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    [SerializeField] private float maxDistance;

    public string selection;
    // output for raycast
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selection = "Prefabs/Platform";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selection = "Prefabs/Wall";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selection = "Prefabs/Door";
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // if the play hits an object in 10 meters
            if (Physics.Raycast(transform.position, GetComponentInChildren<Camera>().transform.forward, out hit, maxDistance))
            {

            }
            else
            {
                Vector3 playerPosition = transform.position;
                Vector3 playerDirection = GetComponentInChildren<Camera>().transform.forward;
                Quaternion playerRotation = transform.rotation;

                Vector3 spawnPosition = playerPosition + playerDirection * 10;

                GameObject platform = Instantiate(Resources.Load(selection), spawnPosition, playerRotation) as GameObject;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // if the play hits an object in 10 meters
            if (Physics.Raycast(transform.position, GetComponentInChildren<Camera>().transform.forward, out hit, maxDistance))
            {
                // despawn the object
                Destroy(hit.transform.gameObject);
            }
        }
	}
}
