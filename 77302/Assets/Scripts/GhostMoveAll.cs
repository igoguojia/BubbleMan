using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//气氛组
public class GhostMoveAll : MonoBehaviour
{
    public int Enemy=0;
    public bool isDie = false;
    public GameObject quad;
    public GameObject home;
    public int State = 0;//0 为正常寻路 1为四散模式 2为保护dot模式 3为震惊模式
    //存储所有路径点
    private GameObject[] wayPointsGos;
    public float speed = 0.05f;
    private List<Vector3> wayPoints = new List<Vector3>();
    //当前要去哪个路径点
    private int index = 0;
    private Grid grid;
    private Vector3 dots;
    private float tempTime=0;
    private GameObject parentObj;

    public GameObject blinky;
    bool reverse = false;
    private Vector3 findPos;
    private List<Vector3> lastwayPoints = new List<Vector3>();

    private void Start()
    {
        parentObj = gameObject.transform.parent.gameObject;
        grid = quad.GetComponent<Grid>();
        switch (Enemy)
        {
            case 1:
                FindingPath(grid.player.position, grid.destPos.position);
                wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                LoadAPath(wayPointsGos);
                if (wayPoints[0] == transform.position)
                    wayPoints.RemoveAt(0);
                break;
            case 2:
                FindingPath(grid.player.position, grid.destPos.position);
                wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                LoadAPath(wayPointsGos);
                if (wayPoints[0] == transform.position)
                    wayPoints.RemoveAt(0);
                break;
            case 3:
                findPos = grid.destPos.position - blinky.transform.position + grid.destPos.position;
                FindingPath(grid.player.position, findPos);
                wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                LoadAPath(wayPointsGos);
                if (wayPoints[0] == transform.position)
                    wayPoints.RemoveAt(0);
                break;
            case 4:
                FindingPath(grid.player.position, grid.destPos.position);
                wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                LoadAPath(wayPointsGos);
                if (wayPoints[0] == transform.position)
                    wayPoints.RemoveAt(0);
                lastwayPoints.Insert(0, wayPoints[0]);
                break;
        }

    }

