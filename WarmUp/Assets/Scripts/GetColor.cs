using UnityEngine;
using System.Collections;

public class GetColor : MonoBehaviour {

    public ColorTypes currentColor;

    void Update()
    {
        if(Camera.main.WorldToViewportPoint(transform.position).y < -0.25f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().MissedChains += 1;
            Destroy(gameObject);
        }
    }

	public virtual int GetSpriteColor()
    {
        currentColor = (ColorTypes)Random.Range(0, 3);
        return (int)currentColor;
    }
}
