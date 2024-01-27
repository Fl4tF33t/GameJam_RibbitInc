using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeBreakable : MonoBehaviour
{
    public List<GameObject> platformsList;

    private void Start()
    {
        platformsList = new List<GameObject>();

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject platform in platforms)
        {
            platformsList.Add(platform);
        }
    }

    public void MakeOneBreakable()
    {
        int random = Random.Range(0, platformsList.Count);

        Breakable chosenPlatform = platformsList[random].GetComponent<Breakable>();

        if (chosenPlatform != null)
        {
            chosenPlatform.isBreakable = true;
        }
    }

    public void Inactive(GameObject platform)
    {
        StartCoroutine(SetInactive(platform));
    }

    private IEnumerator SetInactive(GameObject platform)
    {
        platform.SetActive(false);
        yield return new WaitForSeconds(5f);
        platform.SetActive(true);
    }
}
