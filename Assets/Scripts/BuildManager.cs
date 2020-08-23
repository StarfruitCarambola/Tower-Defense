using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    void Awake() //called before game starts
    {
        if(instance!=null)
        {
            Debug.LogError("more than one is bad");
            return;
        }
        instance = this;
    }
    
    public GameObject buildEffect;
    public GameObject sellEffect;
    public GameObject turretRange;
    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    private GameObject range;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint trrt)
    {
        turretToBuild = trrt;
        DeselectNode();
        turretRange.transform.localScale = new Vector3(trrt.turret.range * 2, 0.0001f, trrt.turret.range * 2);
    }
    public void DrawTurretRange(Node node)
    {
        range = (GameObject)Instantiate(turretRange, node.GetBuildPosition() + new Vector3(0f, turretToBuild.prefab.transform.position.y, 0f), Quaternion.identity);
    }
    public void DestroyRange()
    {
        Destroy(range);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
