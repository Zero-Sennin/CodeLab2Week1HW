using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public KeyCode left, right;
    float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(left) && Camera.main.WorldToViewportPoint(transform.position).x > 0.05f)
        {
            transform.Translate(Vector3.right * -5f * Time.deltaTime);
        }

        if (Input.GetKey(right) && Camera.main.WorldToViewportPoint(transform.position).x < 0.95f)
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
    }
}
