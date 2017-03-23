namespace Light.Framework.Core.Enums
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    public static class GenderHelper
    {
        public static string GetText(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "男";
                case Gender.Female:
                    return "女";
            }
            return "未知";
        }
    }
}