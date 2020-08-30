using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        [SerializeField] Text Score_text;
        [SerializeField] int combo=1;
        public int cur_score;

        private void Start()
        {
            cur_score = 0;
            combo = 1;
            Score_text.text = cur_score.ToString();
        }
        public void score_change(int hit)
        {
            cur_score+=hit;
            Score_text.text = cur_score.ToString();
        }

    }
}