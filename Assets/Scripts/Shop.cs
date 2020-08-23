using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint sniperTurret;
    public TurretBlueprint slowTurret;
    public TurretBlueprint fireTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserBeamer;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectSniperTurret()
    {
        buildManager.SelectTurretToBuild(sniperTurret);
    }
    public void SelectSlowTurret()
    {
        buildManager.SelectTurretToBuild(slowTurret);
    }
    public void SelectFireTurret()
    {
        buildManager.SelectTurretToBuild(fireTurret);
    }
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
