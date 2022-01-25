using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootPointsPositioner : MonoBehaviour
{
    private ShootPoint prefab;

    public List<ShootPoint> frontPoints = new List<ShootPoint>();
    public List<ShootPoint> sidePoints = new List<ShootPoint>();
    public List<ShootPoint> deg30Points = new List<ShootPoint>();
    public List<ShootPoint> backPoints = new List<ShootPoint>();

    private List<ShootPoint> allPoints = new List<ShootPoint>();

    private float offsets = 0.3f;

    // Start is called before the first frame update
    void Awake() {
        prefab = frontPoints.First();
        var current = Instantiate(prefab, transform);
        prefab.gameObject.SetActive(false);
        frontPoints.Remove(prefab);
        frontPoints.Add(current);
        allPoints.Add(current);
    }

    public List<ShootPoint> GetShootingPoints() {
        return allPoints;
    }

    [ContextMenu("Add30Deg")]
    public void Add30Deg() {
        var newLeft = Instantiate(prefab, transform);
        var newRight = Instantiate(prefab, transform);

        newLeft.gameObject.SetActive(true);
        newRight.gameObject.SetActive(true);
        newRight.transform.RotateAround(transform.position, Vector3.up, 30);
        newLeft.transform.RotateAround(transform.position, Vector3.up, -30);
        deg30Points.Add(newRight);
        deg30Points.Add(newLeft);
        allPoints.Add(newRight);
        allPoints.Add(newLeft);
    }

    [ContextMenu("AddSideProjectiles")]
    public void AddSideProjectiles() {

        var newLeft = Instantiate(prefab, transform);
        var newRight = Instantiate(prefab, transform);

        newLeft.gameObject.SetActive(true);
        newRight.gameObject.SetActive(true);
        newRight.transform.RotateAround(transform.position, Vector3.up, 90);
        newLeft.transform.RotateAround(transform.position, Vector3.up, -90);
        sidePoints.Add(newLeft);
        sidePoints.Add(newRight);
        allPoints.Add(newRight);
        allPoints.Add(newLeft);
    }

    [ContextMenu("AddFrontProjectile")]
    public void AddFrontProjectile() {
        for (int j = 0; j < 1; j++) {
            var newPoint = Instantiate(prefab, transform);
            newPoint.gameObject.SetActive(true);
            frontPoints.Add(newPoint);
            allPoints.Add(newPoint);
            var off = 0.25f;
            var start = -((frontPoints.Count - 1) * off) / 2;
            var localPos = Vector3.forward;
            for (int i = 0; i < frontPoints.Count; i++) {
                localPos.x = start + off * i;
                frontPoints[i].transform.localPosition = localPos;
            }
        }

    }

    [ContextMenu("AddBackProjectile")]
    public void AddBackProjectile() {

        var newPoint = Instantiate(prefab, transform);
        allPoints.Add(newPoint);
        newPoint.gameObject.SetActive(true);
        newPoint.transform.RotateAround(transform.position, Vector3.up, 180);
        backPoints.Add(newPoint);
    }
}
