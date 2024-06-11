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
    // UDP�ʐM�Ɏg�p���郍�[�J���|�[�g�ԍ�
    int LOCA_LPORT = 12345;

    // �ϊ��̊J�n������臒l
    public static int CONV_START = 99;

    // �ُ�l��臒l
    float THRE_ABNORMAL = 768;

    // �ʏ펞�̎���
    int TIME_NORMAL = 49;

    // UDP�N���C�A���g�ƃX���b�h
    static UdpClient udp;
    Thread thread;

    // �ؓd�ʃf�[�^�̕ϐ�
    public static float emg = 0;

    // �ؓd�ʂ̃��X�g
    List<int> vA = new List<int>();
    List<int> vB = new List<int>();

    // �ؓd�ʂ̐�Βl�̃��X�g
    public static List<float> vA_abs = new List<float>();
    public static List<float> vB_abs = new List<float>();

    // ���[�p�X�t�B���^�̌W��
    float r_lp = 0.5f;

    // ��Βl�̋ؓd�ʂ̃J�E���^
    int absCnt = 0;

    // �ؓd��A��B�̎���
    int egTime_A = 0, egTime_B = 0;

    // �ؓd�ʂ̐��A���̃J�E���^�A�Z�b�g�̐�
    int numCnt = 0;
    public static int vecCnt = 0;
    int numA = 0, numB = 0;
    int start = 0, goal = 0;

    void Start()
    {
        // UDP�N���C�A���g�𐶐����A�X���b�h���J�n����
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

        // Unity�t���[�����ƂɍX�V����鏈���͂����ɋL�q�����

        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);

        // ��M�����f�[�^��float�^�ɕϊ�
        float emgValue = BitConverter.ToSingle(data, 0);

        // ���������i10�̈ʁj�݂̂𒊏o����
        int integerPart = (int)emgValue;

        // emg�ɑ��
        emg = integerPart;

        Debug.Log("EMGtest : " + emg);

    }

    // �A�v���P�[�V�������I������ۂ̏���
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }

    // ���[�p�X�t�B���^�̓K�p
    float Lpf(List<int> v, int x)
    {
        float lpf = 0f;
        lpf = r_lp * v[x] + (1 - r_lp) * v[x - 1];
        return lpf;
    }

    // ���X�g���̍ő�l��������
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

    // UDP�f�[�^����M����X���b�h�̃��\�b�h
    public void ThreadMethod()
    {
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);

            // ��M�����f�[�^��float�^�ɕϊ�
            float emgValue = BitConverter.ToSingle(data, 0);

            // ���������i10�̈ʁj�݂̂𒊏o����
            int integerPart = (int)emgValue / 10;

            // emg�ɑ��
            emg = integerPart;
            Debug.Log(emg);

            //var task = DelayFunktion();
        }
    }

    private static async Task DelayFunktion()
    {
        await Task.Delay(50000); // �~���b
    }
}
