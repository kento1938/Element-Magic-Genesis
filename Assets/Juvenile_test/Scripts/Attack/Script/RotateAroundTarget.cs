using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.up;

    [SerializeField, Tooltip("速度係数")]
    private float SpeedFactor = 0.1f;

    [SerializeField, Tooltip("半径距離")]
    private float RadiusDistance = 1.0f;

    [SerializeField, Tooltip("軸方向の平行移動")]
    private float AxialDifference = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TargetObject == null) return;

        // 指定オブジェクトと自身の現在位置を取得する
        Vector3 selfPosition = this.transform.position;
        Vector3 targetPosition = TargetObject.transform.position;
        float targetPositionAxial = TargetObject.transform.position.y + AxialDifference;    //誤差を修正するために記憶しておく
        // 回転軸がx,zの場合
        if (RotateAxis == Vector3.right)
        {
            targetPositionAxial = TargetObject.transform.position.x + AxialDifference;
        } else if (RotateAxis == Vector3.forward)
        {
            targetPositionAxial = TargetObject.transform.position.z + AxialDifference;
        }

        // 座標が重なっていた場合は回転軸の直交方向に離れた場所を初期位置とする
        if (selfPosition.Equals(targetPosition))
        {
            // 直交ベクトルを求めるため、回転軸に平行でないダミーベクトルを作成する
            Vector3 rotateAxisNormal = RotateAxis.normalized;
            Vector3 dummyDirectVector = Vector3.forward;
            if (Mathf.Abs(rotateAxisNormal.y) < 0.5f) dummyDirectVector = Vector3.up;

            // 回転軸とダミーベクトルから直交ベクトルを算出し、初期位置を設定する
            Vector3 directVector = Vector3.Cross(RotateAxis, dummyDirectVector).normalized;
            selfPosition = directVector * RadiusDistance;
        }

        // 軸方向の移動量は追従する
        Vector3 diffVector = selfPosition - targetPosition;
        float diffMagnitude = diffVector.magnitude;
        float dot = Vector3.Dot(diffVector, RotateAxis);
        // 回転軸との内積から回転軸方向への移動量を求める
        selfPosition -= RotateAxis.normalized * (diffMagnitude * dot);

        // y軸方向に対する計算誤差を修正する
        selfPosition.y = targetPositionAxial;
        targetPosition.y = targetPositionAxial;

        // 現在の距離と半径距離の差分を取得する
        float diffDistance = Vector3.Distance(selfPosition, targetPosition) - RadiusDistance;

        // 指定半径の距離になるよう近づく(or離れる)
        this.transform.position = Vector3.MoveTowards(selfPosition, targetPosition, diffDistance);

        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            targetPosition,
            RotateAxis,
            360.0f / (1.0f / SpeedFactor) * Time.deltaTime
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "strong_PB" || other.gameObject.tag == "weak_PB")
        {
            //球があたった瞬間に消滅
            Destroy(other.gameObject);
        }
    }
}