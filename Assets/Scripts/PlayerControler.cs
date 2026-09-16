using UnityEngine;
using UnityEngine.InputSystem; //para usar el input action

public class PlayerControler : MonoBehaviour
{

    private int _maxHealth = 100;

    [SerializeField] private float _movementSpeed = 4.5f;

    //float "nombre" = 5.7f;  con decimales
    //bool "nombre" = "true/false";
    //string  texto
    //int   numero entero

    private Rigidbody2D _rigidbody2D;

    private InputAction _moveAction;
    private Vector2 _moveInput;

    void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _moveAction = InputSystem.actions["Move"];
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>(); //leemos el valor de las teclas pulsadas del move

        
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2(_moveInput.x *_movementSpeed, _rigidbody2D.linearVelocity.y); //Mover personaje
    }

}
