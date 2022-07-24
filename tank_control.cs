using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Tank_Type
//{
//    tank_one = 1,
//    tank_two,
 //   tank_enemy,
//}
public class tank_control : MonoBehaviour
{
    public Rigidbody _rigidbody;
    /*炮弹*/
    //public GameObject shell;                    //炮弹对象
    //public GameObject shellPos;                 //炮弹的方向

    private float H_value;
    private float V_valut;

    public float speed = 0.01f;
    public float rotate_speed = 2;
    //public Tank_Type tank_type = tank_one;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();        //获取组件实例
        //_shellPos = this.gameObject.GetGameObject<shellPos>();
        //inputHorizontalStr = inputHorizontalStr + (int)tank_type;
        //inputVerticalStr = inputVerticalStr + (int)tank_type;
    }

    // Update is called once per frame
    void Update()
    {
        H_value = Input.GetAxis("Horizontal");
        V_valut = Input.GetAxis("Vertical");
        if (V_valut != 0)
            _rigidbody.MovePosition(this.transform.position + V_valut*this.transform.forward*speed*Time.deltaTime);
            //this.transform.position = this.transform.position + this.transform.forward * speed * V_valut;           //控制角色在垂直方向上移动
        if (H_value != 0)
        {
            if (V_valut != 0)
                H_value = -H_value;
            this.gameObject.transform.Rotate(Vector3.up * H_value *rotate_speed);                                   //控制角色在水平方向上旋转
        }
        //if (Input.GetButtonDown("Fire1"))
           // OpenFire();
    }
    //定时调用
    //private void FixedUpdate()
    //{

    //}
}
//void OpenFire()
//{
    //GameObject shellobj = Instantiate(shell, shellPos.position, shell.transform.rotation);
//}