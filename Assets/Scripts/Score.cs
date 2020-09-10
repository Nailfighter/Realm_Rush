using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        public High_Score_Data data;
        [SerializeField] Text[] Score_text;
        [SerializeField] int combo=1;
        public int cur_score;

        private void Start()
        {
            cur_score = 0;
            combo = 1;
            Score_text[0].text = cur_score.ToString();
            Score_text[1].text = cur_score.ToString();
        }
        public void score_change(int hit)
        {
            combo = Random.Range(1, 5);
            hit *= combo;
            cur_score+=hit;
            Score_text[0].text = cur_score.ToString();
            Score_text[1].text = cur_score.ToString();
        }
    public void score_modifier(int level, int score)
    {
        if (score > data.score[level])
        {
            data.score[level] = score;
        }
    }
    }
}