    private void FixedUpdate()
    {
        switch (Enemy)
        {
            case 1:
                if (transform.position != wayPoints[0])
                {
                    Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[0], speed);
                    GetComponent<Rigidbody2D>().MovePosition(temp);
                }
                else
                {
                    switch (State)
                    {
                        case 0:
                            FindingPath(grid.player.position, grid.destPos.position);

                            break;
                        case 1:
                            FindingPath(grid.player.position, home.transform.position);
                            break;
                        case 2:
                            dots = GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist[0].transform.position;
                            FindingPath(grid.player.position, dots);
                            if ((grid.player.position - grid.destPos.position).sqrMagnitude <= 100)
                            {
                                State = 0;
                                speed = 0.05f;
                            }
                            break;
                        case 3:
                            FindingPath(grid.player.position, grid.player.position);
                            break;


                    }
                    wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                    LoadAPath(wayPointsGos);
                    if (State != 3)
                    {
                        if (wayPoints[0] == transform.position)
                            wayPoints.RemoveAt(0);
                    }
                }
                break;
            case 2:
                if (transform.position != wayPoints[0])
                {
                    Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[0], speed);
                    GetComponent<Rigidbody2D>().MovePosition(temp);
                }
                else
                {
                    switch (State)
                    {
                        case 0:
                            FindingPath(grid.player.position, grid.destPos.position);

                            break;
                        case 1:
                            FindingPath(grid.player.position, home.transform.position);
                            break;
                        case 2:
                            dots = GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist[1].transform.position;
                            FindingPath(grid.player.position, dots);
                            if ((grid.player.position - grid.destPos.position).sqrMagnitude <= 100)
                            {
                                State = 0;
                                speed = 0.05f;
                            }
                            break;
                        case 3:
                            FindingPath(grid.player.position, grid.player.position);
                            break;


                    }
                    wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                    LoadAPath(wayPointsGos);
                    if (State != 3)
                    {
                        if (wayPoints[0] == transform.position)
                            wayPoints.RemoveAt(0);
                    }
                }
                break;
            case 3:
                if (transform.position != wayPoints[0])
                {

                    Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[0], speed);
                    GetComponent<Rigidbody2D>().MovePosition(temp);
                }
                else
                {
                    switch (State)
                    {
                        case 0:
                            findPos = grid.destPos.position - blinky.transform.position + grid.destPos.position;
                            FindingPath(grid.player.position, findPos);
                            break;
                        case 1:
                            FindingPath(grid.player.position, home.transform.position);
                            break;
                        case 2:
                            dots = GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist[2].transform.position;
                            FindingPath(grid.player.position, dots);
                            if ((grid.player.position - grid.destPos.position).sqrMagnitude <= 100)
                            {
                                State = 0;
                                speed = 0.05f;
                            }
                            break;
                        case 3:
                            FindingPath(grid.player.position, grid.player.position);
                            break;
                    }
                    wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                    LoadAPath(wayPointsGos);
                    if (State != 3)
                    {
                        if (wayPoints[0] == transform.position)
                            wayPoints.RemoveAt(0);
                    }

                }
                break;
            case 4:
                if (!reverse)
                {
                    if (transform.position != wayPoints[0])
                    {
                        Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[0], speed);
                        GetComponent<Rigidbody2D>().MovePosition(temp);
                    }
                    else
                    {
                        switch (State)
                        {
                            case 0:
                                FindingPath(grid.player.position, grid.destPos.position);
                                break;
                            case 1:
                                FindingPath(grid.player.position, home.transform.position);
                                break;
                            case 2:
                                dots = GameObject.Find("Dots").gameObject.GetComponent<DotPosList>().dotlist[3].transform.position;
                                FindingPath(grid.player.position, dots);
                                if ((grid.player.position - grid.destPos.position).sqrMagnitude <= 100)
                                {
                                    State = 0;
                                    speed = 0.05f;
                                }
                                break;
                            case 3:
                                FindingPath(grid.player.position, grid.player.position);
                                break;

                        }
                        wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                        LoadAPath(wayPointsGos);
                        if (State != 3)
                        {
                            if (wayPoints[0] == transform.position)
                                wayPoints.RemoveAt(0);
                        }
                        lastwayPoints.Insert(0, wayPoints[0]);
                        if (lastwayPoints.Count >= 17)
                            lastwayPoints.RemoveAt(16);
                        if ((grid.player.position - grid.destPos.position).sqrMagnitude <= 60)
                            reverse = true;

                    }
                }
                else
                {
                    if (transform.position != lastwayPoints[index])
                    {
                        Vector2 temp = Vector2.MoveTowards(transform.position, lastwayPoints[index], speed);
                        GetComponent<Rigidbody2D>().MovePosition(temp);
                    }
                    else
                    {
                        index++;
                        if (index == lastwayPoints.Count)
                        {
                            index = 0;
                            reverse = false;
                            lastwayPoints.Clear();

                            FindingPath(grid.player.position, grid.destPos.position);
                            wayPointsGos = quad.GetComponent<Grid>().pathObj.ToArray();
                            LoadAPath(wayPointsGos);
                 
                        }
                    }
                }
                break;
          
        }

        //动画
        Vector2 dir = wayPoints[0] - transform.position;
        
        if (State == 1)
            GetComponent<Animator>().SetBool("isShock", true);
        else
            GetComponent<Animator>().SetBool("isShock", false);
        GetComponent<Animator>().SetFloat("DirX", dir.x);

        switch (State)
        {
            case 3:
                tempTime += Time.deltaTime;
                if (isDie)
                {
                    GameObject.Find("Maze").gameObject.GetComponent<Animator>().SetBool("isAlarm", false);
                    foreach (Transform child in parentObj.transform)
                    {
                        child.gameObject.GetComponent<GhostMoveAll>().speed = 0.1f;
                        child.gameObject.GetComponent<GhostMoveAll>().State = 1;
                        child.gameObject.GetComponent<GhostMoveAll>().tempTime = 0;

                    }
                    //transform.position = home.transform.position;
                    //this.gameObject.GetComponent<GhostMoveAll>().isDie = false;
                    isDie = false;
                    //State = 0;
                    //speed = 10.0f;
                    //tempTime = 0;
                    //Vector3 temp = home.transform.position;
                    //temp.x += 0.5f;
                    //wayPoints[0] = temp;
                }
                else if (tempTime >= 4)
                {
                    State = 0;
                    tempTime = 0;
                    GameObject.Find("Maze").gameObject.GetComponent<Animator>().SetBool("isAlarm", false);
                }
                break;
            case 1:
                foreach (Transform child in parentObj.transform)
                {
                 if ((child.transform.position - home.transform.position).sqrMagnitude <= 3)
                    {
                        child.gameObject.GetComponent<GhostMoveAll>().speed = 0.05f;
                        child.gameObject.GetComponent<GhostMoveAll>().State = 0;
                    }
                }
                break;
            default:
                break;
        }
    }
    private void LoadAPath(GameObject[] go)
    {
        wayPoints.Clear();
        for (int i = 0; i < go.Length; i++)
        {
            wayPoints.Add(go[i].transform.position);

        }

    }
    // A*寻路
    public void FindingPath(Vector3 s, Vector3 e)
    {
        Grid.NodeItem startNode = grid.getItem(s);
        Grid.NodeItem endNode = grid.getItem2(e);

        List<Grid.NodeItem> openSet = new List<Grid.NodeItem>();
        HashSet<Grid.NodeItem> closeSet = new HashSet<Grid.NodeItem>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Grid.NodeItem curNode = openSet[0];

            for (int i = 0, max = openSet.Count; i < max; i++)
            {
                if (openSet[i].fCost <= curNode.fCost &&
                    openSet[i].hCost < curNode.hCost)
                {
                    curNode = openSet[i];
                }
            }

            openSet.Remove(curNode);
            closeSet.Add(curNode);

            // 找到的目标节点
            if (curNode == endNode)
            {
                generatePath(startNode, endNode);
                return;
            }

            // 判断周围节点，选择一个最优的节点
            foreach (var item in grid.getNeibourhood(curNode))
            {
                // 如果是墙或者已经在关闭列表中
                if (item.isWall || closeSet.Contains(item))
                    continue;
                // 计算当前相领节点现开始节点距离
                int newCost = curNode.gCost + getDistanceNodes(curNode, item);
                // 如果距离更小，或者原来不在开始列表中
                if (newCost < item.gCost || !openSet.Contains(item))
                {
                    // 更新与开始节点的距离
                    item.gCost = newCost;
                    // 更新与终点的距离
                    item.hCost = getDistanceNodes(item, endNode);
                    // 更新父节点为当前选定的节点
                    item.parent = curNode;
                    // 如果节点是新加入的，将它加入打开列表中
                    if (!openSet.Contains(item))
                    {
                        openSet.Add(item);
                    }
                }
            }
        }

        generatePath(startNode, null);
    }

    // 生成路径
    void generatePath(Grid.NodeItem startNode, Grid.NodeItem endNode)
    {
        List<Grid.NodeItem> path = new List<Grid.NodeItem>();
        if (endNode != null)
        {
            Grid.NodeItem temp = endNode;
            while (temp != startNode)
            {
                path.Add(temp);
                temp = temp.parent;
            }
            // 反转路径
            path.Reverse();
        }
        // 更新路径
        grid.updatePath(path);
    }

    // 获取两个节点之间的距离
    int getDistanceNodes(Grid.NodeItem a, Grid.NodeItem b)
    {
        int cntX = Mathf.Abs(a.x - b.x);
        int cntY = Mathf.Abs(a.y - b.y);
        // 判断到底是那个轴相差的距离更远
        if (cntX > cntY)
        {
            return 14 * cntY + 10 * (cntX - cntY);
        }
        else
        {
            return 14 * cntX + 10 * (cntY - cntX);
        }
    }
}
