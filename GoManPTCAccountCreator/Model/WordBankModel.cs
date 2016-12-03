using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GoManPTCAccountCreator.Model
{
    class WordBankModel : Dictionary<int, ArrayList>, IDisposable
    {

        public WordBankModel()
        {
            if (!File.Exists("word_bank.words"))
                File.WriteAllBytes("word_bank.words", Properties.Resources.Word_bank);
            LoadWords();
        }


        private void LoadWords()
        {
            var words = "";
            using (var sr = new StreamReader("word_bank.words"))
            {
                words = sr.ReadToEnd();
            }

            string[] splitWords = words.Split(' ');

            foreach (string word in splitWords)
            {
                if (ContainsKey(word.Length))
                    this[word.Length].Add(word);
                else
                {
                    Add(word.Length, new ArrayList());
                    this[word.Length].Add(word);
                }
            }

        }

        void IDisposable.Dispose()
        {
            this.Clear();
        }
    }
}
