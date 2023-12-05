using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameStates
{
    None,
    Start,
    Over
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStates GameStates = GameStates.None;

    public GameObject[] objectsToPool;
    public int pooledAmount = 5;
    public Transform pooledTransform;
    private List<GameObject>[] objectPools;

    float leftPos = -5.5f;
    float rightPos = 5.5f;

    public TMP_Text scoreTxt;
    public int score = 0;

    public GameObject GetPooledObject(int index)
    {
        for (int i = 0; i < objectPools[index].Count; i++)
        {
            if (!objectPools[index][i].activeInHierarchy)
            {
                return objectPools[index][i];
            }
        }

        return null;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        leftPos = 0;
        rightPos = Screen.currentResolution.width;

        InstantiateGO();
        GameStates = GameStates.Start;
        Debug.Log("GameStart");
        StartCoroutine(GamePlay());
        scoreTxt.text = "Score = 0";
    }

    void InstantiateGO()
    {
        objectPools = new List<GameObject>[objectsToPool.Length];

        for (int i = 0; i < objectsToPool.Length; i++)
        {
            objectPools[i] = new List<GameObject>();

            for (int j = 0; j < pooledAmount; j++)
            {
                GameObject obj = Instantiate(objectsToPool[i]);
                obj.SetActive(false);
                obj.transform.parent = pooledTransform;
                obj.transform.localPosition = Vector3.zero;
                objectPools[i].Add(obj);
            }
        }
    }

    IEnumerator GamePlay()
    {
        yield return new WaitForSeconds(1.0f);

        for(int i = 0; i<pooledTransform.childCount; i++)
        {
            int x = Random.Range(0, pooledTransform.childCount);
            GameObject setTrue = pooledTransform.GetChild(x).gameObject;
            setTrue.SetActive(true);
            setTrue.transform.localPosition = new Vector3(Random.Range(-5.5f, 5.5f), 2.0f, 0.0f);
            yield return new WaitForSeconds(1.25f);
        }

        StartCoroutine(GamePlay());
    }

    public void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
