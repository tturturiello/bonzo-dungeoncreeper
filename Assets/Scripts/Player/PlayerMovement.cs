using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Transform localForward;
    [SerializeField] private AudioSource steps;

    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    private Vector3 target = Vector3.forward;
    private bool isThirdPOV = true;
    private bool isCrouched = false;

    public Animator Animator { get; set; }
    public Vector3 LocalForward { 
        get 
        {
            return localForward.position;
        }
    }

    void Awake()
    {
        GameEvent.playerDead.AddListener(() => GetComponent<Rigidbody>().useGravity = false);
        GetComponent<Rigidbody>().useGravity = true;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();

        if (_movement.magnitude > 0.1)
        {
            CalculateDirection();
        }
        else
        {
            StartCoroutine(WaitForInput());
        }

        Animator.SetFloat("VelX", horizontal);
        Animator.SetFloat("VelY", vertical);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isCrouched = true;
            Animator.SetBool("IsCrouched", true);
            Debug.Log("KEY DOWN");
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouched = false;
            Animator.SetBool("IsCrouched", false);
        }

        StartCoroutine(SetPOV());
    }

    private IEnumerator SetPOV()
    {
        yield return new WaitUntil(PlayerInput.HasSwitchedCamera);
        isThirdPOV = !isThirdPOV;

    }

    private IEnumerator WaitForInput()
    {
        steps.Stop();
        yield return new WaitUntil(() => Input.anyKey);
        if (Animator.GetBool("IsCrouched"))
        {
            steps.Stop();
        }
        else
        {
            steps.Play();
        }
    }

    private void CalculateDirection()
    {
        float targetAngle = Mathf.Atan2(_movement.x, _movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        Vector3 desiredForward;

        desiredForward = Quaternion.Euler(0f, angle, 0f) * target;

        _rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + _rotation * target * Animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);

    }
}