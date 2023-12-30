using UnityEngine;

public class Bulet : MonoBehaviour
{
    [SerializeField] private GameObject bulet;
    [SerializeField] private Transform _shootPos;

    public static float _scale_x;

    public float a = _scale_x;

    private void Update()
    {
        _scale_x = transform.localScale.x;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulet, _shootPos.transform.position, transform.rotation);
        }
          
    }

}
