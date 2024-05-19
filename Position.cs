using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YutNori
{
    internal class Position : Button
    {
        public const int N_POSITION = 31; // 발판 갯수
        public const int X_MARGIN = 60;
        public const int Y_MARGIN = 60;
        public readonly int id;
        private static int next_id = 0;

        // 플레이어 위치
        public readonly int x;
        public readonly int y;

        //private static Point[] xy = new Point[N_POSITION];  // 구조체 1차원 배열
        //*********************************************************************
        private static int[] _x = new int[N_POSITION]   
        { //0  1  2  3  4  5  6  7  8  9
            600, 600, 600, 600, 600, 600, 480, 360, 240, 120,
              0,   0,   0,   0,   0,   0, 120, 240, 360, 480,
            100, 200, 300, 400, 500, 500, 400, 200, 100, 720, 840
        };
        private static int[] _y = new int[N_POSITION]
        { //0  1  2  3  4  5  6  7  8  9
            600, 480, 360, 240, 120,   0,   0,   0,   0,   0,
              0, 120, 240, 360, 480, 600, 600, 600, 600, 600,
            100, 200, 300, 400, 500, 100, 200, 400, 500, 600, 600
        };
        //*********************************************************************

        private static int[] size = new int[N_POSITION] // 발판 사이즈
        { // 0   1   2   3   4   5   6   7   8   9
            80, 60,  60, 60, 60, 80, 60, 60, 60, 60,
            80, 60,  60, 60, 60, 80, 60, 60, 60, 60,
            60, 60, 100, 60, 60, 60, 60, 60, 60, 80, 80
        };

        private static int[] _next_go = new int[N_POSITION] // 일반 발판(일반통행)
        { // 0   1   2   3   4   5   6   7   8   9
             1,  2,  3,  4,  5,  6,  7,  8,  9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19,  0,
            21, 22, 23, 24,  0, 26, 22, 28, 15,  1, 1
          // 22는 2개이기에 이전 발판을 기억하여 다음 발판을 설정
        };
        private static int[] _next_stop = new int[N_POSITION] // 지름길 발판(해당 발판에 멈추면 지름길로 통행)
        { // 0   1   2   3   4   5   6   7   8   9
            1,   2,  3,  4,  5, 25,  7,  8,  9, 10,
            20, 12, 13, 14, 15, 16, 17, 18, 19,  0,
            21, 22, 23, 24,  0, 26, 22, 28, 15,  1, 1
          // 22는 2개이기에 이전 발판을 기억하여 다음 발판을 설정
        };

        public Position() 
        {
            id = next_id++;//발판 위치 주소

            int half = size[id] / 2;  //스탑발판 사이즈 조정하기 위함

            x = (X_MARGIN) + _x[id]; //플레이어 위치 x축
            y = (Y_MARGIN) + _y[id]; //플레이어 위치 y축

            Location = new System.Drawing.Point(x - half , y - half);
            Name = "";
            Size = new System.Drawing.Size(size[id], size[id]);
            TabIndex = 0;
            Text = id.ToString();
            UseVisualStyleBackColor = true;
        }
        public static int NextGo(int current, int prev = -1)
        {
            return _next_go[current];
        }
        public static int NextStop(int current)
        {
            return _next_stop[current];
        }
    }
}
