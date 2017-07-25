using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed;
	public float rotationSpeed;
	public float jumpHeight;

	public Lydscript lydscript;

	Rigidbody rigidbody; 


	void Start(){
		rigidbody = GetComponent<Rigidbody>();
		//lydscript = GetComponent<Lydscript> ();
	}

	void Update () {
		Move();
		Jump ();
	}

	void Move(){

		float translation = Input.GetAxis("Vertical")* speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

		if (translation != 0 || rotation != 0) {
			lydscript.WalkSound ();
		}

		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate (0,rotation,0);
	}
	void Jump (){
		if (Input.GetKeyDown ("space")) {
			rigidbody.AddForce (transform.up * jumpHeight);
			lydscript.JumpSound ();
		}


	}

}
