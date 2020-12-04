using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Day4.Library
{
    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColour { get; set; }
        public string EyeColour { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }

#pragma warning disable IDE1006 // Naming Styles
        private static readonly string[] EYE_COLOURS = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        private static readonly string[] ALLOWED_HEX_ALPHA = { "a", "b", "c", "d", "e", "f" };
#pragma warning restore IDE1006 // Naming Styles

        public Passport(string[] rawData)
        {
            foreach (var item in rawData)
            {
                var fieldData = item.Substring(item.IndexOf(":") + 1);

                switch (item.Substring(0, 3))
                {
                    case "byr": BirthYear = fieldData; break;
                    case "iyr": IssueYear = fieldData; break;
                    case "eyr": ExpirationYear = fieldData; break;
                    case "hgt": Height = fieldData; break;
                    case "hcl": HairColour = fieldData; break;
                    case "ecl": EyeColour = fieldData; break;
                    case "pid": PassportID = fieldData; break;
                    case "cid": CountryID = fieldData; break;
                    default:
                        break;
                }
            }
        }

        public static List<Passport> PassportifyList(string[] data)
        {
            var passports = new List<Passport>();
            var singlePassport = new StringBuilder();

            foreach (var line in data)
            {
                singlePassport.Append($"{line} ");

                if (line == "")
                {
                    passports.Add(new Passport(singlePassport.ToString().Trim().Split(" ")));
                    singlePassport.Clear();
                }
            }

            return passports;
        }

        public bool IsValidPart1
        {
            get
            {
                // Validate not null
                if (BirthYear == null || IssueYear == null || ExpirationYear == null || Height == null
                    || HairColour == null || EyeColour == null || PassportID == null)
                    return false;
                return true;
            }
        }

        public bool IsValidPart2
        {
            get
            {
                if (!IsValidPart1) return false;

                var birthYear = int.Parse(BirthYear);
                var issueYear = int.Parse(IssueYear);
                var expirationYear = int.Parse(ExpirationYear);

                // Validate dates
                if (birthYear > 2002 || birthYear < 1920) return false;
                if (issueYear > 2020 || issueYear < 2010) return false;
                if (expirationYear > 2030 || expirationYear < 2020) return false;

                // Validate height
                if (Height.Contains("cm"))
                {
                    var height = int.Parse(Height.Replace("cm", ""));
                    if (height > 193 || height < 150) return false;
                }
                else if (Height.Contains("in"))
                {
                    var height = int.Parse(Height.Replace("in", ""));
                    if (height > 76 || height < 59) return false;
                }
                else
                    return false;

                // Validate hair colour (would rather die than use REGEX)
                if (HairColour[0] != '#' || HairColour.Length != 7) return false;

                var substr = HairColour.Substring(1, 6);

                if (!ALLOWED_HEX_ALPHA.Any(c => substr.Contains(c)) && !int.TryParse(substr.ToString(), out _))
                    return false;

                // Validate eye colour
                if (!EYE_COLOURS.Any(c => EyeColour.Contains(c))) return false;

                // Validate passport ID
                if (PassportID.Length != 9 || !int.TryParse(PassportID, out _)) return false;

                return true;
            }
        }
    }
}