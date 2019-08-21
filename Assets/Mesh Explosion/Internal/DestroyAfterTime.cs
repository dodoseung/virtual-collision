using System.Collections;

using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	
	public float waitTime;
	
	IEnumerator Starts() {
		yield return new WaitForSeconds(waitTime);
		GameObject.Destroy(gameObject);
	}
	
}
