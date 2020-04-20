using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
   
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;
 
public int score;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Application.LoadLevel(Application.loadedLevel);
            }

            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 150)
        {
            gameOverText.text = "You win! Game created by Deja Fernandez.";


            musicSource.clip = winMusic;
            musicSource.Play();
        
        }
    
        
    }

        public void GameOver()
    {

        if (score <= 150)
        { 
            gameOverText.text = "Game Over! Game created by Deja Fernandez.";
            musicSource.clip = backgroundMusic;
            musicSource.Stop(); }
        {

            musicSource.clip = loseMusic;
            musicSource.Play();


        }

        if (score>=100)
        {

            musicSource.clip = winMusic;
            musicSource.Play();


        }

     
        gameOver = true;
        restart = true;
    }
}
