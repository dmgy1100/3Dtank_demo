using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tank_Type
{
    tank_one = 1,
    tank_two = 2,
    tank_enemy = 3,
}

public class tank_control : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Tank_Type tankType = Tank_Type.tank_one;
    public string inputHorizontalStr;
    public string inputVerticalStr;
    
    /*炮弹*/
    public GameObject shell;                    //炮弹对象
    public GameObject shellPos;                 //炮弹的方向
    private float shell_speed = 10;

    private float H_value;
    private float V_valut;

    public float speed = 0.01f;
    public float rotate_speed = 2;
    public Tank_Type tank_type = Tank_Type.tank_one;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();        //获取组件实例
        //_shellPos = this.gameObject.GetGameObject<shellPos>();
        inputHorizontalStr = inputHorizontalStr + (int)tankType;
        inputVerticalStr = inputVerticalStr + (int)tankType;
    }

    // Update is called once per frame
    void Update()
    {
        H_value = Input.GetAxis(inputHorizontalStr);
        V_valut = Input.GetAxis(inputVerticalStr);
        if (V_valut != 0)
            _rigidbody.MovePosition(this.transform.position + V_valut*this.transform.forward*speed*Time.deltaTime);
            //this.transform.position = this.transform.position + this.transform.forward * speed * V_valut;           //控制角色在垂直方向上移动
        if (H_value != 0)
        {
            if (V_valut != 0)
                H_value = -H_value;
            this.gameObject.transform.Rotate(Vector3.up * H_value *rotate_speed);                                   //控制角色在水平方向上旋转
        }
        if (Input.GetButtonDown("Fire1"))
            OpenFire();
    }
    //定时调用
    private void FixedUpdate()
    {

    }
    /*发射炮弹*/
    void OpenFire()
    {
        /*克隆一个炮弹*/
        if (shell != null)
        {
            GameObject shellobj = Instantiate(shell, shellPos.transform.position, shell.transform.rotation);
            //Rigidbody shell_rigidbody = (Rigidbody)Instantiate(shell, shell.transform.position, shellPos.rotation);
            //shell_rigidbody.velocity = transform.transformDirection(Vector3.forward*shell_speed);
            /*给炮弹一个初速度*/
            //shell.Info.Speed = shellPos.forward*shell_speed;
            //Rigidbody shellRigidbody = shellobj.GetComponent<Rigidbody>();
            //if (shellRigidbody != null)
            //{
                //Vector3 v = Vector3.zero;
                //v.x = shell_speed;
                //Rigidbody.AddForce(v);
            //}
        }
    }
}
