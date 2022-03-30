using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    public float moveSpeed = 10f; //�̵��ӵ�
    [HideInInspector]
    public Vector3 moveDirection; //�̵�����
  

    CharacterController characterController;


    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Clamp(value, 7.0f, 12.0f);//7
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //�̵� ����. CharacterController�� Move()�Լ��� �̿��� �̵�
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        moveDirection.y -= 1f;
    }



    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

}
