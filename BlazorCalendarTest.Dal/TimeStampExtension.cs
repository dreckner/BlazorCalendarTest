namespace BlazorCalendarTest.Dal
{
    public static class TimeStampExtension
    {
        public static bool Matches(this byte[] stamp1, byte[] stamp2)
        {
             if (stamp1 != null && stamp2 != null)
                if (stamp1.Length == stamp2.Length)
                {
                for (int i = 0; i < stamp1.Length; i++)
                    if (!stamp1[i].Equals(stamp2[i]))
                    return false;
                return true;
                }
            return false;
        }
    }
}