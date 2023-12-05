using Unity.VisualScripting;
using UnityEngine;

public class ObjectFallen : MonoBehaviour
{
    float speed = 4f;

    private void Update()
    {
        if (GameManager.instance.GameStates == GameStates.Start)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);

            if (transform.position.y < -20.0f)
            {
                transform.gameObject.SetActive(false);
                transform.localPosition = Vector3.zero;
            }
        }
    }
}
