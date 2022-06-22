using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Generisanje_fraze.Classes
{
    public class Population
    {

        #region Attributes

        private float mutationRate;
        private List<Phrase> selectionList;
        public Phrase[] population;
        private int generations;
        private String targetPhrase;
        private bool finished;

        #endregion

        #region Constructor

        public Population(String target, int popSize, float mutRate, Random rnd)
        {
            this.mutationRate = mutRate;
            this.targetPhrase = target;
            this.population = new Phrase[popSize];
            for (int i = 0; i < popSize; i++)
            {
                this.population[i] = new Phrase(target.Length,rnd);
            }
            this.calcFitness();
            this.selectionList = new List<Phrase>();
            this.generations = 0;
            this.finished = false;
        }

        #endregion

        #region Functions

        public void calcFitness()
        {
            for (int i = 0; i < this.population.Length; i++)
                this.population[i].calcFitness(this.targetPhrase.ToCharArray());
        }

        public void generate(Random rnd)
        {
            for (int i = 0; i < this.population.Length; i++)
            {
               
                int p1Num = rnd.Next(this.selectionList.Count);
                int p2Num = rnd.Next(this.selectionList.Count);

                Phrase parentA = this.selectionList.ElementAt(p1Num);
                Phrase parentB = this.selectionList.ElementAt(p2Num);

                Phrase child = parentA.crossover(parentB, rnd);

                child.mutate(this.mutationRate,rnd);

                this.population[i] = child;
            }
            this.generations++;
        }

        public void naturalSelection()
        {
            this.selectionList.Clear();
            float maxFitness = 0;

            for(int i=0;i<this.population.Length;i++)
            {
                if (this.population[i].getFitness > maxFitness)
                    maxFitness = this.population[i].getFitness;
            }

            for (int i=0;i<this.population.Length;i++)
            {
                float nFitness = map(0, maxFitness, 0, 1, this.population[i].getFitness);
                int number = (int)(nFitness * 100);
                for (int j = 0; j < number; j++)
                    this.selectionList.Add(this.population[i]);

            }

        }

        public Phrase bestPhrase(double stopRatio)
        {
            float bestFitness = 0;
            int index = 0;

            for(int i=0;i<this.population.Length;i++)
            {
                if(bestFitness<this.population[i].getFitness)
                {
                    index = i;
                    bestFitness = this.population[i].getFitness;
                }
            }

            if (bestFitness >= stopRatio) this.finished = true;

            return this.population[index];
        }

        private float map(float a0, float a1, float b0, float b1, float a)
        {
            return b0 + (b1 - b0) * ((a - a0) / (a1 - a0));
        }

        #endregion

        #region Getters

        public int getGenerations
        {
            get { return this.generations; }
        }

        public bool isFinished
        {
            get { return this.finished; }
        }

        #endregion
    }
}
