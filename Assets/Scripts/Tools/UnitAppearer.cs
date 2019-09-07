using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class UnitAppearer 
{
    private GameObject appearRoot;
    private WaveAppearsModel waveAppearsModels;

    public UnitAppearer(GameObject appearRoot,WaveAppearsModel waveAppearsModels)
    {
        this.appearRoot = appearRoot;
        this.waveAppearsModels = waveAppearsModels;
    }

    public List<GameObject> AppearBy(double elapsedTime)
    {
        List<WaveAppearModel> searchAppearModels = waveAppearsModels.SearchAppearModel(elapsedTime);
        List<GameObject> InstantiateGameObjects = new List<GameObject>();

        foreach(var searchAppearModel in searchAppearModels)
        {
            searchAppearModel.Appear();

            var instantiateGameObject = GameObject.Instantiate(searchAppearModel.AppearEnemyGroup);
            instantiateGameObject.transform.SetParent(appearRoot.transform);
            InstantiateGameObjects.Add(instantiateGameObject);
        }

        return InstantiateGameObjects;
    }

    public bool IsAllAppeared
    {
        get { return waveAppearsModels.IsAllAppeard; }
    }

}
