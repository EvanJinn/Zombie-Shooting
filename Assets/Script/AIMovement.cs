using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public int moveSpeed = 1;//怪物移动速度
    public int rotationSpeed = 5;//怪物转身数独

    private Transform target;//目标玩家
    private Transform myTransform;//目标怪物
    private Vector3 targetPosition;//目标玩家的坐标
    private float maxDistance;//玩家跟怪物间的距离

    void Awake()
    {
        myTransform = transform;//当前怪物的transform付给myTransform
    }

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");//找到tag为player的对象
        target = player.transform;//定义player就是目标玩家
    }

    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.red);//在玩家跟怪物中间画一条直的红线方便查看

        //设置怪物转身,正面始终朝向玩家
        targetPosition = new Vector3(target.position.x, 0, target.position.z);//得到怪物脚下xz坐标
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(targetPosition - myTransform.position), rotationSpeed * Time.deltaTime);//挂物转身朝向玩家

        //设置怪物想玩家移动
        maxDistance = Vector3.Distance(targetPosition, myTransform.position);//获取玩家与怪物之间的距离
        if (maxDistance >= 2)
        {
            //当距离大于两米时移动
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;//让怪物朝着自己的正面移动
        }
        else
        {
        }
    }
}
