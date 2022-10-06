using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/LevelData")]
public class LevelData : ScriptableObject
{
    public int currentLevelID;
    public int nextLevelID;

    [System.Serializable]
    public struct Level 
    {
        public int levelID;
        public int obstaclespawnLimit;
        public int animalspawnLimit;
        public List<GameObject> animals;
        public List<GameObject> obstacles;
        public List<Vector3> obstaclespawnPoints;
        public List<Vector3> animalspawnPoints;
        public Vector3 animalspawnRotation;
        public Vector3 obstaclespawnRotation;
    };
}
