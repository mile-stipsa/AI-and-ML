using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Security;

namespace Generisanje_fraze.Classes
{
    public class Phrase
    {

        #region Attributes

        private char[] phrase;
        private float fitness;

        #endregion

        #region Constructor

        public Phrase(int length,Random rnd)
        {

            String s = generateRandomString(length, rnd);
            this.phrase = s.ToCharArray();

        }

        #endregion

        #region Generate

        private string generateRandomString(int length, Random random)
        {
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(this.generateCharacter(random));
            }
            return result.ToString();
        }

        private char generateCharacter(Random random)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
            return characters[random.Next(characters.Length)];
        }

        #endregion

        #region Functions

        public void calcFitness(char[] target)
        {
            int score = 0;
            for (int i = 0; i < target.Length; i++)
            {
                char a = this.phrase[i];
                char b = target[i];

                if (a==b)
                    score++;
            }

            this.fitness = (float) score /(float)this.phrase.Length;
        }

        public Phrase crossover(Phrase partner, Random rnd)
        {
            Phrase child = new Phrase(this.phrase.Length,rnd);


            int point = rnd.Next(this.phrase.Length);
            double ex = rnd.NextDouble();

            for(int i=0;i<this.phrase.Length;i++)
            {
                if (i <= point)
                {
                    if(ex <= 0.5f)
                        child.phrase[i] = partner.phrase[i];
                    else
                        child.phrase[i] = this.phrase[i];
                }
                else
                {
                    if (ex <= 0.5f)
                        child.phrase[i] = this.phrase[i];
                    else
                        child.phrase[i] = partner.phrase[i];
                }
            }

            return child;

        }

        public void mutate(float mutationRate, Random rnd)
        {
            for (int i = 0; i < this.phrase.Length; i++)
            {
                if (rnd.NextDouble() < mutationRate)
                {
                    this.phrase[i] = this.generateCharacter(rnd);
                }
            }
        }

        #endregion

        #region Getters

        public String getPhrase()
        {
            String s = new string(this.phrase);
            return s;
        }

        public float getFitness
        {
            get { return this.fitness; }
        }

        #endregion

    }
}
