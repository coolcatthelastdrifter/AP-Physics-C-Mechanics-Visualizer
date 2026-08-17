using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBodyManager : MonoBehaviour
{
    public GameObject[] threeBodies;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject body in threeBodies)
        {
            body.transform.position = new Vector3 (body.transform.position.x + Random.Range(-2,2), body.transform.position.y + Random.Range(-2,2), 0);
            body.GetComponent<TrailRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject body in threeBodies)
        {
            if (body.transform.position.magnitude > 10)
            {
                foreach (GameObject newBody in threeBodies)
                {
                    body.GetComponent<TrailRenderer>().enabled = false;
                    newBody.transform.position = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
                    body.GetComponent<TrailRenderer>().enabled = true;

                    newBody.GetComponent<ThreeBody>().velocity.x = 0;
                    newBody.GetComponent<ThreeBody>().velocity.y = 0;
                }
            }
        }
    }
}
