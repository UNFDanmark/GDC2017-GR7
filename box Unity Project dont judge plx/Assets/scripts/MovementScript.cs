using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MovementScriptDone : MonoBehaviour {
	public float speed;
	public float rotationSpeed;
	public float jumpHeight;


	Rigidbody rigidbody; 
	

	void Start(){
		rigidbody = GetComponent<Rigidbody>();

	}

	void Update () {
		Move();
		Jump ();
	}

	void Move(){

		float translation = Input.GetAxis("Vertical")* speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

		if (translation != 0 || rotation != 0) {

		}

		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate (0,rotation,0);
	}
	void Jump (){
		if (Input.GetKeyDown ("space")) {
			rigidbody.AddForce (transform.up * jumpHeight);

		}


	}

}

