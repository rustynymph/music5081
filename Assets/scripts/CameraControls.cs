using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public float rotAmount;
	private Camera camera;


	void Start(){
		camera = GetComponent<Camera>();
	}

	void Update(){
		if (Input.GetKey(KeyCode.LeftArrow)){
            camera.transform.Rotate(Vector3.down * Time.deltaTime * rotAmount);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
      		camera.transform.Rotate(Vector3.up * Time.deltaTime * rotAmount);
		}	
		if (Input.GetMouseButtonDown(0)){ // 0 is left mouse button clicked, 1 is right, 2 is middle
     		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
  		    RaycastHit hit;
	   		if (Physics.Raycast(ray, out hit)){
	   			SequenceChanger sequenceChanger;
	      		if (sequenceChanger = hit.transform.GetComponent<SequenceChanger>()){
	      			sequenceChanger.toggle = !sequenceChanger.toggle;
	      		}
	     	}
   		}			
	}
}