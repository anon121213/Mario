using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _force = 20.0f;

    public float _turn;

    private float length;
    [SerializeField] private float max_length;

    private Rigidbody2D bulet_rb;

    private void Awake()
    {
        
        bulet_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        length = transform.position.x;
        max_length = length + 15f;
        _turn = Bulet._scale_x;
        bulet_rb.velocity = new Vector2(_force * _turn, 0f);          
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (length > max_length || length < max_length * -1)
        {
            Destroy(gameObject);
        }       
    }
}
