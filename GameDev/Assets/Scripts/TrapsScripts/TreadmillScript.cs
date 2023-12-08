using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEditor.ShaderGraph.Internal;

public class TreadmillScript : MonoBehaviour
{
    [SerializeField]
    private float lungime = 1.0f;
    [SerializeField]
    private Transform[] _cubePrefabs = null;
    [SerializeField]
    private Transform _planePrefab = null;
    [SerializeField]
    private float speed = 1.0f;
    private float _spawnTime = 3.0f;
    private List<Transform> ObstacleList = new List<Transform>();
    private List<Transform> PlaneList = new List<Transform>();
    private List<Transform> CylinderList = new List<Transform>();
    private float cylinderx = 19f, cylindery = 4.35f, cylinderz = 0.0f;
    private float wallx = 19f, wally = 7.15f;
    private float stepx = 19f, stepy = 5.15f, stepz = 0.0f;
    private float planex = 19f, planey = 5f, planez = 0f;


    private void Awake()
    {
        _spawnTime = 3.0f / speed;
        var globalx = transform.position.x;
        var globaly = transform.position.y;
        var globalz = transform.position.z;
        var planexOriginal = planex;
        cylinderx = globalx + cylinderx * lungime;
        wallx = globalx + wallx * lungime;
        stepx = globalx + stepx * lungime;
        planex = globalx + planex * lungime;
        cylindery = globaly + planey * lungime - 0.33f;
        wally = globaly + planey * lungime + 2.43f;
        stepy = globaly + planey * lungime + 0.43f;
        planey = globaly + planey * lungime;
        stepz = globalz + stepz;
        planez = globalz + planez;
        cylinderz = globalz + cylinderz;

        var planeDown = Instantiate(_cubePrefabs[3]);
        planeDown.position = new Vector3(globalx - 22.2f, globaly - 6.58f, globalz);
        var planeUp = Instantiate(_cubePrefabs[4]);
        planeUp.position = new Vector3(planex + 1.8f, planey + 0.06f, globalz);

        var planeUp2 = Instantiate(_cubePrefabs[5]);
        planeUp2.position = new Vector3(planex + 13.87f, planey + 1.975f, globalz);
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        var globalx = transform.position.x;
        var globaly = transform.position.y;
        var globalz = transform.position.z;
        while (true)
        {
            int cntWall = 1;
            var nrPrefab = Random.Range(0, 3);
            Debug.Log(nrPrefab);
            //wall creation
            if (nrPrefab == 1)
            {
                cntWall = Random.Range(1, 3);
                //Debug.Log(cntWall);
                for (int i = 0; i < cntWall; i++)
                {
                    var wallz = 0f;
                    int contloc = Random.Range(0, 3);
                    //Debug.Log(contloc);
                    if (contloc == 0)
                        wallz = -3.0f;
                    else if (contloc == 1)
                        wallz = 3.0f;
                    else if (contloc == 2)
                        wallz = 0.0f;

                    wallz = wallz + globalz;

                    var obstacle = Instantiate(_cubePrefabs[nrPrefab]);
                    obstacle.AddComponent<Rigidbody>().GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                    obstacle.GetComponent<Rigidbody>().isKinematic = true;
                    obstacle.position = new Vector3(wallx, wally, wallz);

                    ObstacleList.Add(obstacle);
                }
            }//step creation
            else if(nrPrefab == 0)
            {
                var obstacle = Instantiate(_cubePrefabs[nrPrefab]);
                obstacle.AddComponent<Rigidbody>().GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                obstacle.GetComponent<Rigidbody>().isKinematic = true;
                obstacle.position = new Vector3(stepx, stepy, stepz);
                ObstacleList.Add(obstacle);
            }//cylinder creation
            else
            {
                var obstacle = Instantiate(_cubePrefabs[nrPrefab]);
                obstacle.AddComponent<Rigidbody>().GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                obstacle.GetComponent<Rigidbody>().isKinematic = true;
                obstacle.position = new Vector3(cylinderx, cylindery, cylinderz);
                CylinderList.Add(obstacle); 
            }
            //plane creation
            if (nrPrefab != 2)
            {
                var plane = Instantiate(_planePrefab);
                plane.position = new Vector3(planex, planey, planez);
                PlaneList.Add(plane);
                
            }
            yield return new WaitForSeconds(_spawnTime);
        }

    }



    private void Update()
    {
        var globalx = transform.position.x;
        var globaly = transform.position.y;
        var globalz = transform.position.z;
        for (int i = 0;i < ObstacleList.Count;i++)
        {
            //ObstacleList[i].position = Vector3.MoveTowards(ObstacleList[i].position, new Vector3(-20.0f, -5.0f, ObstacleList[i].position.z), _speed);
            float z = ObstacleList[i].position.z;
            ObstacleList[i].Translate(-4f * Time.deltaTime * speed, -1.065f * Time.deltaTime * speed, 0);
            if (ObstacleList[i].position.x <= -20.0f + globalx)
            {
                Destroy(ObstacleList[i].gameObject);
                ObstacleList.Remove(ObstacleList[i]);
            }
        }
        for (int i = 0; i < PlaneList.Count; i++)
        {
            PlaneList[i].Rotate(0f, 0f, -15f, Space.Self);
           PlaneList[i].Translate(-4f * Time.deltaTime * speed, -1.065f * Time.deltaTime * speed, 0);
            PlaneList[i].Rotate(0f, 0f, 15f, Space.Self);

            if (PlaneList[i].position.x <= -20.0f + globalx)
            {
                Destroy(PlaneList[i].gameObject);
                PlaneList.Remove(PlaneList[i]);
            }
        }
        for (int i = 0; i < CylinderList.Count; i++)
        {
            CylinderList[i].Rotate(0f, 0f, -105f, Space.Self);
            CylinderList[i].Translate(-4f * Time.deltaTime * speed, -1.065f * Time.deltaTime * speed, 0);
            CylinderList[i].Rotate(0f, 0f, 105f, Space.Self);

            if (CylinderList[i].position.x <= -20.0f + globalx)
            {
                Destroy(CylinderList[i].gameObject);
                CylinderList.Remove(CylinderList[i]);
            }
        }
        
    }
}
