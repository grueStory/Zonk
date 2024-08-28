using System;

namespace _Project.Scripts
{
    public class Score
    {
        private ScoreConfig _scoreConfig;

        public int Value { get; private set; }

        public event Action OnUpdated;
        public event Action OnWin;
        
        public Score(ScoreConfig scoreConfig)
        {
            _scoreConfig = scoreConfig;
        }
        
        public void AddOne(int count)
        {
            AddScore(_scoreConfig.pointsOne * count);
        }

        public void AddFive(int count)
        {
            AddScore(_scoreConfig.pointsFive * count);
        }

        public void AddStreet()
        {
            AddScore(_scoreConfig.pointsStreet);
        }

        public void AddThreeOne()
        {
            AddScore(_scoreConfig.pointsThreeOne);
        }

        public void AddAddThreeSix()
        {
            AddScore(_scoreConfig.pointsThreeSix);
        }

        public void AddThreeFive()
        {
            AddScore(_scoreConfig.pointsThreeFive);
        }

        public void AddThreeFour()
        {
            AddScore(_scoreConfig.pointsThreeFour);
        }

        public void AddThreeThree()
        {
            AddScore(_scoreConfig.pointsThreeThree);
        }

        public void AddThreeTwo()
        {
            AddScore(_scoreConfig.pointsThreeTwo);
        }

        private void AddScore(int value)
        {
            Value += value;
            OnUpdated?.Invoke();

            if (Value >= _scoreConfig.pointsToWin)
            {
                OnWin?.Invoke();
            }
        }
    }
}