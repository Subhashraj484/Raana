
using UnityEngine;
using UnityEngine.Animations;

public class UICameraMovement : MonoBehaviour
{
    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;
    [SerializeField] Vector2 yRotaionRange;
    [Range(0.01f,0.1f)]
    [SerializeField] float lerpSpeed = 0.01f;
    Vector3 _newPosition ;
    Quaternion _newRotatiom;
    private void Start() {
        _newPosition = transform.position;
        _newRotatiom = transform.rotation;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _newPosition , lerpSpeed*Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation , _newRotatiom , lerpSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position , _newPosition) < 0.1f)
        {
            CalculateNewPosition();
        }
    }

    private void CalculateNewPosition()
    {
        float x = Random.Range(min.x , max.x);
        float z = Random.Range(min.y , max.y);

        _newPosition = new Vector3(x,0,z);
        _newRotatiom = Quaternion.Euler(0,Random.Range(yRotaionRange.x , yRotaionRange.y), 0);
    }
}
