using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {

	public GameObject backgroundSpr;

	void Start () {
		GameObject.Instantiate(backgroundSpr,
		                       backgroundSpr.transform.position,
		                       backgroundSpr.transform.rotation);
	}

	void Update () {
		
	}
}
