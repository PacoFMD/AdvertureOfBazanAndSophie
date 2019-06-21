using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE_GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject[] SpawnPoints;
    public GameObject background;
    public GameObject blackScreen;
    public GameObject defeatScreen;

    int SizeOfEnemies = 3, level = 1, i = 0, EnemiesOnLevel;
    bool IsOnLevel = true;
    float WaitTime = 0, TopTime = 1;

    float screenTimer = 0;
    void Start()
    {
        EnemiesOnLevel = SizeOfEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        WaitTime += Time.deltaTime;
        if (IsOnLevel)
        {            
            if (i < SizeOfEnemies)
            {
                if (WaitTime > TopTime)
                {                      
                    Instantiate(prefab, SpawnPoints[Random.Range(0, 2)].transform.position, Quaternion.identity);
                    WaitTime = 0;
                    i++;
                }
            }
        }
        else
        {
            IsOnLevel = false;
        }

        Debug.Log(EnemiesOnLevel);
        if(EnemiesOnLevel <= 0)
        {
            SizeOfEnemies *= 2;

            i = 0;
            IsOnLevel = true;
            if (level < 3)
            {
                ChangeLevel();
            }
            else
            {
                blackScreen.SetActive(true);
                Time.timeScale = 0;
                //Application.Quit();
            }
        }     
    }

    public void defeat()
    {
        defeatScreen.SetActive(true);
        Time.timeScale = 0;
        //Application.Quit();
    }

    void ChangeLevel()
    {
        level++;

        background.transform.Translate(-17.77f, 0, 0);
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].transform.position = new Vector3(-7.8f, Players[i].transform.position.y, Players[i].transform.position.z);
        }
        EnemiesOnLevel = SizeOfEnemies;
        screenTimer = 0;
        blackScreen.SetActive(false);
    }

    public void EnemyCount()
    {
        EnemiesOnLevel--;
    }
}

    


