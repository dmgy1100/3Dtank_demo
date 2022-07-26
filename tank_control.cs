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
    private string inputFire = "Fire1";
    
    /*閻愵喖鑴�*/
    public GameObject shell;                    //閻愵喖鑴婄€电钖�
    public GameObject shellPos;                 //閻愵喖鑴婇惃鍕煙閸氾拷
    public float shell_speed = 1000f;

    private float H_value;
    private float V_valut;

    public float speed = 0.01f;
    public float rotate_speed = 2;
    public Tank_Type tank_type = Tank_Type.tank_one;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();        //閼惧嘲褰囩紒鍕鐎圭偘绶�
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
            //this.transform.position = this.transform.position + this.transform.forward * speed * V_valut;           //閹貉冨煑鐟欐帟澹婇崷銊ョ€惄瀛樻煙閸氭垳绗傜粔璇插З
        if (H_value != 0)
        {
            if (V_valut != 0)
                H_value = -H_value;
            this.gameObject.transform.Rotate(Vector3.up * H_value *rotate_speed);                                   //閹貉冨煑鐟欐帟澹婇崷銊︽寜楠炶櫕鏌熼崥鎴滅瑐閺冨娴�
        }
        if (Input.GetButtonDown(inputFire))
            OpenFire(shell_speed);
        /*按下*/
        if (Input.GetButton(inputFire))
        {

        }
        /*松开按键*/
        if (Input.GetButtonUp(inputFire))
        {

        }
    }
    //鐎规碍妞傜拫鍐暏
    private void FixedUpdate()
    {

    }
    /*閸欐垵鐨犻悙顔艰剨*/
    void OpenFire(float p_speed)
    {
        /*閸忓娈曟稉鈧稉顏嗗仏瀵拷*/
        if (shell != null)
        {
            GameObject shellobj = Instantiate(shell, shellPos.transform.position, shell.transform.rotation);
            //Rigidbody shell_rigidbody = (Rigidbody)Instantiate(shell, shell.transform.position, shellPos.rotation);
            //shell_rigidbody.velocity = transform.transformDirection(Vector3.forward*shell_speed);
            /*缂佹瑧鍋栧閫涚娑擃亜鍨甸柅鐔峰*/
            //shell.Info.Speed = shellPos.forward*shell_speed;
            Rigidbody shellRigidbody = shellobj.GetComponent<Rigidbody>();
            if (shellRigidbody != null)
            {
                //Vector3 v = Vector3.zero;
                //v.x = shell_speed;
                shellRigidbody.AddForce(this.transform.forward*p_speed);
            }
        }
    }
}
