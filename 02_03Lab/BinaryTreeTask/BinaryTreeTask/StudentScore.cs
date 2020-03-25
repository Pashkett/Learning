using System;

namespace BinaryTreeTask
{
    public class StudentScore : IComparable
    {
        public StudentScore() { }

        public string TestName { get; set; }
        public string StudentName { get; set; }

        public DateTime TestDate { get; set; }

        public int Score { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            return Score.CompareTo(((StudentScore)obj).Score);
        }

        public override string ToString()
        {
            return $"Test: {TestName}, Student: {StudentName}, Score: {Score}, Date: {TestDate}";
        }
    }
}