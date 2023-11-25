using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    private List<GameObject> currentEnnemies = new List<GameObject>();
    private List<GameObject> nextEnnemies = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // populate current ennemies list
            currentEnnemies.Add(transform.GetChild(i).gameObject);
        }

        nextEnnemies = CopyEnnemies(currentEnnemies);
        SetEnnemiesActive(nextEnnemies, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnnemies.Count == 0)
        {
            currentEnnemies = CopyEnnemies(nextEnnemies);
            SetEnnemiesActive(currentEnnemies, true);
        }
    }

    private List<GameObject> CopyEnnemies(List<GameObject> list)
    {
        List<GameObject> ret = new List<GameObject>();
        
        foreach (GameObject ennemy in list)
        {
            ret.Add(Instantiate(ennemy));
        }

        return ret;
    }

    private void SetEnnemiesActive(List<GameObject> list, bool active)
    {
        foreach (GameObject ennemy in list)
        {
            ennemy.SetActive(active);
        }
    }
    
    public void RemoveEnnemy(GameObject ennemy)
    {
        currentEnnemies.Remove(ennemy);
    }
}