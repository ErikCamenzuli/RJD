using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    //array of paths
    public GameObject[] paths;
    //how many paths on screen
    public int pathsOnScreen = 10;
    //player protection distance
    public float playerProtection = 12.5f;

    //player transform
    private Transform player;
    //spawning path 
    private float spawnPathZ = -5f;
    //length of the path
    private float pathLength = 10f;
    //last path
    private int lastPath = 0;

    //listing the gameobjects for the current paths
    private List<GameObject> currentPaths = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //finding a tag with "player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //making the paths spawn
        for(int i = 0; i < pathsOnScreen; i++ )
        {
            SpawnPath();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //checking if the players position - the players protection is greater than the vale of 
        //the spawn path of Z - how many paths are on screen * the length of the path.
        //Then calling SpawnPath/DeletePath
        if(player.position.z - playerProtection > (spawnPathZ - pathsOnScreen * pathLength))
        {
            SpawnPath();
            DeletePath();
        }
    }

    void SpawnPath(int index = -1)
    {
        //setting a gameobject
        GameObject path;
        //instantiating/spawning the gameobject
        path = Instantiate(paths[RandomPathGen()]) as GameObject;
        //setting the gameobject to our own transform
        path.transform.SetParent(transform);
        //moving the bridge forward (0,0,1)
        path.transform.position = Vector3.forward * spawnPathZ;
        //setting path spawn to path length
        spawnPathZ += pathLength;
        currentPaths.Add(path);
    }

    /// <summary>
    /// destroying/removing the paths that is behind the player
    /// </summary>
    void DeletePath()
    {
        Destroy(currentPaths[0]);
        currentPaths.RemoveAt(0);
    }

    public int RandomPathGen()
    {
        //setting random index to the last path
        int RandomIndex = lastPath;
        //checking if the length of the path is less than or equaled to 1
        if (paths.Length <= 1)
        {
            //return 0
            return 0;      
        }
        //while the random index is equaled to the last path
        while (RandomIndex == lastPath)
        {
            //set the random index to a random range within 0 and the length of how many paths
            //there are
            RandomIndex = Random.Range(0, paths.Length);
        }
        //set the last path to the random index and return its value
        lastPath = RandomIndex;
        return RandomIndex;
    }
}
