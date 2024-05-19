using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YutNori
{
    internal class Player : Button
    {
        public int position_id;
        public readonly int player;
        public const int SIZE = 20; //플레이어 size
        public const int N_PLAYERS = 8; //플레이어 size
        public Player(int player)
        {
            this.player = player;

            Location = new System.Drawing.Point(0, 0);
            Name = "";
            Size = new System.Drawing.Size(SIZE, SIZE);
            TabIndex = 0;
            Text = player.ToString();
            UseVisualStyleBackColor = true;
            this.player = player;
        }
        public void MoveXY(int x, int y)
        {
            int half = SIZE / 2;
            Location = new System.Drawing.Point(x - half, y - half); // 발판 위 플레이어 위치(센터)

            BringToFront();
        }
    }
}
