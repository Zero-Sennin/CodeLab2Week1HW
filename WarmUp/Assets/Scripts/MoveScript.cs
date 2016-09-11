using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public KeyCode left, right;
    public ColorTypes currentColor = ColorTypes.NONE;
    public Color[] colors;

    GameManager gameManagerRef;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        gameManagerRef = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<SpriteRenderer>().color = colors[(int)currentColor];

        if (Input.GetKey(left) && Camera.main.WorldToViewportPoint(transform.position).x > 0.05f)
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }

        if (Input.GetKey(right) && Camera.main.WorldToViewportPoint(transform.position).x < 0.95f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.GetComponent<GetColor>())
        {
            if (currentColor == ColorTypes.NONE || other.gameObject.GetComponent<GetColor>().currentColor != currentColor)
            {
                currentColor = other.gameObject.GetComponent<GetColor>().currentColor;
                gameManagerRef.Score += 5;
                gameManagerRef.CurrentChain += 1;

                if (gameManagerRef.CurrentChain % 5 == 0)
                {
                    GetPowerup();
                }
                Destroy(other.gameObject);
            }

            else if (currentColor == other.gameObject.GetComponent<GetColor>().currentColor)
            {
                gameManagerRef.Score -= 5;
                gameManagerRef.Lives -= 1;
                Destroy(other.gameObject);
            }
        }
    }

    void GetPowerup()
    {
        gameManagerRef.Score *= 2;

        if (speed + 2f < 15f)
        { 
            speed += 2f;
        }
    }
}
