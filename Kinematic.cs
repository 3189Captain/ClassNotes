using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
	public Vector3 linearVelocity;
	public float angularVelocity;
	public GameObject target;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//update position and rotation
		transform.position += linearVelocity * Time.deltaTime;
		transform.eulerAngles += new Vector3(0, angularVelocity * Time.deltaTime, 0);

		//update linear and angular velocities
		Seek mySeek = new Seek();
		mySeek.character = this;
		mySeek.target = target;
		SteeringOutput steering = mySeek.getSteering();
		linearVelocity += steering.linear * Time.deltaTime;
		angularVelocity += steering.angular * Time.deltaTime;
    }
}
