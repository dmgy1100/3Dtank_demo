using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuansu_move_control : MonoBehaviour
{
    public Rigidbody _rigidbody;

    public float H_value;
    public float V_valut;

    public float speed = 0.01f;
    public float rotate_speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();        //获取组件实例
    }

    // Update is called once per frame
    void Update()
    {
        H_value = Input.GetAxis("Horizontal1");
        V_valut = Input.GetAxis("Vertical1");
        if (V_valut != 0)
            _rigidbody.MovePosition(this.transform.position + V_valut*this.transform.forward*speed*Time.deltaTime);
            //this.transform.position = this.transform.position + this.transform.forward * speed * V_valut;           //控制角色在垂直方向上移动
        if (H_value != 0)
        {
            if (V_valut != 0)
                H_value = -H_value;
            this.gameObject.transform.Rotate(Vector3.up * H_value *rotate_speed);                                   //控制角色在水平方向上旋转
        }
    }
}
