using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public Vector3 randPos;
    public Vector3 currentGoal;
    public Vector3 position;
    public static bool isGameLost = false;

    public int listPos = 0;

    List<Vector2> pointList = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        randPos = new Vector3(Random.Range(-24.0f, 24.0f), Random.Range(-10.0f, 10.0f), 0);
        pointList.Add(randPos);
        currentGoal = pointList[listPos];
        position = gameObject.transform.position;


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isGameLost = true;
            GameAndMenu.isGameWon = false;
            print("oops");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(position, currentGoal);
        position = gameObject.transform.position;

        if (isGameLost == false & GameAndMenu.timeLeft > 0 & GameAndMenu.isTimerRunning == true & GameAndMenu.isGameWon == false)
        {
            if (distance >= 0.01f)
            {
                float step = GameAndMenu.enemySpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, currentGoal, step);
            }
            else
            {
                randPos = new Vector3(Random.Range(-24.0f, 24.0f), Random.Range(-13.25f, 13.25f), 0);
                listPos = listPos + 1;
                pointList.Add(randPos);
                currentGoal = pointList[listPos];
            }
        }
        else
        {
                
        }
    }
}
