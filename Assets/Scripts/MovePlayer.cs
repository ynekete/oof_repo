using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private GameObject player; //��������� ������� ��������� � ������� ����� ��������.

    public static int speed = 6; //�������� ����������� ���������. ������ public static ���������� ��� �� ������ ���������� � ���� ���������� �� ������ �������
    public static int _speed; //���������� �������� ����������� ���������
    public int rotation = 250; //�������� ��������� ���������
    public int jump = 3; //������ ������


    public static bool IsDrawWeapon; //�������� ����������, ������� ����� �������� ��������� �� � ��� ������.  
    public static float x = 0.0f; //���� �������� ��������� �� ��� x
    void Start()
    {
        IsDrawWeapon = false; //�� ��������� ������ � ��� ��������.
        _speed = speed; //������ ���������� ����������� �������� �������� ���������
        player = (GameObject)this.gameObject; //������ ��� ��� �������� ��� ������ �� ������� ���������� ������
    }

    void Update()
    {
        if (IsDrawWeapon == true) //���� ������ ��������
        {
            speed = _speed * 2; // ������ �������� �����������(� ��� ������ ������ ���, � ���� ������� ���� �������� �������� ������� ����� � �����. � �������� �������� �������� � ���� ���������� �� �������)
            if (Input.GetKey(KeyCode.W)) //���� ������ W
            {
                player.transform.position += player.transform.forward * speed * Time.deltaTime; //���������� ��������� � �����, � ������� ��������. Time.deltaTime �������� ��� �������� ����������� ���������, ���� ����� �� ����� �� ����� ��������� �������
            }
            if (Input.GetKey(KeyCode.S))
            {
                speed = _speed / 2; //��� ������������� ����� ������� �������� �����������
                player.transform.position -= player.transform.forward * speed * Time.deltaTime; //���������� �����
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                speed = _speed * 2; //���������� c���������� ��������
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position -= player.transform.right * speed * Time.deltaTime; //���������� � ����
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position += player.transform.right * speed * Time.deltaTime; //���������� � �����
            }
            if (Input.GetKey(KeyCode.Space))
            {
                player.transform.position += player.transform.up * jump * Time.deltaTime; //�������
            }

            if (Input.GetKey(KeyCode.Tab)) //��� ������� � �� ������ Tab
            {
                IsDrawWeapon = false; //�� ������� ���� ������.
            }
        }
        else if (IsDrawWeapon == false) //���� ������ �� ��������. |||||| ������� ���������� �� �������� � ����������� �� ���� �������� �� � ��� ������ ��� ���, ������ ��� �������� ����� ������������ ������� �������� � ���� � ���� �������, ��� � ��� ������� �� �� ��������� ��������� �������� � ��������.  
        {
            speed = _speed;//�������� � ����������� ��������
            if (Input.GetKey(KeyCode.LeftShift)) //���� ������ ����� Shift
            {
                speed = _speed * 2; //����������� �������� �����������(���)
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) //���� ���������
            {
                speed = _speed; //���������� ����������� ��������
            }
            if (Input.GetKey(KeyCode.W)) //���� ������ W
            {
                player.transform.position += player.transform.forward * speed * Time.deltaTime; //���������� ��������� � �����.
            }
            if (Input.GetKey(KeyCode.S))
            {
                speed = _speed / 2;
                player.transform.position -= player.transform.forward * speed * Time.deltaTime; //���������� �����
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                speed = _speed; //���������� c���������� ��������
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position -= player.transform.right * speed * Time.deltaTime; //���������� � ����
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position += player.transform.right * speed * Time.deltaTime; //���������� � �����
            }
            if (Input.GetKey(KeyCode.Space))
            {
                player.transform.position += player.transform.up * jump * Time.deltaTime; //�������
            }
            if (Input.GetKey(KeyCode.Tab)) //��� ������� �� ������ ���
            {
                IsDrawWeapon = true; //�� ������� ���� ������
            }
        }

        //������������ ���������. ��� ��� ���� ���������� x ���������, �� ������� ������ � �� ����� ���������� ����� �� ������� ��������� ��������� ���� � �� ��� X � ������������ ����� ����� �������� ��� ��������
        Quaternion rotate = Quaternion.Euler(0, x, 0); //������� ����� ���������� ���� Quaternion ��� ��������� ���� ��������
        player.transform.rotation = rotate; //������������ ��������

    }
}
