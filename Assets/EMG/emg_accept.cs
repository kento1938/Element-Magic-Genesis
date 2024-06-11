
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;

public class emg_accept : MonoBehaviour
{
	int LOCA_LPORT = 12345;
	//遅らせる数字(startNo = conversion[0])になるように後ろ側の=とか注意！
	public static int CONV_START = 99;
	/* 5000倍の時,512-1024の間にあったことから */
	float THRE_ABNORMAL = 768;
	int TIME_NORMAL = 49;

	static UdpClient udp;
	Thread thread;

    public float emg = 0;
	//vA,vB:筋電位[1][2]
	List<int> vA = new List<int>();
	List<int> vB = new List<int>();
	//abs
	public static List<float> vA_abs = new List<float>();
	public static List<float> vB_abs = new List<float>();


	float r_lp = 0.5f;

	int absCnt = 0;
	int egTime_A = 0, egTime_B = 0;
	// numCnt:奇数は[1],偶数は[2](2個で1セット=vecCnt)
	// num:Receiveしたものを一旦格納するためのint
	// Max,Min:最大,最小 グラフ描画のためpublicにしました
	int numCnt = 0;
	public static int vecCnt = 0;
	int numA = 0, numB = 0;
	int start = 0, goal = 0;

	void Start()
	{
		udp = new UdpClient(LOCA_LPORT);
		thread = new Thread(new ThreadStart(() =>
		{
			ThreadMethod();
		}));
		thread.Start();

	}
	void Update()
	{

	}
	/*void Update()
	{
		KeyCheck();
		if (Input.GetKey(KeyCode.Space)) udp.Close();
		if (Input.GetKeyDown(KeyCode.Escape)) Quit();
	}*/

	/*void OnApplicationQuit()
	{
		thread.Abort();
		udp.Close();
	}*/

	void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
#endif

	}

	//lpf = v[x]*r + v[x-1]*(1-r) (b = r*B + (1-r)*A : A,B=元の数.b=変換後の数)　LPFを行う
	float Lpf(List<int> v, int x)
	{
		float lpf = 0f;
		lpf = r_lp * v[x] + (1 - r_lp) * v[x - 1];
		return lpf;
	}

	//


	float vecMaxf(List<float> v, int x1, int x2)
	{
		//Debug.LogFormat("vecMaxf {0} to {1}".Orange(), x1, x2);
		float vMax = 0f;

		for (int i = x1; i < x2; ++i)
		{
			//xx.CompareTo(yy) ---> x>y = 1, x==y = 0 x<y = -1
			if (v[i].CompareTo(vMax) == 1)
			{
				vMax = v[i];
			}
		}
		return vMax;
	}
	/**/


	public void ThreadMethod()
	{
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            float[] temp = new float[1];
            Buffer.BlockCopy(data, 0, temp, 0, sizeof(float));
            emg = temp[0];
            Debug.Log("aaa");
            Debug.Log("EMGaccept : " + emg);
           
        }
	}
}


