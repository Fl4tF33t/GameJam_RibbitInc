using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeBreakable : MonoBehaviour
{
    public List<GameObject> platformsList;
    Player1Controller player1Controller;

    private void Start()
    {
        player1Controller = GameObject.Find("Player1").GetComponent<Player1Controller>();

        platformsList = new List<GameObject>();

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject platform in platforms)
        {
            platformsList.Add(platform);
        }
    }

    public void MakeOneBreakable()
    {
        StartCoroutine(SetInactive(player1Controller.breakable));
    }

    private IEnumerator SetInactive(GameObject platform)
    {
        platform.SetActive(false);
        yield return new WaitForSeconds(5f);
        platform.SetActive(true);
    }
}
