using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour 
{
	[SerializeField]
	private GameObject boxDestroyed;

	public void DestroyBox()
	{
		Instantiate(boxDestroyed,transform.position,transform.rotation);
		Destroy(this.gameObject);
	}

}
