using UnityEngine;

public class DetectClicks : MonoBehaviour
{
    RaycastHit2D hit;
    Touch touch;
    int tapCount;
    [SerializeField] private GameObject popupGameOver;

    private void Start()
    {
        popupGameOver.SetActive(false);
    }

    void Update()
    {
        tapCount = Input.touchCount;
        for (int i = 0; i < tapCount; i++)
        {
            touch = Input.GetTouch(i);
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.gameObject.SetActive(false);

                    if (hit.collider.name.Contains("Minus"))
                    {
                        Debug.Log("Minus --");
                        GameManager.instance.score--;
                    }
                    else
                    {
                        Debug.Log("Plus ++");
                        GameManager.instance.score++;
                    }

                    GameManager.instance.scoreTxt.text = "Score = " + GameManager.instance.score;

                    if(GameManager.instance.score <= 0)
                    {
                        Debug.Log("GameEnd");

                        GameManager.instance.GameStates = GameStates.Over;

                        popupGameOver.SetActive(true);
                    }
                }
            }
        }
    }
}
