using UnityEngine;
using UnityEngine.InputSystem; //para usar el input action

public class PlayerControler : MonoBehaviour
{

    private int _maxHealth = 100;

    [SerializeField] private float _movementSpeed = 4.5f;
    [SerializeField] private float _forceJump = 10;

    //float "nombre" = 5.7f;  con decimales
    //bool "nombre" = "true/false";
    //string  texto
    //int   numero entero

    private Rigidbody2D _rigidbody2D;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Vector2 _moveInput;

    [SerializeField] private Transform _groundSensor;
    [SerializeField] private float _sensorSize = 1;
    [SerializeField] private LayerMask _groundLayer;


    void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>(); //leemos el valor de las teclas pulsadas del move

        if(_moveInput.x < 0) //para rotar el personaje al cambiar la direccion
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(_jumpAction.WasPressedThisFrame() && IsGrounded()) //para llamar la funcion de salto al pulsar tecla y estar en el suelo
        {
            Jump();
        }

        
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2(_moveInput.x *_movementSpeed, _rigidbody2D.linearVelocity.y); //Mover personaje
    }

    void Jump() //crear el movimiento de salto
    {
        _rigidbody2D.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorSize);

        foreach (Collider2D item in collider2D)
        {
            if(item.gameObject.layer == 6)
            {
                return true;
            }
        }
        return false;
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundSensor.position, _sensorSize);
    }

    

}
