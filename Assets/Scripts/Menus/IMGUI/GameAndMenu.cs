using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAndMenu : MonoBehaviour
{
    public Vector2 screen;
    public static bool isMenuOpen = true;
    public static float timeLeft;
    public int selectedDifficulty;
    public GameObject enemy;
    public GameObject player;
    public GameObject[] enemies;
    public static float enemySpeed;
    public static bool isTimerRunning = true;
    public static bool isGameWon = false;
    public string humanTime;



    // Start is called before the first frame update
    private void OnGUI()
    {
        screen.x = Screen.width / 16;
        screen.y = Screen.height / 9;

        if (isMenuOpen)
          {
            Menu();
          }
        if (!isMenuOpen)
        {
            Debug.Log(enemies);
            GUI.Box(new Rect(screen.x * 0, screen.y * 0, screen.x * 1, screen.y * 1), humanTime);

            if (timeLeft > 0 & isTimerRunning == true & EnemyMoveScript.isGameLost == false & isGameWon == false)
            {
                timeLeft -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeLeft / 60);
                float seconds = Mathf.FloorToInt(timeLeft % 60);
                humanTime = string.Format("{0:00}:{1:00}", minutes, seconds);
                print(humanTime);
            }
            else
            {
                isTimerRunning = false;
                isGameWon = true;
                timeLeft = 0;
            }
        }
    }

    void Menu()
    {
        if (GUI.Button(new Rect(screen.x * 6, screen.y * 2, screen.x * 3, screen.y * 1), "Easy"))
        {
            isMenuOpen = false;
            timeLeft = 15;
            selectedDifficulty = 4;
            enemySpeed = 6f;
            isTimerRunning = true;
            Spawner();
        }
        if (GUI.Button(new Rect(screen.x * 6, screen.y * 4, screen.x * 3, screen.y * 1), "Medium"))
        {
            isMenuOpen = false;
            timeLeft = 20;
            selectedDifficulty = 6;
            enemySpeed = 7f;
            isTimerRunning = true;
            Spawner();
        }
        if (GUI.Button(new Rect(screen.x * 6, screen.y * 6, screen.x * 3, screen.y * 1), "Hard"))
        {
            isMenuOpen = false;
            timeLeft = 30;
            selectedDifficulty = 10;
            enemySpeed = 8f;
            isTimerRunning = true;
            Spawner();
        }
    }

    void Spawner()
    {
        enemies = new GameObject[selectedDifficulty];
        for (int i = 0; i < selectedDifficulty; i++)
        {
            enemies[i] = Instantiate(enemy);
        }
        Instantiate(player, new Vector3(0,0,0), transform.rotation);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameWon == true || EnemyMoveScript.isGameLost == true)
        {
            SceneManager.LoadScene(3);
        }
    }
}
