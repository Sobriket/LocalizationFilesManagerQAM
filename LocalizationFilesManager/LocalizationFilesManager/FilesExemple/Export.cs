namespace LocalizationFilesManager
{
enum Langage
{
EN,
FR,
JA,
COUNT
};
public class Data
{
public static Dictionary<String,String>[] files = new Dictionary<String,String>[(ushort)Langage.COUNT];
public static void Init()
{
for (int i = 0; i < (ushort)Langage.COUNT; i++)
            {
                files[i] = new Dictionary<string, string>();
            }files[(ushort)Langage.EN].Add("Start","Start");
files[(ushort)Langage.EN].Add("Leaderboards","Leaderboards");
files[(ushort)Langage.EN].Add("Options","Options");
files[(ushort)Langage.EN].Add("Quit","Quit");
files[(ushort)Langage.FR].Add("Start","Démarrer");
files[(ushort)Langage.FR].Add("Leaderboards","Classements");
files[(ushort)Langage.FR].Add("Options","Options");
files[(ushort)Langage.FR].Add("Quit","Quitter");
files[(ushort)Langage.JA].Add("Start","開始");
files[(ushort)Langage.JA].Add("Leaderboards","リーダーボード”");
files[(ushort)Langage.JA].Add("Options","オプション");
files[(ushort)Langage.JA].Add("Quit","よす");

}
}
}