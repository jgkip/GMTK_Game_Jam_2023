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
    // public GameObject worldDataObject = null;
    private WorldData worldData;

    private void Start()
    {
        items = GetComponent<ItemList>();
        // worldData = worldDataObject.GetComponent<WorldData>();
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
      
        Instantiate(items.itemList[0], RandSpawnPos(), Quaternion.identity);
    }

    public void SpawnIncreaseHealth()
    {
        Instantiate(items.itemList[1], RandSpawnPos(), Quaternion.identity);
    }

    public void SpawnIncreaseDamage()
    {
        Instantiate(items.itemList[2], RandSpawnPos(), Quaternion.identity);
    }

    public void SpawnIncreaseSpeed()
    {
        Instantiate(items.itemList[3], RandSpawnPos(), Quaternion.identity);
    }

    private Vector2 RandSpawnPos()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    


}
