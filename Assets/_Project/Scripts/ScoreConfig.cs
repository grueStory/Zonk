using UnityEngine;

namespace _Project.Scripts
{
    [CreateAssetMenu(menuName = "Create ScoreConfig", fileName = "ScoreConfig", order = 0)]
    public class ScoreConfig : ScriptableObject
    {
        public int pointsOne = 100;
        public int pointsFive = 50;
        public int pointsThreeOne = 1000;
        public int pointsThreeTwo = 200;
        public int pointsThreeThree = 300;
        public int pointsThreeFour = 400;
        public int pointsThreeFive = 500;
        public int pointsThreeSix = 600;
        public int pointsStreet = 1500;
        public int pointsToWin = 1500;
    }
}