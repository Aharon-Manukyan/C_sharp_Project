using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryDLL
{
    public class ClassDll
    {
        private Dictionary<string,int> ChangeText(string text)
        {

            Dictionary<string, int> dict = new Dictionary<string, int> { };
            char[] letters = new char[25];
            string word = " ";

            foreach (char letter in text)
            {
                if (char.IsLetter(letter))
                {
                    word += char.ToString(char.ToLower(letter));
                }
                else if (char.IsDigit(letter) || letter == '_')
                {
                    continue;
                }
                else
                {
                    if (word != " ")
                    {
                        if (dict.ContainsKey(word))
                        {
                            dict[word] += 1;
                        }
                        else
                        {
                            dict[word] = 1;
                        }
                        letters = new char[25];
                        word = " ";
                    }
                }
            }
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return dict;

        }
    }
}
