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

    int missedChains;
    
    public int MissedChains
    {
        get { return missedChains; }
        set { missedChains = value; }
    }

    public MoveScript player;
    public Image[] missImages;

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

        switch(missedChains)
        {
            case 0:
                foreach (Image icon in missImages)
                {
                    icon.enabled = false;
                }
                break;

            case 1:
                missImages[0].enabled = true;
                break;

            case 2:
                missImages[0].enabled = true;
                missImages[1].enabled = true;
                missImages[2].enabled = false;
                break;

            case 3:
                foreach (Image icon in missImages)
                {
                    icon.enabled = true;
                }
                break;
        }

        if (missedChains == 3)
        {
            missedChains = 0;
            score -= 10;
            lives -= 1;

            if (player.speed - 2f >= 5f)
            {
                player.speed -= 2f;
            } 
            
            else
            {
                player.speed = 5f;
            }  
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
