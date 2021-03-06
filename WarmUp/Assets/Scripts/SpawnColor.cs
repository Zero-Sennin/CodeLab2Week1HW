﻿using UnityEngine;
using System.Collections;

public class SpawnColor : MonoBehaviour {

    public Sprite[] sprites;
    public float spawnInterval = 1f;
    float timer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
	}

    /// <summary>
    /// Create a new colored orb and set its position and color.
    /// </summary>
    void Spawn()
    {
        GameObject sprite = Instantiate(Resources.Load("Prefabs/Color") as GameObject);
        float spawnPointX = Random.Range(0.05f, 0.95f);
        sprite.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(spawnPointX, 0.5f, 0f));
        sprite.transform.position = new Vector3(sprite.transform.position.x, transform.position.y, transform.position.z);
        int num = sprite.GetComponent<GetColor>().GetSpriteColor();
        sprite.GetComponent<SpriteRenderer>().sprite = sprites[num];
    }
}
