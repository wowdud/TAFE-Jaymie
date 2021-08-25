using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    public Vector2 screen;
    GUIStyle style = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        style.alignment = TextAnchor.MiddleCenter;
    }

    private void OnGUI()
    {
        screen.x = Screen.width / 16;
        screen.y = Screen.height / 9;

        if (EnemyMoveScript.isGameLost == false & GameAndMenu.isGameWon == true)
        {
            GUI.Box(new Rect(screen.x * 4, screen.y * 0, screen.x * 7, screen.y * 3), "You Win!", style);
        }
        if (EnemyMoveScript.isGameLost == true)
        {
            GUI.Box(new Rect(screen.x * 4, screen.y * 0, screen.x * 7, screen.y * 3), "You Lose!", style);
        }

        if (GUI.Button(new Rect(screen.x * 6, screen.y * 5, screen.x * 3, screen.y * 1), "Play again"))
        {
            GameAndMenu.isGameWon = false;
            EnemyMoveScript.isGameLost = false;
            GameAndMenu.isMenuOpen = true;
            SceneManager.LoadScene(2);
        }
        if (GUI.Button(new Rect(screen.x * 6, screen.y * 7, screen.x * 3, screen.y * 1), "Back to menu"))
        {
            GameAndMenu.isGameWon = false;
            EnemyMoveScript.isGameLost = false;
            GameAndMenu.isMenuOpen = true;
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
