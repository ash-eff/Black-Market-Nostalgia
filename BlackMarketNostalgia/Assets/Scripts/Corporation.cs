using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corporation : MonoBehaviour {

    new Collider2D collider;

	void Start ()
    {
        collider = GetComponent<Collider2D>();
	}
}
