using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public ItemList items;
    [SerializeField] private string newGame = "Game";
    private float minX, maxX, minY, maxY;
    private Vector2 bounds;
    public GameObject worldDataObject;
    private WorldData worldData;
    private bool paused;

    private void Start()
    {
        paused = false;
        items = GetComponent<ItemList>();
        worldData = worldDataObject.GetComponent<WorldData>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Pause();
            }
            else
            {
                paused = false;
                Play();
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGame);
    }

    public void Play()
    {
       
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Change this later... please
    public void SpawnHealthPack()
    {
      
        Instantiate(items.itemList[0], worldData.RandSpawnPos(), Quaternion.identity);
    }

    public void SpawnIncreaseHealth()
    {
        Instantiate(items.itemList[1], worldData.RandSpawnPos(), Quaternion.identity);
    }

    public void SpawnIncreaseDamage()
    {
        Instantiate(items.itemList[2], worldData.RandSpawnPos(), Quaternion.identity);
    }

    public void SpawnIncreaseSpeed()
    {
        Instantiate(items.itemList[3], worldData.RandSpawnPos(), Quaternion.identity);
    }

}
