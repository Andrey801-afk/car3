using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    [SerializeField] public GameObject Basket;
    [SerializeField] public GameObject StartFlag;
    [SerializeField] public GameObject EndFlag;
    [SerializeField] public List<GameObject> Items = new List<GameObject>();
    [SerializeField] public GameObject Player;

    private void Start()
    {
        GlobalEvents.StartFlagTouched.AddListener(StartSimulation);
        GlobalEvents.EndFlagTouched.AddListener(EndGame);

        EndFlag.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void StartSimulation()
    {
        Debug.Log("Start simulation");
        EndFlag.GetComponent<Rigidbody>().isKinematic = false;
        Player.layer = 3;
    }

    public void EndGame()
    {
        SaveManager.LevelDone(SceneManager.GetActiveScene().name);
        Debug.Log("Game over");
    }

    public void Restart()
    {
        GameScenesControl.Reload();
    }
}
