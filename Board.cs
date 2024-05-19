using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YutNori
{
    public partial class Board : Form
    {
        Position[] positions = new Position[Position.N_POSITION]; //보드내에서만 사용할 것이라 public x
        Player[] players = new Player[Player.N_PLAYERS];
        public Board()
        {
            InitializeComponent();

            for (int i = 0; i < Position.N_POSITION; i++) //플레이어 시작 발판 위치
            {
                positions[i] = new Position();
                Controls.Add(positions[i]);
            }
            for (int i = 0; i < Player.N_PLAYERS; i++) // 플레이어 시작 위치
            {
                players[i] = new Player(i < (Player.N_PLAYERS / 2) ? 1 : 2);
                Controls.Add(players[i]);
                MovePlayerToPosition(i, players[i].player == 1 ? 29 : 30);
            }

            
            

            RepositionPlayer(29);
            RepositionPlayer(30);

            /*positions[0] = new Position();
            Controls.Add(positions[0]);*/  //윳놀이 발판 1개 만들기
        }
        public void MovePlayerToPosition(int player_index, int pos_index) //보드위 발판에 플레이어 위치
        {
            players[player_index].MoveXY(positions[pos_index].x, positions[pos_index].y);
            players[player_index].position_id = pos_index;
        }
        public void RepositionPlayer(int pos_index)
        {
            List<Player> players_in = new List<Player>(); //플레이어 말 갯수
            
            foreach (Player p in players) //발판 위에 플레이어가 카운팅되면 위치 조정
            {
                if ( p.position_id == pos_index )
                {
                    continue;
                }
                players_in.Add(p);
            }

            int half = Player.SIZE / 2;
            switch (players_in.Count) //발판 위 플레이어 갯수 카운팅
            {
                case 2:
                    players_in[0].MoveXY(positions[pos_index].x - half, positions[pos_index].y);
                    players_in[1].MoveXY(positions[pos_index].x + half, positions[pos_index].y);
                    break;
                case 3:
                    players_in[0].MoveXY(positions[pos_index].x, positions[pos_index].y - half);
                    players_in[1].MoveXY(positions[pos_index].x - half, positions[pos_index].y + half);
                    players_in[2].MoveXY(positions[pos_index].x + half, positions[pos_index].y + half);
                    break;

                case 4:
                    players_in[0].MoveXY(positions[pos_index].x - half, positions[pos_index].y - half);
                    players_in[1].MoveXY(positions[pos_index].x - half, positions[pos_index].y + half);
                    players_in[2].MoveXY(positions[pos_index].x + half, positions[pos_index].y - half);
                    players_in[3].MoveXY(positions[pos_index].x + half, positions[pos_index].y + half);
                    break;

            }
        }
        private void Move(int player_index, int n)
        {
            Player p = players[player_index];
            
            for (int i = 0; i < n; i++)
            {
                int next_pos = (i == 0) ? Position.NextStop(p.position_id) : Position.NextGo(p.position_id);

                MovePlayerToPosition(player_index, next_pos);
            }
            

        }
        private void MoveTest(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int n = int.Parse(b.Text);//-1 ~ 5
            Move(0, n); // 첫번째 플레이어
        }
    }
}
