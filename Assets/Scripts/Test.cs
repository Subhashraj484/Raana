
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(transform.InverseTransformPoint(player.position));
        }
    }
}
