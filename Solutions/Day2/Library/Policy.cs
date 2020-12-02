namespace Solutions.Day2.Library
{
    public class Policy
    {
        public int Pos1 { get; private set; }
        public int Pos2 { get; private set; }
        public char Char { get; private set; }
        public string Password { get; private set; }

        public Policy(string line)
        {
            var split = line.Split(":");
            var policyRaw = split[0];
            var positions = policyRaw
                .Substring(0, policyRaw.Length - 1)
                .Trim()
                .Split("-");

            Password = split[1];
            Pos1 = int.Parse(positions[0]);
            Pos2 = int.Parse(positions[1]);
            Char = policyRaw.Split(" ")[1][0];
        }
    }
}