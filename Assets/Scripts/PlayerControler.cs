using UnityEngine;
using UnityEngine.InputSystem; //para usar el input action

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 4.5f;
    [SerializeField] private float _jumpHeight = 10;

    //float "nombre" = 5.7f;  con decimales
    //bool "nombre" = "true/false";
    //string  texto
    //int   numero entero

    private Rigidbody2D _rigidbody2D;

    private InputAction _attackAction;
    private InputAction _pauseAction;
    private InputAction _moveAction;
    private InputAction _jumpAction;

    private Vector2 _moveInput;

    private AudioSource _playAudioSource;

    [SerializeField] private Transform _groundSensor;
    [SerializeField] private float _sensorSize = 1;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private int _attackDamage = 7;
    [SerializeField] private Transform _attackHitBox;
    [SerializeField] private float _hitBoxRadius = 1f;
    [SerializeField] private int _actualHealth;
    [SerializeField] private int _maxHealth = 100;

    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _attackSound;

    private Animator _animator;

    void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _attackAction = InputSystem.actions["Attack"];
        _pauseAction = InputSystem.actions["Pause"];

        _animator = GetComponent<Animator>();
        _playAudioSource = GetComponent<AudioSource>();
    }


    void Start()
    {
        //_actualHealth = _maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(_pauseAction.WasPressedThisFrame())
        {
            GamaManager.Instance.Pause();
        }

        if(GamaManager.Instance.IsPaused())
        {
            return;            
        }

        _moveInput = _moveAction.ReadValue<Vector2>(); //leemos el valor de las teclas pulsadas del move

        if(_moveInput.x < 0) //para rotar el personaje al cambiar la direccion
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRuning", true);
        }
        else if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRuning", true);
        }
        else
        {
            _animator.SetBool("IsRuning", false);
        }

        if(_jumpAction.WasPressedThisFrame() && IsGrounded()) //para llamar la funcion de salto al pulsar tecla y estar en el suelo
        {
            Jump();
        }
        
        _animator.SetBool("IsJumping", !IsGrounded());

        if(_attackAction.WasPressedThisFrame() && IsGrounded())
        {
            Attack();
        }
  
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2(_moveInput.x *_movementSpeed, _rigidbody2D.linearVelocity.y); //Mover personaje
    }

    void Jump() //crear el movimiento de salto
    {
        _rigidbody2D.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
        PlaySFX(_jumpSound);
    }

    void Attack()
    {
        _animator.SetTrigger("IsAttacking");

        PlaySFX(_attackSound, 0.5f);

        Collider2D[] collider2D = Physics2D.OverlapCircleAll(_attackHitBox.position, _hitBoxRadius);

        foreach (Collider2D enemy in collider2D)
        {
            if(enemy.gameObject.layer == 7)
            {
                Mimik enemyScript = enemy.GetComponent<Mimik>();
                enemyScript.TakeDamage(_attackDamage);
            }
        }
    }

    public void CurarVida(int sumarVida)
    {
         _actualHealth += sumarVida;

        if(_actualHealth >= _maxHealth)
        {
            _actualHealth = _maxHealth;
        }
    }
    



    void PlaySFX(AudioClip clip, float volume = 1)
    {
        _playAudioSource.PlayOneShot(clip, volume);
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

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackHitBox.position, _hitBoxRadius);
    }

}
