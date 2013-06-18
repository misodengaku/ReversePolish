using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverse_polish
{
    public class ReversePolish
    {
        //TODO: 数式で代入できるようにしてreadonlyな感じにする
        public Dictionary<string, int> Variables = new Dictionary<string, int>();

        /// <summary>
        /// 数式を逆ポーランド記法に変換します。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetPolishString(string s)
        {
            string ret = "";
            var stack = new Stack<char>();
            foreach (var i in s)
            {
                if (i == '+' || i == '-' || i == '*' || i == '/' || i == '=')
                {
                    ret += ",";
                    stack.Push(i);
                }
                else
                    ret += i;

            }
            for (int i = stack.Count() - 1; i >= 0; i--)
            {
                ret += ",";
                ret += stack.Pop();
            }
            return ret;
        }

        /// <summary>
        /// カンマ区切りの逆ポーランド記法で表された数式を実行し、計算結果を返します
        /// </summary>
        /// <param name="s">数式</param>
        /// <returns>計算結果</returns>
        public int ExecutePolish(string s)
        {
            try
            {
                var stack = new Stack<string>();
                string n1, n2;

                foreach (var i in s.Split(new char[] { ',' }))
                {
                    if (i[0] >= '0' && i[0] <= '9')
                    {
                        stack.Push("" + i);
                    }
                    else if (i == "+" || i == "-" || i == "*" || i == "/" || i == "=")
                    {
                        int r = 0;
                        n2 = stack.Pop();
                        n1 = stack.Pop();
                        switch (i)
                        {
                            case "+":
                                r = int.Parse(n1) + int.Parse(n2);
                                break;
                            case "-":
                                r = int.Parse(n1) - int.Parse(n2);
                                break;
                            case "*":
                                r = int.Parse(n1) * int.Parse(n2);
                                break;
                            case "/":
                                r = int.Parse(n1) / int.Parse(n2);
                                break;
                            case "=":
                                r = int.Parse(n2);
                                n1 = n2;
                                break;
                        }
                        stack.Push("" + r);
                    }
                    else
                    {
                        stack.Push("" + Variables[i]);
                    }
                }
                return int.Parse(stack.Pop());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 変数を指す文字列かどうかを判定します
        /// </summary>
        /// <param name="s">判定対象の文字列</param>
        /// <returns>変数であればtrue</returns>
        public bool isVariable(string s)
        {
            return (s != "+") && (s != "-") && (s != "*") && (s != "/") && !(s[0] >= '0' && s[0] <= '9');
        }

    }
}
