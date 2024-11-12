
namespace LocalizationFilesManager
{
    enum Langage
    {
        EN,
        FR,
        ES,
        COUNT
    };

    public class Data
    {
        public static Dictionary<String,String>[] files = new Dictionary<String,String>[(ushort)Langage.COUNT];

        public static void Init()
        {
            files[(ushort)Langage.FR].Add("PLAY","Jouer");
        }
    }
}
