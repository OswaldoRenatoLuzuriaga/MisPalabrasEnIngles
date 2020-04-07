using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.CodeDom;

public class GameOver : MonoBehaviour
{

	private Rigidbody rbd;
	private float downForce = 20000f;
	// Start is called before the first frame update
	void Start()
    {
		rbd = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		rbd.constraints = RigidbodyConstraints.None;
		rbd.velocity = Vector2.zero;
		rbd.AddForce(Vector2.down * downForce);
	}

	public void LanzarGameOver() {
		rbd.constraints = RigidbodyConstraints.None;
		rbd.velocity = Vector2.zero;
		rbd.AddForce(Vector2.down * downForce);
	}
}
