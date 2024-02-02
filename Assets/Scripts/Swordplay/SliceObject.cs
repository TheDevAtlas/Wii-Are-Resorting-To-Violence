using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour {

	public Transform startSlicePoint;
	public Transform endSlicePoint;
	public VelocityEstimator velocityEstimator;
	public LayerMask layer;

	public Material cutMat;
	public float cutForce;
	public bool hasHit;

	public SwordGame sg;

	public AudioSource sound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
/*	void FixedUpdate(){
		RaycastHit hit;
		hasHit = Physics.Linecast (startSlicePoint.position, endSlicePoint.position, out hit, layer);

		if (Physics.Linecast (startSlicePoint.position, endSlicePoint.position, out hit, layer)) {
			GameObject target = hit.transform.gameObject;
			Slice(target);
		}
	}*/

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "SlicableObject") {
			GameObject target = col.gameObject.transform.gameObject;
			Slice (target);
		}
	}

	public void Slice(GameObject target){
		Vector3 velocity = velocityEstimator.GetVelocityEstimate ();
		Vector3 planeNormal = Vector3.Cross (endSlicePoint.position - startSlicePoint.position, velocity);
		planeNormal.Normalize ();

		SlicedHull hull = target.Slice (endSlicePoint.position, planeNormal);

		if (hull != null) {
			Material newMat = target.GetComponent<Renderer> ().material;

			GameObject upperHull = hull.CreateUpperHull (target, cutMat);
			SetupSlicedComponent (upperHull);
			GameObject lowerHull = hull.CreateLowerHull (target, cutMat);
			SetupSlicedComponent (lowerHull);

			sg.scoreTotal++;
			sound.Play ();

			Destroy (target);
		}
	}

	public void SetupSlicedComponent(GameObject slicedObject){
		Rigidbody rb = slicedObject.AddComponent<Rigidbody> ();
		MeshCollider collider = slicedObject.AddComponent<MeshCollider> ();
		collider.convex = true;
		rb.AddExplosionForce (cutForce, slicedObject.transform.position, 1);
		//slicedObject.transform.localScale = new Vector3 (100f, 100f, 100f);
	}
}
