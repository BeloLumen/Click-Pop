using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> targets;
    [SerializeField] float spawnRate = 2.0f;
    private int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;
    public bool isGameActive;
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score < 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(1);
        while (isGameActive)
        {
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(spawnRate);
        }
      
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;

    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
