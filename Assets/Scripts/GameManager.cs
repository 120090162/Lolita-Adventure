using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GameManager
{
    // 场景信息
    private static int _level = 0;
    public static int puzzle_row = 2;
    public static int puzzle_col = 2;
    public static int score = 0;
    public static List<int> picture = new List<int>(){ 0, 1, -1, 2};
    public static List<int> target_picture = new List<int>() { 0, 1, 2, -1 };
    public static bool is_level_over = false;
    public static bool is_game_over = false;
    
    // 定义一个公共属性Level，用于监控_level变量的值变化
    public static int Level
    {
        get { return _level; }
        set
        {
            if (_level != value)
            {
                _level = value;
                if (_level == 1)
                {
                    picture = new List<int>(){ 0, 1, 2, 3, 4, -1};
                    target_picture = new List<int>() { 0, 1, 2, 3, 4, -1 };
                    puzzle_col = 3;
                    puzzle_row = 2;
                }else if (_level == 2)
                {
                    picture = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7, -1};
                    target_picture = new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7, -1};
                    puzzle_col = 3;
                    puzzle_row = 3;
                }else if (_level == 3)
                {
                    picture = new List<int>(){ 8, 9, 10, 11};
                }else if (_level == 4)
                {
                    picture = new List<int>() { 12, 13, 14, 15 };
                }else if (_level == 5)
                {
                    picture = new List<int>() { 16, 17, 18, 19 };
                }else if (_level == 6)
                {
                    picture = new List<int>() { 20, 21, 22, 23 };
                }else if (_level == 7)
                {
                    picture = new List<int>() { 24, 25, 26, 27 };
                }
                else
                {
                    is_game_over = true;
                }
            }
        }
    }
    
    // 玩家信息
    public static int player_id = 0;
    public static Vector3 player_pos = new Vector3(0, 0, 0);
    public static bool is_enter = false; // 是否进入图片
    public static int steps = 0; // 步数
    
    // 相机信息
    public static Vector3 camera_pos = new Vector3(-28.67f, 6.47f, -3.16f);
    
    public static bool CanSwapWithEmpty(int blockIndex, int emptyIndex)
    {
        // 计算块的行号和列号
        int blockRow = blockIndex / puzzle_col;
        int blockCol = blockIndex % puzzle_col;

        // 计算空块的行号和列号
        int emptyRow = emptyIndex / puzzle_col;
        int emptyCol = emptyIndex % puzzle_col;

        // 如果blockIndex在emptyIndex的上下左右位置，返回true，否则返回false
        if ((blockRow == emptyRow && Mathf.Abs(blockCol - emptyCol) == 1) || (blockCol == emptyCol && Mathf.Abs(blockRow - emptyRow) == 1))
        {
            return true;
        }

        return false;
    }
    
    public static void SetPlayerId(Vector3 pos)
    {
        if(Level == 0)
        {
            if (pos.x <= 0f)
            {
                if (pos.y >= 0f)
                {
                    player_id = picture[0];
                }
                else
                {
                    player_id = picture[2];
                }
            }
            else
            {
                if (pos.y >= 0f)
                {
                    player_id = picture[1];
                }
                else
                {
                    player_id = picture[3];
                }
            }
        }else if(Level == 1)
        {
            player_id = 1;
        }else if(Level == 2){
            player_id = 2;
        }else if(Level == 3){
            player_id = 3;
        }else if(Level == 4){
            player_id = 4;
        }else if(Level == 5){
            player_id = 5;
        }else if(Level == 6){
            player_id = 6;
        }else if(Level == 7){
            player_id = 7;
        }
    }
}
