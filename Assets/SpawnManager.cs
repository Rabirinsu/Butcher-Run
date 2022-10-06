using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager;
    private LevelData levelData;

    private int currentlevelID;
    public List<GameObject> animals;
    public List<GameObject> obstacles;
    private int obstaclespawnLimit;
    private int animalspawnLimit;
    [SerializeField] private List<Vector3> animalspawnPoints;
    [SerializeField] private List<Vector3> obstaclespawnPoints;
    private Vector3 animalspawnRotation;
    private Vector3 obstaclespawnRotation;

    private void Awake()
    {
        if (spawnManager != null && spawnManager != this)
        {
            Destroy(this);
        }
        else
        {
            spawnManager = this;
        }

    }
    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        
         currentlevelID = LevelManager.levelManager.currentLevelID;
        currentlevelID--;
        var currentLevel = LevelManager.levelManager.Levels[currentlevelID]; // Get current level
        obstaclespawnLimit = currentLevel.obstaclespawnLimit;
        animalspawnLimit = currentLevel.animalspawnLimit;
        animalspawnPoints = currentLevel.animalspawnPoints;
        obstaclespawnPoints = currentLevel.obstaclespawnPoints;
        animals = currentLevel.animals;
        obstacles = currentLevel.obstacles;
        animalspawnRotation = currentLevel.animalspawnRotation;
        obstaclespawnRotation = currentLevel.obstaclespawnRotation;
     
        SpawnLevel();
    }

    private void SpawnLevel()
    {

        for (var i = 0; i < obstaclespawnLimit; i++)
        {
            var spawnedObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)], obstaclespawnPoints[i], Quaternion.Euler(obstaclespawnRotation));

        }
        for (var i = 0; i < animalspawnLimit; i++)
        {
            var spawnedAnimal = Instantiate(animals[Random.Range(0, animals.Count)], animalspawnPoints[i], Quaternion.Euler(animalspawnRotation));
        }

    }
}

  
