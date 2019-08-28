using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAlphabetProblem
{
    public class AlphabetProblem
    {
        public static string AlphabetProblemScramble(string _key, string _word)
        {
            StringBuilder sb = new StringBuilder();
            int o = 0;
            //Expand_KeyToFit_Word();

            for (int i = 0; i < _word.Length; i++)
            {
                int c = (((int)_key[o]+(int)_word[i]))-97-97;
                c = c > (25) ? c - 26 + 97 : c + 97;
                sb.Append((char)c);
                o++;
                o = _key.Length == o ? 0 : o;
            }


            //for (int i = 0; i < _word.Length; i++)
            //{
            //    char c = (char)(((((int)_key[i]) - 97) + ((int)_word[i] - 97) % 26 ) + 97);
            //    sb.Append(c);
            //}

            return sb.ToString();
            


            //void Expand_KeyToFit_Word()
            //{
            //    int o = 0;
            //    for (int i = 0; i < _word.Length; i++)
            //    {
            //        sb.Append(_key[o]);
            //        o = o == _key.Length-1 ? 0: o+1 ;
            //    }

            //    _key = sb.ToString();
            //    sb.Clear();
            //}

        }

        public static string AlphabetProblemUnScramble(string _key, string _word)
        {
            StringBuilder sb = new StringBuilder();
            int o = 0;

            for (int i = 0; i < _word.Length; i++)
            {
                int c = ((((int)_word[i]-97) - ((int)_key[o]-97)));
                c = c < (0) ? c + 26 + 97 : c + 97;
                sb.Append((char)c);
                o++;
                o = _key.Length == o ? 0 : o;
            }

            return sb.ToString();
        }


        public static string OtherSolution1(string cipher, string msg)
        {


            var r = Enumerable.Range(0, Math.Max(cipher.Length, msg.Length))
                .Select(x => {
                    return (msg[x], cipher[x % cipher.Length]);
                })
                .Select(x => {
                    return (char)((((int)x.Item1 - 97) + ((int)x.Item2 - 97)) % 26 + 97);
                });
            List<char> c = new List<char>();

            r.ToList().ForEach(x => {
                c.Add(x);
            });

            return c.ToArray().ToString();
        }
    }
}
