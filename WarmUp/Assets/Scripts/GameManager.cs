using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Text scoreCounter, livesCounter, chainCounter;
    public SpawnColor spawnerRef;

    int score, lives = 3;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    int currentChain;

    public int CurrentChain
    {
        get { return currentChain; }
        set { currentChain = value; }
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("DecreaseSpawnTimer", 10f, 10f);
	}

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = "Score: " + score;
        livesCounter.text = "Lives: " + lives;
        chainCounter.text = currentChain + " chain";

        if (lives == 0)
        {
            SceneManager.LoadScene("EmptyScene");
        }
    }

    void DecreaseSpawnTimer()
    {
        if (spawnerRef.spawnInterval > 0.2f)
        { 
            spawnerRef.spawnInterval -= 0.1f;
        }
    }
}
