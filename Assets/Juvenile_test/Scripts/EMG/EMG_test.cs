using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;
using static UnityEngine.GraphicsBuffer;
using System.Threading.Tasks;

public class emg_test : MonoBehaviour
{
    // UDP通信に使用するローカルポート番号
    int LOCA_LPORT = 12345;

    // 変換の開始を示す閾値
    public static int CONV_START = 99;

    // 異常値の閾値
    float THRE_ABNORMAL = 768;

    // 通常時の時間
    int TIME_NORMAL = 49;

    // UDPクライアントとスレッド
    static UdpClient udp;
    Thread thread;

    // 筋電位データの変数
    public static float emg = 0;

    // 筋電位のリスト
    List<int> vA = new List<int>();
    List<int> vB = new List<int>();

    // 筋電位の絶対値のリスト
    public static List<float> vA_abs = new List<float>();
    public static List<float> vB_abs = new List<float>();

    // ローパスフィルタの係数
    float r_lp = 0.5f;

    // 絶対値の筋電位のカウンタ
    int absCnt = 0;

    // 筋電位AとBの時間
    int egTime_A = 0, egTime_B = 0;

    // 筋電位の数、数のカウンタ、セットの数
    int numCnt = 0;
    public static int vecCnt = 0;
    int numA = 0, numB = 0;
    int start = 0, goal = 0;

    void Start()
    {
        // UDPクライアントを生成し、スレッドを開始する
        udp = new UdpClient(LOCA_LPORT);
        /*thread = new Thread(new ThreadStart(() =>
        {
            ThreadMethod();
        }));
        thread.Start();
        */
    }

    void FixedUpdate()
    {

        ThreadMethod();

        // Unityフレームごとに更新される処理はここに記述される

        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);

        // 受信したデータをfloat型に変換
        float emgValue = BitConverter.ToSingle(data, 0);

        // 整数部分（10の位）のみを抽出する
        int integerPart = (int)emgValue;

        // emgに代入
        emg = integerPart;

        Debug.Log("EMGtest : " + emg);

    }

    // アプリケーションが終了する際の処理
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }

    // ローパスフィルタの適用
    float Lpf(List<int> v, int x)
    {
        float lpf = 0f;
        lpf = r_lp * v[x] + (1 - r_lp) * v[x - 1];
        return lpf;
    }

    // リスト内の最大値を見つける
    float vecMaxf(List<float> v, int x1, int x2)
    {
        float vMax = 0f;

        for (int i = x1; i < x2; ++i)
        {
            if (v[i].CompareTo(vMax) == 1)
            {
                vMax = v[i];
            }
        }
        return vMax;
    }

    // UDPデータを受信するスレッドのメソッド
    public void ThreadMethod()
    {
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);

            // 受信したデータをfloat型に変換
            float emgValue = BitConverter.ToSingle(data, 0);

            // 整数部分（10の位）のみを抽出する
            int integerPart = (int)emgValue / 10;

            // emgに代入
            emg = integerPart;
            Debug.Log(emg);

            //var task = DelayFunktion();
        }
    }

    private static async Task DelayFunktion()
    {
        await Task.Delay(50000); // ミリ秒
    }
}
