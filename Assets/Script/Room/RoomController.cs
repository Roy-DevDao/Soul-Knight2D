using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    public bool isSolved = false;
    public List<RoomGate> gates;
    public List<BaseEnemy> enemiesInRoom;
    public UnityEvent onSolved;
    public GameObject chest;

    private bool hasPlayerEnteredUnsolvedRoom = false;

    // Use this for initialization
    void Start()
    {
        if (chest != null)
        {
            chest.SetActive(false);
        }
        foreach (RoomGate gate in gates)
        {

            gate.roomController = this;

            gate.onEnter(() =>
            {
                if (!isSolved && !hasPlayerEnteredUnsolvedRoom)
                {
                    hasPlayerEnteredUnsolvedRoom = true;
                    //gate.gameObject.SetActive(false);
                    foreach (BaseEnemy enemy in enemiesInRoom)
                    {
                        AIDestinationSetter setter = enemy.GetComponent<AIDestinationSetter>();
                        if (setter != null)
                        {
                            setter.target = GameObject.Find("Player")?.transform;
                        }

                        enemy.target = FindAnyObjectByType<Player>();
                    }
                }
            });

            gate.gameObject.SetActive(true);
        }
    }

    public void Solve()
    {
        if (isSolved) return;

        Debug.Log("Solve Room");

        isSolved = true;
        //foreach (RoomGate gate in gates)
        //{
        //    gate.gameObject.SetActive(true);
        //}
        if (chest != null)
        {
            chest.SetActive(true);
            Transform chestClose = chest.transform.Find("ChestClose");
            if (chestClose != null)
                chestClose.gameObject.SetActive(true);
            Debug.Log("Chest found: " + chest.name);

            Transform chestOpen = chest.transform.Find("ChestOpen");
            if (chestOpen != null)
                chestOpen.gameObject.SetActive(false);
            Debug.Log("Chest found: " + chest.name);


        }

        if (onSolved != null && onSolved.GetPersistentEventCount() > 0)
            onSolved.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSolved) return;

        if (gates.Count > 0)
        {
            List<RoomGate> gatesFiltered = new List<RoomGate>();
            foreach (RoomGate gate in gates)
            {
                if (gate.gameObject.activeSelf)
                {
                    gatesFiltered.Add(gate);
                }
            }
            gates = gatesFiltered;
        }

        List<BaseEnemy> enemiesFilterd = new List<BaseEnemy>();
        for (int i = 0; i < enemiesInRoom.Count; ++i)
        {
            if (enemiesInRoom[i] != null && enemiesInRoom[i].gameObject != null)
            {
                enemiesFilterd.Add(enemiesInRoom[i]);
            }
        }
        enemiesInRoom = enemiesFilterd;

        if (enemiesInRoom.Count == 0)
        {
            this.Solve();
        }
    }

    public void HideGateTemporarily(GameObject gateObj)
    {
        StartCoroutine(HideGateCoroutine(gateObj));
    }

    private IEnumerator HideGateCoroutine(GameObject gateObj)
    {
        gateObj.SetActive(false);
        yield return new WaitForSeconds(1f);
        gateObj.SetActive(true);
    }
}
